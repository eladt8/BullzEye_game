using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace B17_Ex05_Elad_304958184_Bar_201438777
{
    public class PickAColorForm : Form
    {
        private readonly Button[] m_colorFanButton = new Button[8];
        private Color m_choosenCoulorByUser;
        private Button m_currentNewButton;
        
        public Color UserChoosenColor
        {
            get { return m_choosenCoulorByUser; }
        }

        public PickAColorForm()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            m_currentNewButton = new Button();
            this.ClientSize = new Size(235, 130);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Name = "PickAColorForm";
            this.Text = "Pick A Color:";
            this.StartPosition = FormStartPosition.CenterParent;
            ////create first button
            m_currentNewButton.BackColor = Color.Purple;
            m_currentNewButton.Location = new Point(20, 10);
            m_currentNewButton.Size = new Size(40, 40);
            m_currentNewButton.Click += PickAColor_Click;
            this.Controls.Add(this.m_currentNewButton);
            m_colorFanButton[0] = m_currentNewButton;

            for (int i = 1; i < ConstUtilitis.k_PinsNumber; i++)
            {
                m_currentNewButton = new Button();
                m_currentNewButton.Top = m_colorFanButton[0].Top;
                m_currentNewButton.Left = m_colorFanButton[i - 1].Right + 8;
                m_currentNewButton.Size = new Size(40, 40);
                m_currentNewButton.Click += PickAColor_Click;
                this.Controls.Add(this.m_currentNewButton);
                m_colorFanButton[i] = m_currentNewButton;
            }

            Point bottomLineColors = new Point(m_colorFanButton[0].Bottom + 8, m_colorFanButton[0].Left);

            for (int i = 4; i < 8; i++)
            {
                m_currentNewButton = new Button();
                m_currentNewButton.Top = bottomLineColors.X;
                m_currentNewButton.Left = bottomLineColors.Y;
                m_currentNewButton.Size = new Size(40, 40);
                m_currentNewButton.Click += PickAColor_Click;
                this.Controls.Add(this.m_currentNewButton);
                m_colorFanButton[i] = m_currentNewButton;
                bottomLineColors.Y = m_currentNewButton.Right + 8;
            }

            m_colorFanButton[1].BackColor = Color.Red;
            m_colorFanButton[2].BackColor = Color.Green;
            m_colorFanButton[3].BackColor = Color.Cyan;
            m_colorFanButton[4].BackColor = Color.Blue;
            m_colorFanButton[5].BackColor = Color.Yellow;
            m_colorFanButton[6].BackColor = Color.Brown;
            m_colorFanButton[7].BackColor = Color.White;
        }

        private void PickAColor_Click(object sender, EventArgs e)
        {
            m_choosenCoulorByUser = (sender as Button).BackColor;
            this.Close();
        }
    }
}

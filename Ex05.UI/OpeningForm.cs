using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace B17_Ex05_Elad_304958184_Bar_201438777
{
    public class OpeningForm : Form 
    {
        private Button m_NumberOfChancesButton;
        private Button m_StartButton;
        private int m_numberOfChancesCounter = 4;
       
        public int NumberOfChances
        {
            get { return m_numberOfChancesCounter; }
        }

        public OpeningForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.m_NumberOfChancesButton = new Button();
            this.m_StartButton = new Button();
            
            this.m_NumberOfChancesButton.Location = new Point(8, 8);
            this.m_NumberOfChancesButton.Size = new Size(250, 40);
            this.m_NumberOfChancesButton.Text = string.Format("Number of chances:{0}", m_numberOfChancesCounter);
            this.m_NumberOfChancesButton.Click += numberOfChancesButton_Click;
         
            this.m_StartButton.Location = new Point(168, 63);
            this.m_StartButton.Size = new Size(90, 25);
            this.m_StartButton.Text = "Start";
            this.m_StartButton.Click += startButton_Click;
      
            this.ClientSize = new Size(280, 110);
            this.Controls.Add(this.m_NumberOfChancesButton);
            this.Controls.Add(this.m_StartButton);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Bol Piga";
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void numberOfChancesButton_Click(object sender, EventArgs e)
        {
            if (m_numberOfChancesCounter < ConstUtilitis.k_MaxNumberOfGuess)
            {
                m_numberOfChancesCounter++;
                this.m_NumberOfChancesButton.Text = string.Format("Number of chances:{0}", m_numberOfChancesCounter);
            }
            else
            {
                m_numberOfChancesCounter = ConstUtilitis.k_MinMumberOfGuess;
                this.m_NumberOfChancesButton.Text = string.Format("Number of chances:{0}", m_numberOfChancesCounter);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace B17_Ex05_Elad_304958184_Bar_201438777
{
    public class MainForm : Form
    {
        private readonly Logic m_bullzEye = new Logic();
        private readonly List<Button> m_currectColorHatch = new List<Button>();
        private readonly List<RoundButton> m_roundButtoms = new List<RoundButton>();
        private int m_roundCounter = 0;
        private Color[] m_userGuessArray;

        public MainForm(int i_NumberOfGuess)
        {
            InitializeComponent(i_NumberOfGuess);
            m_bullzEye.ColoreGuessCreator();
        }

        private void InitializeComponent(int i_NumberOfGuess)
        {
            Point startPosition = new Point(ConstUtilitis.k_SpaceBetWeenButtonHeight, ConstUtilitis.k_DistanceFromLeft);

            for (int i = 0; i < ConstUtilitis.k_PinsNumber; i++)
            {
                Button currectColor = new Button();
                currectColor.Top = startPosition.X;
                currectColor.Left = startPosition.Y + ((currectColor.Width - ConstUtilitis.k_DistanceFromLeft) * i);
                currectColor.Size = new Size(ConstUtilitis.k_BigButtonWidth, ConstUtilitis.k_BigButtonHeight);
                currectColor.Enabled = true;
                currectColor.BackColor = Color.Black;
                m_currectColorHatch.Add(currectColor);
                this.Controls.Add(currectColor);
            }

            startPosition.X += m_currectColorHatch[0].Bottom + ConstUtilitis.k_LittleButtonHeight;

            for (int i = 0; i < i_NumberOfGuess; i++)
            {
                m_roundButtoms.Add(new RoundButton(new Point(startPosition.X + ((m_currectColorHatch[0].Height + ConstUtilitis.k_SpaceBetWeenButtonHeight) * i), startPosition.Y)));
                foreach (Button bt in m_roundButtoms[i].CurrentRoundButton)
                {
                    this.Controls.Add(bt);
                }

                m_roundButtoms[i].ArrowButton.Click += ArrowWasClicked;
            }

            m_roundButtoms[0].EnableRound();
            this.AutoSize = true;
            this.Text = "Bullz Eye";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void UpdateColorArray(RoundButton i_CurrentRound)
        {
            m_userGuessArray = new Color[ConstUtilitis.k_PinsNumber];
            for (int i = 0; i < ConstUtilitis.k_PinsNumber; i++)
            {
                m_userGuessArray[i] = i_CurrentRound.CurrentRoundButton[i].BackColor;
            }
        }
    
        public void ArrowWasClicked(object sender, EventArgs e)
        {
            m_userGuessArray = m_roundButtoms[m_roundCounter].UpdateColorArray();
            m_bullzEye.GuessChecker(ref m_userGuessArray);
            m_roundButtoms[m_roundCounter].UpdateAnswer(m_userGuessArray);
            if (m_bullzEye.UpdateGuessOnForm(ref m_userGuessArray) || (m_roundCounter == (m_roundButtoms.Capacity - 1)))
            {
                m_roundButtoms[m_roundCounter].DisablePreviosRound();
                ShowCorrectAnswer();
            }
            else
            {
                m_roundButtoms[m_roundCounter].DisablePreviosRound();
                m_roundCounter++;
                m_roundButtoms[m_roundCounter].EnableRound();
            }
        }

        public void ShowCorrectAnswer()
        {
            for (int i = 0; i < ConstUtilitis.k_PinsNumber; i++)
            {
                m_currectColorHatch[i].BackColor = m_bullzEye.ColorToGuessArray[i];
            }
        }
    }
}
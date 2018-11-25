using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace B17_Ex05_Elad_304958184_Bar_201438777
{
    public class RoundButton
    {
        private Button[] m_RoundLine;

        public Button[] CurrentRoundButton
        {
            get { return m_RoundLine; }
        }

        public RoundButton(Point i_StartPosition)
        {
            m_RoundLine = new Button[9];
            for (int i = 0; i < ConstUtilitis.k_PinsNumber; i++)
            {
                m_RoundLine[i] = new Button();
                m_RoundLine[i].Top = i_StartPosition.X;
                m_RoundLine[i].Left = i_StartPosition.Y + ((m_RoundLine[i].Width - ConstUtilitis.k_DistanceFromLeft) * i);
                m_RoundLine[i].Size = new Size(ConstUtilitis.k_BigButtonHeight, ConstUtilitis.k_BigButtonWidth);
                m_RoundLine[i].Click += RoundButtom_Click;
                m_RoundLine[i].Enabled = false;
            }

            m_RoundLine[4] = new Button();
            m_RoundLine[4].Top = m_RoundLine[3].Top + ConstUtilitis.k_SpaceBetWeenButtonHeight;
            m_RoundLine[4].Left = m_RoundLine[3].Right + ConstUtilitis.k_SpaceBetWeenButtonWidth;
            m_RoundLine[4].Size = new Size(ConstUtilitis.k_BigButtonWidth, ConstUtilitis.k_ArrowButtonHeight);
            m_RoundLine[4].Text = " -->>";
            m_RoundLine[4].Enabled = false;

            m_RoundLine[5] = new Button();
            m_RoundLine[5].Top = m_RoundLine[3].Top + 3;
            m_RoundLine[5].Left = m_RoundLine[4].Right + ConstUtilitis.k_SpaceBetWeenButtonWidth;
            m_RoundLine[5].Size = new Size(ConstUtilitis.k_LittleButtonWidth, ConstUtilitis.k_LittleButtonHeight);
            m_RoundLine[5].Enabled = false;

            m_RoundLine[6] = new Button();
            m_RoundLine[6].Top = m_RoundLine[5].Top;
            m_RoundLine[6].Left = m_RoundLine[5].Right + ConstUtilitis.k_SpaceBetWeenButtonWidth;
            m_RoundLine[6].Size = new Size(ConstUtilitis.k_LittleButtonHeight, ConstUtilitis.k_LittleButtonWidth);
            m_RoundLine[6].Enabled = false;

            m_RoundLine[7] = new Button();
            m_RoundLine[7].Top = m_RoundLine[5].Bottom + ConstUtilitis.k_SpaceBetWeenButtonWidth;
            m_RoundLine[7].Left = m_RoundLine[5].Left;
            m_RoundLine[7].Size = new Size(ConstUtilitis.k_LittleButtonHeight, ConstUtilitis.k_LittleButtonWidth);
            m_RoundLine[7].Enabled = false;

            m_RoundLine[8] = new Button();
            m_RoundLine[8].Top = m_RoundLine[5].Bottom + ConstUtilitis.k_SpaceBetWeenButtonWidth;
            m_RoundLine[8].Left = m_RoundLine[6].Left;
            m_RoundLine[8].Size = new Size(ConstUtilitis.k_LittleButtonHeight, ConstUtilitis.k_LittleButtonWidth);
            m_RoundLine[8].Enabled = false;
        }

        public Button ArrowButton
        {
            get { return m_RoundLine[4]; }
        }

        public void EnableRound()
        {
            for(int i = 0; i < ConstUtilitis.k_PinsNumber; i++)
            {
                m_RoundLine[i].Enabled = true;
            }  
        }

        public void DisablePreviosRound()
        {
            for (int i = 0; i < ConstUtilitis.k_ButtonRoundToDisable; i++)
            {
                m_RoundLine[i].Enabled = false;
                m_RoundLine[i].FlatStyle = FlatStyle.Popup;
            }
        }

        public Color[] UpdateColorArray()
        {
            Color[] guessOfUser = new Color[4];
            for (int i = 0; i < ConstUtilitis.k_PinsNumber; i++)
            {
                guessOfUser[i] = m_RoundLine[i].BackColor;
            }

            return guessOfUser;
        }

        public void UpdateAnswer(Color[] i_GuessResults)
        {
            for (int i = 0; i < ConstUtilitis.k_PinsNumber; i++)
            {
                m_RoundLine[i + 5].BackColor = i_GuessResults[i];
            }
        }
            
        public bool AllButtonsPaint()
        {
            bool allButtonsPainted = true;
            for (int i = 0; i < ConstUtilitis.k_PinsNumber; i++)
            {
                if (m_RoundLine[i].BackColor.Name == "Control" && allButtonsPainted)
                {
                    allButtonsPainted = false;
                }
            }

            return allButtonsPainted;
        }

        private void RoundButtom_Click(object sender, EventArgs e)
        {
            PickAColorForm chooseColor = new PickAColorForm();
            chooseColor.ShowDialog();
            (sender as Button).BackColor = chooseColor.UserChoosenColor;
            if (AllButtonsPaint())
            {
                m_RoundLine[4].Enabled = true;
            }
        }
    }
} 

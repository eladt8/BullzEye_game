using System;
using System.Collections.Generic;
using System.Text;

namespace B17_Ex05_Elad_304958184_Bar_201438777
{
    public class UserInterface
    {
        private OpeningForm m_startForm = new OpeningForm();
        private MainForm m_mainForm;

        public void Run()
        {
            int numberOfGuess;

            m_startForm.ShowDialog();

            if (m_startForm.DialogResult != System.Windows.Forms.DialogResult.Cancel)
            {
                numberOfGuess = m_startForm.NumberOfChances;
                m_mainForm = new MainForm(numberOfGuess);

                m_mainForm.ShowDialog();
            }
        }
    }
}

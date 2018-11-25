using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace B17_Ex05_Elad_304958184_Bar_201438777
{
    public class Logic
    {
        private Random randLatters = new Random();
        private Color[] m_colorsToGuess;
        
        public Color[] ColorToGuessArray
        {
            get { return m_colorsToGuess; }
        }

        public void ColoreGuessCreator()
        {
            bool[] guessedNumbers = new bool[8];
            int randomNumber;
            int[] guessArrayInNumbers = new int[ConstUtilitis.k_PinsNumber];

            for (int i = 0; i < ConstUtilitis.k_PinsNumber; i++)
            {
                do
                {
                    randomNumber = randLatters.Next(0, 7);
                }
                while (guessedNumbers[randomNumber] == true);

                guessedNumbers[randomNumber] = true;

                guessArrayInNumbers[i] = randomNumber;
            }

            m_colorsToGuess = ConvertNumbersToColors(guessArrayInNumbers);
        }

        public Color[] ConvertNumbersToColors(int[] i_ArrayInNumbers)
        {
            Color[] newColorArray = new Color[ConstUtilitis.k_PinsNumber];
            for(int i = 0; i < ConstUtilitis.k_PinsNumber; i++)
            {
                switch (i_ArrayInNumbers[i])
                {
                    case 1:
                        newColorArray[i] = Color.Purple;
                        break;
                    case 2:
                        newColorArray[i] = Color.Red;
                        break;
                    case 3:
                        newColorArray[i] = Color.Green;
                        break;
                    case 4:
                        newColorArray[i] = Color.Cyan;
                        break;
                    case 5:
                        newColorArray[i] = Color.Blue;
                        break;
                    case 6:
                        newColorArray[i] = Color.Yellow;
                        break;
                    case 7:
                        newColorArray[i] = Color.Brown;
                        break;
                    case 8:
                        newColorArray[i] = Color.White;
                        break;
                }
            }

            return newColorArray;
        }

        public void GuessChecker(ref Color[] io_GuessInput)
        {
            int i, j;
            int indexOfGuessCheckerOutput = 0;
            int vCounter = 0;
            int xCounter = 0;
            Color[] guessCheckerOutput = new Color[ConstUtilitis.k_PinsNumber];

            ////counts V's
            for (i = 0; i < ConstUtilitis.k_PinsNumber; i++)
            {
                if (io_GuessInput[i] == m_colorsToGuess[i])
                {
                    vCounter++;
                }
            }

            ////count X's
            for (i = 0; i < ConstUtilitis.k_PinsNumber; i++)
            {
                for (j = 0; j < ConstUtilitis.k_PinsNumber; j++)
                {
                    if (m_colorsToGuess[i] == io_GuessInput[j])
                    {
                        xCounter++;
                    }
                }
            }

            ////create the output string
            xCounter = xCounter - vCounter;

            for (i = 0; i < vCounter; i++)
            {
                io_GuessInput[indexOfGuessCheckerOutput] = Color.Black;
                indexOfGuessCheckerOutput++;
            }

            for (j = 0; j < xCounter; j++)
            {
                io_GuessInput[indexOfGuessCheckerOutput] = Color.Yellow;
                indexOfGuessCheckerOutput++;
            }

            for(int k = i + j; k < ConstUtilitis.k_PinsNumber; k++)
            {
                io_GuessInput[indexOfGuessCheckerOutput] = SystemColors.Control;
                indexOfGuessCheckerOutput++;
            }
        }

        public bool UpdateGuessOnForm(ref Color[] io_UserGuessColorArray)
        {
            bool isPerfectGuess = true;
            foreach(Color backColor in io_UserGuessColorArray)
            {
                if (isPerfectGuess)
                {
                    isPerfectGuess = backColor == Color.Black;
                }
            }

            return isPerfectGuess;
        }
    }
}
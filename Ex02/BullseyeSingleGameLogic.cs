using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class BullseyeSingleGameLogic
    {
        private Random m_sequenceItemRandomizer = new Random();
        private char[] m_secretSequance = new char[4];
        public int MaxGuesses { get; set; }
        public int CurrentGuessCount { get; private set; }

        public class Guess //public for testing
        {
            internal char[] m_guess;
            internal int Hits { get; set; }

            internal int Misses { get; set; }

            public Guess(char[] i_guess)
            {
                m_guess = i_guess;
            }
        }

        public bool checkWin()
        {
            bool isWin = false;
            if (m_guessList.Last().Hits == 4)
            {
                isWin = true;
            }
            return isWin;
        }

        public List<Guess> m_guessList = new List<Guess>(); //public for testing

        public void setSecretSequance(char[] i_sequanceItems)
        {
            m_secretSequance = i_sequanceItems;
        }

        public void SetUpNewGame()
        {
            CurrentGuessCount = 0;
            m_guessList.Clear();
        }


       public void CheckGuess(char[] i_guess)
        {
            int hits = 0;
            int misses = 0;
            CurrentGuessCount++;
            Guess guess = new Guess(i_guess);
            for (int inputIndex = 0; inputIndex<i_guess.Length; inputIndex++)
            {
                for(int SequenceIndex = 0; SequenceIndex < i_guess.Length; SequenceIndex++)
                {
                    if (i_guess[inputIndex].Equals(m_secretSequance[SequenceIndex]) == true)
                    {
                        if (inputIndex == SequenceIndex)
                        {
                            hits++;
                        }
                        else
                        {
                            misses++;
                        }
                    }
                }
            }
            guess.Misses = misses;
            guess.Hits = hits;
            m_guessList.Add(guess);
        }

        public bool checkLoss()
        {
            bool lost = false;
            if (MaxGuesses-1 < CurrentGuessCount)
            {
                lost= true;
            }
            return lost;
        }

        public void generateSequance()
        {
            char[] sequance = new char[4];
            do
            {
                for (int i = 0; i < sequance.Length; i++)
                {
                    sequance[i] = (char)m_sequenceItemRandomizer.Next('A', 'I');
                }
            } while (sequenceHasNoDuplicates(sequance) == false);
            m_secretSequance = sequance;
        }

        private bool sequenceHasNoDuplicates(char[] i_input)
            //merge with input validator
        {
            bool hasNoDuplicates = true;
            bool[] ArrayOfLetters = new bool[8];
            for (int i = 0; i < 4; i++)
            {
                char currentLetterToCheck = char.ToUpper(char.ToUpper(i_input[i]));
                int indexOfLetter = currentLetterToCheck - 'A';
                if (ArrayOfLetters[indexOfLetter] == true)
                {
                    hasNoDuplicates = false;
                    break;
                }
                else
                {
                    ArrayOfLetters[indexOfLetter] = true;
                }

            }
            return hasNoDuplicates;
        }
    }
}

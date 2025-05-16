using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class GameLogic
    {
        public const int k_amountOfItemsInSequence = 4;
        public const int k_maximumAnountOfGuesses = 10;
        public const int k_minumumAmountOfGuesses = 4;
        public const int k_amountOfOptionsForSequanceItems = 8;

        public List<Guess> m_guessList = new List<Guess>();
        SequenceValidator m_sequenceValidator = new SequenceValidator();
        private Random m_sequenceItemRandomizer = new Random();
        private char[] m_secretsequence = new char[k_amountOfItemsInSequence];
        public int MaxGuesses { get; set; }
        public int CurrentGuessCount { get; private set; }

        public class Guess 
        {
            public char[] m_guess;
            public int Hits { get; set; }

            public int Misses { get; set; }

            public Guess(char[] i_guess)
            {
                m_guess = i_guess;
            }

        }

        public bool CheckWin()
        {
            bool isWin = (m_guessList.Last().Hits == k_amountOfItemsInSequence);

            return isWin;
        }

        public void SetSecretSequence(char[] i_sequenceItems)
        {
            m_secretsequence = i_sequenceItems;
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
            Guess guess = new Guess(i_guess);

            CurrentGuessCount++;
            for (int inputIndex = 0; inputIndex<i_guess.Length; inputIndex++)
            {
                for(int SequenceIndex = 0; SequenceIndex < i_guess.Length; SequenceIndex++)
                {
                    if (i_guess[inputIndex].Equals(m_secretsequence[SequenceIndex]) == true)
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

        public bool CheckLoss()
        {
            bool didPlayerLose = MaxGuesses - 1 < CurrentGuessCount;
            
            return didPlayerLose;
        }

        public void GenerateSequence()
        {
            char[] sequence;

            do
            {
                sequence = createRandomSequence();
            } 
            while (m_sequenceValidator.SequenceHasNoDuplicates(sequence) == false);

            m_secretsequence = sequence;
        }

        private char[] createRandomSequence()
        {
            char[] sequence = new char[k_amountOfItemsInSequence];

            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = (char)m_sequenceItemRandomizer.Next('A', 'I');
            }

            return sequence;
        }

    }

}

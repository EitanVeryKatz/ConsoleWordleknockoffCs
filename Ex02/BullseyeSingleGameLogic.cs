using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class BullseyeSingleGameLogic<Type>
    {
        private Type[] m_secretSequance = new Type[4];
        public int MaxGuesses { get; set; }
        public int CurrentGuessCount { get; private set; }

        public class Guess //public for testing
        {
            internal Type[] m_guess;
            internal int Hits { get; set; }

            internal int Misses { get; set; }

            public Guess(Type[] i_guess)
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

        public void setSecretSequance(Type[] i_sequanceItems)
        {
            m_secretSequance = i_sequanceItems;
        }

        public void SetUpNewGame()
        {
            CurrentGuessCount = 0;
            m_guessList.Clear();
        }


       public void CheckGuess(Type[] i_guess)
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
            m_guessList.Add(guess);
        }

        public bool checkLoss()
        {
            bool lost = false;
            if (MaxGuesses < CurrentGuessCount)
            {
                lost= true;
            }
            return lost;
        }

        //internal void CheckGuess(string i_Guess,out int io_Hits, out int io_Misses)
        //{
        //    io_Hits = 0;
        //    io_Misses = 0;
        //    for (int i = 0; i < 4; i++)
        //    {

        //        bool isInSequance = SequanceMap.TryGetValue(i_Guess[i], out int Index);
        //        if (isInSequance == true)
        //        {
        //            if(Index == i)
        //            {
        //                io_Hits++;
        //            }
        //            else
        //            {
        //                io_Misses++;
        //            }
        //        }
        //    }
        //}




    }
}

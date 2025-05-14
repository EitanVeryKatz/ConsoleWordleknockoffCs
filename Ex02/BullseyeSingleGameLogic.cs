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
            internal Type[] m_guess = new Type[4];
            internal int Hits { get; set; }

            internal int Misses { get; set; }
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


        //internal void GenerateSecretSequance()
        //{
        //    StringBuilder temporalSequance = new StringBuilder();
        //    do
        //    {
        //        temporalSequance.Clear();

        //        for (int i = 0; i < 4; i++)
        //        {
        //            Random rd = new Random();
        //            char randomChar = (char)((rd.Next() % 8) + 'A');
        //            temporalSequance.Append(randomChar);
        //        }
        //    } while (InputValidator.IsValidSequence(temporalSequance.ToString()));

        //    secretSequance = temporalSequance.ToString();

        //    for (int i = 0; i < 4; i++)
        //    {
        //        SequanceMap[temporalSequance[i]] = i;
        //    }
        //}



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

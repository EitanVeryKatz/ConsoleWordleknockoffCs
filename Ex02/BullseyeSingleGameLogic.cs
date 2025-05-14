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

        internal void GenerateSecretSequance()//TODO
        {
            //Random m_sequenceItemRandomizer = new Random();
            //Type[] sequance = new Type[4];
            //do
            //{
            //    for (int i = 0; i < 4; i++)
            //    {
            //        sequance[i] = (Type)m_sequenceItemRandomizer.Next(0, 8);
            //    }
            //} while (InputValidator.IsValidSequence(sequance) == false);
            //m_secretSequance = sequance;
        }
        internal void CheckGuess(Type[] i_guess)
        {
            Guess currentGuess = new Guess();
            currentGuess.m_guess = i_guess;
            m_guessList.Add(currentGuess);
            CurrentGuessCount++;
            for (int i = 0; i < 4; i++)
            {
                if (m_secretSequance[i].Equals(i_guess[i]))
                {
                    currentGuess.Hits++;
                }
                else
                {
                    currentGuess.Misses++;
                }
            }
        }




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class BullseyeSingleGameLogic
    {
        string secretSequance {  get; set; }
        int MaxGuesses { get; set; }
        int CurrentGueseCount { get; set; }

        internal void GenerateSecretSequance();
        internal bool IsValidGuess(string i_Guess);
        internal int CheckGuess(string i_Guess);

        


    }
}

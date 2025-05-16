using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class InputValidator
    {
        
       


        internal bool SequenceHasNoDuplicates(char[] i_input) { 
            bool hasNoDuplicates = true;
            bool[] arrayOfLetters=new bool[BullseyeSingleGameLogic.k_amountOfOptionsForSequanceItems];
            for(int i = 0;i < 4;i++)
            {
                char currentLetterToCheck = char.ToUpper(i_input[i]);
                int indexOfLetter = currentLetterToCheck - 'A';
                if (arrayOfLetters[indexOfLetter] == true)
                {
                    hasNoDuplicates = false;
                    break;
                }
                else
                {
                    arrayOfLetters[indexOfLetter] = true;
                }

            }
            return hasNoDuplicates;
        }


        

       
    }
}

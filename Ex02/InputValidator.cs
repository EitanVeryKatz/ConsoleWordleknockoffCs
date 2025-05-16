using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class InputValidator//supports only char[]
    {
        
       


        internal bool sequenceHasNoDuplicates(char[] i_input) { 
            bool hasNoDuplicates = true;
            bool[] ArrayOfLetters=new bool[BullseyeSingleGameLogic.k_amountOfOptionsForSequanceItems];
            for(int i = 0;i < 4;i++)
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

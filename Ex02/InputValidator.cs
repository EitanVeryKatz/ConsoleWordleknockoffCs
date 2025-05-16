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
            Dictionary<char,bool> ExistingCharsInSequence = new Dictionary<char,bool>();
            for (int i = 0; i < BullseyeSingleGameLogic.k_amountOfItemsInSequence; i++)
            {
                char currentLetterToCheck = char.ToUpper(i_input[i]);
                if (ExistingCharsInSequence.ContainsKey(currentLetterToCheck))
                {
                    hasNoDuplicates = false;
                    break;
                }
                else
                {
                    ExistingCharsInSequence[currentLetterToCheck] = true;
                }
            }
            return hasNoDuplicates;
        }


        

       
    }
}

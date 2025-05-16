using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class SequenceValidator
    {
        public bool SequenceHasNoDuplicates(char[] i_input)
        { 
            bool hasNoDuplicates = true;
            Dictionary<char,bool> existingCharsInSequence = new Dictionary<char,bool>();

            for (int i = 0; i < GameLogic.k_amountOfItemsInSequence; i++)
            {
                char currentLetterToCheck = char.ToUpper(i_input[i]);

                if (existingCharsInSequence.ContainsKey(currentLetterToCheck))
                {
                    hasNoDuplicates = false;
                    break;
                }
                else
                {
                    existingCharsInSequence[currentLetterToCheck] = true;
                }

            }

            return hasNoDuplicates;
        }

    }

}

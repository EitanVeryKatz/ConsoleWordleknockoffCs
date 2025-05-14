using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class InputValidator
    {
        private bool isValidLength(char[] i_input)
        {
            bool validLength = false;
            if (i_input.Length == 4)
            {
                validLength = true;
            }
            return validLength;
        }
        private bool containsOnlyValidChars(char[] i_input) {
            bool validChars = true;
            for(int i = 0; i < 4; i++)
            {
                char currentLetter = char.ToUpper(i_input[i]);
                if (currentLetter < 'A' || currentLetter > 'H')
                {
                    validChars = false;
                    break;
                }
            }
            return validChars;
        }
        private bool hasNoDuplicates(char[] i_input) { 
            bool hasDuplicates = false;
            bool[] ArrayOfLetters=new bool[8];
            for(int i = 0;i < 4;i++)
            {
                char currentLetterToCheck = char.ToUpper(char.ToUpper(i_input[i]));
                int indexOfLetter = currentLetterToCheck - 'A';
                if (ArrayOfLetters[indexOfLetter] == true)
                {
                    hasDuplicates = true;
                    break;
                }
                else
                {
                    ArrayOfLetters[indexOfLetter] = true;
                }

            }
            return hasDuplicates;
        }
        public bool IsValidSequence(char[] i_input)
        {
            bool isValid = false;
            if(isValidLength(i_input)&&containsOnlyValidChars(i_input)&& hasNoDuplicates(i_input))
            {
                isValid = true;
            }
            return isValid;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class InputValidator//supports only char[]
    {
        
        private bool isValidLength(string i_input)
        {
            bool validLength = false;
            if (i_input.Length == 7)
            {
                validLength = true;
            }
            return validLength;
        }
        private bool containsOnlyValidChars(string i_input) {
            bool validChars = true;
            for(int i = 0; i < i_input.Length; i++)
            {
                char currentLetter = char.ToUpper(i_input[i]);
                if (i % 2 == 1)
                {
                    if (currentLetter != ' ')
                    {
                        validChars = false;
                        break;
                    }
                }
                else
                {
                    if (currentLetter < 'A' || currentLetter > 'H')
                    {
                        validChars = false;
                        break;
                    }
                }
            }
            return validChars;
        }

        public char[] ToSequense(string i_input)
        {
            char[] sequence = new char[4];
            int sequenceIndex = 0;
            for (int i = 0; i < i_input.Length && i <= 7; i++)
            {
                if (i % 2 == 0)
                {
                    sequence[sequenceIndex] = i_input[i];
                    sequenceIndex++;
                }
                
            }
            return sequence;
        }

        private bool stringHasNoDuplicates(string i_input)
        {
            char[] sequence = ToSequense(i_input);
            return sequenceHasNoDuplicates(sequence);
        }


        internal bool sequenceHasNoDuplicates(char[] i_input) { 
            bool hasNoDuplicates = true;
            bool[] ArrayOfLetters=new bool[8];
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


        public bool IsValidUserInput(string i_input)
        {
            bool isValid = false;
            if(i_input!="Q" && isValidLength(i_input)&&containsOnlyValidChars(i_input)&& stringHasNoDuplicates(i_input))
            {
                isValid = true;
            }
            return isValid;

        }

        public bool IsValidYesOrNoInput(string i_userInput)
        {
            bool isValid = false;
            if (i_userInput=="Y"||i_userInput == "N")
            {
                isValid = true;
            }
            return isValid;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class ConsoleUserInterfaceInputValidaor
    {
        InputValidator m_sequenceValidator = new InputValidator();

        private bool isValidLength(string i_input)
        {
            bool validLength = false;
            if (i_input.Length == 7)
            {
                validLength = true;
            }
            return validLength;
        }
        private bool containsOnlyValidChars(string i_input)
        {
            bool validChars = true;
            for (int i = 0; i < i_input.Length; i++)
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



        private bool stringHasNoDuplicates(string i_input)
        {
            char[] sequence = ToSequense(i_input);
            return m_sequenceValidator.sequenceHasNoDuplicates(sequence);
        }

        internal char[] ToSequense(string i_input)
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

        public bool IsValidYesOrNoInput(string i_userInput)
        {
            bool isValid = false;
            if (i_userInput == "Y" || i_userInput == "N")
            {
                isValid = true;
            }
            return isValid;
        }

        public bool IsValidUserInput(string i_input, out string o_errorMessage)
        {
            bool isValid = true;
            if (i_input == "Q")
            {
                o_errorMessage = string.Empty;
                isValid = true;
            }

            else if (isValidLength(i_input) == false)
            {
                o_errorMessage = "Input must be 4 letters separated by spaces (e.g., A B C D).";
                isValid = false;
            }

            else if (containsOnlyValidChars(i_input) == false)
            {
                o_errorMessage = "Input must contain only letters A-H and spaces between them.";
                isValid = false;
            }

            else if (stringHasNoDuplicates(i_input) == false)
            {
                o_errorMessage = "Input must not contain duplicate letters.";
                isValid = false;
            }
            else
            {
                o_errorMessage = string.Empty;
            }

            return isValid;
        }
    }
}

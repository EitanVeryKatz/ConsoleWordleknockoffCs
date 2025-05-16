using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class ConsoleInputValidaor
    {
        private const int k_validLengthForGuessInput = 7;
        SequenceValidator m_sequenceValidator = new SequenceValidator();

        internal bool IsGuessAmountValid(string i_userInputStr, out string o_errorMessage, out int o_userInputInt)
        {
            bool isValid = true;
            bool isInteger = int.TryParse(i_userInputStr, out o_userInputInt);
            int minimumAmountOfGuesses = GameLogic.k_minumumAmountOfGuesses;
            int maximumAmountOfGuesses = GameLogic.k_maximumAnountOfGuesses;

            o_errorMessage = string.Empty;
            if (isInteger)
            {
                if (o_userInputInt < minimumAmountOfGuesses|| o_userInputInt > maximumAmountOfGuesses )
                {
                    o_errorMessage = "Input must be between 4 and 10.";
                    isValid = false;
                }

            }
            else
            {
                o_errorMessage = "Input must be a number.";
                isValid = false;
            }

            return isValid;
        }

        private bool isValidGuessLength(string i_input)
        {
            bool validLength = (i_input.Length == k_validLengthForGuessInput);
            
            return validLength;
        }

        private bool guessHasOnlyValidChars(string i_input)
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

        private bool guessHasNoDuplicates(string i_input)
        {
            char[] sequence = Tosequence(i_input);

            return m_sequenceValidator.SequenceHasNoDuplicates(sequence);
        }

        internal char[] Tosequence(string i_input)
        {
            char[] sequence = new char[GameLogic.k_amountOfItemsInSequence];
            int sequenceIndex = 0;

            for (int i = 0; i < i_input.Length && i <= k_validLengthForGuessInput; i++) 
            {
                if (i % 2 == 0)
                {
                    sequence[sequenceIndex] = i_input[i];
                    sequenceIndex++;
                }

            }

            return sequence;
        }

        internal bool IsValidYesOrNoInput(string i_userInput)
        {
            bool isValid = (i_userInput == "Y" || i_userInput == "N");

            return isValid;
        }

        internal bool IsValidUserInput(string i_input, out string o_errorMessage)
        {
            bool isValid = true;

            if (i_input == "Q")
            {
                o_errorMessage = string.Empty;
                isValid = true;
            }
            else if (isValidGuessLength(i_input) == false)
            {
                o_errorMessage = "Input must be 4 letters separated by spaces (e.g., A B C D).";
                isValid = false;
            }
            else if (guessHasOnlyValidChars(i_input) == false)
            {
                o_errorMessage = "Input must contain only letters A-H and spaces between them.";
                isValid = false;
            }
            else if (guessHasNoDuplicates(i_input) == false)
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

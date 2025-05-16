using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;

namespace Ex02
{
    internal class UserInterfaceConsole
    {
        private const string k_stopPlaying = "Q";
        private const string k_askUserForGuessMessage = "Please type your next guess<A B C D> or 'Q' to quit:";
        private const string k_askUserForAmountOfGuessesMessage = "Please enter amount of guesses: ";
        private const string k_askUserToPlayAgainMessage = "Would you like to start a new game? (Y/N)";

        private ConsoleUserInterfaceInputValidaor m_validator = new ConsoleUserInterfaceInputValidaor();
        private BullseyeSingleGameLogic m_gameLogic = new BullseyeSingleGameLogic();
        
        private void setUpSingleGame()//DONE
        {
            m_gameLogic.SetUpNewGame();
            m_gameLogic.generatesequence();
            askPlayerForNumOfGuesses();
            printBoard();
        }

        public void Run()//DONE
        {
            setUpSingleGame();
            runGameLoop();
        }

        private void runGameLoop()//DONE
        {
            while (true)
            {
                string userInput = askUserInput();

                if (userInput == k_stopPlaying)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                m_gameLogic.CheckGuess(m_validator.Tosequence(userInput));
                printBoard();
                if (checkIfGameOver())
                {
                    if (askToPlayAgain() == true)
                    {
                        setUpSingleGame();
                    }
                    else
                    {
                        break;
                    }

                }

            }

        }

        private bool checkIfGameOver()//DONE
        {
            bool gameEnded = false;

            if (m_gameLogic.checkWin() == true)
            {
                gameEnded = true;
                Console.WriteLine("You guessed after {0} steps!",m_gameLogic.CurrentGuessCount);
            }
            else if (m_gameLogic.checkLoss())
            {
                gameEnded = true;
                Console.WriteLine("No more guesses allowed. You lost.");
            }

            return gameEnded;
        }

        private void askPlayerForNumOfGuesses()//DONE
        {
            int userInputInt;

            Console.WriteLine(k_askUserForAmountOfGuessesMessage);
            string userInputStr = Console.ReadLine();

            while (m_validator.IsGuessAmountValid(userInputStr, out string errorMessage, out userInputInt) == false) 
            {
                Console.WriteLine(errorMessage);
                Console.WriteLine(k_askUserForAmountOfGuessesMessage);
                userInputStr = Console.ReadLine();
            }

            m_gameLogic.MaxGuesses = userInputInt;
        }

        private string askUserInput()//DONE
        {
            string errorMessage;

            Console.WriteLine(k_askUserForGuessMessage);
            string userInputStr = Console.ReadLine();

            while (m_validator.IsValidUserInput(userInputStr, out errorMessage) == false) 
            {
                printBoard();
                Console.WriteLine(errorMessage);
                Console.WriteLine(k_askUserForGuessMessage);
                userInputStr = Console.ReadLine();
            }

            return userInputStr;
        }

        private bool askToPlayAgain()//DONE
        {
            bool playAgain = false;

            Console.WriteLine(k_askUserToPlayAgainMessage);
            string userInputStr = Console.ReadLine();

            while (m_validator.IsValidYesOrNoInput(userInputStr) == false)
            {
                Console.WriteLine(k_askUserToPlayAgainMessage);
                userInputStr = Console.ReadLine();
            }

            playAgain = (userInputStr == "Y" || userInputStr == "y");

            return playAgain;
        }

        private void printBoard()//DONE
        {
            Screen.Clear(); // dll for console utils made by Guy Ronen
            Console.WriteLine("|Pins:    |Result:  |");
            Console.WriteLine("|=========|=========|");
            Console.WriteLine("| # # # # |         |");
            Console.WriteLine("|=========|=========|");

            for (int i = 0; i < m_gameLogic.MaxGuesses; i++)
            {
                if (i < m_gameLogic.m_guessList.Count && m_gameLogic.m_guessList[i] != null)
                {
                    BullseyeSingleGameLogic.Guess guess = m_gameLogic.m_guessList[i];
                    StringBuilder result = new StringBuilder();

                    Console.Write("| {0} {1} {2} {3} |",
                        guess.m_guess[0],
                        guess.m_guess[1],
                        guess.m_guess[2],
                        guess.m_guess[3]);

                    for (int hitIndex = 0; hitIndex < guess.Hits; hitIndex++)
                    {
                        result.Append("V ");
                    }

                    for (int missIndex = 0; missIndex < guess.Misses; missIndex++)
                    {
                        result.Append("X ");
                    }

                    string resultStr = result.ToString().TrimEnd().PadRight(5);
                    string padding = "   ";
                    if (result.Length == 8)
                    {
                        padding = " ";
                    }

                    Console.WriteLine(" {0}{1}|", resultStr,padding);
                }
                else
                {
                    Console.WriteLine("|         |         |");
                }

                Console.WriteLine("|=========|=========|");
            }

        }

    }

}

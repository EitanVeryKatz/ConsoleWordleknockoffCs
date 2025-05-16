using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;//dll for console utils made by Guy Ronen

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
        

        private void setUpSingleGame()
        {
            m_gameLogic.SetUpNewGame();
            //will use private methods of gamelogic to
            //do all setup job for the new game
            m_gameLogic.generatesequence();
            askPlayerForNumOfGuesses();
            //also updated the gamelogic
            printBoard();
        }

        public void Run()
        {
            setUpSingleGame();
            runGameLoop();
        }



        private void runGameLoop()
        {
            while (true)
            {
                string userInput = askUserInput();
                //ask user input uses inputVallidator internally
                if (userInput == k_stopPlaying)
                {
                    break;
                }
                m_gameLogic.CheckGuess(m_validator.Tosequence(userInput));
                //need to update check guess
                printBoard();
                
                if (checkIfGameOver())
                //if game ended
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

        private bool checkIfGameOver()
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



        private void askPlayerForNumOfGuesses()
        {
            Console.WriteLine(k_askUserForAmountOfGuessesMessage);
            string userInputStr = Console.ReadLine();
            //input validator will check if input is valid
            int userInputInt;
            

            while (m_validator.IsGuessAmountValid(userInputStr, out string errorMessage, out userInputInt)==false)//amount of guesses not valid
            {
                Console.WriteLine(errorMessage);
                Console.WriteLine(k_askUserForAmountOfGuessesMessage);
                userInputStr = Console.ReadLine();
            }

            m_gameLogic.MaxGuesses = userInputInt;

        }

        private string askUserInput()
        {
            
            Console.WriteLine(k_askUserForGuessMessage);
            string userInputStr = Console.ReadLine();
            string errorMessage;
            while (m_validator.IsValidUserInput(userInputStr,out errorMessage) == false)
            {
                printBoard();
                Console.WriteLine(errorMessage);
                Console.WriteLine(k_askUserForGuessMessage);
                userInputStr = Console.ReadLine();
            }
            return userInputStr;
        }

        private bool askToPlayAgain()
        {
            bool playAgain = false;
            Console.WriteLine(k_askUserToPlayAgainMessage);
            string userInputStr = Console.ReadLine();
            while (m_validator.IsValidYesOrNoInput(userInputStr)==false)
            {

                Console.WriteLine(k_askUserToPlayAgainMessage);
                userInputStr = Console.ReadLine();
            }
            if (userInputStr == "Y" || userInputStr == "y")
            {
                playAgain = true;
            }
            return playAgain;
        }

        private void printBoard()
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
                    // Print guessed pins
                    Console.Write("| {0} {1} {2} {3} |",
                        guess.m_guess[0],
                        guess.m_guess[1],
                        guess.m_guess[2],
                        guess.m_guess[3]);

                    // Prepare result string (V for hit, X for miss)
                    StringBuilder result = new StringBuilder();
                    for (int j = 0; j < guess.Hits; j++)
                    {
                        result.Append("V ");
                    }
                    for (int j = 0; j < guess.Misses; j++)
                    {
                        result.Append("X ");
                    }

                    // Pad or trim result to fit nicely
                    string resultStr = result.ToString().TrimEnd().PadRight(5);
                    string padding = "   ";
                    if (result.Length == 8)
                    {
                        //get rid of the last space
                        
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

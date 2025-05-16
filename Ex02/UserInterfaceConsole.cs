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
        private const string c_stopPlaying = "Q";

        private ConsoleUserInterfaceInputValidaor m_validator = new ConsoleUserInterfaceInputValidaor();
        private BullseyeSingleGameLogic m_gameLogic = new BullseyeSingleGameLogic();
        private bool m_winFlag = false;
        private bool m_lossFlag = false;
        

        private void setUpSingleGame()
        {
            m_gameLogic.SetUpNewGame();
            //will use private methods of gamelogic to
            //do all setup job for the new game
            m_gameLogic.generateSequance();
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
                if (userInput == c_stopPlaying)
                {
                    break;
                }
                m_gameLogic.CheckGuess(m_validator.ToSequense(userInput));
                //need to update check guess
                printBoard();
                
                //uses data from game logic that will sore info
                //of past guesses and hits and misses and shit
                //to print current state of game
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
            if(m_gameLogic.checkWin() == true)
            {
                gameEnded = true;
                Console.WriteLine("win");
            }else if(m_gameLogic.checkLoss())
            {
                gameEnded=true;
                Console.WriteLine("loss");
            }
            return gameEnded;
        }
        
        

        private void askPlayerForNumOfGuesses()
        {
            Console.WriteLine("Please enter amount of guesses: ");
            string userInputStr = Console.ReadLine();
            int userInputInt;
            while (int.TryParse(userInputStr, out userInputInt) == false|| userInputInt>10 || userInputInt<4)
            {
                Console.WriteLine("Invalid input...");
                Console.WriteLine("Please enter amount of guesses: ");
                userInputStr = Console.ReadLine();
            }
            m_gameLogic.MaxGuesses = userInputInt;

        }

        private string askUserInput()
        {
            
            Console.WriteLine("Please type your next guess<A B C D> or 'Q' to quit:");
            string userInputStr = Console.ReadLine();
            while (m_validator.IsValidUserInput(userInputStr) == false)
            {
                printBoard();
                Console.WriteLine("Please type your next guess<A B C D> or 'Q' to quit:");
                userInputStr = Console.ReadLine();
            }
            return userInputStr;
        }

        private bool askToPlayAgain()
        {
            bool playAgain = false;
            Console.WriteLine("Would you like to start a new game? (Y/N)");
            string userInputStr = Console.ReadLine();
            while (m_validator.IsValidYesOrNoInput(userInputStr)==false)
            {

                Console.WriteLine("Would you like to start a new game? (Y/N)");
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
            Screen.Clear();//dll for console utils made by Guy Ronen
            Console.WriteLine("|Pins:    |Result:|");
            Console.WriteLine("|=========|=======|");
            Console.WriteLine("| # # # # |       |");
            Console.WriteLine("|=========|=======|");
            for (int i = 0; i < m_gameLogic.CurrentGuessCount; i++)
            {
                var guess = m_gameLogic.m_guessList[i];
                // Print guessed pins
                Console.Write("| {0} {1} {2} {3} |",
                    guess.m_guess[0],
                    guess.m_guess[1],
                    guess.m_guess[2],
                    guess.m_guess[3]);
                // Print result (Hits and Misses)
                Console.Write("|");
                for (int j = 0; j < guess.Hits; j++)
                {
                    Console.Write(" V");
                }
                for (int j = 0; j < guess.Misses; j++)
                {
                    Console.Write(" X");
                }
                Console.WriteLine(" |");
                Console.WriteLine("|=========|=======|");
            }
        }

        


    }
}

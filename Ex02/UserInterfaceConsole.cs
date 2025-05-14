using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class UserInterfaceConsole
    {
        private const string c_stopPlaying = "Q";
        
        private InputValidator m_validator = new InputValidator();
        private BullseyeSingleGameLogic<char> m_gameLogic = new BullseyeSingleGameLogic<char>();
        private bool m_winFlag = false;
        private bool m_lossFlag = false;
        private Random m_sequenceItemRandomizer = new Random();

        private void setUpSingleGame() {
            m_gameLogic.SetUpNewGame();
            //will use private methods of gamelogic to
            //do all setup job for the new game
            generateSequance();
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
                if (m_winFlag == true || m_lossFlag == true)
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
            finishGame();
        }

        private bool askToPlayAgain()
        {
            bool playAgain = false;
            Console.WriteLine("Would you like to start a new game? <Y/N>");
            string userInput = Console.ReadLine();
            while (m_validator.IsValidYesOrNoInput(userInput))
            {
                Console.WriteLine("InvalidInput...");
                Console.WriteLine("Would you like to start a new game? <Y/N>");
                userInput = Console.ReadLine();
            }
            if(userInput == "Y")
            {
                playAgain = true;
            }
            return playAgain;
          
        }

        private void generateSequance()
        {
            char[] sequance = new char[4];
            do
            {
                for (int i = 0; i < sequance.Length; i++)
                {
                    sequance[i] = (char)m_sequenceItemRandomizer.Next('A', 'I');
                }
            } while (m_validator.sequenceHasNoDuplicates(sequance) == false);
            m_gameLogic.setSecretSequance(sequance);
        }
        
        private void askPlayerForNumOfGuesses()
        {
            Console.WriteLine("Please enter amount of guesses: ");
            string userInputStr = Console.ReadLine();
            if(int.TryParse(userInputStr,out int userInputInt) == false)
            {
                Console.WriteLine("Invalid input...");
                Console.WriteLine("Please enter amount of guesses: ");
                userInputStr = Console.ReadLine();
            }
            m_gameLogic.MaxGuesses = userInputInt;

        }

        private string askUserInput()
        {
            char[] userGess = new char[4];
            Console.WriteLine("Please type your next guess<A B C D> or 'Q' to quit:");
            string userInputStr = Console.ReadLine();
            while(m_validator.IsValidUserInput(userInputStr) == false)
            {
                Console.WriteLine("Invalid input...");
                Console.WriteLine("Please type your next guess<A B C D> or 'Q' to quit:");
                userInputStr = Console.ReadLine();
            }
            return userInputStr;
        }

        

    }
}

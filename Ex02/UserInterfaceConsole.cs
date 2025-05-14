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
            printScreen();
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
                m_gameLogic.CheckGuess(userInput, out m_winFlag, out m_lossFlag);
                //need to update check guess
                PrintBoard();
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

        private void generateSequance()
        {
            char[] sequance = new char[4];
            do
            {
                for (int i = 0; i < sequance.Length; i++)
                {
                    sequance[i] = (char)m_sequenceItemRandomizer.Next('A', 'I');
                }
            } while (m_validator.IsValidSequence(sequance) == false);
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

        private void askUserInput()
        {
            char[] userGess = new char[4];
            Console.WriteLine("Please type your next guess<A B C D> or 'Q' to quit:");
            string userInputStr = Console.ReadLine();
            
        }

    }
}

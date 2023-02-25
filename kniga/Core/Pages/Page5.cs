using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kniga.Core.Pages
{
    public static class Page5
    {
        public static void Run()
        {
            Console.Clear();
            //Крестики - нолики - игра
            User.TicTacToe tictactoe = new User.TicTacToe();

            tictactoe.Scale = 3;
            tictactoe.Width = tictactoe.Height = tictactoe.Scale;

            List<User.TicTacToe.Cell> cell = new List<User.TicTacToe.Cell>();
            for (int i = 0; i < tictactoe.Scale * tictactoe.Scale + 1; i++)
            {
                cell.Add(new User.TicTacToe.Cell() { ChoicedPos = i, IsFree = true });
            }

            string[] tictactoeArea = Functions.CoreFunctions.CreateTicTacToeArea(tictactoe.Scale);

            string stepSign = "X";
            string stepSignPrew = null;
            bool turnStep = true;
            short stepCounter = 0;

            bool isResumeWork;

            int length = 0;
            //Graphic interface
            string stepsListX = null;
            string stepsListO = null;
            string currentStepsList = null;

            bool endGameCheck = false;

            do
            {
                Console.WriteLine("---------");
                Functions.CoreFunctions.DisplayTicTacToeArea(tictactoeArea);
                Console.WriteLine("---------");
                Console.WriteLine("Turn: " + stepSign);
                Console.WriteLine("Steps player X: " + stepsListX);
                Console.WriteLine("Steps player O: " + stepsListO);

                length++;
                bool numberChoiceParse;
                int numberChoice = 0;

                do
                {
                    numberChoiceParse = int.TryParse(Console.ReadKey().KeyChar.ToString(), out numberChoice);
                    if (!numberChoiceParse || !cell[numberChoice].IsFree || numberChoice <= 0)
                    {
                        break;
                    }
                    if (turnStep)
                    {
                        cell[numberChoice].Sign = stepSignPrew = "X";
                        stepSign = "O";
                    }
                    else
                    {
                        cell[numberChoice].Sign = stepSignPrew = "O";
                        stepSign = "X";
                    }

                    cell[numberChoice].ChoicedPos = numberChoice - 1;
                    cell[numberChoice].IsFree = false;

                    Functions.CoreFunctions.ReplaceElementTicTacToeArea(tictactoeArea, cell[numberChoice].ChoicedPos, cell[numberChoice].Sign);
                    if (cell[numberChoice].Sign == "X")
                    {
                        stepsListX = Functions.CoreFunctions.StepsMessageLog(cell[numberChoice].ChoicedPos, stepsListX);
                        currentStepsList = stepsListX;
                    }
                    if (cell[numberChoice].Sign == "O")
                    {
                        stepsListO = Functions.CoreFunctions.StepsMessageLog(cell[numberChoice].ChoicedPos, stepsListO);
                        currentStepsList = stepsListO;
                    }

                    endGameCheck = Functions.CoreFunctions.CheckEndGameTicTacToe(currentStepsList);

                    stepCounter++;
                    turnStep = !turnStep;

                    break;

                }
                while (numberChoiceParse);

                if (endGameCheck)
                {
                    Console.Clear();
                    Console.WriteLine("---------");
                    Functions.CoreFunctions.DisplayTicTacToeArea(tictactoeArea);
                    Console.WriteLine("---------");
                    Console.WriteLine("\nSteps player X: " + stepsListX);
                    Console.WriteLine("Steps player O: " + stepsListO);
                    Console.WriteLine("\nWinner is: " + stepSignPrew);
                    isResumeWork = false;
                    Functions.CoreFunctions.LoggingTicTacToeAsync(stepsListX, stepsListO, stepSignPrew);
                }
                else
                {
                    if (stepCounter != 9)
                    {
                        Console.Clear();
                        isResumeWork = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("---------");
                        Functions.CoreFunctions.DisplayTicTacToeArea(tictactoeArea);
                        Console.WriteLine("---------");
                        Console.WriteLine("\nSteps player X: " + stepsListX);
                        Console.WriteLine("Steps player O: " + stepsListO);
                        Console.WriteLine("\nDraw !");
                        isResumeWork = false;
                        Functions.CoreFunctions.LoggingTicTacToeAsync(stepsListX, stepsListO, "Draw");
                    }

                }

            }
            while (isResumeWork == true);
        }
    }
}

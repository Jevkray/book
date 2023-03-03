using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using kniga.Functions;
using kniga.Functions.PageFunctions;
using static User;

namespace kniga.Core.Pages
{
    public static class TicTacToe
    {
        private const int GameScale = 3;

        public static void Run()
        {
            Console.Clear();
            //Крестики - нолики - игра
            User.TicTacToe tictactoe = new User.TicTacToe();

            tictactoe.Scale = GameScale;
            tictactoe.Width = tictactoe.Height = tictactoe.Scale;

            List<User.TicTacToe.Cell> cell = new List<User.TicTacToe.Cell>();

            for (int i = 0; i < tictactoe.Scale * tictactoe.Scale + 1; i++)
            {
                cell.Add(new User.TicTacToe.Cell() { ChoicedPos = i, IsFree = true });
            }

            string[] tictactoeArea = TicTacToeFunctions.CreateTicTacToeArea(tictactoe.Scale);

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
                TicTacToeFunctions.PrintInterface(tictactoeArea, tictactoe.Scale, stepSign, stepsListX, stepsListO);

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
                    else if (turnStep)
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

                    TicTacToeFunctions.ReplaceElementTicTacToeArea(tictactoeArea, cell[numberChoice].ChoicedPos, cell[numberChoice].Sign);
                    if (cell[numberChoice].Sign == "X")
                    {
                        stepsListX = TicTacToeFunctions.StepsMessageLog(cell[numberChoice].ChoicedPos, stepsListX);
                        currentStepsList = stepsListX;
                    }
                    else
                    {
                        stepsListO = TicTacToeFunctions.StepsMessageLog(cell[numberChoice].ChoicedPos, stepsListO);
                        currentStepsList = stepsListO;
                    }

                    endGameCheck = TicTacToeFunctions.CheckEndGameTicTacToe(currentStepsList);

                    stepCounter++;
                    turnStep = !turnStep;

                    break;

                }
                while (numberChoiceParse);

                if (endGameCheck)
                {
                    Console.Clear();
                    TicTacToeFunctions.PrintInterface(tictactoeArea, tictactoe.Scale, stepSign, stepsListX, stepsListO);
                    Console.WriteLine("\nWinner is: " + stepSignPrew);

                    isResumeWork = false;
                    TicTacToeFunctions.LoggingTicTacToeAsync(stepsListX, stepsListO, stepSignPrew);
                }
                else
                {
                    if (stepCounter != GameScale * GameScale)
                    {
                        Console.Clear();
                        isResumeWork = true;
                    }
                    else
                    {
                        Console.Clear();
                        TicTacToeFunctions.PrintInterface(tictactoeArea, tictactoe.Scale, stepSign, stepsListX, stepsListO);
                        Console.WriteLine("\nDraw !");
                        isResumeWork = false;
                        TicTacToeFunctions.LoggingTicTacToeAsync(stepsListX, stepsListO, "Draw");
                    }

                }

            }
            while (isResumeWork == true);
        }
    }
}

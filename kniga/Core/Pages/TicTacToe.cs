using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using kniga.Functions;
using static User;

namespace kniga.Core.Pages
{
    public static class TicTacToe
    {
        private const int GameScale = 3;

        public static void PrintInterface(string[] tictactoeArea, int gameScale, string? stepSign, string stepsListX, string stepsListO)
        {
            Console.WriteLine("---------");
            CoreFunctions.DisplayTicTacToeArea(tictactoeArea, gameScale);
            Console.WriteLine("---------");
            Console.WriteLine("Turn: " + stepSign);
            Console.WriteLine("Steps player X: " + stepsListX);
            Console.WriteLine("Steps player O: " + stepsListO);
        }

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

            string[] tictactoeArea = CoreFunctions.CreateTicTacToeArea(tictactoe.Scale);

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
                PrintInterface(tictactoeArea, tictactoe.Scale, stepSign, stepsListX, stepsListO);

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

                    CoreFunctions.ReplaceElementTicTacToeArea(tictactoeArea, cell[numberChoice].ChoicedPos, cell[numberChoice].Sign);
                    if (cell[numberChoice].Sign == "X")
                    {
                        stepsListX = CoreFunctions.StepsMessageLog(cell[numberChoice].ChoicedPos, stepsListX);
                        currentStepsList = stepsListX;
                    }
                    else
                    {
                        stepsListO = CoreFunctions.StepsMessageLog(cell[numberChoice].ChoicedPos, stepsListO);
                        currentStepsList = stepsListO;
                    }

                    endGameCheck = CoreFunctions.CheckEndGameTicTacToe(currentStepsList);

                    stepCounter++;
                    turnStep = !turnStep;

                    break;

                }
                while (numberChoiceParse);

                if (endGameCheck)
                {
                    Console.Clear();
                    PrintInterface(tictactoeArea, tictactoe.Scale, stepSign, stepsListX, stepsListO);

                    isResumeWork = false;
                    CoreFunctions.LoggingTicTacToeAsync(stepsListX, stepsListO, stepSignPrew);
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
                        PrintInterface(tictactoeArea, tictactoe.Scale, stepSign, stepsListX, stepsListO);
                        Console.WriteLine("\nDraw !");
                        isResumeWork = false;
                        CoreFunctions.LoggingTicTacToeAsync(stepsListX, stepsListO, "Draw");
                    }

                }

            }
            while (isResumeWork == true);
        }
    }
}

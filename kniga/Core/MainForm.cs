using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga.Functions;
using kniga.Core.Pages;
namespace kniga.Core

{
    class MainForm
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            {

                User user = new User();
                user.ModeChoice = CoreFunctions.ModeChoosing();

                switch (CoreFunctions.PageChoosing(user.ModeChoice))
                {
                    case 1:
                        {
                            Page1.Run(user);
                            if (user.ModeChoice) { break; }
                        }
                        goto case 2;

                    case 2:
                        {
                            Page2.Run();
                            if (user.ModeChoice) { break; }
                        }
                        goto case 3;

                    case 3:
                        {
                            {
                                //Сраница номер 3
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Страница №2, Степени числа до \"n\" (В горочку) \n");

                                double number;
                                do
                                {
                                    Console.Write("Введите число которое вы хотите возвести в степень: ");
                                    number = Functions.CoreFunctions.ParseToDoubleNumber(Console.ReadLine());

                                }
                                while (number == 0);
                                Console.Clear();

                                double degree;
                                do
                                {
                                    Console.Write($"Введите степень в которую вы хотите возвести {number}: ");
                                    degree = Functions.CoreFunctions.ParseToDoubleNumber(Console.ReadLine());

                                }
                                while (degree == 0);

                                Console.Clear();

                                if (degree > 0)
                                {
                                    for (int i = 0; i < degree;)
                                    {
                                        i++;
                                        double resultOfExp = Math.Pow(number, i);
                                        Console.WriteLine($"{number}^{i} = {resultOfExp}");

                                    }
                                }
                                else
                                {
                                    for (int i = 0; i > degree;)
                                    {
                                        i--;
                                        double resultOfExp = Math.Pow(number, i);
                                        Console.WriteLine($"{number}^{i} = {resultOfExp}");

                                    }
                                }

                                Console.ReadKey();
                                Console.Clear();

                            }
                            if (user.ModeChoice) { break; }
                        }
                        goto case 4;

                    case 4:
                        {
                            {
                                User.Rectangle rectangle = new User.Rectangle();

                                Console.WriteLine("Страница 3 Fill the Area");
                                Console.ReadKey();
                                Console.Clear();

                                do
                                {
                                    Console.Write("Введите длинну стороны прямоугольника: ");
                                    rectangle.Width = Functions.CoreFunctions.ParseToIntPositiveNumber(Console.ReadLine());
                                }
                                while (rectangle.Width == 0);

                                do
                                {
                                    Console.Write("Введите высоту стороны прямоугольника: ");
                                    rectangle.Height = Functions.CoreFunctions.ParseToIntPositiveNumber(Console.ReadLine());
                                }
                                while (rectangle.Height == 0);

                                string[,] rectangleArea = Functions.CoreFunctions.CreateRectangleArea(rectangle.Height, rectangle.Width);
                                Functions.CoreFunctions.DisplayRectangleArea(rectangleArea);

                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("Рисование областей в основной");
                                Console.ReadKey();
                                Console.Clear();

                                bool isResumeWork;
                                do
                                {
                                    Functions.CoreFunctions.DisplayRectangleArea(rectangleArea);

                                    Console.WriteLine("Если хотите разместить область внутри основной нажмите Y");
                                    var a = Console.ReadKey().KeyChar;
                                    Console.Clear();

                                    Functions.CoreFunctions.DisplayRectangleArea(rectangleArea);

                                    if (a == 'y' | a == 'Y')
                                    {
                                        Console.WriteLine("Введите начальную X координату");
                                        int xStartCoord = int.Parse(Console.ReadLine()) - 1;
                                        Console.WriteLine("Введите начальную Y координату");
                                        int yStartCoord = int.Parse(Console.ReadLine()) - 1;

                                        Console.WriteLine("Введите конечную X координату");
                                        int xEndCoord = int.Parse(Console.ReadLine()) - 1;
                                        Console.WriteLine("Введите конечную Y координату");
                                        int yEndCoord = int.Parse(Console.ReadLine()) - 1;

                                        Console.WriteLine("Введите который будет основой области:");
                                        string symbolOfFillRectangleArea = Console.ReadLine();

                                        Functions.CoreFunctions.FillRectangleArea(rectangleArea, xStartCoord, yStartCoord, xEndCoord, yEndCoord, symbolOfFillRectangleArea);

                                        isResumeWork = true;
                                    }
                                    else
                                    {
                                        isResumeWork = false;
                                    }

                                }
                                while (isResumeWork == true);
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("Конец.");
                            }
                            if (user.ModeChoice) { break; }
                        }
                        goto case 5;

                    case 5:
                        {
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
                            if (user.ModeChoice) { break; }
                        }
                        break;

                    case 0:
                        {
                            //Тупо тестовый
                        }
                        break;
                }
            }
        }
    }
}

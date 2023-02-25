using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga.Functions;
namespace kniga.Core

{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            {
                Console.WriteLine("Нажмите F если хотите использовать быстрый режим, S - если медленный");
                var ModeChoice = Console.ReadKey().KeyChar;
                string ModeChiceSwitch = "0";
                if (ModeChoice == 'f' | ModeChoice == 'F')
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Быстрый переход");
                    Console.Write("Введите номер страницы на которую желаете перейти:");
                    ModeChiceSwitch = Console.ReadLine();
                    ModeChoice = 'F';
                }
                if (ModeChoice == 's' | ModeChoice == 'S')
                {
                    ModeChiceSwitch = "0";
                }
                switch (ModeChiceSwitch)
                {
                    case "0":
                        {
                            //Страница привествия
                            Console.Clear();
                            Console.Write("Введите имя персонажа за которого вы будете играть: ");
                            string? name = Console.ReadLine();

                            User user = new User();
                            user.Name = name;
                            Console.Clear();

                            do // do .. while - выступает в качестве возвращения в начало , в случае ошибки
                            {
                                Console.Write("Введите возраст персонажа: ");
                                user.Age = functions.ParseToIntPositiveNumber(Console.ReadLine());
                            }
                            while (user.Age == 0);

                            Console.Clear();

                            user.Print();

                            Console.ReadKey();
                            Console.Clear();
                            if (ModeChoice == 'F') { break; }
                        }
                        goto case "1";

                    case "1":
                        {
                            {
                                //Страница номер 1 
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Страница №1, больше - меньше\n");
                                Console.ResetColor();

                                bool EnterNumberA = false;
                                double confirmedNumberA = 0;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Введите числа для сравнения ");
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("Число a = ");
                                    string? numberA = Console.ReadLine();
                                    if (numberA == "0")
                                    {
                                        EnterNumberA = true;
                                        confirmedNumberA = 0;
                                    }
                                    else
                                    {
                                        confirmedNumberA = functions.ParseToDoubleNumber(numberA);
                                        EnterNumberA = true;

                                        if (confirmedNumberA == 0)
                                        {
                                            EnterNumberA = false;
                                        }
                                    }
                                }
                                while (EnterNumberA == false);
                                Console.Clear();

                                bool EnterNumberB = false;
                                double confirmedNumberB = 0;
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("Число b = ");
                                    string? numberB = Console.ReadLine();
                                    if (numberB == "0")
                                    {
                                        EnterNumberB = true;
                                        confirmedNumberB = 0;
                                    }
                                    else
                                    {
                                        confirmedNumberB = functions.ParseToDoubleNumber(numberB);
                                        EnterNumberB = true;

                                        if (confirmedNumberB == 0)
                                        {
                                            EnterNumberB = false;
                                        }
                                    }
                                }
                                while (EnterNumberB == false);
                                Console.Clear();

                                {
                                    if (confirmedNumberA == confirmedNumberB)
                                    {
                                        Console.WriteLine("Число a = b");
                                    }
                                    if (confirmedNumberA > confirmedNumberB)
                                    {
                                        Console.WriteLine("Число a > b");
                                    }
                                    if (confirmedNumberA < confirmedNumberB)
                                    {
                                        Console.WriteLine("Число b > a");
                                    }

                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                            if (ModeChoice == 'F') { break; }
                        }
                        goto case "2";

                    case "2":
                        {
                            {
                                //Сраница номер 2
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Страница №2, Степени числа до \"n\" (В горочку) \n");

                                double number;
                                do
                                {
                                    Console.Write("Введите число которое вы хотите возвести в степень: ");
                                    number = functions.ParseToDoubleNumber(Console.ReadLine());

                                }
                                while (number == 0);
                                Console.Clear();

                                double degree;
                                do
                                {
                                    Console.Write($"Введите степень в которую вы хотите возвести {number}: ");
                                    degree = functions.ParseToDoubleNumber(Console.ReadLine());

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
                            if (ModeChoice == 'F') { break; }
                        }
                        goto case "3";

                    case "3":
                        {
                            {
                                User.Rectangle rectangle = new User.Rectangle();

                                Console.WriteLine("Страница 3 Fill the Area");
                                Console.ReadKey();
                                Console.Clear();

                                do
                                {
                                    Console.Write("Введите длинну стороны прямоугольника: ");
                                    rectangle.Width = functions.ParseToIntPositiveNumber(Console.ReadLine());
                                }
                                while (rectangle.Width == 0);

                                do
                                {
                                    Console.Write("Введите высоту стороны прямоугольника: ");
                                    rectangle.Height = functions.ParseToIntPositiveNumber(Console.ReadLine());
                                }
                                while (rectangle.Height == 0);

                                string[,] rectangleArea = functions.CreateRectangleArea(rectangle.Height, rectangle.Width);
                                functions.DisplayRectangleArea(rectangleArea);

                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("Рисование областей в основной");
                                Console.ReadKey();
                                Console.Clear();

                                bool isResumeWork;
                                do
                                {
                                    functions.DisplayRectangleArea(rectangleArea);

                                    Console.WriteLine("Если хотите разместить область внутри основной нажмите Y");
                                    var a = Console.ReadKey().KeyChar;
                                    Console.Clear();

                                    functions.DisplayRectangleArea(rectangleArea);

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

                                        functions.FillRectangleArea(rectangleArea, xStartCoord, yStartCoord, xEndCoord, yEndCoord, symbolOfFillRectangleArea);

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
                            if (ModeChoice == 'F') { break; }
                        }
                        goto case "4";

                    case "4":
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

                                string[] tictactoeArea = functions.CreateTicTacToeArea(tictactoe.Scale);

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
                                    functions.DisplayTicTacToeArea(tictactoeArea);
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

                                        functions.ReplaceElementTicTacToeArea(tictactoeArea, cell[numberChoice].ChoicedPos, cell[numberChoice].Sign);
                                        if (cell[numberChoice].Sign == "X")
                                        {
                                            stepsListX = functions.StepsMessageLog(cell[numberChoice].ChoicedPos, stepsListX);
                                            currentStepsList = stepsListX;
                                        }
                                        if (cell[numberChoice].Sign == "O")
                                        {
                                            stepsListO = functions.StepsMessageLog(cell[numberChoice].ChoicedPos, stepsListO);
                                            currentStepsList = stepsListO;
                                        }

                                        endGameCheck = functions.CheckEndGameTicTacToe(currentStepsList);

                                        stepCounter++;
                                        turnStep = !turnStep;

                                        break;

                                    }
                                    while (numberChoiceParse);

                                    if (endGameCheck)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("---------");
                                        functions.DisplayTicTacToeArea(tictactoeArea);
                                        Console.WriteLine("---------");
                                        Console.WriteLine("\nSteps player X: " + stepsListX);
                                        Console.WriteLine("Steps player O: " + stepsListO);
                                        Console.WriteLine("\nWinner is: " + stepSignPrew);
                                        isResumeWork = false;
                                        functions.LoggingTicTacToeAsync(stepsListX, stepsListO, stepSignPrew);
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
                                            functions.DisplayTicTacToeArea(tictactoeArea);
                                            Console.WriteLine("---------");
                                            Console.WriteLine("\nSteps player X: " + stepsListX);
                                            Console.WriteLine("Steps player O: " + stepsListO);
                                            Console.WriteLine("\nDraw !");
                                            isResumeWork = false;
                                            functions.LoggingTicTacToeAsync(stepsListX, stepsListO, "Draw");
                                        }

                                    }

                                }
                                while (isResumeWork == true);
                            }
                            if (ModeChoice == 'F') { break; }
                        }
                        break;

                    case "5":
                        {
                            //Тупо тестовый
                        }
                        break;
                }
            }
        }
    }
}

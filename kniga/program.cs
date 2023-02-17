using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga.face;
namespace kniga

{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
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
                                user.Age = func.ParseToIntPositiveNumber(Console.ReadLine());
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
                                        confirmedNumberA = func.ParseToDoubleNumber(numberA);
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
                                        confirmedNumberB = func.ParseToDoubleNumber(numberB);
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
                                    number = func.ParseToDoubleNumber(Console.ReadLine());

                                }
                                while (number == 0);
                                Console.Clear();

                                double degree;
                                do
                                {
                                    Console.Write($"Введите степень в которую вы хотите возвести {number}: ");
                                    degree = func.ParseToDoubleNumber(Console.ReadLine());

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
                                    rectangle.Width = func.ParseToIntPositiveNumber(Console.ReadLine());
                                }
                                while (rectangle.Width == 0);

                                do
                                {
                                    Console.Write("Введите высоту стороны прямоугольника: ");
                                    rectangle.Height = func.ParseToIntPositiveNumber(Console.ReadLine());
                                }
                                while (rectangle.Height == 0);

                                string[,] rectangleArea = func.CreateRectangleArea(rectangle.Height, rectangle.Width);
                                func.DisplayRectangleArea(rectangleArea);

                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("Рисование областей в основной");
                                Console.ReadKey();
                                Console.Clear();

                                bool isResumeWork;
                                do
                                {
                                    func.DisplayRectangleArea(rectangleArea);

                                    Console.WriteLine("Если хотите разместить область внутри основной нажмите Y");
                                    var a = Console.ReadKey().KeyChar;
                                    Console.Clear();

                                    func.DisplayRectangleArea(rectangleArea);

                                    if (a == 'y' | a == 'Y')
                                    {
                                        Console.WriteLine("Введите начальную X координату");
                                        int xStartCoord = Int32.Parse(Console.ReadLine()) - 1;
                                        Console.WriteLine("Введите начальную Y координату");
                                        int yStartCoord = Int32.Parse(Console.ReadLine()) - 1;

                                        Console.WriteLine("Введите конечную X координату");
                                        int xEndCoord = Int32.Parse(Console.ReadLine()) - 1;
                                        Console.WriteLine("Введите конечную Y координату");
                                        int yEndCoord = Int32.Parse(Console.ReadLine()) - 1;

                                        Console.WriteLine("Введите который будет основой области:");
                                        string symbolOfFillRectangleArea = (Console.ReadLine());

                                        func.FillRectangleArea(rectangleArea, xStartCoord, yStartCoord, xEndCoord, yEndCoord, symbolOfFillRectangleArea);

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
                                //Крестики - нолики - игра
                                User.TicTacToe tictactoe = new User.TicTacToe();

                                tictactoe.Scale = 3;
                                tictactoe.Width = tictactoe.Height = tictactoe.Scale;

                                List<User.TicTacToe.Cell> cell = new List<User.TicTacToe.Cell>();
                                for (int i = 0; i < tictactoe.Scale * tictactoe.Scale + 1; i++)
                                {
                                    cell.Add(new User.TicTacToe.Cell() { ChoicedPos = i, IsFree = true });
                                }

                                string[] tictactoeArea = func.CreateTicTacToeArea(tictactoe.Scale);

                                bool turnStep = true;

                                bool isResumeWork;

                                //Graphic interface
                                do
                                {
                                    Console.WriteLine("---------");
                                    func.DisplayTicTacToeArea(tictactoeArea);
                                    Console.WriteLine("---------");

                                    bool numberChoiceParse;
                                    int numberChoice = 0;

                                    do
                                    {
                                        numberChoiceParse = Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out numberChoice);
                                        if (!numberChoiceParse || !cell[numberChoice].IsFree || numberChoice <= 0)
                                        {
                                            break;
                                        }
                                        cell[numberChoice].ChoicedPos = numberChoice - 1;
                                        cell[numberChoice].IsFree = false;

                                        func.ReplaceElementTicTacToeArea(tictactoeArea, cell[numberChoice].ChoicedPos, turnStep);
                                        break; 

                                    }
                                    while (numberChoiceParse);

                                    Console.Clear();
                                    turnStep = !turnStep;
                                    isResumeWork = true;
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

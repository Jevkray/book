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
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
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
                        user.name = name;
                        Console.Clear();

                        do // do .. while - выступает в качестве возвращения в начало , в случае ошибки
                        {
                            Console.Write("Введите возраст персонажа: ");
                            user.age = func.ParseToIntPositiveNumber(Console.ReadLine());
                        }
                        while (user.age == 0);

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
                                rectangle.width = func.ParseToIntPositiveNumber(Console.ReadLine());
                            }
                            while (rectangle.width == 0);

                            do
                            {
                                Console.Write("Введите высоту стороны прямоугольника: ");
                                rectangle.height = func.ParseToIntPositiveNumber(Console.ReadLine());
                            }
                            while (rectangle.height == 0);

                            func.BuildAndFillRectangleArea(rectangle.height, rectangle.width,0,0,0,0);
                            Console.ReadKey();
                            Console.Clear();
                            Console.WriteLine("Рисование цветных областей в основной");
                            Console.ReadKey();
                            Console.Clear();

                            func.BuildAndFillRectangleArea(rectangle.height, rectangle.width,0,0,0,0);

                            bool isResumeWork;
                            do
                            {
                                Console.WriteLine("Если хотите разместить область нажмите Y");
                                var a = Console.ReadKey().KeyChar;
                                if (a == 'y' | a == 'Y')
                                {
                                    Console.WriteLine("Введите начальную X координату");
                                    int xStartCoord = func.ParseToIntPositiveNumber(Console.ReadLine());
                                    Console.WriteLine("Введите начальную Y координату");
                                    int yStartCoord = func.ParseToIntPositiveNumber(Console.ReadLine());

                                    Console.WriteLine("Введите конечную X координату");
                                    int xEndCoord = func.ParseToIntPositiveNumber(Console.ReadLine());
                                    Console.WriteLine("Введите конечную Y координату");
                                    int yEndCoord = func.ParseToIntPositiveNumber(Console.ReadLine());

                                    func.BuildAndFillRectangleArea(xStartCoord, yStartCoord, xEndCoord, yEndCoord, rectangle.height, rectangle.width);

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
                    }
        
                break;

                }
            }
        }
    }
}

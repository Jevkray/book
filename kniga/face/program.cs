using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kniga.face

{
    class Program
    {
        public static void Main()
        {
            {
                //Страница привествия

                Console.Write("Введите имя персонажа за которого вы будете играть: ");
                string name = Console.ReadLine();
                Console.WriteLine("Имя вашего персонажа: " + name);

                Console.ReadKey();
                Console.Clear();

            }

            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Страница №1, больше - меньше\n");
                Console.ResetColor();

                Console.Write("Введите числа для сравнения \nчисло a = ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("число b = ");
                int b = int.Parse(Console.ReadLine());
                {
                    if (a == b)
                    {
                        Console.WriteLine("Число a = b");
                    }
                    if (a > b)
                    {
                        Console.WriteLine("Число a > b");
                    }
                    if (a < b)
                    {
                        Console.WriteLine("Число b > a");
                    }

                    Console.ReadKey();
                    Console.Clear();
                }
            }

            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Страница №2, Степени числа до \"n\" (В горочку) \n");
                Console.ReadKey();
            }

        }
    }
}

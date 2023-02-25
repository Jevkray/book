using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kniga.Core.Pages
{
    public static class Page2
    {
        public static void Run()
        {
            //Страница номер 2 
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
                    confirmedNumberA = Functions.CoreFunctions.ParseToDoubleNumber(numberA);
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
                    confirmedNumberB = Functions.CoreFunctions.ParseToDoubleNumber(numberB);
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
    }
}

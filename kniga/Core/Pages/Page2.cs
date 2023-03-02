using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga.Functions;

namespace kniga.Core.Pages
{
    public static class Page2
    {
        private const string NameA= "A";
        private const string NameB = "B";

        public static void ChangeColorAndText(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }

        public static double interNumberAndParseToDouble(string nameOfIndex)
        {
            bool EnterNumber = false;
            double confirmedNumber = 0;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Число " + nameOfIndex + " = ");
                string number = Console.ReadLine();
                if (number == "0")
                {
                    EnterNumber = true;
                    confirmedNumber = 0;
                }
                else
                {
                    confirmedNumber = CoreFunctions.ParseToDoubleNumber(number);
                    EnterNumber = true;

                    if (confirmedNumber == 0)
                    {
                        EnterNumber = false;
                    }
                }
            }
            while (EnterNumber == false);
            Console.Clear();

            return confirmedNumber;
        }

        public static void Run()
        {
            Console.Clear();

            ChangeColorAndText(ConsoleColor.DarkBlue, "Страница №2, больше - меньше \n");

            ChangeColorAndText(ConsoleColor.Magenta, "Введите числа для сравнения");

            double confirmedNumberA = interNumberAndParseToDouble(NameA);
            double confirmedNumberB = interNumberAndParseToDouble(NameB);

            {
                if (confirmedNumberA == confirmedNumberB)
                {
                    Console.WriteLine("Число A = B");
                }
                if (confirmedNumberA > confirmedNumberB)
                {
                    Console.WriteLine("Число A > B");
                }
                if (confirmedNumberA < confirmedNumberB)
                {
                    Console.WriteLine("Число B > A");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}


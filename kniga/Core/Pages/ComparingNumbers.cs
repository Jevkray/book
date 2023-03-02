using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga.Functions;

namespace kniga.Core.Pages
{
    public static class ComparingNumbers
    {

        public static void OutputText(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }

        public static double EnterDouble(string message)
        {
            double confirmedNumber;
            bool EnterNumber;

            do
            {
                string number = StartPage.EnterStringValue(message);
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
            while (!EnterNumber);
            Console.Clear();

            return confirmedNumber;
        }

        public static void Run()
        {
            Console.Clear();

            OutputText(ConsoleColor.DarkBlue, "Страница №2, больше - меньше \n");

            OutputText(ConsoleColor.Magenta, "Введите числа для сравнения");

            var confirmedNumberA = EnterDouble("Введите число А: ");
            var confirmedNumberB = EnterDouble("Введите число B: ");

            if (confirmedNumberA == confirmedNumberB)
            {
                Console.WriteLine("Число A = B");
            }
            else if (confirmedNumberA > confirmedNumberB)
            {
                Console.WriteLine("Число A > B");
            }
            else
            {
                Console.WriteLine("Число B > A");
            }

        }

    }
}


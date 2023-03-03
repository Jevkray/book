using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga.Functions;
using kniga.Functions;

namespace kniga.Core.Pages
{
    public static class ComparingNumbers
    {

        public static void Run()
        {
            Console.Clear();

            CoreFunctions.OutputText(ConsoleColor.DarkBlue, "Страница №2, больше - меньше \n");

            CoreFunctions.OutputText(ConsoleColor.Magenta, "Введите числа для сравнения");

            var confirmedNumberA = CoreFunctions.EnterDouble("Введите число А: ");
            var confirmedNumberB = CoreFunctions.EnterDouble("Введите число B: ");

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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga.Functions;

namespace kniga.Core.Pages
{
    public static class Exponentation
    {

        public static void Run()
        {
            Console.Clear();

            CoreFunctions.OutputText(ConsoleColor.Green, "Страница №3, Степени числа до \"n\" (В горочку) \n");

            double number = CoreFunctions.EnterDouble("Введите число которое нужно возвести в степень: ");
            double degree = CoreFunctions.EnterDouble($"Введите степень в которую нужно взвести число {number}: ");

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

        }
    }
}

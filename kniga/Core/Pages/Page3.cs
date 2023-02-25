using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kniga.Core.Pages
{
    public static class Page3
    {
        public static void Run()
        {
            //Сраница номер 3
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Страница №3, Степени числа до \"n\" (В горочку) \n");

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kniga.Core.Pages
{
    public static class Page4
    {
        public static void Run()
        {
            User.Rectangle rectangle = new User.Rectangle();

            Console.WriteLine("Страница 3 Fill the Area");
            Console.ReadKey();
            Console.Clear();

            do
            {
                Console.Write("Введите длинну стороны прямоугольника: ");
                rectangle.Width = Functions.CoreFunctions.ParseToIntPositiveNumber(Console.ReadLine());
            }
            while (rectangle.Width == 0);

            do
            {
                Console.Write("Введите высоту стороны прямоугольника: ");
                rectangle.Height = Functions.CoreFunctions.ParseToIntPositiveNumber(Console.ReadLine());
            }
            while (rectangle.Height == 0);

            string[,] rectangleArea = Functions.CoreFunctions.CreateRectangleArea(rectangle.Height, rectangle.Width);
            Functions.CoreFunctions.DisplayRectangleArea(rectangleArea);

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Рисование областей в основной");
            Console.ReadKey();
            Console.Clear();

            bool isResumeWork;
            do
            {
                Functions.CoreFunctions.DisplayRectangleArea(rectangleArea);

                Console.WriteLine("Если хотите разместить область внутри основной нажмите Y");
                var a = Console.ReadKey().KeyChar;
                Console.Clear();

                Functions.CoreFunctions.DisplayRectangleArea(rectangleArea);

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

                    Functions.CoreFunctions.FillRectangleArea(rectangleArea, xStartCoord, yStartCoord, xEndCoord, yEndCoord, symbolOfFillRectangleArea);

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
}

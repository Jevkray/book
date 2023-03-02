using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga.Functions;

namespace kniga.Core.Pages
{
    public static class PaintingRectangles
    {
        public static int EnterIntValue(string message)
        {
            Console.Write(message);
            int value = CoreFunctions.ParseToIntNumber(Console.ReadLine());
            return value;
        }
        public static char EnterCharValue(string inputMessage)
        {
            Console.Write(inputMessage);
            char value = Console.ReadKey().KeyChar;
            return value;
        }

        public static void Run()
        {
            Console.Clear();
            
            User.Rectangle rectangle = new User.Rectangle();

            Console.WriteLine("Страница 4 Fill the Area");
            Console.ReadKey();
            Console.Clear();

            do
            {
                rectangle.Width = EnterIntValue("Введите длинну стороны прямоугольника: ");
            }
            while (rectangle.Width <= 0);

            do
            {
                rectangle.Height = EnterIntValue("Введите длинну стороны прямоугольника: ");
            }
            while (rectangle.Height <= 0);

            string[,] rectangleArea = CoreFunctions.CreateRectangleArea(rectangle.Height, rectangle.Width);

            CoreFunctions.DisplayRectangleArea(rectangleArea);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Рисование областей в основной");
            Console.ReadKey();
            Console.Clear();

            bool isResumeWork;
            do
            {
                CoreFunctions.DisplayRectangleArea(rectangleArea);

                var a = EnterCharValue("\nЕсли хотите разместить область внутри основной нажмите Y");
                Console.Clear();

                CoreFunctions.DisplayRectangleArea(rectangleArea);

                if (a == 'y' | a == 'Y')
                {

                    int xStartCoord = EnterIntValue("Введите начальную X координату: \n") - 1;
                    int yStartCoord = EnterIntValue("Введите начальную Y координату: \n") - 1;

                    int xEndCoord = EnterIntValue("Введите конечную X координату: \n") - 1;
                    int yEndCoord = EnterIntValue("Введите конечную Y координату: \n") - 1;

                    char symbolOfFillRectangleArea = EnterCharValue("Нажмите на символ которым хотите заполить область: \n");

                    CoreFunctions.FillRectangleArea(rectangleArea, xStartCoord, yStartCoord, xEndCoord, yEndCoord, symbolOfFillRectangleArea);

                    isResumeWork = true;
                }
                else
                {
                    isResumeWork = false;
                }

            }
            while (isResumeWork == true);

        }
    }
}

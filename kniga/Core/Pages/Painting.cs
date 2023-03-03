using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga.Functions;
using kniga.Functions.PageFunctions;

namespace kniga.Core.Pages
{
    public static class Painting
    {

        public static void Run()
        {
            Console.Clear();

            User.Rectangle rectangle = new User.Rectangle();

            Console.WriteLine("Страница 4 Fill the Area");
            Console.ReadKey();
            Console.Clear();

            rectangle.Width = PaintingFunctions.EnterPositiveInt(rectangle.Width, "Введите ширину стороны прямоугольника: ");
            rectangle.Height = PaintingFunctions.EnterPositiveInt(rectangle.Height, "Введите высоту стороны прямоугольника: ");

            string[,] rectangleArea = PaintingFunctions.CreateRectangleArea(rectangle.Height, rectangle.Width);

            PaintingFunctions.DisplayRectangleArea(rectangleArea);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Рисование областей в основной");
            Console.ReadKey();
            Console.Clear();

            bool isResumeWork;
            do
            {
                PaintingFunctions.DisplayRectangleArea(rectangleArea);

                var a = CoreFunctions.EnterCharValue("\nЕсли хотите разместить область внутри основной нажмите Y");
                Console.Clear();

                PaintingFunctions.DisplayRectangleArea(rectangleArea);

                if (a == 'y' | a == 'Y')
                {

                    int xStartCoord = CoreFunctions.EnterIntValue("Введите начальную X координату: \n") - 1;
                    int yStartCoord = CoreFunctions.EnterIntValue("Введите начальную Y координату: \n") - 1;

                    int xEndCoord = CoreFunctions.EnterIntValue("Введите конечную X координату: \n") - 1;
                    int yEndCoord = CoreFunctions.EnterIntValue("Введите конечную Y координату: \n") - 1;

                    char symbolOfFillRectangleArea = CoreFunctions.EnterCharValue("Нажмите на символ которым хотите заполить область: \n");

                    PaintingFunctions.FillRectangleArea(rectangleArea, xStartCoord, yStartCoord, xEndCoord, yEndCoord, symbolOfFillRectangleArea);

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

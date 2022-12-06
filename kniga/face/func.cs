using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga.face.constants; //пишем чтобы сократить путь (раньше писали kniga.face.constants.errorMessages.ErrorMessage.... а теперь просто errorMessages...

namespace kniga.face
{
    public class func
    {
        public static int ParseToIntPositiveNumber(string input)
        {
            bool result = int.TryParse(input, out int number);
            if (result == true && number > 0)
            {
                return number;
            }
            else
            {
                errorMessages.ErrorMessage(errorMessages.ErrorType.DefaultError);//формат должен быть static чтобы функция ErrorMessage- работала
                return 0;
            }
        }

        public static int ParseToIntNumber(string input)
        {
            bool result = int.TryParse(input, out int number);
            if (result == true)
            {
                return number;
            }
            else
            {
                errorMessages.ErrorMessage(errorMessages.ErrorType.DefaultError);
                return 0;
            }
        }

        public static double ParseToDoubleNumber(string input)
        {
            bool result = double.TryParse(input, out double number);
            if (result == true)
            {
                return number;
            }
            else
            {
                errorMessages.ErrorMessage(errorMessages.ErrorType.DefaultError);
                return 0;
            }
        }

        //СДЕЛАТЬ ЧТОБЫ НЕ СБРАСЫВАЛСЯ ПРЕДЫДУЩИЙ КВАДРАТ ИЗ МАТРИЦЫ
        public static string[,] CreateRectangleArea(int rectangleHeight, int rectangleWidth)
        {
            Console.Clear();
            string[,] rectangleArea = new string[rectangleHeight, rectangleWidth];
            for (int i = 0; i < rectangleArea.GetLength(0); i++)
            {
                for (int j = 0; j < rectangleArea.GetLength(1); j++)
                {
                    rectangleArea[i, j] = "\u25A1";
                }
            }
            return rectangleArea;
        }

        public static int DisplayRectangleArea(string[,] rectangleArea)

        {
            for (int i = 0; i < rectangleArea.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < rectangleArea.GetLength(1); j++)
                {
                    Console.Write(rectangleArea[i, j]);
                }
            }
            Console.WriteLine("\n");
            return 0;
        }

        public static string[,] FillRectangleArea(string[,] rectangleArea, int xStartCoord, int yStartCoord, int xEndCoord, int yEndCoord)
        {
            Console.Clear();
            for (int i = 0; i < rectangleArea.GetLength(0); i++)
            {
                for (int j = 0; j < rectangleArea.GetLength(1); j++)
                {
                    if (i >= yStartCoord && i <= yEndCoord && j >= xStartCoord && j <= xEndCoord)
                    {  
                        rectangleArea[i, j] = "*";
                    }
                }
            }
            return rectangleArea;
        }

    }
}
/*ТАК Я ДОДУМАЛСЯ ДО ТОГО ЧТО МОЖНО ПО ОТДЕЛЬНОСТИ ЗАПИСЫВАТЬ И ВЫВОДИТЬ МАТРИЦУ*/
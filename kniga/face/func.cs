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

        public static int BuildAndFillRectangleArea(int xStartCoord, int yStartCoord, int xEndCoord, int yEndCoord, int rectangleHeight, int rectangleWidth)
        {
            Console.Clear();
            char[,] rectangleArea = new char[rectangleHeight, rectangleWidth];
            for (int i = 0; i < rectangleArea.GetLength(0); i++)
            {
                for (int j = 0; j < rectangleArea.GetLength(1); j++)
                {
                    //if (i >= yStartCoord && i <= yEndCoord && j >= xStartCoord && j <= xEndCoord) // ПОМЕНЯТЬ УСЛОВИЕ А ТО ХУЙНЯ.
                    {
                        rectangleArea[i, j] = '*';
                    }
                    else
                    {
                        rectangleArea[i, j] = '\u25A1';
                    }
                    Console.Write(rectangleArea[i, j]);
                }
                Console.WriteLine();
            }
            return 0;
        }

    }
}

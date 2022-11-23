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

        public static int BuildRectangle(int inputRectangleHeight, int inputRectangleWidth)
        {

            for (int i = 0; i < inputRectangleHeight; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < inputRectangleWidth; j++)
                {
                    Console.Write('\u25A1');
                }
            }
            return 0;
        }

        public static int FillRectangleArea(int xStartCoord,int yStartCoord, int xEndCoord,int yEndCoord,int RectangleHeight,int RectangleWidth )
        {



            return 0;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga.face.constants; //пишем чтобы сократить путь (раньше писали kniga.face.constants.errorMessages.ErrorMessage.... а теперь просто errorMessages...
using kniga;

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

        //Рисование полей с заполнением.

        public static string[,] CreateRectangleArea(int Height, int Width)
        {
            Console.Clear();
            string[,] rectangleArea = new string[Height, Width];
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

        public static string[,] FillRectangleArea(string[,] rectangleArea, int xStartCoord, int yStartCoord, int xEndCoord, int yEndCoord, string fillSymbol)
        {
            Console.Clear();
            for (int i = 0; i < rectangleArea.GetLength(0); i++)
            {
                for (int j = 0; j < rectangleArea.GetLength(1); j++)
                {
                    if (i >= yStartCoord && i <= yEndCoord && j >= xStartCoord && j <= xEndCoord)
                    {
                        rectangleArea[i, j] = fillSymbol;
                    }
                }
            }
            return rectangleArea;
        }

        //КРЕСТИКИ-НОЛИКИ

        public static string[] CreateTicTacToeArea(int Scale)
        {
            string[] TicTacToeArea = new string[(Scale * Scale)]; //Scale ^2 - Кол-во ячеек
            for (int i = 0; i < (Scale * Scale); i++)
            {
                TicTacToeArea[i] = "\u25A1";
            }
            // User.TicTacToe.CellPosition cellPosition = new User.TicTacToe.CellPosition();
            return TicTacToeArea;
        }

        public static int DisplayTicTacToeArea(string[] tictactoeArea)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.Write($" {tictactoeArea[i]} ");
                if (i % 3 == 2)
                    Console.WriteLine();
            }
            return 0;
        }
        public static string StepsMessageLog(int CellPosition, string stepsMessage)
        {
            stepsMessage = stepsMessage + Convert.ToString(CellPosition + 1);
            return stepsMessage;
        }

        public static bool CheckEndGameTicTacToe(string stepsList)
        {
            if ((stepsList.Contains('1') && stepsList.Contains('2') && stepsList.Contains('3')) ||
                (stepsList.Contains('4') && stepsList.Contains('5') && stepsList.Contains('6')) ||
                (stepsList.Contains('7') && stepsList.Contains('8') && stepsList.Contains('9')) ||
                (stepsList.Contains('1') && stepsList.Contains('4') && stepsList.Contains('7')) ||
                (stepsList.Contains('2') && stepsList.Contains('5') && stepsList.Contains('8')) ||
                (stepsList.Contains('3') && stepsList.Contains('6') && stepsList.Contains('9')) ||
                (stepsList.Contains('1') && stepsList.Contains('5') && stepsList.Contains('9')) ||
                (stepsList.Contains('3') && stepsList.Contains('5') && stepsList.Contains('7')))
            {
                return true;
            }
            return false;
        }

        public static string[] ReplaceElementTicTacToeArea(string[] tictactoeArea, int cellNumber, string Sign)
        {

            tictactoeArea[cellNumber] = Sign;
            return tictactoeArea;
        }

        public static async Task<bool> LoggingTicTacToeAsync(string stepsListX, string stepsListO, string winner)
        {
            string path = @"C:\Users\Kray\source\repos\kniga\kniga\Logs\LogsTicTacToe.txt";
            string textLog;
            if (winner == "Draw")
            {
            textLog = "Game at: " + DateTime.Now.ToString("G") + "\n" +
                          "Steps of side 'X': '" + stepsListX + "'\n" +
                          "Steps of side 'O': '" + stepsListO + "'\n" +
                          "Draw\n\n";
            }
            else { 
            textLog = "Game at: "+ DateTime.Now.ToString("G") + "\n" +
                          "Steps of side 'X': '" + stepsListX + "'\n" +
                          "Steps of side 'O': '" + stepsListO + "'\n" +
                          "Winner is: '" + winner + "'\n\n";
            }
            using (FileStream fstream = new FileStream(path, FileMode.Append))
            {
                // преобразуем строку в байты
                byte[] buffer = Encoding.Default.GetBytes(textLog);
                // запись массива байтов в файл
                await fstream.WriteAsync(buffer, 0, buffer.Length);
                Console.WriteLine("\nЛоггирование данной игры произведено.");
            }
            return true;
        }


    }
}

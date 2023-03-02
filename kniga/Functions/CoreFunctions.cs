using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga;
using kniga.Helpers.Enums;
using kniga.Heplers;

namespace kniga.Functions
{
    public class CoreFunctions
    {
        public static int PageChoosing(bool ModeChoice)
        {
            
            int PageChoiceSwitch = 0;
            if (ModeChoice)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Быстрый переход");
                Console.Write("Введите номер страницы на которую желаете перейти:");
                PageChoiceSwitch = ParseToIntNumber(Console.ReadLine());
            }

            if (!ModeChoice)
            {
                PageChoiceSwitch = 1;
                Console.Clear();
            }

            return PageChoiceSwitch;
        }

        public static bool ModeChoosing()
        {
            char ReadModeChoice;
            do
            {
                Console.WriteLine("Нажмите F если хотите использовать быстрый режим, S - если медленный");
                ReadModeChoice = Console.ReadKey().KeyChar;

                if (ReadModeChoice == 'f' | ReadModeChoice == 'F')
                {
                    return true;
                }

                if (ReadModeChoice == 's' | ReadModeChoice == 'S')
                {
                    return false;
                }

                Console.Clear();

            }
            while (ReadModeChoice != 'f' | ReadModeChoice != 'F' | ReadModeChoice != 's' | ReadModeChoice != 'S');

            throw new Exception("Something going wrong");

        }

        public static int ParseToIntPositiveNumber(string input)
        {
            bool result = int.TryParse(input, out int number);
            if (result && number > 0)
            {
                return number;
            }
            else
            {
                ErrorMessagesWriter.ErrorMessage(ErrorType.DefaultError);//формат должен быть static чтобы функция ErrorMessage- работала
                return 0;
            }
        }

        public static int ParseToIntNumber(string input)
        {
            bool result = int.TryParse(input, out int number);
            if (result)
            {
                return number;
            }
            else
            {
                ErrorMessagesWriter.ErrorMessage(ErrorType.DefaultError);
                return 0;
            }
        }

        public static double ParseToDoubleNumber(string input)
        {
            bool result = double.TryParse(input, out double number);
            if (result)
            {
                return number;
            }
            else
            {
                ErrorMessagesWriter.ErrorMessage(ErrorType.DefaultError);
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
            string textLog = "Game at: " + DateTime.Now.ToString("G") + "\n" +
                          "Steps of side 'X': '" + stepsListX + "'\n" +
                          "Steps of side 'O': '" + stepsListO + "'\n";

            if (winner == "Draw")
            {
                textLog += "Draw\n\n";
            }
            else
            {
                textLog += "Winner is: '" + winner + "'\n\n";
            }
            using (FileStream fstream = new FileStream(path, FileMode.Append))
            {
                // преобразуем строку в байты
                byte[] buffer = Encoding.Default.GetBytes(textLog);
                // запись массива байтов в файл
                await fstream.WriteAsync(buffer);
                Console.WriteLine("\nSession logs saved.");
            }
            return true;
        }


    }
}

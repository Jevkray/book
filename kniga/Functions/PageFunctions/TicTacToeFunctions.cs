using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga.Core;

namespace kniga.Functions.PageFunctions
{
    public static class TicTacToeFunctions
    {

        public static void PrintInterface(string[] tictactoeArea, int gameScale, string? stepSign, string stepsListX, string stepsListO)
        {
            Console.WriteLine("---------");
            DisplayTicTacToeArea(tictactoeArea, gameScale);
            Console.WriteLine("---------");
            Console.WriteLine("Turn: " + stepSign);
            Console.WriteLine("Steps player X: " + stepsListX);
            Console.WriteLine("Steps player O: " + stepsListO);
        }

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

        public static int DisplayTicTacToeArea(string[] tictactoeArea, int Scale)
        {
            for (int i = 0; i < Scale*Scale; i++) 
            {
                Console.Write($" {tictactoeArea[i]} ");
                if (i % Scale == 2)
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

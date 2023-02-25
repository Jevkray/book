using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga.Functions;
public class User 
{
    public string Name = "Undefined";   
    public int Age = 0;
    public void Print()
    {
        Console.WriteLine($"User {Name} has {Age} years");
    }

    public class Rectangle
    {
        public int Height { get; set; } = 0;
        public int Width { get; set; } = 0;
    }

    public class TicTacToe
    {
        public int Scale { get; set; } = 0;
        public int Height { get; set; } = 0;
        public int Width { get; set; } = 0;
        public class Cell
            {
                public int ChoicedPos { get; set; } = 0;
                public bool IsFree { get; set; } = true;
                public string Sign { get; set; } = null;
            }
        public int Score { get; set; } = 0;
        public int Steps { get; set; } = 0;
    }
}


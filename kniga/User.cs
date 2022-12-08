using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga.face;
public class User 
{
    public string name = "Undefined";   
    public int age = 0;
    public void Print()
    {
        Console.WriteLine($"User {name} has {age} years");
    }

    public class Rectangle
    {
        public int height { get; set; } = 0;
        public int width { get; set; } = 0;
    }

    public class TicTacToe
    {
        public int scale { get; set; } = 0;
        public int height { get; set; } = 0;
        public int width { get; set; } = 0;
        public int score { get; set; } = 0;
        public int steps { get; set; } = 0;
    }
}


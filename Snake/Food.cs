using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Food
    {
        public Food()
        {
            Random rand = new Random();
            var x = rand.Next(1, 20);
            var y = rand.Next(1, 20);
            FoodCordinate = new Coordinate(x, y);
            Draw();
        }

        public Coordinate FoodCordinate { get; set; }

        void Draw()
        {
            Console.SetCursorPosition(FoodCordinate.X, FoodCordinate.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("$");
        }
    }
}

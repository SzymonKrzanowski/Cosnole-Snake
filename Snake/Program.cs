using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool exitGame = false;
            double speed = 5.0;
            double frameRate = 1000 / speed;
            DateTime lastTime = DateTime.Now;
            Food food = new Food();
            Snake snake = new Snake();

            while (!exitGame)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input = Console.ReadKey();
                    switch (input.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            snake.Direction = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Direction = Direction.Right;
                            break;
                        case ConsoleKey.UpArrow:
                            snake.Direction = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Direction = Direction.Down;
                            break;
                        case ConsoleKey.Escape:
                            exitGame = true;
                            break;
                    }
                }

                if ((DateTime.Now-lastTime).TotalMilliseconds >= frameRate)
                {
                    snake.Move();
                    
                    if (food.FoodCordinate.X == snake.HeadPosition.X && food.FoodCordinate.Y == snake.HeadPosition.Y)
                    {
                        snake.Eat();
                        food = new Food();
                    }
                    if (snake.GameOver)
                    {
                        Console.Clear();
                        Console.WriteLine("GAME OVER");
                        Console.WriteLine($"Your score:{snake.Length}");
                        Console.WriteLine("Play again? Y/N");
                        ConsoleKeyInfo playAgain = Console.ReadKey();
                        if (playAgain.Key == ConsoleKey.N)
                            exitGame = true;
                        Console.ReadLine();
                        Console.Clear();
                        food = new Food();
                        snake = new Snake();
                        
                    }
                    lastTime = DateTime.Now;
                }
            }
        }
    }
}

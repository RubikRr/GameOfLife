using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using GameOfLife;

namespace ConsoleLife
{
    public class Program
    {

        [DllImport("kernel32.dll",ExactSpelling = true)]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll",CharSet = CharSet.Auto,SetLastError = true)]
        public static extern IntPtr ShowWindow(IntPtr hWnd,int nCmdShow);

        private const int MAXIMIZE = 3;


        static void Main(string[] args)
        {
           
            

            Console.ReadLine(); 
            Console.SetWindowSize(Console.LargestWindowWidth,Console.LargestWindowHeight);
            ShowWindow(GetConsoleWindow(), MAXIMIZE);
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            var gameEngine = new GameEngine
            (
                rows: 14,
                cols: 500,
                density: 10
            );

            while (true)
            {
                Console.Title = gameEngine.CurrentGeneration.ToString();
                var field = gameEngine.GetCurrentGeneration();
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    var str = new char[field.GetLength(0)];
                    for (int x = 0; x < field.GetLength(0); x++)
                    {
                        if (field[x, y])
                            str[x] = '#';
                        else
                            str[x] = ' ';
                    }

                    Console.WriteLine(str);
                }
                Console.SetCursorPosition(0, 0);
                gameEngine.NextGeneration();
            }
        }
    }
}
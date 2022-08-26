using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameOfLife
{
    public class GameEngine
    {
        private bool[,] field;
        private readonly int rows;
        private readonly int cols;
        public uint CurrentGeneration { get; private set; }
      

        public GameEngine(int rows, int cols,int density)
        {
            this.rows = rows;
            this.cols = cols;
            field=new bool[cols, rows]; 
            Random random = new Random();
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next(density) == 0;
                }
            }
        }
        private int CountNeighbours(int x, int y)
        {
            int ans = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int col = (x + i + cols) % cols;
                    int row = (y + j + rows) % rows;
                    bool isSelfChecking = row == y & col == x;
                    bool isAlive = field[col, row];
                    if (isAlive && !isSelfChecking)
                    {
                        ans++;
                    }
                }
            }
            return ans;
        }

        public bool[,] GetCurrentGeneration()
        {
            var result=new bool[cols, rows];
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    result[x, y] = field[x, y];
                }
            }

            return result;
        }

        public void NextGeneration()
        {
            var newField = new bool[cols, rows];
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    var neighbours = CountNeighbours(x, y);
                    var isAlive = field[x, y];

                    if (!isAlive && neighbours == 3)
                    {
                        newField[x, y] = true;
                    }
                    else if (isAlive && (neighbours < 2 || neighbours > 3))
                    {
                        newField[x, y] = false;
                    }
                    else
                    {
                        newField[x, y] = field[x, y];
                    }

                   
                }
            }
            field = newField;
            CurrentGeneration++;
        }

        private bool ValidateCellPosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < cols && y < rows;
        }

        private void UpdateCell(int x, int y, bool state)
        {
            if (ValidateCellPosition(x, y))
                field[x, y] = state;
        }

        public void AddCell(int x, int y)
        {
            UpdateCell(x,y,true);
        }
        public void RemoveCell(int x, int y)
        {
            UpdateCell(x, y, false);
        }
    }
}

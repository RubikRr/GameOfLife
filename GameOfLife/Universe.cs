using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Universe : Form
    {
        private Graphics graphics;
        private int currentGeneration;
        private int _resolution;
        private int _density;
        private bool[,] field;
        private int rows;
        private int cols;
        public Universe()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void StartGame()
        {
            if (timer.Enabled)
                return;

            currentGeneration = 0;
            resolution.Enabled = false;
            density.Enabled = false;

            _resolution = (int)resolution.Value;
            _density = (int)density.Value;

            rows = map.Height / _resolution;
            cols = map.Width / _resolution;
            field = new bool[cols, rows];
            Random random = new Random();
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next(_density) == 0;
                }
            }

            map.Image = new Bitmap(map.Width, map.Height);
            graphics = Graphics.FromImage(map.Image);
            timer.Start();
            //graphics.FillRectangle(Brushes.Blue, 0, 0, _resolution, _resolution);
        }

        private void NextGeneration()
        {
            graphics.Clear(Color.IndianRed);
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

                    if (isAlive)
                    {
                        graphics.FillRectangle(Brushes.Blue, x * _resolution, y * _resolution, _resolution, _resolution);
                    }
                }
            }

            field = newField;
            map.Refresh();
            this.Text = $"Generation{++currentGeneration}";
            //Random random = new Random();
            //for (int x = 0; x < cols; x++)
            //{
            //    for (int y = 0; y < rows; y++)
            //    {
            //        field[x, y] = random.Next(_density) == 0;
            //    }
            //}
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

        private void timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void start_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StopGame()
        {
            if (!timer.Enabled)
                return;
            timer.Stop();

            resolution.Enabled = true;
            density.Enabled = true;
        }

        private void stop_Click(object sender, EventArgs e)
        {
            StopGame();
        }

        private void map_MouseMove(object sender, MouseEventArgs e)
        {
            if (!timer.Enabled)
                return;


            if (e.Button == MouseButtons.Left)
            {
                var x = e.Location.X / _resolution;
                var y = e.Location.Y / _resolution;

                if (ValidateMousePosition(x, y))
                    field[x, y] = true;
            }
            if (e.Button == MouseButtons.Right)
            {
                var x = e.Location.X / _resolution;
                var y = e.Location.Y / _resolution;
                if (ValidateMousePosition(x, y))
                    field[x, y] = false;
            }
        }

        private bool ValidateMousePosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < cols && y < rows;
        }
    }
}

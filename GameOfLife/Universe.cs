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
        private int _resolution;
        private int _density;
        private bool[,] field;
        private int rows;
        private int cols;
        public Universe()
        {
            InitializeComponent();
            StartPosition= FormStartPosition.CenterScreen;
        }

        private void StartGame()
        {
            if (timer.Enabled)
                return;

            resolution.Enabled = false;
            density.Enabled = false;

            _resolution = (int)resolution.Value;
            _density= (int)density.Value;

            rows = map.Height / _resolution;
            cols = map.Width / _resolution;
            field = new bool[cols, rows];
            Random random = new Random();
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next(_density)==0 ;
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

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (field[x, y])
                    {
                        graphics.FillRectangle(Brushes.Blue,x*_resolution,y*_resolution,_resolution,_resolution);
                    }
                }
            }
            map.Refresh();
            Random random = new Random();
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next(_density) == 0;
                }
            }
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
            if(!timer.Enabled)
                return;
            timer.Stop();

            resolution.Enabled = true;
            density.Enabled = true;
        }

        private void stop_Click(object sender, EventArgs e)
        {
            StopGame();
        }
    }
}

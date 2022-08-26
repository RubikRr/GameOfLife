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
        private GameEngine gameEngine;
        private int _resolution;
   

        public Universe()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void StartGame()
        {
            if (timer.Enabled)
                return;


            resolution.Enabled = false;
            density.Enabled = false;

            _resolution = (int)resolution.Value;

            gameEngine = new GameEngine
            
            (
                rows: map.Height / _resolution,
                cols: map.Width / _resolution,
                density: (int)(density.Maximum + density.Minimum - density.Value)
            );

            map.Image = new Bitmap(map.Width, map.Height);
            graphics = Graphics.FromImage(map.Image);
            timer.Start();
        }

        private void DrawNextGeneration()
        {
            graphics.Clear(Color.IndianRed);
            var field = gameEngine.GetCurrentGeneration();

            for (int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    if (field[x, y])
                        graphics.FillRectangle(Brushes.Blue, x * _resolution, y * _resolution, _resolution - 1, _resolution - 1);
                }
            }
            map.Refresh();
            this.Text = $"Generation{gameEngine.CurrentGeneration}";
            gameEngine.NextGeneration();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DrawNextGeneration();
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
                gameEngine.AddCell(x, y);
            }
            if (e.Button == MouseButtons.Right)
            {
                var x = e.Location.X / _resolution;
                var y = e.Location.Y / _resolution;
                gameEngine.RemoveCell(x, y);
            }
        }
    }
}

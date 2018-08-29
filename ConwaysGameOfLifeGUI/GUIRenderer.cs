using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwaysGameOfLifeGUI
{
    public partial class GUIRenderer : Form
    {
        private const int cellSize = 10;
        private GameEngine GameEngine;
        private List<Cell> InitialCells = new List<Cell>();
        

        public GUIRenderer(GameEngine gameEngine)
        {
            InitializeComponent();
            RenderTitle();
            GameEngine = gameEngine;
        }

        public void RenderTitle()
        {
            this.Text = "Conway's Game Of Life";
        }
        private void WidthBox_ValueChanged(object sender, EventArgs e)
        {
            this.GridBox.Width = (int)WidthBox.Value;
        }

        private void HeightBox_ValueChanged(object sender, EventArgs e)
        {
            this.GridBox.Height = (int)HeightBox.Value;
        }

        private void GridBox_Click(object sender, MouseEventArgs e)
        {
            var row = (int)Math.Round(e.X / 10.0) * cellSize;
            var column = (int)Math.Round(e.Y / 10.0) * cellSize;
            InitialCells.Add(new Cell(row / cellSize, column / cellSize));
            SetNumberOfLivingCells(InitialCells.Count);
            Render(DrawLivingCells(InitialCells));
        }

        private void ShowGrid_Click(object sender, EventArgs e)
        {
            Render(DrawGridLines());
        }

        public Bitmap DrawGridLines()
        {
            var bitmap = new Bitmap(this.GridBox.Width, this.GridBox.Height);
            var graphics = Graphics.FromImage(bitmap);
            for (int x = 0; x < GridBox.Width / cellSize; x++)
            {
                graphics.DrawLine(new Pen(Color.Gray), x * cellSize, 0, x * cellSize, GridBox.Height / cellSize * cellSize);
            }
            for (int y = 0; y < GridBox.Height / cellSize; y++)
            {
                graphics.DrawLine(new Pen(Color.Gray), 0, y * cellSize, GridBox.Width / cellSize * cellSize,
                    y * cellSize);
            }
            return bitmap;
        }

        private void ClearGridButton_Click(object sender, EventArgs e)
        {
            InitialCells.Clear();
            SetNumberOfLivingCells(InitialCells.Count);
            Render(new Bitmap(this.GridBox.Width, this.GridBox.Height));
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            GameEngine.SetGridSize(GetGridHeight(), GetGridWidth());
            GameEngine.SetLivingCells(InitialCells);
            StartGameButton.Enabled = false;
            var generation = 1;
            var numberOfLivingCells = GameEngine.LivingCells.Count();
            while (true)
            {
                SetGenerationNumber(generation);
                SetNumberOfLivingCells(numberOfLivingCells);
                Render(DrawLivingCells(GameEngine.LivingCells));
                GameEngine.Evolve();

                generation += 1;
                numberOfLivingCells = GameEngine.LivingCells.Count();
                Thread.Sleep(500);
            }
        }

        public int GetGridWidth()
        {
            return (int) WidthBox.Value;
        }

        public int GetGridHeight()
        {
            return (int)HeightBox.Value;
        }

        public void Render(Bitmap bitmap)
        {
            this.GridBox.Image = bitmap;
            this.GridBox.Refresh();
        }

        public Bitmap DrawLivingCells(IEnumerable<Cell> livingCells)
        {
            var bitmap = new Bitmap(this.GridBox.Width, this.GridBox.Height);
            var graphics = Graphics.FromImage(bitmap);
            for (int i = 0; i < livingCells.Count(); i++)
            {
                graphics.FillRectangle(Brushes.Aqua, livingCells.ElementAt(i).Row * cellSize, livingCells.ElementAt(i).Column * cellSize, cellSize, cellSize);
            }
            return bitmap;
        }   

        public void SetGenerationNumber(int generation)
        {
            this.GenerationNumber.Text = generation.ToString();
            this.GenerationNumber.Refresh();
        }

        public void SetNumberOfLivingCells(int noOfLivingCells)
        {
            this.NoOfLivingCells.Text = noOfLivingCells.ToString();
            this.NoOfLivingCells.Refresh();
        }


        
    }
}

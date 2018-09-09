using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ConwaysGameOfLifeGUI
{
    public partial class GUIRenderer : Form
    {
        private const int cellSize = 10;
        private GameOfLife GameOfLife;
        private List<Cell> InitialCells = new List<Cell>();
        

        public GUIRenderer(GameOfLife gameOfLife)
        {
            InitializeComponent();
            RenderTitle();
            GameOfLife = gameOfLife;
        }

        public void RenderTitle()
        {
            Text = "Conway's Game Of Life";
        }
        private void WidthBox_ValueChanged(object sender, EventArgs e)
        {
            GridBox.Width = (int)WidthBox.Value;
        }

        private void HeightBox_ValueChanged(object sender, EventArgs e)
        {
            GridBox.Height = (int)HeightBox.Value;
        }

        private void GridBox_Click(object sender, MouseEventArgs e)
        {
            var row = (int)Math.Round(e.X / 10.0) * cellSize;
            var column = (int)Math.Round(e.Y / 10.0) * cellSize;
            UpdateGrid(row, column);
        }

        private void UpdateGrid(int row, int column)
        {
            InitialCells.Add(new Cell(row / cellSize, column / cellSize));
            SetNumberOfLivingCells(InitialCells.Count);
            Render(DrawLivingCells(InitialCells));
        }

        private void ClearGridButton_Click(object sender, EventArgs e)
        {
            InitialCells.Clear();
            SetNumberOfLivingCells(InitialCells.Count);
            Render(new Bitmap(this.GridBox.Width, this.GridBox.Height));
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            GameOfLife.SetGridSize(GetGridHeight(), GetGridWidth());
            GameOfLife.SetInitialStateOfGrid(InitialCells);
            StartGameButton.Enabled = false;
            var generation = 1;
            var numberOfLivingCells = GameOfLife.LivingCells.Count();
            while (true)
            {
                SetGenerationNumber(generation);
                SetNumberOfLivingCells(numberOfLivingCells);
                Render(DrawLivingCells(GameOfLife.LivingCells));
                GameOfLife.Evolve();

                generation += 1;
                numberOfLivingCells = GameOfLife.LivingCells.Count();
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
            GridBox.Image = bitmap;
            GridBox.Refresh();
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
            GenerationNumber.Text = generation.ToString();
            GenerationNumber.Refresh();
        }

        public void SetNumberOfLivingCells(int noOfLivingCells)
        {
            NoOfLivingCells.Text = noOfLivingCells.ToString();
            NoOfLivingCells.Refresh();
        }       
    }
}

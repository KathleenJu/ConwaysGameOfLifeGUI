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
        private int cellSize = cellSize;

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
            RenderGrid(InitialCells);
        }

        private void ShowGrid_Click(object sender, EventArgs e)
        {
            DrawGridLines();
        }

        public void DrawGridLines()
        {
            var bitmap = new Bitmap(this.GridBox.Width, this.GridBox.Height);
            var graphics = Graphics.FromImage(bitmap);
            for (int x = 0; x < GridBox.Width / cellSize; x++)
            {
                graphics.DrawLine(new Pen(Color.Gray), x * cellSize, 0, x * cellSize, GridBox.Height / cellSize * cellSize);
            }
            for (int y = 0; y < GridBox.Height / cellSize; y++)
            {
                graphics.DrawLine(new Pen(Color.Gray), 0, y * cellSize, GridBox.Width / cellSize * cellSize, y * cellSize);

            }
            this.GridBox.Image = bitmap;
            this.GridBox.Refresh();
        }

        private void ClearGridButton_Click(object sender, EventArgs e)
        {
            InitialCells.Clear();
            RenderGrid(InitialCells);
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
                RenderGrid(GameEngine.LivingCells);
                GameEngine.Evolve();

                generation += 1;
                numberOfLivingCells = GameEngine.LivingCells.Count();
                Thread.Sleep(500);
            }
        }

        public List<Cell> GetInitialStateOfGrid()
        {
            return new List<Cell>
            {
                new Cell(4,4), new Cell(5,4),new Cell(6,4),new Cell(3,5),new Cell(7,5), new Cell(2,6),new Cell(8,6), new Cell(1,8), new Cell(9,8),
                new Cell(4,13), new Cell(5,13),new Cell(6,13),new Cell(3,12),new Cell(7,12), new Cell(2,11),new Cell(8,11), new Cell(1,9), new Cell(9,9)
            };
        }

        public int GetGridWidth()
        {
            return (int) WidthBox.Value;
        }

        public int GetGridHeight()
        {
            return (int)HeightBox.Value;
        }

        public void RenderGrid(IEnumerable<Cell> cells)
        {
            this.GridBox.Image = this.Draw(cells);
            this.GridBox.Refresh();
        }

        public Bitmap Draw(IEnumerable<Cell> cells)
        {
            var bitmap = new Bitmap(this.GridBox.Width, this.GridBox.Height);
            var graphics = Graphics.FromImage(bitmap);
            
            
            for (int i = 0; i < cells.Count(); i++)
            {
                graphics.FillRectangle(Brushes.Aqua, cells.ElementAt(i).Row * cellSize, cells.ElementAt(i).Column * cellSize, cellSize, cellSize);
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

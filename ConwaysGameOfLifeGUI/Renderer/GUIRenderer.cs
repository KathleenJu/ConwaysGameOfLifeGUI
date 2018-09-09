using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ConwaysGameOfLifeGUI
{
    public partial class GUIRenderer : Form, IRenderer
    {
        private const int CellSize = 10;
        private readonly GameOfLife _gameOfLife;
        private readonly List<Cell> _initialCells = new List<Cell>();
        

        public GUIRenderer(GameOfLife gameOfLife)
        {
            InitializeComponent();
            RenderTitle("Conway's Game Of Life");
            _gameOfLife = gameOfLife;
        }

        public void RenderTitle(string title)
        {
            Text = title;
        }

        private void UpdateGrid(int row, int column)
        {
            _initialCells.Add(new Cell(row / CellSize, column / CellSize));
            SetNumberOfLivingCells(_initialCells.Count);
            Render(DrawLivingCells(_initialCells));
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

        public int GetGridWidth()
        {
            return (int)WidthBox.Value;
        }

        public int GetGridHeight()
        {
            return (int)HeightBox.Value;
        }

        private void StartGame()
        {
            _gameOfLife.SetGridSize(GetGridHeight(), GetGridWidth());
            _gameOfLife.SetInitialStateOfGrid(_initialCells);
            StartGameButton.Enabled = false;
            var generation = 1;
            var numberOfLivingCells = _gameOfLife.LivingCells.Count();
            while (true)
            {
                SetGenerationNumber(generation);
                SetNumberOfLivingCells(numberOfLivingCells);
                Render(DrawLivingCells(_gameOfLife.LivingCells));
                _gameOfLife.Evolve();

                generation += 1;
                numberOfLivingCells = _gameOfLife.LivingCells.Count();
                Thread.Sleep(500);
            }
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
            var row = (int)Math.Round(e.X / 10.0) * CellSize;
            var column = (int)Math.Round(e.Y / 10.0) * CellSize;
            UpdateGrid(row, column);
        }

        private void ClearGridButton_Click(object sender, EventArgs e)
        {
            _initialCells.Clear();
            SetNumberOfLivingCells(_initialCells.Count);
            Render(new Bitmap(this.GridBox.Width, this.GridBox.Height));
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            StartGame();
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
                graphics.FillRectangle(Brushes.Aqua, livingCells.ElementAt(i).Row * CellSize, livingCells.ElementAt(i).Column * CellSize, CellSize, CellSize);
            }
            return bitmap;
        }   
    }
}

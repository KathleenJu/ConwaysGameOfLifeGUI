using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ConwaysGameOfLifeGUI.Renderer
{
    public partial class GuiRenderer : Form
    {
        private const int CellSize = 10;
        private readonly GameOfLife _gameOfLife;
        private readonly List<Cell> _initialCells;
        private Bitmap gridBitmap;

        public GuiRenderer(GameOfLife gameOfLife)
        {
            InitializeComponent();
            SetTitle("Conway's Game Of Life");
            _gameOfLife = gameOfLife;
            _initialCells = new List<Cell>();
        }

        public void SetTitle(string title)
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

        public void StartGame()
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
                //DrawLivingCells(_gameOfLife.GetGrid());
                //Render(gridBitmap);
                Render(DrawLivingCells(_gameOfLife.LivingCells));
                _gameOfLife.Evolve();

                generation += 1;
                numberOfLivingCells = _gameOfLife.LivingCells.Count();
                Thread.Sleep(500);
            }
        }

        public Bitmap DrawLivingCells(IEnumerable<Cell> livingCells)
        {
            var bitmap = new Bitmap(GridBox.Width, GridBox.Height);
            var graphics = Graphics.FromImage(bitmap);
            for (int cellIndex = 0; cellIndex < livingCells.Count(); cellIndex++)
            {
                graphics.FillRectangle(Brushes.Aqua, livingCells.ElementAt(cellIndex).Row * CellSize, livingCells.ElementAt(cellIndex).Column * CellSize, CellSize, CellSize);
            }

            //graphics.Clear();
            //only new the bitmap when start game, setting the grid height and width
            return bitmap;
        }

//        public void SetGrid(Grid grid)
//        {
//            var bitmap = new Bitmap(GridBox.Width, GridBox.Height);
//            var graphics = Graphics.FromImage(bitmap);
//            for (int cellIndex = 0; cellIndex < grid.GetLivingCells().Count(); cellIndex++)
//            {
//                graphics.FillRectangle(Brushes.Aqua, grid.GetLivingCells().ElementAt(cellIndex).Row * CellSize, grid.GetLivingCells().ElementAt(cellIndex).Column * CellSize, CellSize, CellSize);
//            }
//            
//            //graphics.Clear();
//            //only new the bitmap when start game, setting the grid height and width
//            gridBitmap = bitmap;
//        }

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
            Render(new Bitmap(GridBox.Width, GridBox.Height));
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
    }
}

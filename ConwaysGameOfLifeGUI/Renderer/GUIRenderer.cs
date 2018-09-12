using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ConwaysGameOfLifeGUI.Renderer
{
    public partial class GuiRenderer : Form
    {
        private const int CellSize = 10;
        private readonly GameEngine _gameEngine;

        public GuiRenderer(GameEngine gameEngine)
        {
            InitializeComponent();          
            _gameEngine = gameEngine;
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

        public Bitmap GetGridBitmap(IEnumerable<Cell> livingCells)
        {
            var bitmap = new Bitmap(GridBox.Width, GridBox.Height);
            var graphics = Graphics.FromImage(bitmap);
            for (int cellIndex = 0; cellIndex < livingCells.Count(); cellIndex++)
            {
                graphics.FillRectangle(Brushes.Aqua, livingCells.ElementAt(cellIndex).Row * CellSize, livingCells.ElementAt(cellIndex).Column * CellSize, CellSize, CellSize);
            }

            return bitmap;
        }

        private void GridBox_Click(object sender, MouseEventArgs e)
        {
            var row = (int)Math.Round(e.X / 10.0) * CellSize;
            var column = (int)Math.Round(e.Y / 10.0) * CellSize;
            UpgradeGridBox(new Cell(row / CellSize, column / CellSize));
        }

        private void UpgradeGridBox(Cell cell)
        {
            _gameEngine.AddCellToGrid(cell);
            Render(_gameEngine.LivingCells);
        }

        private void ClearGridButton_Click(object sender, EventArgs e)
        {
            _gameEngine.ClearGrid();
            Render(_gameEngine.LivingCells);
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            Action<IEnumerable<Cell>> renderAction = Render;
            _gameEngine.StartGame(renderAction);        
        }

        public void Render(IEnumerable<Cell> livingCells)
        {
            GridBox.Image = GetGridBitmap(livingCells);
            GridBox.Refresh();
            SetGenerationNumber(_gameEngine.GetGenerationNumber());
            SetNumberOfLivingCells(_gameEngine.GetNumberOfLivingCells());
        }

        private void SetGridButton_Click(object sender, EventArgs e)
        {
            GridBox.Height = (int) HeightBox.Value;
            GridBox.Width = (int) WidthBox.Value;
            GridBox.Visible = true;
            _gameEngine.SetGrid(GridBox.Height, GridBox.Width);
        }
    }
}

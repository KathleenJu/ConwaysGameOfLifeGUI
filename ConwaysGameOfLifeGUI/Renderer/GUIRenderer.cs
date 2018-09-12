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

        public void GuiRenderer_Load(object sender, EventArgs e)
        {
            _gameEngine.SetGridSize((int)HeightBox.Value, (int)WidthBox.Value);
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

            //graphics.Clear();
            //only new the bitmap when start game, setting the grid height and width
            return bitmap;
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
            UpgradeGridBox(new Cell(row / CellSize, column / CellSize));
        }

        private void UpgradeGridBox(Cell cell)
        {
            _gameEngine.AddLivingCell(cell);
            Render(GetGridBitmap(_gameEngine.LivingCells));
        }

        private void ClearGridButton_Click(object sender, EventArgs e)
        {
            _gameEngine.ClearGrid();
            Render(new Bitmap(GridBox.Width, GridBox.Height));
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            _gameEngine.SetGridSize((int)HeightBox.Value, (int)WidthBox.Value);
            Action<IEnumerable<Cell>> renderAction = RenderAction;
            _gameEngine.StartGame(renderAction);        
        }

        private void RenderAction(IEnumerable<Cell> gameEngineLivingCells)
        {
            GridBox.Image = GetGridBitmap(gameEngineLivingCells);
            GridBox.Refresh();
            SetGenerationNumber(_gameEngine.GetGenerationNumber());
            SetNumberOfLivingCells(_gameEngine.GetNumberOfLivingCells());
        }

        public void Render(Bitmap bitmap)
        {          
            GridBox.Image = bitmap;
            GridBox.Refresh();
            SetGenerationNumber(_gameEngine.GetGenerationNumber());
            SetNumberOfLivingCells(_gameEngine.GetNumberOfLivingCells());
        }    
    }
}

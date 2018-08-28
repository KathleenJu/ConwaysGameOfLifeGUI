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
        private string Title;
        private GameEngine GameEngine;
       

        public GUIRenderer(GameEngine gameEngine)
        {
            InitializeComponent();
            RenderTitle();
            GameEngine = gameEngine;

        }

        public List<Cell> GetInitialStateOfGrid()
        {
            return new List<Cell>
            {
                new Cell(0,0), new Cell(0, 1), new Cell(0, 2), new Cell(0, 3), new Cell(0, 4), new Cell(0, 5), new Cell(0, 6),
                new Cell(4,4), new Cell(4,5),new Cell(4,6),new Cell(3,5),new Cell(7,5), new Cell(2,6),new Cell(8,6), new Cell(1,8), new Cell(9,8),
                new Cell(4,4), new Cell(4,5),new Cell(4,6),new Cell(3,5),new Cell(7,5), new Cell(2,6),new Cell(8,6), new Cell(1,8), new Cell(9,8)
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

        public void RenderGrid()
        {
            this.GridBox.Image = this.Draw();
            this.GridBox.Refresh();
        }

        public Bitmap Draw()
        {
            var bitmap = new Bitmap(this.GridBox.Width, this.GridBox.Height);
            var graphics = Graphics.FromImage(bitmap);
            var cellSize = 10;
            var livingCellsList = GameEngine.LivingCells.ToList();
            
            for (int i = 0; i < livingCellsList.Count; i++)
            {
                graphics.FillRectangle(Brushes.Aqua, livingCellsList[i].Row * cellSize, livingCellsList[i].Column * cellSize, cellSize, cellSize);
            }
            return bitmap;
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            GameEngine.SetGridSize(GetGridHeight(), GetGridWidth());
            GameEngine.SetLivingCells(GetInitialStateOfGrid());

            var generation = 1;

            while(true){
                SetGenerationNumber(generation);
                SetNumberOfLivingCells(GameEngine.LivingCells.Count());
                RenderGrid();
                GameEngine.StartGame();
            
                generation++;
                Thread.Sleep(100);
             }
        }

        public void RenderTitle()
        {
            this.Text = Title;
        }

        public void SetGenerationNumber(int generation)
        {
            GenerationNumber.Text = generation.ToString();
        }

        public void SetNumberOfLivingCells(int noOflivingCells)
        {
            NoOfLivingCells.Text = noOflivingCells.ToString();
        }


        private void WidthBox_ValueChanged(object sender, EventArgs e)
        {
            this.GridBox.Width = (int) WidthBox.Value;
        }

        private void HeightBox_ValueChanged(object sender, EventArgs e)
        {
            this.GridBox.Height = (int)HeightBox.Value;
        }
    }
}

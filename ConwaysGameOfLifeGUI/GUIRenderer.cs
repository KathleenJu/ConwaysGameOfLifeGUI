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
    public partial class GUIRenderer : Form, IRenderer
    {
        private string Title;
        private int Generation;
        private int NumberOfLivingCells;
        private Grid Grid;

        public GUIRenderer()
        {
            InitializeComponent();
            this.GridBox.Width = this.Width ;
            this.GridBox.Height = this.Height ;
            this.GridBox.BackColor = Color.Black;
            this.GridBox.BorderStyle = BorderStyle.None;

            this.widthBox.Value = this.GridBox.Size.Width - 30;
            this.heightBox.Value = this.GridBox.Size.Height - 30;
            SetGrid(new Grid(100, 100));
            RenderGrid();
        }

        public int GetGridDimension(string dimension)
        {
            var dimensionBox = dimension == "width" ? widthBox : heightBox;
            return (int) dimensionBox.Value;
        }

        public List<Cell> GetInitialStateOfGrid()
        {
            return new List<Cell> { new Cell(0, 0) };
        }

        public void RenderGrid()
        {
            
            this.GridBox.Image = this.Draw();
            GridBox.Invalidate();
        }

        public Bitmap Draw()
        {
            var bitmap = new Bitmap(this.GridBox.Width, this.GridBox.Height);
            var graphics = Graphics.FromImage(bitmap);
            var cellSize = 10;
            //var foo = Grid.GetLivingCells().ToList();
            var foo = new List<Cell> {new Cell(11, 11), new Cell(3, 2), new Cell(3, 3), new Cell(10, 10)};
            for (int i = 0; i < NumberOfLivingCells; i++)
            {
                graphics.FillRectangle(new SolidBrush(Color.DodgerBlue), 5 + cellSize, 5 + cellSize, cellSize, cellSize);
                
            }
            //graphics.FillRectangle(new SolidBrush(Color.DodgerBlue), 0, 0, cellSize, cellSize);
            //graphics.FillRectangle(new SolidBrush(Color.DodgerBlue), 2 + cellSize, 2 + cellSize, cellSize, cellSize);
            return bitmap;
        }

        public void RenderTitle()
        {
            this.Text = Title;
        }

        public void SetGenerationNumber(int generation)
        {
            GenerationNumber.Text = generation.ToString();
        }

        public void SetGrid(Grid grid)
        {
            Grid = grid;
        }

        public void SetNumberOfLivingCells(int noOflivingCells)
        {
            NoOfLivingCells.Text = noOflivingCells.ToString();
        }

        public void SetTitle(string title)
        {
            Title = title;
        }
    }
}

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
        private Grid Grid;

        public GUIRenderer()
        {
            InitializeComponent();
            SetGrid(new Grid(100, 100));
            RenderGrid();
        }

       

        public int GetGridDimension(string dimension)
        {
            var dimensionBox = dimension == "width" ? WidthBox : HeightBox;
            return (int) dimensionBox.Value;
        }

        public List<Cell> GetInitialStateOfGrid()
        {
            return new List<Cell> { new Cell(0, 0) };
        }

        public void SetGridWidth(int width)
        {
            this.GridBox.Width = width;
        }

        public void SetGridHeight(int height)
        {
            this.GridBox.Height = height;
        }

        public void RenderGrid()
        {
            this.GridBox.Image = this.Draw();
            this.GridBox.Invalidate();
        }

        public Bitmap Draw()
        {
            var bitmap = new Bitmap(this.GridBox.Width, this.GridBox.Height);
            var graphics = Graphics.FromImage(bitmap);
            var cellSize = 10;
            //var foo = Grid.GetLivingCells().ToList();
            var foo = new List<Cell> {new Cell(0, 0), new Cell(1, 1), new Cell(2, 2)};
            for (int i = 0; i < foo.Count; i++)
            {
                graphics.FillRectangle(Brushes.Aqua, foo[i].Row * cellSize, foo[i].Column * cellSize, cellSize, cellSize);
            }
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

        private void widthButton_Click(object sender, EventArgs e)
        {
            SetGridWidth((int) this.WidthBox.Value);
            WidthButton.Enabled = false;
        }

        private void HeightButton_Click(object sender, EventArgs e)
        {
            SetGridHeight((int) this.HeightBox.Value);
            HeightButton.Enabled = false;
        }

    }
}

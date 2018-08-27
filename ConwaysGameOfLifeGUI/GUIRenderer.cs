using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwaysGameOfLifeGUI
{
    public partial class GUIRenderer : Form, IRenderer
    {
        private string Title;
        private int Generation;
        private int NumberOfLivingCells;
        private string GridString;

        public GUIRenderer()
        {
            InitializeComponent();
            RenderGrid();
        }

        public int GetGridDimension(string dimension)
        {
            throw new NotImplementedException();
        }

        public List<Cell> GetInitialStateOfGrid()
        {
            return new List<Cell> { new Cell(0, 0) };
        }

        public void RenderGrid()
        {
            //using (Graphics g = this.CreateGraphics())
            //{
            //    int numOfCells = 50;
            //    int cellSize = 30;
            //    Pen p = new Pen(Color.Black);
            //    for (int y = 0; y < numOfCells; ++y)
            //    {
            //        g.DrawLine(p, 0, y * cellSize, this.Width, y * cellSize);
            //    }

            //    for (int x = 0; x < numOfCells; ++x)
            //    {
            //        g.DrawLine(p, x * cellSize, 0, x * cellSize, this.Height);
            //    }
            //    //g.DrawRectangle(new Pen(Color.Red), 0, panel1.Height, cellSize, cellSize);
            //    //g.FillRectangle(Brushes.Red, 0, panel1.Height, cellSize, cellSize);
            //}
            var image1 = new Bitmap(Grid.Width,Grid.Height);

            int x, y;

            // Loop through the images pixels to reset color.
            for (x = 0; x < image1.Width; x++)
            {
                for (y = 0; y < image1.Height; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.Red;
                    image1.SetPixel(x, y, newColor);
                }
            }

            image1.SetPixel(10,10, Color.Red);
            // Set the PictureBox to display the image.
            
            Grid.Image = image1;
            Graphics g1 = Graphics.FromImage(this.Grid.Image);

            Pen gridPen = new Pen(Color.Black, 1);

            g1.DrawLine(gridPen, 0, 0, 100, 100);
        }

        public void RenderTitle()
        {
            this.Text = Title;
        }

        public void SetGenerationNumber(int generation)
        {
            throw new NotImplementedException();
        }

        public void SetGrid(Grid grid)
        {
            throw new NotImplementedException();
        }

        public void SetNumberOfLivingCells(int noOflivingCells)
        {
            throw new NotImplementedException();
        }

        public void SetTitle(string title)
        {
            Title = "Conway's Game Of Life";
        }

        
    }
}

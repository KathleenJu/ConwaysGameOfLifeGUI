using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
        private Grid Grid1;

        public GUIRenderer()
        {
            InitializeComponent();
            this.Grid.Width = this.Width - 100;
            this.Grid.Height = this.Height - 100;
            this.Grid.BackColor = Color.Black;
            this.Grid.BorderStyle = BorderStyle.None;
            
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

            //var image1 = new Bitmap(Grid.Width,Grid.Height);

            ////Graphics g1 = Graphics.FromImage(image1);
            //using (Graphics G = Graphics.FromImage(image1))
            //{
            //    G.DrawRectangle(Pens.Red, 2, 2, 10, 10);

            //}
            //g1.Clear(Color.Orange);
            //g1.DrawRectangle(Pens.Red, 2, 2, 10, 10);
            //g1.DrawRectangle(Pens.Red, 3, 3, 10, 10);
            //g1.DrawRectangle(Pens.Red, 4, 4, 10, 10);
            //image1.SetPixel(10,10, Color.Red);
            //image1.SetPixel(20, 20, Color.Red);


            //Grid.Image = image1;
            this.Grid.Image = this.Draw();

        }

        public Bitmap Draw()
        {
            var bitmap = new Bitmap(this.Grid.Width, this.Grid.Height);
            var graphics = Graphics.FromImage(bitmap);
            
            graphics.FillRectangle(new SolidBrush(Color.DodgerBlue), 10, 10, 10, 10);

            return bitmap;
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

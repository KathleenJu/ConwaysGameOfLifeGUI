using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeGUI
{
    public interface IRenderer
    {
        void SetTitle(string title);
        void SetGenerationNumber(int generation);
        void SetNumberOfLivingCells(int noOflivingCells);
        void SetGrid(Grid grid);
        void RenderTitle();
        int GetGridDimension(string dimension);
        List<Cell> GetInitialStateOfGrid();
        void SetGridWidth(int width);
        void SetGridHeight(int height);
        void RenderGrid();
    }
}

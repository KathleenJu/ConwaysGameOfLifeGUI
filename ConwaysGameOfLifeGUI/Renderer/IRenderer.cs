using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeGUI
{
    interface IRenderer
    {
        void RenderTitle(string title);
        int GetGridWidth();
        int GetGridHeight();
        void SetGenerationNumber(int generation);
        void SetNumberOfLivingCells(int noOfLivingCells);
        void StartGame();
    }
}

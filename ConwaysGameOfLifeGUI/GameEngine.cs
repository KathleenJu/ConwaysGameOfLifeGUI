using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeGUI
{
    public class GameEngine
    {
        private readonly GameOfLife GameOfLife;
        public IEnumerable<Cell> LivingCells => GameOfLife.LivingCells; 

        public GameEngine(GameOfLife gameOfLife)
        {
            GameOfLife = gameOfLife;
        }

        public void Evolve()
        {
            GameOfLife.Evolve();
            
        }

        public void SetLivingCells(List<Cell> initialCells)
        {
            GameOfLife.SetInitialStateOfGrid(initialCells);
        }

        public void SetGridSize( int height, int width)
        {
            GameOfLife.SetGridSize (height, width);
        }
    }
}

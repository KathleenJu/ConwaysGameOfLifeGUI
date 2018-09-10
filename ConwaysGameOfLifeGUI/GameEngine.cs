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
        private GameOfLife GameOfLife;

        public GameEngine(GameOfLife gameOfLife)
        {
            GameOfLife = gameOfLife;
        }

        public void StartGame()
        {
            GameOfLife.SetGridSize(GetGridHeight(), GetGridWidth());
            GameOfLife.SetInitialStateOfGrid(GetInitialStateOfGrid());
           
            var generation = 1;
            var numberOfLivingCells = GameOfLife.LivingCells.Count();
            while (true)
            {
                SetGenerationNumber(generation);
                SetNumberOfLivingCells(numberOfLivingCells);
                SetGrid(GameOfLife.GetGrid());
                GameOfLife.Evolve();

                generation += 1;
                numberOfLivingCells = GameOfLife.LivingCells.Count();
                Thread.Sleep(500);
            }
        }

        private List<Cell> GetInitialStateOfGrid()
        {
            throw new NotImplementedException();
        }

        private int GetGridWidth()
        {
            throw new NotImplementedException();
        }

        private int GetGridHeight()
        {
            throw new NotImplementedException();
        }

        public void SetGenerationNumber(int generation)
        {
            
        }

        public void SetNumberOfLivingCells(int noOfLivingCells)
        {

        }

        public void SetGrid(Grid grid)
        {

        }
    }
}

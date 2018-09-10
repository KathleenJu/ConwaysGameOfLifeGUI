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
        private int _generationNumber;
        private int _numberOfLivingCells;
        private readonly GameOfLife _gameOfLife;

        public IEnumerable<Cell> LivingCells => _gameOfLife.LivingCells;

        public GameEngine(GameOfLife gameOfLife)
        {
            _gameOfLife = gameOfLife;
        }

        public void StartGame()
        {
            _generationNumber = 1;
            _numberOfLivingCells = _gameOfLife.LivingCells.Count();
            while (true)
            {  
                _gameOfLife.Evolve();
                _generationNumber += 1;
                _numberOfLivingCells = _gameOfLife.LivingCells.Count();
                Thread.Sleep(500);
            }
        }

        public void SetGridSize(int height, int width)
        {
            _gameOfLife.SetGridSize(height, width);
        }

        public void SetInitialStateOfGrid(List<Cell> initialCells)
        {
            _gameOfLife.SetInitialStateOfGrid(initialCells);
        }

        public int GetGenerationNumber()
        {
            return _generationNumber;
        }

        public int GetNumberOfLivingCells()
        {
            return _numberOfLivingCells;
        }

    }
}

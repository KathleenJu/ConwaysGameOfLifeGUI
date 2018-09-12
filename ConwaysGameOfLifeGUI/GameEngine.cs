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
        private int _generationNumber = 1;
        private int _numberOfLivingCells;
        private readonly GameOfLife _gameOfLife;
        public IEnumerable<Cell> LivingCells => _gameOfLife.LivingCells;

        public GameEngine(GameOfLife gameOfLife)
        {
            _gameOfLife = gameOfLife;
        }

        public void StartGame(Action<IEnumerable<Cell>> renderAction)
        {
            _numberOfLivingCells = LivingCells.Count();
            while (true)
            {  
                _gameOfLife.Evolve();
                renderAction(LivingCells);
                _generationNumber += 1;
                _numberOfLivingCells = LivingCells.Count();
                Thread.Sleep(500);
            }
        }

        public void SetGrid(int height, int width)
        {
            _gameOfLife.SetGrid(height, width);
        }

        public void UpdateGridSize(int height, int width)
        {
            _gameOfLife.UpdateGridSize(height, width);
        }

        public int GetGenerationNumber()
        {
            return _generationNumber;
        }

        public int GetNumberOfLivingCells()
        {
            return _numberOfLivingCells;
        }
        
        public void AddCellToGrid(Cell cell)
        {
            _gameOfLife.AddCellToGrid(cell);
        }

        public void ClearGrid()
        {
            _gameOfLife.ClearGrid();
        }
    }
}

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

        public void StartGame(Action<IEnumerable<Cell>> renderAction)
        {
            _generationNumber = 1;
            _numberOfLivingCells = _gameOfLife.LivingCells.Count();
            while (true)
            {  
                _gameOfLife.Evolve();
                renderAction(_gameOfLife.LivingCells);
                _generationNumber += 1;
                _numberOfLivingCells = _gameOfLife.LivingCells.Count();
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

        public void RemoveCellFromGrid(Cell cell)
        {
            _gameOfLife.RemoveCellFromGrid(cell);
        }

        public void ClearGrid()
        {
            _gameOfLife.ClearGrid();
        }
    }
}

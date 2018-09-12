using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLifeGUI.EvolutionRules;

namespace ConwaysGameOfLifeGUI
{
    public class GameOfLife
    {
        private Grid Grid;
        private readonly DeadEvolutionRules _deadEvolutionRules;
        private readonly LiveEvolutionRules _liveEvolutionRules;
        public IEnumerable<Cell> LivingCells => Grid.GetLivingCells();

        public GameOfLife()
        {
            _deadEvolutionRules = new DeadEvolutionRules();
            _liveEvolutionRules = new LiveEvolutionRules();
        }

        public void Evolve()
        {
            var allDeadNeighboursOfLiveCells = new List<Cell>();
            var allLiveNeighboursOfLiveCell = new List<Cell>();

            foreach (var cell in LivingCells)
            {
                allDeadNeighboursOfLiveCells.AddRange(Grid.GetDeadNeighboursOfLivingCell(cell));
                allLiveNeighboursOfLiveCell.AddRange(Grid.GetLiveNeighboursOfLivingCell(cell));
            }

            var cellsThatShouldLive = _liveEvolutionRules.GetDeadCellsThatShouldLive(allDeadNeighboursOfLiveCells);
            var cellsThatShouldDie = _deadEvolutionRules.GetLiveCellsThatShouldDie(allLiveNeighboursOfLiveCell);

            var newLivingCells = LivingCells.Where(cell => !cellsThatShouldDie.Any(x => cell.Row == x.Row && cell.Column == x.Column)).Concat(cellsThatShouldLive).ToList();
            UpdateGrid(newLivingCells);
        }

        private void UpdateGrid(List<Cell> newLivingCells)
        {
            Grid.Clear();
            newLivingCells.ForEach(cell => { Grid.AddCell(cell); });
        }

        public void SetGridSize(int height, int width)
        {
            Grid = new Grid(height, width);
        }

        public void AddCellToGrid(Cell cell)
        {
            Grid.AddCell(cell);
        }

        public void ClearGrid()
        {
            Grid.Clear();
        }
    }
}

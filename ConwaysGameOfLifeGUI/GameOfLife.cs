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
            //flatten list
            var allDeadNeighboursOfLiveCell = new List<IEnumerable<Cell>>();
            var allLiveNeighboursOfLiveCell = new List<IEnumerable<Cell>>();

            foreach (var cell in LivingCells)
            {
                allDeadNeighboursOfLiveCell.Add(Grid.GetDeadNeighboursOfLivingCell(cell));
                allLiveNeighboursOfLiveCell.Add(Grid.GetLiveNeighboursOfLivingCell(cell));
            }

            var cellsThatShouldLive = _liveEvolutionRules.GetDeadCellsThatShouldLive(allDeadNeighboursOfLiveCell);
            var cellsThatShouldDie = _deadEvolutionRules.GetLiveCellsThatShouldDie(allLiveNeighboursOfLiveCell, LivingCells);
            var newLivingCells = cellsThatShouldLive.Except(cellsThatShouldDie).ToList();

            UpdateGrid(newLivingCells, cellsThatShouldDie);
        }

        private void UpdateGrid(List<Cell> newLivingCells, List<Cell> cellsThatShouldDie)
        {
            Grid.Clear();
            newLivingCells.ForEach(cell => { Grid.AddCell(cell); });
        }

        public void SetGridSize(int height, int width)
        {
            Grid = new Grid(height, width);
        }

        public void AddLivingCell(Cell cell)
        {
            Grid.AddCell(cell);
        }

        public void SetInitialStateOfGrid(List<Cell> initialLivingCells)
        {//upgradeGrid()
            initialLivingCells.ForEach(cell => Grid.AddCell(cell));
        }

    }
}

using System.Collections.Generic;
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
            var allDeadNeighboursOfLiveCell = new List<IEnumerable<Cell>>();
            var allLiveNeighboursOfLiveCell = new List<IEnumerable<Cell>>();

            foreach (var cell in LivingCells)
            {
                allDeadNeighboursOfLiveCell.Add(Grid.GetDeadNeighboursOfLivingCell(cell));
                allLiveNeighboursOfLiveCell.Add(Grid.GetLiveNeighboursOfLivingCell(cell));
            }

            var cellsThatShouldLive = _liveEvolutionRules.GetDeadCellsThatShouldLive(allDeadNeighboursOfLiveCell);
            var cellsThatShouldDie = _deadEvolutionRules.GetLiveCellsThatShouldDie(allLiveNeighboursOfLiveCell, LivingCells);

            UpdateGrid(cellsThatShouldLive, cellsThatShouldDie);
        }

        private void UpdateGrid(List<Cell> cellsThatShouldLive, List<Cell> cellsThatShouldDie)
        {
            cellsThatShouldLive.ForEach(cell => { Grid.AddCell(cell); });
            cellsThatShouldDie.ForEach(cell => { Grid.RemoveCell(cell); });
        }

        public Grid GetGrid()
        {
            return Grid;
        }

        public void SetGridSize(int height, int width)
        {
            Grid = new Grid(height, width);
        }

        public void SetInitialStateOfGrid(List<Cell> initialLivingCells)
        {
            initialLivingCells.ForEach(cell => Grid.AddCell(cell));
        }

    }
}

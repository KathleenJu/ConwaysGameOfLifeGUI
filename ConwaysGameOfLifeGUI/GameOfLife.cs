using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeGUI
{
    public class GameOfLife
    {
        private Grid Grid;
        private readonly DeadEvolutionRules DeadEvolutionRules;
        private readonly LiveEvolutionRules LiveEvolutionRules;
        public IEnumerable<Cell> LivingCells => Grid.GetLivingCells();

        public GameOfLife()
        {
            DeadEvolutionRules = new DeadEvolutionRules();
            LiveEvolutionRules = new LiveEvolutionRules();
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

            var cellsThatShouldLive = LiveEvolutionRules.GetDeadCellsThatShouldLive(allDeadNeighboursOfLiveCell);
            var cellsThatShouldDie = DeadEvolutionRules.GetLiveCellsThatShouldDie(allLiveNeighboursOfLiveCell, LivingCells);

            UpdateGrid(cellsThatShouldLive, cellsThatShouldDie);
        }

        private void UpdateGrid(List<Cell> cellsThatShouldLive, List<Cell> cellsThatShouldDie)
        {
            cellsThatShouldLive.ForEach(cell => { Grid.AddCell(cell); });
            cellsThatShouldDie.ForEach(cell => { Grid.RemoveCell(cell); });
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

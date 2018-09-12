using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLifeGUI.EvolutionRules
{
    public class DeadEvolutionRules
    {
        private readonly int _minimumNeighboursNeededtoLive = 2;
        private readonly int _maximumNeighboursNeededtoLive = 3;

        public List<Cell> GetLiveCellsThatShouldDie(List<Cell> allLiveNeighboursOfAliveCells)
        {
            var cellsThatShouldDie = allLiveNeighboursOfAliveCells.GroupBy(cell => new { cell.Row, cell.Column })
                .Where(cell => cell.Count() < _minimumNeighboursNeededtoLive || cell.Count() > _maximumNeighboursNeededtoLive)
                .Select(cell => new Cell(cell.Key.Row, cell.Key.Column)).ToList();

            return cellsThatShouldDie;
        }
    }
}

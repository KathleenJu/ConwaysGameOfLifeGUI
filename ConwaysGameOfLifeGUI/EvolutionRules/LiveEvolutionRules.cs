using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLifeGUI.EvolutionRules
{
    public class LiveEvolutionRules
    {
        private const int NumberOfNeighboursNeededtoLive = 3;

        public List<Cell> GetDeadCellsThatShouldLive(List<Cell> listOfAllDeadNeighboursOfLiveCells)
        {
            var cellsThatShouldLive = listOfAllDeadNeighboursOfLiveCells.GroupBy(cell => new {cell.Row, cell.Column})
                .Where(cell => cell.Count() == NumberOfNeighboursNeededtoLive)
                .Select(cell => new Cell(cell.Key.Row, cell.Key.Column)).ToList();     
            
            return cellsThatShouldLive;
        }

       
    }
}

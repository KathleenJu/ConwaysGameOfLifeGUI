﻿using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLifeGUI.EvolutionRules
{
    class LiveEvolutionRules
    {
        private const int NumberOfNeighboursNeededtoLive = 3;

        public List<Cell> GetDeadCellsThatShouldLive(List<IEnumerable<Cell>> listOfAllDeadNeighboursOfLiveCells)
        {
            var dict = new Dictionary<Cell, int>();
            foreach (var deadNeighboursOfLivingCell in listOfAllDeadNeighboursOfLiveCells)
            {
                foreach (var cell in deadNeighboursOfLivingCell)
                {
                    var key = dict.Where(cellInDict => cellInDict.Key.Row == cell.Row && cellInDict.Key.Column == cell.Column).Select(x => x.Key);
                    if (!key.Any())
                    {
                        dict.Add(cell, 1);
                    }
                    else
                    {
                        dict[key.First()]++;
                    }
                }
            }
            var cellsWithThreeNeighbours = dict.Where(cellInDict => cellInDict.Value == NumberOfNeighboursNeededtoLive).Select(cellInDict => cellInDict.Key).ToList();
            return cellsWithThreeNeighbours;
        }
    }
}

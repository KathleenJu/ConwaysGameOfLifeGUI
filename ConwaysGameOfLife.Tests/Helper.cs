using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLifeGUI;

namespace ConwaysGameOfLife.Tests
{
    public class Helper
    {
        public List<Cell> TransformGraphToCells(int[][] graph)
        {
            var cells = new List<Cell>();
            for (int rowIndex = 0; rowIndex < graph.Length; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < graph[rowIndex].Length; columnIndex++)
                {
                    if (graph[rowIndex][columnIndex] == 1)
                    {
                        cells.Add(new Cell(rowIndex, columnIndex));
                    }
                }
            }
            return cells;
        }

        public string ToAssertableString(Dictionary<Cell, int> dictionary)
        {
            var assertableString = dictionary.OrderBy(p => p.Key)
                .Select(p => p.Key + ": " + string.Join(", ", p.Value)).ToString();
            return assertableString;
        }

    }
}
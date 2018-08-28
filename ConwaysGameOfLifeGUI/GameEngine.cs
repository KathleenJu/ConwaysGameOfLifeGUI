using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeGUI
{
    class GameEngine
    {
        private readonly GameOfLife GameOfLife;
        private readonly IRenderer Renderer;

        public GameEngine(GameOfLife gameOfLife)
        {
            GameOfLife = gameOfLife;
            Renderer = renderer;
        }

        public void StartGame()
        {
        }
    }
}

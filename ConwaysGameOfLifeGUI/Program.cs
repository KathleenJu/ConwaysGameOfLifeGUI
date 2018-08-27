using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwaysGameOfLifeGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUIRenderer());
            //var gameOfLife = new GameOfLife();
            //var renderer = new GUIRenderer();
            //var gameEngine = new GameEngine(gameOfLife, renderer);
            //gameEngine.StartGame();
        }
    }
}

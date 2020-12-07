using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Log.Info("Logger started!");
            Game game = new Game();
            game.Run();
        }
          
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TD_0_WhiteService;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessLaw.ChessState state = new ChessLaw.ChessState();
            state.SetupNewGame();
            ChessAIService ai = new ChessAIService();
            ai.GameStart();
            string str = ai.GetStrategy(state, true);
            ai.GetStrategy(state, true);
            ai.UpdateResult(true);
            Console.WriteLine(str);
        }
    }
}

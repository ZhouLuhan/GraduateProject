using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChessLaw;
using QLearningWhite;
using System.ServiceModel;

namespace TestAI
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessAIService chess = new ChessAIService();
            ChessState state = new ChessState();
            state.SetupNewGame();
            chess.GameStart();
            string str = chess.GetStrategy(state, true);
            Console.WriteLine(str);
        }
    }
}

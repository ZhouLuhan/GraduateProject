using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace TestAI
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress ep = new EndpointAddress("http://localhost:8010/QLearningBlack/");
            IChessAIService proxy = ChannelFactory<IChessAIService>.CreateChannel(new BasicHttpBinding(), ep);
            ChessLaw.ChessState state = new ChessLaw.ChessState();
            state.SetupNewGame();
            proxy.GameStart();
            string str = proxy.GetStrategy(state, true);
            Console.WriteLine(str);
        }
    }
}

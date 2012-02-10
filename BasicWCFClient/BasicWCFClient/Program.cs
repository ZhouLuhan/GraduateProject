using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ChessLaw;

namespace BasicWCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress ep = new EndpointAddress("http://localhost:8012/HelloWorld/");
            IChessAIService proxy = ChannelFactory<IChessAIService>.CreateChannel(new BasicHttpBinding(), ep);
            ChessState state = new ChessState(); state.SetupNewGame();
            proxy.GameStart();
            Console.WriteLine(proxy.GetStrategy(state, true));
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using TD_0_WhiteService;

namespace BasicWCFTrial
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ChessAIService));
            host.AddServiceEndpoint(typeof(IChessAIService), new BasicHttpBinding(), "http://localhost:8012/HelloWorld/");
            host.Open();
            Console.WriteLine("Service Start");
            Console.ReadLine();
        }
    }
}

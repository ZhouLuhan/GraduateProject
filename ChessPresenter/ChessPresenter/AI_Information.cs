using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ChessPresenter
{
    public enum AIType { White, Black, Either };

    public class AI_Information
    {
        public static string AITypeStr = "WBE";
        public string ServerName { get; set; }
        public string URL { get; set; }
        public AIType Type { get; set; }
        public IChessAIService proxy;

        public Boolean GetLinked()
        {
            EndpointAddress ep = new EndpointAddress(URL);
            proxy = ChannelFactory<IChessAIService>.CreateChannel(new BasicHttpBinding(), ep);
            return true;
        }
    }
}

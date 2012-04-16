using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;

namespace QLearningWhite
{
    public partial class WindowsService : ServiceBase
    {
        private ServiceHost host;

        public WindowsService()
        {
            InitializeComponent();
            this.ServiceName = "QLearningWhite";
        }

        protected override void OnStart(string[] args)
        {
            host = new ServiceHost(typeof(ChessAIService));
            host.AddServiceEndpoint(typeof(IChessAIService), new BasicHttpBinding(), "http://localhost:8010/QLearningWhite/");
            host.Open();
        }

        protected override void OnStop()
        {
            if (host != null) host.Close();
            host = null;
        }
    }
}

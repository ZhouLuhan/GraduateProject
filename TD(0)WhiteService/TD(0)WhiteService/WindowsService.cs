using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;

namespace TD_0_WhiteService
{
    public partial class WindowsService : ServiceBase
    {
        ServiceHost host;

        public WindowsService()
        {
            InitializeComponent();
            this.ServiceName = "ChessAI_TD(0)_V1.0";
        }

        protected override void OnStart(string[] args)
        {
            host = new ServiceHost(typeof(ChessAIService));
            host.AddServiceEndpoint(typeof(IChessAIService), new BasicHttpBinding(), "http://localhost:8010/ChessAITD0V1_0/");
            host.Open();
        }

        protected override void OnStop()
        {
            if (host != null) host.Close();
            host = null;
        }
    }
}

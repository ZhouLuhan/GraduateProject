using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;


namespace QLaerningBlackService
{
    [RunInstaller(true)]
    public partial class WindowsServiceInstaller : System.Configuration.Install.Installer
    {
        public WindowsServiceInstaller()
        {
            InitializeComponent();

            ServiceProcessInstaller process = new ServiceProcessInstaller();
            ServiceInstaller service = new ServiceInstaller();

            process.Account = ServiceAccount.User;
            service.ServiceName = "QLearningBlack";
            service.Description = "The Second Chess AI for Black, using Q-Learning Algorithm";
            service.DisplayName = "QLearningBlack";
            service.StartType = ServiceStartMode.Automatic;

            Installers.Add(process);
            Installers.Add(service);
        }
    }
}

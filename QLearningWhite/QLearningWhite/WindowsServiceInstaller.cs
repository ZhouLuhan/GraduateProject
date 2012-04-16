using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;

namespace QLearningWhite
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
            service.ServiceName = "QLearningWhite";
            service.Description = "The Second Chess AI for White, using Q-Learning Algorithm";
            service.DisplayName = "QLearningWhite";
            service.StartType = ServiceStartMode.Automatic;

            Installers.Add(process);
            Installers.Add(service);
        }
    }
}

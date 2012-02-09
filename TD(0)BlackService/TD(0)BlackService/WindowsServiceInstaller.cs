using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using System.ComponentModel;
using System.ServiceProcess;

namespace TD_0_BlackService
{
    [RunInstaller(true)]
    public class WindowsServiceInstaller : Installer
    {
        public WindowsServiceInstaller()
        {
            ServiceProcessInstaller process = new ServiceProcessInstaller();
            ServiceInstaller service = new ServiceInstaller();

            process.Account = ServiceAccount.User;
            service.ServiceName = "Black_TD0_V1_0";
            service.Description = "The First Chess AI using TD(0) Algorithm, this is the black part AI";
            service.DisplayName = "Black_TD0_V1_0";
            service.StartType = ServiceStartMode.Automatic;

            Installers.Add(process);
            Installers.Add(service);
        }
    }
}

using GlobalTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTour.ViewModels
{
    public class StartUpVM
    {
        public string ConnectionString { get; set; }
        public string VaultURL { get; set; }

        public string DeveloperName { get; set; }
        public string WHName { get; set; }

        public PositionOptions PositionOptions { get; set; }
    }
}

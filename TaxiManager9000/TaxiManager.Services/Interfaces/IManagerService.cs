using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManager.Services
{
    public interface IManagerService
    {
        void ShowDrivers();
        void ShowDriversLicenseStatus();
        void DriverManager();
        void AssignDriver();
        void UnassignDriver();

    }
}

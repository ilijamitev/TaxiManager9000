using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManager.Models;

namespace TaxiManager.Services.Menus
{
    public interface IMenus
    {
        void StartApp();
        void StartMenu();
        void LoginMenu();
        void AdminMenu(User user);
        void ManagerMenu(User user);
        void MaintenanceMenu(User user);
        void EndApp();
    }
}

using TaxiManager.Models;

namespace TaxiManager.Services.Menus
{
    public class MenuService : IMenus
    {
        public void StartApp()
        {
            StartMenu();
        }

        public void StartMenu()
        {
            TaxiDatabase taxiDatabase = new TaxiDatabase();  //initializing the database
            while (true)
            {
                HelpersService.ShowTitle("\n    Welcome to Taxi Manager 9000");
                HelpersService.ShowApplicationMessages("1.Login\n2.Exit");
                string inputChoice = ValidationService.ValidUserChoice(new string[] { "1", "2" });
                if (inputChoice == "1") LoginMenu();
                else if (inputChoice == "2") EndApp();
            }
        }

        public void LoginMenu()
        {
            User loggedInUser = LoginUser.EnterCredentials();
            Console.WriteLine("LogedUser ID " + loggedInUser.Id);
            HelpersService.ShowGreenText($"\n\n             Welcome {loggedInUser.Role} {loggedInUser.Username}");

            switch (loggedInUser.Role)
            {
                case Role.Administrator:
                    AdminMenu(loggedInUser);
                    break;
                case Role.Manager:
                    ManagerMenu(loggedInUser);
                    break;
                case Role.Maintenance:
                    MaintenanceMenu(loggedInUser);
                    break;
            }
        }

        public void AdminMenu(User user)
        {
            AdminService adminService = new AdminService();
            while (true)
            {
                HelpersService.ShowTitle("\n  ***ADMIN MENU***");
                HelpersService.ShowApplicationMessages("1.Create New User\n2.Terminate User\n3.Change Password\n4.Logout\n5.Exit app");
                string userChoice = ValidationService.ValidUserChoice(new string[] { "1", "2", "3", "4", "5" });
                if (userChoice == "1") adminService.CreateNewUser();
                if (userChoice == "2") adminService.TerminateUser(user);
                if (userChoice == "3") user.ChangePassword();
                if (userChoice == "4") break;
                if (userChoice == "5") EndApp();
            }
        }

        public void MaintenanceMenu(User user)
        {
            MaintenanceService maintenance = new MaintenanceService();
            while (true)
            {
                HelpersService.ShowTitle("\n  ***MAINTENANCE MENU***");
                HelpersService.ShowApplicationMessages("1.List all Vehicles\n2.License Plate Status\n3.Change Password\n4.Logout\n5.Exit app");
                string userChoice = ValidationService.ValidUserChoice(new string[] { "1", "2", "3", "4", "5" });
                if (userChoice == "1") maintenance.ShowVehiclesInfo();
                if (userChoice == "2") maintenance.ShowLicensePlateStatus();
                if (userChoice == "3") user.ChangePassword();
                if (userChoice == "4") break;
                if (userChoice == "5") EndApp();
            }
        }

        public void ManagerMenu(User user)
        {
            ManagerService manager = new ManagerService();
            while (true)
            {
                HelpersService.ShowTitle("\n  ***MANAGER MENU***");
                HelpersService.ShowApplicationMessages("1.List all Drivers\n2.Drivers License Status\n3.Driver Manager Menu\n4.Change Password\n5.Logout\n6.Exit app");
                string userChoice = ValidationService.ValidUserChoice(new string[] { "1", "2", "3", "4", "5", "6" });
                if (userChoice == "1") manager.ShowDrivers();
                if (userChoice == "2") manager.ShowDriversLicenseStatus();
                if (userChoice == "3") manager.DriverManager();
                if (userChoice == "4") user.ChangePassword();
                if (userChoice == "5") break;
                if (userChoice == "6") EndApp();
            }
        }

        public void EndApp()
        {
            Console.Clear();
            HelpersService.ShowApplicationMessages("\n\n\n\n\n\n                    *** THANK YOU FOR USING OUR APP ***");
            Console.ReadLine();
            Environment.Exit(0);
        }

    }
}

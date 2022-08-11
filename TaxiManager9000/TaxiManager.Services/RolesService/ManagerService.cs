using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManager.Models;

namespace TaxiManager.Services
{
    public class ManagerService : IManagerService
    {
        public void ShowDrivers()
        {
            HelpersService.ShowApplicationMessages("==> LIST OF DRIVERS");
            foreach (Driver driver in TaxiDatabase.DriversList)
            {
                if (driver.AssignedCar != null)
                {
                    HelpersService.ShowData($"ID: {driver.Id}. {driver.GetFullName()} is driving in the {driver.Shift} shift with a {driver.AssignedCar.Model} car ({driver.AssignedCar.LicensePlate}).");
                }
                else
                {
                    HelpersService.ShowData($"ID: {driver.Id}. {driver.GetFullName()} hasn't been assigned to a car yet.");
                }
            }
            Console.ReadLine();
        }

        public void ShowDriversLicenseStatus()
        {
            HelpersService.ShowApplicationMessages("\n==>DRIVERS LICENSE STATUS");
            Console.WriteLine("Current date: " + HelpersService.CurrentDate);
            foreach (Driver driver in TaxiDatabase.DriversList)
            {
                string driverInfo = $"ID: {driver.Id}. Driver {driver.GetFullName()} with License {driver.License} expiering on {driver.LicenseExpiryDate}.";
                if (driver.LicenseExpiryDate < HelpersService.CurrentDate)
                {
                    HelpersService.ShowRedText(driverInfo);
                }
                else if (HelpersService.CurrentDate.AddMonths(+3) > driver.LicenseExpiryDate)
                {
                    HelpersService.ShowYellowText(driverInfo);
                }
                else
                {
                    HelpersService.ShowGreenText(driverInfo);
                }
            }
            Console.ReadLine();
        }

        public void DriverManager()
        {
            while (true)
            {
                HelpersService.ShowTitle("\n==> DRIVER MANAGER");
                HelpersService.ShowApplicationMessages("1.Assign driver\n2.Unassign driver\n3.Back to Manager Menu");
                string userChoice = ValidationService.ValidUserChoice(new string[] { "1", "2", "3" });
                if (userChoice == "1") AssignDriver();
                if (userChoice == "2") UnassignDriver();
                if (userChoice == "3") break;
            }
        }

        public void AssignDriver()
        {
            List<Driver> unAssignedDrivers = DatabaseHelpers.UnassignedDrivers();
            while (true)
            {
                HelpersService.ShowTitle("\n==> Assign Driver");
                if (unAssignedDrivers.Count == 0)
                {
                    HelpersService.ShowRedText("SORRY! NO DRIVER AVAILABLE!");
                    break;
                }
                HelpersService.ShowApplicationMessages("List of unassigned drivers:");
                DatabaseHelpers.ShowDrivers(unAssignedDrivers);
                int driverId = ValidationService.GetValidId(unAssignedDrivers);
                Driver selectedDriver = TaxiDatabase.DriversList.FirstOrDefault(x => x.Id == driverId);
                Shift shiftChoice = GetAShift();
                List<Car> availableCars = DatabaseHelpers.GetAvailableCars(shiftChoice);
                if (availableCars.Count == 0)
                {
                    HelpersService.ShowRedText($"SORRY! NO CARS AVAILABLE FOR THE {shiftChoice} SHIFT!");
                    break;
                }
                DatabaseHelpers.ShowAvailableCars(availableCars);
                int carId = ValidationService.GetValidId(availableCars);
                Car selectedCar = TaxiDatabase.CarsList.FirstOrDefault(x => x.Id == carId);
                selectedCar.AsignedDrivers.Add(selectedDriver);
                availableCars.Remove(selectedCar);
                unAssignedDrivers.Remove(selectedDriver);
                selectedDriver.Shift = shiftChoice;
                selectedDriver.AssignedCar = selectedCar;
                HelpersService.ShowGreenText($"Successfully assigned driver {selectedDriver.GetFullName()} to the car {selectedDriver.AssignedCar.Model} ({selectedDriver.AssignedCar.LicensePlate}) with a {selectedDriver.Shift} shift.");
                Console.ReadLine();
                break;
            }
        }

        private Shift GetAShift()
        {
            while (true)
            {
                HelpersService.ShowApplicationMessages("Pick a shift:\n1.Morning\n2.Afternoon\n3.Evening");
                string inputChoice = ValidationService.ValidUserChoice(new string[] { "1", "2", "3" });
                if (inputChoice == "1") return Shift.Morning;
                if (inputChoice == "2") return Shift.Afternoon;
                if (inputChoice == "3") return Shift.Evening;
            }
        }

        public void UnassignDriver()
        {
            List<Driver> assignedDrivers = DatabaseHelpers.AssignedDrivers();
            while (true)
            {
                HelpersService.ShowTitle("\n==> Unassign Driver");
                if (assignedDrivers.Count == 0)
                {
                    HelpersService.ShowRedText("SORRY! NO DRIVER AVAILABLE!");
                    break;
                }
                HelpersService.ShowApplicationMessages("List of assigned drivers:");
                DatabaseHelpers.ShowDrivers(assignedDrivers);
                int driverId = ValidationService.GetValidId(assignedDrivers);
                Driver selectedDriver = TaxiDatabase.DriversList.FirstOrDefault(x => x.Id == driverId);
                selectedDriver.AssignedCar = null;
                selectedDriver.Shift = 0;
                break;
            }

        }

    }
}

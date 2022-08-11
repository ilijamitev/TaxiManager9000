using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManager.Models;

namespace TaxiManager.Services
{
    public static class DatabaseHelpers
    {
        // USERS
        public static void ShowUsersList()
        {
            foreach (User user in TaxiDatabase.UsersList)
            {
                HelpersService.ShowData($"ID: {user.Id}. Username: {user.Username}. Role: {user.Role}");
            }
        }

        // DRIVERS
        public static void ShowDrivers(List<Driver> driverList)
        {
            foreach (Driver driver in driverList)
            {
                HelpersService.ShowData($"ID: {driver.Id}. Driver {driver.GetFullName()} with License {driver.License} expiering on {driver.LicenseExpiryDate}.");
            }
        }

        public static List<Driver> AssignedDrivers()
        {
            return TaxiDatabase.DriversList.Where(driver => driver.AssignedCar != null && driver.LicenseExpiryDate > DateTime.Today).ToList();
        }

        public static List<Driver> UnassignedDrivers()
        {
            return TaxiDatabase.DriversList.Where(driver => driver.AssignedCar == null && driver.LicenseExpiryDate > DateTime.Today).ToList();
        }

        // CARS
        public static void ShowAvailableCars(List<Car> carList)
        {
            foreach (Car car in carList)
            {
                HelpersService.ShowData($"ID: {car.Id}. Model: {car.Model}. License Plate: {car.LicensePlate}. Expiery date: {car.LicensePlateExpieryDate}");
            }
        }

        public static List<Car> GetAvailableCars(Shift shift)
        {
            return TaxiDatabase.CarsList.Where(car => (car.AsignedDrivers.Count == 0 && car.LicensePlateExpieryDate > DateTime.Today) || (car.AsignedDrivers.Count != 0 && car.AsignedDrivers.All(x => x.Shift != shift) && car.LicensePlateExpieryDate > DateTime.Today)).ToList();
        }

    }
}

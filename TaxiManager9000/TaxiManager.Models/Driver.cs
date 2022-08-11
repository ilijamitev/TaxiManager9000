using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManager.Models
{
    public class Driver : IModelsID
    {
        public int Id { get; set; }
        public static int IdCounter = 1;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Car AssignedCar { get; set; }
        public Shift Shift { get; set; }
        public string License { get; set; }
        public DateTime LicenseExpiryDate { get; set; }
        public Driver()
        {
            Id = IdCounter++;

        }
        public Driver(string firstName, string lastName, string license, DateTime expiryDate)
        {
            Id = IdCounter++;
            FirstName = firstName;
            LastName = lastName;
            License = license;
            LicenseExpiryDate = expiryDate;
        }
        public Driver(string firstName, string lastName, string license, DateTime expiryDate, Car assignedCar, Shift shift)
        {
            Id = IdCounter++;
            FirstName = firstName;
            LastName = lastName;
            AssignedCar = assignedCar;
            Shift = shift;
            License = license;
            LicenseExpiryDate = expiryDate;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

    }
}

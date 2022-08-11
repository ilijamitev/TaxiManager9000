using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManager.Models
{
    public class Car : IModelsID
    {
        public int Id { get; set; }
        public static int IdCounter = 1;
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public DateTime LicensePlateExpieryDate { get; set; }
        public List<Driver> AsignedDrivers { get; set; } = new List<Driver>();
        public Car()
        {
            Id = IdCounter++;
        }
        public Car(string model, string licensePlate, DateTime licenseExpieryDate)
        {
            Id = IdCounter++;
            Model = model;
            LicensePlate = licensePlate;
            LicensePlateExpieryDate = licenseExpieryDate;
        }
        public Car(string model, string licensePlate, DateTime licenseExpieryDate, List<Driver> drivers)
        {
            Id = IdCounter++;
            Model = model;
            LicensePlate = licensePlate;
            LicensePlateExpieryDate = licenseExpieryDate;
            AsignedDrivers = drivers;
        }

    }
}

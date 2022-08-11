using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManager.Models;

namespace TaxiManager.Services
{
    public class MaintenanceService : IMaintenanceService
    {
        public void ShowVehiclesInfo()
        {
            HelpersService.ShowApplicationMessages("\n==>LIST OF VEHICLES");
            foreach (Car car in TaxiDatabase.CarsList)
            {
                HelpersService.ShowData($"{car.Id}. Model: {car.Model}. License Plate: {car.LicensePlate} ");
                if (car.AsignedDrivers.Count == 0)
                {
                    HelpersService.ShowRedText($"This car doesn't have assigned drivers yet.");
                }
                else
                {
                    ShiftsCovered shiftsCovered = GetShifts(car);
                    HelpersService.ShowGreenText($"{shiftsCovered.Morning}\n{shiftsCovered.Afternoon}\n{shiftsCovered.Evening}");
                }
            }
            Console.ReadLine();
        }

        public void ShowLicensePlateStatus()
        {
            HelpersService.ShowApplicationMessages("\n==>LICENSE PLATE STATUS");
            Console.WriteLine("Current date: " + HelpersService.CurrentDate);
            foreach (Car car in TaxiDatabase.CarsList)
            {
                string carInfo = $"ID: {car.Id}. Model: {car.Model}. License Plate: {car.LicensePlate}. Expiery date: {car.LicensePlateExpieryDate}";
                if (car.LicensePlateExpieryDate < HelpersService.CurrentDate)
                {
                    HelpersService.ShowRedText(carInfo);
                }
                else if (HelpersService.CurrentDate.AddMonths(+3) > car.LicensePlateExpieryDate)
                {
                    HelpersService.ShowYellowText(carInfo);
                }
                else
                {
                    HelpersService.ShowGreenText(carInfo);
                }
            }
            Console.ReadLine();
        }

        private ShiftsCovered GetShifts(Car car)
        {
            double morningShift = 0;
            double afternoonShift = 0;
            double eveningShift = 0;
            foreach (Driver driver in car.AsignedDrivers)
            {
                if (driver.Shift.ToString() == "Morning") morningShift++;
                else if (driver.Shift.ToString() == "Afternoon") afternoonShift++;
                else if (driver.Shift.ToString() == "Evening") eveningShift++;
                else continue;
            }
            double sum = morningShift + afternoonShift + eveningShift;
            ShiftsCovered shiftPercentage = new ShiftsCovered();
            shiftPercentage.Morning = $"Morning shifts: {morningShift / sum * 100} %.";
            shiftPercentage.Afternoon = $"Afternoon shifts: {afternoonShift / sum * 100} %.";
            shiftPercentage.Evening = $"Evening shifts: {eveningShift / sum * 100} %.";

            return shiftPercentage;
        }


    }

    // not sure if this is the right way to implement class... but gets the job done in returning "multiple" results from method :D
    public class ShiftsCovered
    {
        public string Morning { get; set; }
        public string Afternoon { get; set; }
        public string Evening { get; set; }
        public ShiftsCovered()
        {

        }
    }
}

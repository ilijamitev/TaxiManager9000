using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManager.Models
{
    public class TaxiDatabase
    {
        public static List<User> UsersList = new List<User>()
        {
            new User("Admin","admin",Role.Administrator),
            new User("Manager1","manager1",Role.Manager),
            new User("Manager2","manager2",Role.Manager),
            new User("Service1","service1",Role.Maintenance),
            new User("Service2","service2",Role.Maintenance),
        };

        public static List<Car> CarsList { get; set; } = new List<Car>();
        public static List<Driver> DriversList { get; set; } = new List<Driver>();

        public TaxiDatabase()
        {
            // CARS
            Car toyota1 = new Car("Toyota", "SK1111AB", new DateTime(2022, 7, 14));
            Car mercedes1 = new Car("Mercedes", "SK2222AB", new DateTime(2022, 1, 15));
            Car kia1 = new Car("Kia1", "SK3333AB", new DateTime(2022, 8, 20));
            Car kia2 = new Car("Kia2", "SK4444AB", new DateTime(2022, 7, 15));
            Car ford1 = new Car("Ford", "SK5555AB", new DateTime(2023, 1, 15));

            //DRIVERS
            Driver ilija = new Driver("Ilija", "Mitev", "1111", new DateTime(2025, 5, 15));
            Driver pink = new Driver("Pink", "Panther", "2222", new DateTime(2022, 5, 15));
            Driver mickey = new Driver("Mickey", "Mouse", "3333", new DateTime(2025, 5, 15));
            Driver minie = new Driver("Minie", "Mouse", "4444", new DateTime(2021, 5, 15));
            Driver robin = new Driver("Robin", "Hood", "5555", new DateTime(2022, 7, 15));
            Driver captain = new Driver("Captain", "America", "7777", new DateTime(2022, 5, 15));
            Driver bob = new Driver("Bob", "Bobsky", "8888", new DateTime(2025, 5, 15));
            Driver rob = new Driver("Rob", "Robsky", "9999", new DateTime(2022, 1, 12));
            Driver jon = new Driver("Jon", "Jonsky", "1234", new DateTime(2022, 8, 12));
            Driver don = new Driver("Don", "Donsky", "5678", new DateTime(2022, 12, 12));

            // adding Cars to list
            CarsList.Add(toyota1);
            CarsList.Add(mercedes1);
            CarsList.Add(kia1);
            CarsList.Add(kia2);
            CarsList.Add(ford1);

            // adding Drivers to list
            DriversList.Add(ilija);
            DriversList.Add(pink);
            DriversList.Add(mickey);
            DriversList.Add(minie);
            DriversList.Add(captain);
            DriversList.Add(bob);
            DriversList.Add(robin);
            DriversList.Add(rob);
            DriversList.Add(jon);
            DriversList.Add(don);

        }




    }
}

// See https://aka.ms/new-console-template for more information
using TaxiManager.Services.Menus;

Console.Title = "        ***Taxi Manager 9000***";

MenuService startApp = new MenuService();
startApp.StartApp();

Console.ReadLine();
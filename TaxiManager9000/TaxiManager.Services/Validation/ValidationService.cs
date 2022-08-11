using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManager.Models;

namespace TaxiManager.Services
{
    public static class ValidationService
    {
        public static string ValidUserChoice(string[] validChoices)
        {
            while (true)
            {
                string inputChoice = Console.ReadLine();
                if (validChoices.Contains(inputChoice))
                {
                    return inputChoice;
                }
                else
                {
                    HelpersService.ShowRedText("SELECT VALID OPTION");
                    continue;
                }
            }
        }

        public static User ValidateUsername(string userName)
        {
            return TaxiDatabase.UsersList.FirstOrDefault(x => x.Username == userName);
        }

        public static User ValidateId(int id)
        {
            return TaxiDatabase.UsersList.FirstOrDefault(x => x.Id == id);
        }

        public static bool ValidateId<T>(int id, List<T> modelsList) where T : IModelsID
        {
            return modelsList.Any(x => x.Id == id);
        }

        public static int GetValidId<T>(List<T> modelsList) where T : IModelsID
        {
            while (true)
            {
                try
                {
                    string idInput = Console.ReadLine();
                    bool isValid = int.TryParse(idInput, out int id);
                    if (string.IsNullOrWhiteSpace(idInput))
                    {
                        HelpersService.ThrowException("ENTER VALUE!");
                    }
                    else if (!isValid)
                    {
                        HelpersService.ThrowException("ENTER VALID ID!");
                    }
                    else if (!ValidateId(id, modelsList))
                    {
                        HelpersService.ThrowException("ENTER ID FROM THE LIST!");
                    }
                    return id;
                }
                catch (Exception ex)
                {
                    HelpersService.ShowRedText(ex.Message);
                }
            }
        }


    }
}

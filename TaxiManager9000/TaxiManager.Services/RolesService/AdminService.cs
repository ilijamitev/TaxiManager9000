using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManager.Models;

namespace TaxiManager.Services
{
    public class AdminService : IAdminService
    {
        public void CreateNewUser()
        {
            HelpersService.ShowTitle("\n==>Create New User");
            bool isTrue = true;
            while (isTrue)
            {
                string username = LoginUser.CreateNewUsername();
                string password = LoginUser.CreateNewPassword();
                HelpersService.ShowApplicationMessages("Please select a role: \n1.Administrator\n2.Manager\n3.Maintenance");
                string selectedRole = ValidationService.ValidUserChoice(new string[] { "1", "2", "3" });
                Role role = selectedRole == "1" ? Role.Administrator : selectedRole == "2" ? Role.Manager : Role.Maintenance;
                User newUser = new User(username, password, role);
                TaxiDatabase.UsersList.Add(newUser);
                HelpersService.ShowGreenText($"Successfully created new user {newUser.Username} with a role {newUser.Role} and an Id {newUser.Id}.");
                HelpersService.ShowApplicationMessages("\n1.Add another user\n2.Back to admin menu");
                string userChoice = ValidationService.ValidUserChoice(new string[] { "1", "2" });
                isTrue = userChoice == "1" ? true : false;
            }
        }

        public void TerminateUser(User user)
        {
            HelpersService.ShowTitle("\n==>Delete user");
            bool isTrue = true;
            while (isTrue)
            {
                DatabaseHelpers.ShowUsersList();
                HelpersService.ShowApplicationMessages("Enter the id of the user you wish to delete:\n*0 to cancel");
                string inputChoice = Console.ReadLine();
                if (inputChoice == "0") break;
                bool isValidInput = int.TryParse(inputChoice, out int idValue);
                if (!isValidInput)
                {
                    HelpersService.ShowRedText("ENTER VALID VALUE!");
                    continue;
                }
                User deleteUser = ValidationService.ValidateId(idValue);
                if (deleteUser == null)
                {
                    HelpersService.ShowRedText("NO USER WITH THAT ID!");
                    continue;
                }
                if (user.Id == idValue)
                {
                    HelpersService.ShowRedText("YOU CANNOT DELETE YOURSELF!");
                    continue;
                }
                HelpersService.ShowGreenText($"Successfully deleted {deleteUser.Role} user {deleteUser.Username} with id {deleteUser.Id}");
                TaxiDatabase.UsersList.Remove(deleteUser);
                HelpersService.ShowApplicationMessages("\n1.Remove another user\n2.Back to admin menu");
                string userChoice = ValidationService.ValidUserChoice(new string[] { "1", "2" });
                isTrue = userChoice == "1" ? true : false;
            }

        }
    }
}

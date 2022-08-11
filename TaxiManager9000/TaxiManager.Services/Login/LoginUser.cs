using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManager.Models;

namespace TaxiManager.Services
{
    public static class LoginUser
    {
        public static string CreateNewUsername()
        {
            while (true)
            {
                HelpersService.ShowApplicationMessages("Enter username:");
                string username = Console.ReadLine();
                if (ValidationService.ValidateUsername(username) != null)
                {
                    HelpersService.ShowRedText("THAT USERNAME ALREADY EXISTS!");
                    continue;
                }
                else if (string.IsNullOrWhiteSpace(username))
                {
                    HelpersService.ShowRedText("ENTER VALUE!");
                    continue;
                }
                else if (username.Length < 5)
                {
                    HelpersService.ShowRedText("MUST CONTAIN AT LEAST 5 CHARACTERS!");
                    continue;
                }
                return username;
            }
        }

        public static void ChangePassword(this User user)
        {
            HelpersService.ShowTitle("\n==>Change password");
            while (true)
            {
                HelpersService.ShowApplicationMessages("Enter old password:");
                string oldPassword = Console.ReadLine();
                if (oldPassword != user.Password)
                {
                    HelpersService.ShowRedText("INVALID PASSWORD!");
                    continue;
                }
                string newPassword = CreateNewPassword();
                if (oldPassword == newPassword)
                {
                    HelpersService.ShowRedText("TRY CHANGING THE OLD ONE!");
                    continue;
                }
                user.Password = newPassword;
                HelpersService.ShowGreenText("Successfully changed password.");
                Console.ReadLine();
                break;
            }
        }

        public static string CreateNewPassword()
        {
            string inputPassword = string.Empty;
            while (true)
            {
                HelpersService.ShowApplicationMessages("Enter new password:");
                inputPassword = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputPassword))
                {
                    HelpersService.ShowRedText("ENTER VALUE!");
                    continue;
                }
                else if (inputPassword.Length < 5)
                {
                    HelpersService.ShowRedText("TOO SHORT! MUST CONTAIN AT LEAST 5 CHARACTERS!");
                    continue;
                }
                else if (!inputPassword.Any(char.IsDigit))
                {
                    HelpersService.ShowRedText("THE PASSWORD MUST CONTAIN A NUMBER!");
                    continue;
                }
                else
                {
                    return inputPassword;
                }
            }
        }
        public static User EnterCredentials()
        {
            while (true)
            {
                try
                {
                    HelpersService.ShowApplicationMessages("Enter username: ");
                    string inputUsername = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(inputUsername))
                    {
                        HelpersService.ThrowException("ENTER A VALUE!");
                    }
                    User user = ValidationService.ValidateUsername(inputUsername);
                    if (user == null)
                    {
                        HelpersService.ThrowException("NO USER WITH THAT USERNAME FOUND!");
                    }
                    else
                    {
                        EnterPassword(user);
                        return user;
                    }
                }
                catch (Exception ex)
                {
                    HelpersService.ShowRedText(ex.Message);
                }
            }
        }

        public static void EnterPassword(User user)
        {
            while (true)
            {
                try
                {
                    HelpersService.ShowApplicationMessages("Enter password: ");
                    string inputPassword = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(inputPassword))
                    {
                        HelpersService.ThrowException("ENTER A VALUE!");
                    }
                    else if (user.Password != inputPassword)
                    {
                        HelpersService.ThrowException("INVALID PASSWORD!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    HelpersService.ShowRedText(ex.Message);
                }
            }
        }

    }
}

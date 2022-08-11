using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManager.Models;

namespace TaxiManager.Services
{
    public interface IAdminService
    {
        void CreateNewUser();
        void TerminateUser(User user);

    }
}

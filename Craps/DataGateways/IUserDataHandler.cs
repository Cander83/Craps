using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.DataGateways
{
    public interface IUserDataHandler
    {
        string GetUser(string inputUserName);

        string CreateUser(string inputUserName);
        void DeleteUser(string inputUserName);

        string UpdateUser(string inputUserName);
    }
}

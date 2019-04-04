using Craps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Craps.EntityControllers
{
    public interface IUserDataGateway
    {
        UserModel CreateUser(UserModel inputUserModel);
        UserModel GetUser(string userName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Craps.Models;

namespace Craps.EntityControllers
{
    public class UserEntityController
    {
        public UserEntityController()
        {
            
        }

        private UserModel CreateNewUser(string userName)
        {
            UserModel output = new UserModel(){Name = userName} ;

            return new UserModel();
        }
    }
}

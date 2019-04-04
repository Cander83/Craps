using Craps.DataGateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Craps.EntityFrameworkDataHandlers
{
    public class UserEfDataHandler : IUserDataHandler
    {
        public string CreateUser(string userName)
        {
            using (var dataContext = new Craps.CrapsEntities())
            {
                User user = new User();

                user.name = userName;

                dataContext.Users.Add(user);

                dataContext.SaveChanges();

                string output = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                
                return output;
            }

        }

        public string UpdateUser(string inputUserString)
        {
            User inputUser = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(inputUserString);

            using (var dataContext = new Craps.CrapsEntities())
            {
                User user = (from usr in dataContext.Users
                             where usr.id == inputUser.id
                             select usr).Single();

                user.name = inputUser.name;
                
                dataContext.SaveChanges();

                string output = Newtonsoft.Json.JsonConvert.SerializeObject(user);

                return output;
            }

        }

        public string GetUser(string userName)
        {
            using (var dataContext = new Craps.CrapsEntities())
            {
                User user = (from usr in dataContext.Users
                             where usr.name == userName
                             select usr).Single();

                string output = Newtonsoft.Json.JsonConvert.SerializeObject(user);

                return output;
            }

        }

        public void DeleteUser(string userName)
        {
            using (var dataContext = new Craps.CrapsEntities())
            {
                User user = (from usr in dataContext.Users
                             where usr.name == userName
                             select usr).Single();

                dataContext.Users.Remove(user);

                dataContext.SaveChanges();
                     

            }

        }

    }
}
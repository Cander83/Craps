using Craps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Craps.DataGateways
{
    public class UserDataGateway
    {

        private IUserDataHandler DataHandler { get; set; }

        public UserDataGateway(IUserDataHandler dataHandler)
        {
            DataHandler = dataHandler;
        }

        public UserModel createUser(string userName)
        {
            string result = DataHandler.CreateUser(userName);

            UserModel output = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(result);
            
            return output;
        }
        public void DeleteUser(string userName)
        {
            DataHandler.DeleteUser(userName);
        }

        public UserModel updateUser(string userName)
        {
            string result = DataHandler.UpdateUser(userName);

            UserModel output = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(result);


            return output;
        }

        public UserModel GetUser(string userName)
        {
           string result = DataHandler.GetUser(userName);

            UserModel output = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(result);

            return output;
        }
    }
}
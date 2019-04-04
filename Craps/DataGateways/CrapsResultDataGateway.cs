using Craps.EntityControllers.CrapsObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Craps.DataGateways
{
    public class CrapsResultDataGateway
    {
        ICrapsResultDataHandler DataHandler; 

        public CrapsResultDataGateway(ICrapsResultDataHandler inputDataHandler)
        {
            DataHandler = inputDataHandler;
        }

        public int CreateCrapsResult(Craps.EntityControllers.CrapsObjects.CrapsResultModel inputResult)
        {
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(inputResult);

            int result = DataHandler.CreateCrapsResult(jsonString);

            return result;
        }

        public void UpdateCrapsResult(Craps.EntityControllers.CrapsObjects.CrapsResultModel inputResult)
        {
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(inputResult);

            DataHandler.UpdateCrapsResult(jsonString);
        }

        public List<CrapsResultModel> GetAllCrapsResults(string userId)
        {
            string result = DataHandler.GetAllCrapsResults(userId);

            List<CrapsResultModel> output = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CrapsResultModel>>(result);
            
            return output;
        }

        public void ClearAllCrapsResults(string userId)
        {
             DataHandler.ClearAllCrapsResults(userId);
             
           
        }

    }
}
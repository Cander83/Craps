using Craps.DataGateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Craps.EntityFrameworkDataHandlers
{
    public class GameRecordEfDataHandler : ICrapsResultDataHandler
    {
        public void ClearAllCrapsResults(string userId)
        {
            throw new NotImplementedException();
        }

        public int CreateCrapsResult(string inputJsonResult)
        {
            using (var dataContext = new Craps.CrapsEntities())
            {
                CrapsResult result = Newtonsoft.Json.JsonConvert.DeserializeObject<CrapsResult>(inputJsonResult);
                 
                dataContext.CrapsResults.Add(result);

                dataContext.SaveChanges();

                int output = result.id;

                return output;
            }
        }

        public string GetAllCrapsResults(string userId)
        {
            int userIdInteger = Int32.Parse(userId);

            using (var dataContext = new Craps.CrapsEntities())
            {

                List < CrapsResult > resultList = (from result in dataContext.CrapsResults
                                        where result.userId == userIdInteger
                                        select result).ToList();

               

                string output = Newtonsoft.Json.JsonConvert.SerializeObject(resultList);

                return output;
            }
        }

        public void UpdateCrapsResult(string inputJsonResult)
        {
            using (var dataContext = new Craps.CrapsEntities())
            {
                CrapsResult result = Newtonsoft.Json.JsonConvert.DeserializeObject<CrapsResult>(inputJsonResult);

                CrapsResult modifiedResult = (from res in dataContext.CrapsResults
                                              where res.id == result.id
                                              select res).Single();

                modifiedResult = result;

                dataContext.CrapsResults.Add(result);

                dataContext.SaveChanges();
                               
            }
        }
    }
}
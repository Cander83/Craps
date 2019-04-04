using Craps.EntityControllers.CrapsObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.DataGateways
{
    public interface ICrapsResultDataHandler
    {
        int CreateCrapsResult(string inputJsonResult);


        void UpdateCrapsResult(string inputJsonResult);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>
        /// Returns a  list of Json string of a craps result.
        /// </returns>
       string GetAllCrapsResults(string userId);


        void ClearAllCrapsResults(string userId);
        

    }
}

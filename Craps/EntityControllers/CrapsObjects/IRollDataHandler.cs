using Craps.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Craps.EntityControllers.CrapsObjects
{
    public interface IRollDataHandler
    {
         Task<RollDataModel> GetRollAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Craps.Models
{
    public class HomeModel
    {
        public string UserName { get; set; }
        public string UserId { get; set; }

        public Craps.EntityControllers.CrapsObjects.CrapsResultModel CrapsResultModel { get; set; }

    }
}

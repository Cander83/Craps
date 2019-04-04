using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Craps.EntityFrameworkDataHandlers;

namespace Craps.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class CrapsResultEfDataHandler_Test
    {
        [TestMethod]
        public void CreateCrapsResult()
        {
            //Array
            GameRecordEfDataHandler testedDataHandler = new GameRecordEfDataHandler();

            EntityControllers.CrapsObjects.CrapsResultModel inputResultModel = new EntityControllers.CrapsObjects.CrapsResultModel();

            inputResultModel.FirstRollValue = 1;
            inputResultModel.SecondRollValue = 2;
            inputResultModel.GameStatus = "loss";
            inputResultModel.UserId = 1;

            string resultJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(inputResultModel);

            //Act
            int resultId = testedDataHandler.CreateCrapsResult(resultJsonString);

            //Assert
            Assert.IsTrue(resultId != 0);

        }
    }
}

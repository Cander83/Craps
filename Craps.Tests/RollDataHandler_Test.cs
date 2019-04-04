using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Craps.ApiDataHandlers;
using Craps.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Craps_Test
{
    [TestClass]
    public class RollDataHandler_Test
    {
        [TestMethod]
        public async Task GetRollModel_GivenNothing_AssertsNotNull()
        {
            //Array

            RollDataHandler testedHandler = new RollDataHandler();

            //Act
            var result =  await testedHandler.GetRollAsync();

            //Assert
            RollDataModel expectedModel = new RollDataModel();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, expectedModel.GetType()); //RollDataModel

        }

    }
}

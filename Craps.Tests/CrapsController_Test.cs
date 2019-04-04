using Craps.ApiDataHandlers;
using Craps.EntityControllers.CrapsObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Craps_Test
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class CrapsControllerTest
    {
        [TestMethod]
        public void GetCrapsResult_Given7_expectsWin()
        {
            //Array
            CrapsController testedController = new CrapsController(new RollDataHandler());
            CrapsResultModel inputModel = new CrapsResultModel();
            inputModel.FirstRollValue = 3;
            inputModel.SecondRollValue = 4;
            string result = null;

            //Act
            result = testedController.GetCrapsResult(inputModel.RollSum, inputModel.GameStatus, inputModel.Point);

            //Assert
            Assert.AreEqual("win", result);
        }

        [TestMethod]
        public void GetCrapsResult_Given11_expectsWin()
        {
            //Array
            CrapsController testedController = new CrapsController(new RollDataHandler());
            CrapsResultModel inputModel = new CrapsResultModel();
            inputModel.FirstRollValue = 6;
            inputModel.SecondRollValue = 5;
            string result = null;

            //Act
            result = testedController.GetCrapsResult(inputModel.RollSum, inputModel.GameStatus, inputModel.Point);

            //Assert
            Assert.AreEqual("win", result);
        }

        [TestMethod]
        public void GetCrapsResult_Given12_expectsLoss()
        {
            //Array
            CrapsController testedController = new CrapsController(new RollDataHandler());
            CrapsResultModel inputModel = new CrapsResultModel();
            inputModel.FirstRollValue = 6;
            inputModel.SecondRollValue = 6;
            string result = null;

            //Act
            result = testedController.GetCrapsResult(inputModel.RollSum, inputModel.GameStatus, inputModel.Point);

            //Assert
            Assert.AreEqual("loss", result);
        }

        [TestMethod]
        public void GetCrapsResult_Given3_expectsLoss()
        {
            //Array
            CrapsController testedController = new CrapsController(new RollDataHandler());
            CrapsResultModel inputModel = new CrapsResultModel();
            inputModel.FirstRollValue = 1;
            inputModel.SecondRollValue = 2;
            string result = null;

            //Act
            result = testedController.GetCrapsResult(inputModel.RollSum, inputModel.GameStatus, inputModel.Point);

            //Assert
            Assert.AreEqual("loss", result);
        }

        [TestMethod]
        public void GetCrapsResult_Given2_expectsLoss()
        {
            //Array
            CrapsController testedController = new CrapsController(new RollDataHandler());
            CrapsResultModel inputModel = new CrapsResultModel();
            inputModel.FirstRollValue = 1;
            inputModel.SecondRollValue = 1;
            string result = null;

            //Act
            result = testedController.GetCrapsResult(inputModel.RollSum, inputModel.GameStatus, inputModel.Point);

            //Assert
            Assert.AreEqual("loss", result);
        }

        [TestMethod]
        public void GetCrapsResult_Given4_expectsPoint()
        {
            //Array
            CrapsController testedController = new CrapsController(new RollDataHandler());
            CrapsResultModel inputModel = new CrapsResultModel();
            inputModel.FirstRollValue = 2;
            inputModel.SecondRollValue = 2;
            string result = null;

            //Act
            result = testedController.GetCrapsResult(inputModel.RollSum, inputModel.GameStatus, inputModel.Point);

            //Assert
            Assert.AreEqual("point", result);
        }
    }
}

using Craps.EntityFrameworkDataHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class UserEfDataHandler_Test
    {
        [TestMethod]
        public void CreateUser()
        {
            //array
            UserEfDataHandler testedDataHandler = new UserEfDataHandler();
            string inputName = "test";

            string result = "0";

            //act
            result = testedDataHandler.CreateUser(inputName);

            //assert
            Assert.IsFalse(result == "0", "The result cannot be zero.");
        }

        [TestMethod]
        public void UpdateUser()
        {
            //array
            UserEfDataHandler testedDataHandler = new UserEfDataHandler();
            string inputName = "testtt";
            string result = "1";

            //act
            result = testedDataHandler.UpdateUser(inputName);

            //assert
            Assert.IsFalse(result == "0", "The result cannot be zero.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Sequence contains no elements.")]
        public void DeleteUser()
        {
            //array
            UserEfDataHandler testedDataHandler = new UserEfDataHandler();
            string inputName = "Dell";
            
            //act
            testedDataHandler.DeleteUser(inputName);

            string result = testedDataHandler.GetUser(inputName);

            //assert
           
        }
    }
    
}

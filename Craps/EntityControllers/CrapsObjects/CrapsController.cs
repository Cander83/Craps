using Craps.DataModels;
using Craps.EntityControllers.CrapsObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Craps.EntityControllers.CrapsObjects
{
    public class CrapsController
    {
        /* Roll 2 x 1d6.
         * If sum is 7 or 11 on the first roll the player wins.
         * If the sum is 2, 3, or 12 on the first roll then 'Craps' is the result, and the player loses.
         * If the sum is 4, 5, 6, 8, 9, or 10 then that sum becomes the player's point.
         * Once the point has been set, then the rules of the game change. 
         * If at any time after the first roll, a 7 is rolled, the player loses and the point is reset.
         * If the player rolls the point, the player wins. Hitting the point also resets the point.
         * When the point is reset, the game starts over, and the next roll of the dice acts like the first roll of the dice again.
         */
        private IRollDataHandler RollDataHandler { get; set; }

        public CrapsController(IRollDataHandler rollHandler)
        {
            RollDataHandler = rollHandler;
        }

        public async Task<CrapsResultModel> PlayCraps(CrapsResultModel inputCrapsModel)
        {

            CrapsResultModel outputModel = inputCrapsModel;

            RollDataModel firstRoll = await RollDataHandler.GetRollAsync();
            RollDataModel secondRoll = await RollDataHandler.GetRollAsync();

            outputModel.FirstRollValue = firstRoll.Result;
            outputModel.SecondRollValue = secondRoll.Result;

            outputModel.GameStatus = GetCrapsResult(outputModel.RollSum, outputModel.GameStatus, outputModel.Point);

            if (outputModel.GameStatus == "point")
            {
                outputModel.Point = outputModel.RollSum;
            }

            return outputModel;

        }

        public string GetCrapsResult(int inputValue, string currentStatus, int currentPoints)
        {
            if (currentStatus == "new" && (inputValue == 7 || inputValue == 11))
            { return "win"; }

            else if (currentStatus == "new" && (inputValue == 2 || inputValue == 3 || inputValue == 12))
            { return "loss"; } //craps

            else if (currentStatus == "new")
            { return "point"; } //craps

            if (currentStatus == "point" && (inputValue == 7))
            { return "loss"; }

            if (currentStatus == "point" && (inputValue==currentPoints))
            { return "win"; }

            return "";
        }
    }
}

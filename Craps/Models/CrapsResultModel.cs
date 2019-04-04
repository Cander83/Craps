using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Craps.EntityControllers.CrapsObjects
{
    public class CrapsResultModel
    {
        public CrapsResultModel()
        {
            GameStatus = "new";
        }

        public int GameId { get; set; }
        public int UserId { get; set; }
                
        public string GameStatus { get; set; }
        

        private int _firstRoll = 0;
        public int FirstRollValue
        { get { return _firstRoll; }
            set { _firstRoll = value; }
        }

        private int _secondRoll = 0;
        public int SecondRollValue
        {
            get { return _secondRoll; }
            set { _secondRoll = value; }
        }

        public int RollSum
        { get
            { return _firstRoll + _secondRoll; }
        }

        private bool _hasPoint = false;
        public bool HasPoint
        { get
          { return _hasPoint; }
        }

        private int _point = 0;
        public int Point
        {
            get
            {
                return _point;
            }
            set
            {
                if ((value > 0) && (value < 13))
                {
                    _point = value;
                    _hasPoint = true;
                }
            }
        }
    }
}

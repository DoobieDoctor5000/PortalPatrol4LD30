using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalPatrol
{
    [Serializable]
    public class Player
    {
        public string name = null;

        #region Triggers
        public bool exists = false;
        public bool finishedIntro = false;
        public bool enteredLab = false;
        public bool blueClothesOn = false;
        public bool blueShellUp = false;
        public bool startingAgain = false;
        #endregion
    }

}

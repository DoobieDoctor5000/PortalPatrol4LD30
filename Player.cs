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
        #endregion
    }

}

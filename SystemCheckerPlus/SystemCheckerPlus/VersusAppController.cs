using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemCheckerPlus
{
    class VersusAppController
    {
        private List<VersusApplication> _appList;

        public List<VersusApplication> AppList
        {
            get { return _appList; }
            set { _appList = value; }
        }

        public VersusAppController()
        {
            AppList = new List<VersusApplication>();
        }
        public VersusAppController(VersusApplication[] appList)
        {
            AppList = appList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemCheckerPlus
{
    class VersusApplication
    {
        private string _displayName;

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        private string _vDataName;

        public string VDataName
        {
            get { return _vDataName; }
            set { _vDataName = value; }
        }

        private string[] _bupFiles;

        public string[] BUPFiles
        {
            get { return _bupFiles; }
            set { _bupFiles = value; }
        }

        private string _appFolder;

        public string AppFolder
        {
            get { return _appFolder; }
            set { _appFolder = value; }
        }
        
        public VersusApplication()
        {
            DisplayName = "Test Application";
            VDataName = null;
            BUPFiles = null;
            AppFolder = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SystemCheckerPlus
{
    public class Application : ObservableObject
    {
        private string _displayName;

        public string DisplayName
        {
            get { return _displayName; }
            set 
            {
                _displayName = value;
                RaisePropertyChanged("DisplayName");
            }
        }

        private string procName;

        public string ProcName
        {
            get { return procName; }
            set 
            {
                procName = value;
                RaisePropertyChanged("ProcName");
            }
        }

        private string[] _bupFiles;

        public string[] BUPFiles
        {
            get { return _bupFiles; }
            set 
            {
                _bupFiles = value;
                RaisePropertyChanged("BUPFiles");
            }
        }

        private string _appFolder;

        public string AppFolder
        {
            get { return _appFolder; }
            set 
            {
                _appFolder = value;
                RaisePropertyChanged("AppFolder");
            }
        }

        private int _appVersion;

        public int AppVersion
        {
            get { return _appVersion; }
            set 
            {
                _appVersion = value;
                RaisePropertyChanged("AppVersion");
            }
        }
        private Queue<float> _procUsage = new Queue<float>();

        public float ProcUsage
        {
            get 
            {
                if (_procUsage.Count != 0)
                    return _procUsage.Average();
                else
                    return 0;
            }
            set
            {
                if (_procUsage.Count > 30)
                    _procUsage.Dequeue();
                _procUsage.Enqueue(value);
                RaisePropertyChanged("ProcUsage");
            }
        }

        private float _memUsage = 0;

        public float MemUsage
        {
            get { return _memUsage; }
            set 
            {
                _memUsage = value;
                RaisePropertyChanged("MemUsage");
            }
        }
        private List<XDocument> _appDefFiles;

        public List<XDocument> AppDefFiles
        {
            get { return _appDefFiles; }
            set 
            {
                _appDefFiles = value;
                RaisePropertyChanged("AppDefFiles");
            }
        }

        private XDocument _appDefFile;

        public XDocument AppDefFile
        {
            get { return _appDefFile; }
            set 
            {
                _appDefFile = value;
                RaisePropertyChanged("AppDefFile");
            }
        }
        
        

        public Application()
        {
            DisplayName = "Test Application";
            ProcName = null;
            BUPFiles = null;
            AppFolder = null;
        }
        public Application(string displayName)
            : this()
        {
            DisplayName = displayName;
        }
    }
}

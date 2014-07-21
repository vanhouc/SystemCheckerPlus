using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SystemCheckerPlus.Models
{
    public class Application : ObservableObject
    {
        private XDocument _appDefFile;
        private List<XDocument> _appDefFiles;
        private string _appFolder;
        private int _appVersion;
        private string[] _bupFiles;
        private string _displayName;

        private float _memUsage = 0;

        private Queue<float> _procUsage = new Queue<float>();

        private string procName;

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

        public string AppFolder
        {
            get { return _appFolder; }
            set
            {
                _appFolder = value;
                RaisePropertyChanged("AppFolder");
            }
        }

        public int AppVersion
        {
            get { return _appVersion; }
            set
            {
                _appVersion = value;
                RaisePropertyChanged("AppVersion");
            }
        }

        public string[] BUPFiles
        {
            get { return _bupFiles; }
            set
            {
                _bupFiles = value;
                RaisePropertyChanged("BUPFiles");
            }
        }

        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                _displayName = value;
                RaisePropertyChanged("DisplayName");
            }
        }

        public float MemUsage
        {
            get { return _memUsage; }
            set
            {
                _memUsage = value;
                RaisePropertyChanged("MemUsage");
            }
        }

        public string ProcName
        {
            get { return procName; }
            set
            {
                procName = value;
                RaisePropertyChanged("ProcName");
            }
        }

        public float ProcUsage
        {
            get
            {
                if (_procUsage.Count < 1)
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
    }
}
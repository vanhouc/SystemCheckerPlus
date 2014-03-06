using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;

namespace SystemCheckerPlus
{
    class MainWindowViewModel : ObservableObject
    {
        XMLService xmlService;
        private AppService _appList;

        public AppService AppList
        {
            get { return _appList; }
            set 
            {
                _appList = value;
                RaisePropertyChanged("AppList");
            }
        }
        
        public MainWindowViewModel()
        {

        }
        public void LoadVersusAppData()
        {
            OpenFileDialog openVData = new OpenFileDialog();
            openVData.Filter = "Extensible Markup Language *.xml|*.xml";
            openVData.ShowDialog();
            if (openVData.FileName != null && File.Exists(openVData.FileName))
            {
                xmlService = new XMLService(new XMLLoader(openVData.FileName));
            }
        }
    }
}

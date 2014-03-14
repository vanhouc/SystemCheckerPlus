using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;

namespace SystemCheckerPlus
{
    public class MainWindowViewModel : ObservableObject
    {
        private ObservableCollection<Application> _applications = new ObservableCollection<Application>();
        private float cpuUsage;

        private Timer perfCounter;

        private IXMLService xmlService;

        public MainWindowViewModel()
        {
            perfCounter = new Timer(UpdatePerfCounters, null, 0, 1000);
            Applications.Add(new Application
            {
                DisplayName = "Total CPU Usage",
                ProcName = "Total CPU Usage"
            });
        }

        public ObservableCollection<Application> Applications
        {
            get { return _applications; }
            set
            {
                _applications = value;
                RaisePropertyChanged("Applications");
            }
        }

        public float CPUUsage
        {
            get { return cpuUsage; }
            set
            {
                cpuUsage = value;
                RaisePropertyChanged("CPUUsage");
            }
        }

        public void InitializeAppData(IXMLService service)
        {
            if (service != null)
            {
                Applications = new ObservableCollection<Application>(service.GetAppData(new string[] { "Applications", "Application" }));
            }
        }

        public void LoadAppData()
        {
            OpenFileDialog openVData = new OpenFileDialog();
            openVData.Filter = "Extensible Markup Language *.xml|*.xml";
            openVData.ShowDialog();
            if (openVData.FileName != null && File.Exists(openVData.FileName))
            {
                xmlService = new XMLService(new XMLLoader(openVData.FileName));
                InitializeAppData(xmlService);
            }
        }

        async private void UpdatePerfCounters(object state)
        {
            ProcessService procService = ProcessService.Instance;
            CPUUsage = await procService.TotalCPUAsync();
            if (Applications != null)
            {
                foreach (Application a in Applications)
                {
                    if (a.ProcName != null && a.ProcName != String.Empty)
                    {
                        if (a.ProcName == "Total CPU Usage")
                        {
                            a.ProcUsage = await procService.TotalCPUAsync();
                            a.MemUsage = procService.AvailableMemory();
                        }
                        else
                        {
                            a.ProcUsage = await procService.ProcessCPUAsync(a.ProcName);
                            a.MemUsage = procService.ProcessPrivateMemory(a.ProcName);
                        }
                    }
                }
            }
        }
    }
}
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using SystemCheckerPlus.Models;
using SystemCheckerPlus.Models.Interfaces;
using SystemCheckerPlus.Services;
using SystemCheckerPlus.Services.Interfaces;
using SystemCheckerPlus.ViewModel;
using SystemCheckerPlus.Views;

namespace SystemCheckerPlus
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Application> _applications = new ObservableCollection<Application>();

        private Timer perfCounter;
        private string configPath;
        public MainViewModel()
        {
            perfCounter = new Timer(UpdatePerfCounters, null, 0, 1000);
            Applications.Add(new Application
            {
                DisplayName = "Total CPU Usage",
                ProcessName = "Total CPU Usage"
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
        /// <summary>
        /// The <see cref="TotalCPUUsage" /> property's name.
        /// </summary>
        public const string TotalCPUUsagePropertyName = "TotalCPUUsage";

        private float _totalCPUUsage;

        /// <summary>
        /// Sets and gets the TotalCPUUsage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public float TotalCPUUsage
        {
            get
            {
                return _totalCPUUsage;
            }
            set
            {
                Set(TotalCPUUsagePropertyName, ref _totalCPUUsage, value);
            }
        }
        /// <summary>
        /// The <see cref="AvailableMemory" /> property's name.
        /// </summary>
        public const string AvailableMemoryPropertyName = "AvailableMemory";

        private float _availableMemory = 0;

        /// <summary>
        /// Sets and gets the AvailableMemory property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public float AvailableMemory
        {
            get
            {
                return _availableMemory;
            }
            set
            {
                Set(AvailableMemoryPropertyName, ref _availableMemory, value);
            }
        }

        async private void UpdatePerfCounters(object state)
        {
            TotalCPUUsage = await ProcessService.TotalCPUAsync();
            AvailableMemory = ProcessService.AvailableMemory();
            if (Applications != null)
            {
                foreach (Application a in Applications)
                {
                    if (a.ProcessName != null && a.ProcessName != String.Empty)
                    {
                        a.ProcessUsage = await ProcessService.ProcessCPUAsync(a.ProcessName);
                        a.MemoryUsage = ProcessService.ProcessPrivateMemory(a.ProcessName);
                    }
                }
            }
        }
        private RelayCommand _newAppCommand;

        /// <summary>
        /// Gets the NewAppCommand.
        /// </summary>
        public RelayCommand NewAppCommand
        {
            get
            {
                return _newAppCommand
                    ?? (_newAppCommand = new RelayCommand(
                                          () =>
                                          {
                                              var newApp = new EditApplication();
                                              newApp.DataContext = new NewApplicationViewModel(newApp);
                                              newApp.Show();
                                          }));
            }
        }
        public void SaveApplication(IApplication toSave)
        {
            var configService = ServiceLocator.Current.GetInstance<IConfigurationService>();
            configService.SaveApplication(configPath, toSave);
        }
    }
}
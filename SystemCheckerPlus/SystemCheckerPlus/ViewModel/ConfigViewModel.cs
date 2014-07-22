using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCheckerPlus.Services.Interfaces;
using SystemCheckerPlus.Views;

namespace SystemCheckerPlus.ViewModel
{
    class ConfigViewModel : ViewModelBase
    {
        private ConfigWindow _view;
        public ConfigViewModel(ConfigWindow view)
        {
            _view = view;
        }
        /// <summary>
        /// The <see cref="ConfigPath" /> property's name.
        /// </summary>
        public const string ConfigPathPropertyName = "ConfigPath";

        private string _configPath;

        /// <summary>
        /// Sets and gets the ConfigPath property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ConfigPath
        {
            get
            {
                return _configPath;
            }
            set
            {
                Set(ConfigPathPropertyName, ref _configPath, value);
            }
        }
        private RelayCommand<string> _setPathCommand;

        /// <summary>
        /// Gets the SetPathCommand.
        /// </summary>
        public RelayCommand<string> SetPathCommand
        {
            get
            {
                return _setPathCommand
                    ?? (_setPathCommand = new RelayCommand<string>(
                                          p =>
                                          {
                                              if (p == "New")
                                              {
                                                  SaveFileDialog dialog = new SaveFileDialog();
                                                  if (dialog.ShowDialog() == true)
                                                  {
                                                      ConfigPath = dialog.FileName;
                                                      var configService = ServiceLocator.Current.GetInstance<IConfigurationService>();
                                                      configService.CreateNewConfiguration(ConfigPath);
                                                  }
                                              }
                                              if (p == "Open")
                                              {
                                                  OpenFileDialog dialog = new OpenFileDialog();
                                                  if (dialog.ShowDialog() == true)
                                                  {
                                                      ConfigPath = dialog.FileName;
                                                  }
                                              }
                                              _view.DialogResult = true;
                                          }));
            }
        }
    }
}

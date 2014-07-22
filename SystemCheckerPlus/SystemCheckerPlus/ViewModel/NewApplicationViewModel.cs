using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCheckerPlus.Models;
using SystemCheckerPlus.Models.Interfaces;
using SystemCheckerPlus.Services.Interfaces;
using SystemCheckerPlus.Views;

namespace SystemCheckerPlus.ViewModel
{
    public class NewApplicationViewModel : ViewModelBase
    {
        private EditApplication _view;
        public NewApplicationViewModel(EditApplication view)
        {
            NewApplication = new Application();
            _view = view;
        }
        /// <summary>
        /// The <see cref="NewApplication" /> property's name.
        /// </summary>
        public const string NewApplicationPropertyName = "NewApplication";

        private IApplication _newApplication;

        /// <summary>
        /// Sets and gets the NewApplication property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public IApplication NewApplication
        {
            get
            {
                return _newApplication;
            }
            set
            {
                Set(NewApplicationPropertyName, ref _newApplication, value);
            }
        }
        private RelayCommand<IApplication> _saveCommand;

        /// <summary>
        /// Gets the SaveCommand.
        /// </summary>
        public RelayCommand<IApplication> SaveCommand
        {
            get
            {
                return _saveCommand
                    ?? (_saveCommand = new RelayCommand<IApplication>(
                                          a =>
                                          {
                                              var main = ServiceLocator.Current.GetInstance<MainViewModel>();
                                              main.SaveApplication(NewApplication);
                                              _view.Close();
                                          }));
            }
        }
    }
}

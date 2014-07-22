using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCheckerPlus.Services;
using SystemCheckerPlus.Services.Interfaces;

namespace SystemCheckerPlus.ViewModel
{
    public class ViewModelLocator
    {
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public NewApplicationViewModel EditApplication
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NewApplicationViewModel>();
            }
        }
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (ViewModelBase.IsInDesignModeStatic)
            {

            }
            else
            {

            }
            SimpleIoc.Default.Register<IConfigurationService, XMLConfigService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<NewApplicationViewModel>();
        }
    }
}

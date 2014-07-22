using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using SystemCheckerPlus.Models.Interfaces;

namespace SystemCheckerPlus.Models
{
    public class Application : ObservableObject, IApplication
    {
        public Application()
        {
            DisplayName = "Test Application";
            ProcessName = String.Empty;
            Files = new string[0];
            Folder = String.Empty;
        }

        public Application(string displayName)
            : this()
        {
            DisplayName = displayName;
        }
        /// <summary>
        /// The <see cref="Folder" /> property's name.
        /// </summary>
        public const string FolderPropertyName = "Folder";
        
        private string _folder;
        
        /// <summary>
        /// Sets and gets the Folder property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Folder
        {
            get
            {
                return _folder;
            }
            set
            {
                Set(FolderPropertyName, ref _folder, value);
            }
        }
        /// <summary>
        /// The <see cref="Version" /> property's name.
        /// </summary>
        public const string VersionPropertyName = "Version";
        
        private string _version;
        
        /// <summary>
        /// Sets and gets the Version property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Version
        {
            get
            {
                return _version;
            }
            set
            {
                Set(VersionPropertyName, ref _version, value);
            }
        }
        /// <summary>
        /// The <see cref="Files" /> property's name.
        /// </summary>
        public const string FilesPropertyName = "Files";

        private string[] _files;
        
        /// <summary>
        /// Sets and gets the Files property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string[] Files
        {
            get
            {
                return _files;
            }
            set
            {
                Set(FilesPropertyName, ref _files, value);
            }
        }
        /// <summary>
        /// The <see cref="DisplayName" /> property's name.
        /// </summary>
        public const string DisplayNamePropertyName = "DisplayName";
        
        private string _displayName;
        
        /// <summary>
        /// Sets and gets the DisplayName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DisplayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                Set(DisplayNamePropertyName, ref _displayName, value);
            }
        }
        /// <summary>
        /// The <see cref="FileName" /> property's name.
        /// </summary>
        public const string FileNamePropertyName = "FileName";

        private string _fileName;

        /// <summary>
        /// Sets and gets the FileName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                Set(FileNamePropertyName, ref _fileName, value);
            }
        }
        /// <summary>
        /// The <see cref="Executable" /> property's name.
        /// </summary>
        public const string ExecutablePropertyName = "Executable";
        
        private string _executable;
        
        /// <summary>
        /// Sets and gets the Executable property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Executable
        {
            get
            {
                return _executable;
            }
            set
            {
                Set(ExecutablePropertyName, ref _executable, value);
            }
        }
        /// <summary>
        /// The <see cref="MemoryUsage" /> property's name.
        /// </summary>
        public const string MemoryUsagePropertyName = "MemoryUsage";
        
        private float _memoryUsage;
        
        /// <summary>
        /// Sets and gets the MemoryUsage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public float MemoryUsage
        {
            get
            {
                return _memoryUsage = 0;
            }
            set
            {
                Set(MemoryUsagePropertyName, ref _memoryUsage, value);
            }
        }
        /// <summary>
        /// The <see cref="ProcessName" /> property's name.
        /// </summary>
        public const string ProcessNamePropertyName = "ProcessName";
        
        private string _processName;
        
        /// <summary>
        /// Sets and gets the ProcessName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ProcessName
        {
            get
            {
                return _processName;
            }
            set
            {
                Set(ProcessNamePropertyName, ref _processName, value);
            }
        }
        /// <summary>
        /// The <see cref="ProcessUsage" /> property's name.
        /// </summary>
        public const string ProcessUsagePropertyName = "ProcessUsage";
        
        private Queue<float> _processUsage = new Queue<float>();
        
        /// <summary>
        /// Sets and gets the ProcessUsage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public float ProcessUsage
        {
            get
            {
                if (_processUsage.Count < 1)
                    return _processUsage.Average();
                else
                    return 0;
            }
            set
            {
                                if (_processUsage.Count > 30)
                    _processUsage.Dequeue();
                _processUsage.Enqueue(value);
                RaisePropertyChanged("ProcessUsage");
            }
        }
    }
}
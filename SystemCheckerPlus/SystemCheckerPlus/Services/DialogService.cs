using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCheckerPlus.Services.Interfaces;

namespace SystemCheckerPlus.Services
{
    public class DialogService : IDialogService
    {
        public string SelectNewFile()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == true)
                return dialog.FileName;
            else
                return String.Empty;
        }

        public string OpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
                return dialog.FileName;
            else
                return String.Empty;
        }
    }
}

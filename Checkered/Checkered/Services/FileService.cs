using Checkered.Models.Interfaces;
using Checkered.Services.Interfaces;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Checkered.Services
{
    public class FileService : IFileService
    {
        public bool BackupFiles(IApplication toBackup, string backupPath)
        {
            try
            {
                DateTime today = DateTime.Today;
                ZipFile archive = new ZipFile(String.Format("{0}{1}{2}{3}.zip", backupPath, today.Year.ToString(), today.Month.ToString(), today.Day.ToString()));
                foreach (string file in toBackup.Files)
                {
                    if (file[file.Length - 1] == '\\')
                        archive.AddDirectory(toBackup.Folder + file, toBackup.Folder.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).Last() + "\\" + file);
                    else
                        archive.AddFile(toBackup.Folder + file, toBackup.Folder.Split(new char[] {'\\'}, StringSplitOptions.RemoveEmptyEntries).Last() + "\\");
                }
                archive.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string GetFileVersion(string path)
        {
            FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(path);
            return String.Format("{0}.{1}.{2}.{3}", fileVersion.FileMajorPart, fileVersion.FileMinorPart, fileVersion.FileBuildPart, fileVersion.FilePrivatePart);
        }
    }
}

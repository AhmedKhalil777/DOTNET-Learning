using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using TreeViews.Demo.Contracts;
using TreeViews.Demo.Contracts.ViewModels;

namespace TreeViews.Demo.Processors
{
    public static class DirectoryProcessor
    {
        public static List<DirectoryItem> GetLogicelDrives() => Directory.GetLogicalDrives()
            .Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        
        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            var normalizedPath = path.Replace('/', '\\');
            var lastIndex = normalizedPath.LastIndexOf('\\');
            if (lastIndex <= 0)
                return path;
            return path.Substring(lastIndex + 1);
        }

        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            var items = new List<DirectoryItem>();
            try
            {
                //Handling Directories
                var directories = Directory.GetDirectories(fullPath);
                if (directories.Length > 0)
                    items.AddRange(directories.Select(x => new DirectoryItem { FullPath = x, Type = DirectoryItemType.Folder }));
                //Handling Files
                var files = Directory.GetFiles(fullPath);
                if (files.Length > 0)
                    items.AddRange(directories.Select(x => new DirectoryItem { FullPath = x, Type = DirectoryItemType.File }));

                // Returning Contents
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return items;
        }
    }


}

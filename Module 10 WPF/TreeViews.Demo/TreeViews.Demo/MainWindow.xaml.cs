using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TreeViews.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    { 

        private Dictionary<string, string> Images = new Dictionary<string, string> ();
        public MainWindow()
        {
            InitializeComponent();
            Images.Add("drive", "E:\\Projects\\DOTNET - Learning\\Module 10 WPF\\TreeViews.Demo\\TreeViews.Demo\\Images\\Drive.png");
            Images.Add("file", "E:\\Projects\\DOTNET - Learning\\Module 10 WPF\\TreeViews.Demo\\TreeViews.Demo\\Images\\file.png");
            Images.Add("folderClosed", "E:\\Projects\\DOTNET - Learning\\Module 10 WPF\\TreeViews.Demo\\TreeViews.Demo\\Images\\folder.png");
            Images.Add("folderOpend", "E:\\Projects\\DOTNET - Learning\\Module 10 WPF\\TreeViews.Demo\\TreeViews.Demo\\Images\\folderOpen.png");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        { 
            foreach (var Drive in Directory.GetLogicalDrives())
            {
                var folderItem = new TreeViewItem();
                folderItem.Header = Drive;
                folderItem.Tag = Drive;
                
                // Dummy Data
                folderItem.Items.Add(null);

                folderItem.Expanded += FolderExpanded;
                FolderView.Items.Add(folderItem);

            }

        }

        private void FolderExpanded(object sender, RoutedEventArgs e)
        {
            var directories = new List<string>();
            var files = new List<string>();
            var folderItem = (TreeViewItem)sender;

            if (folderItem.Items.Count != 1 || folderItem.Items == null)
                return;

            folderItem.Items.Clear();

            //GetFullPath
            var fullPath = (string)folderItem.Tag;

            try
            {
                foreach (var directory in Directory.GetDirectories(fullPath))
                {
                    
                   
                    string directoryName;
                    var folderDirectory = new TreeViewItem {
                        Header =  directoryName = GetFileFolderName(directory),
                        Tag = directory
                    };
                    folderDirectory.Expanded += FolderOpened;
                    directories.Add(directoryName);

                    // Dummy Data
                    folderDirectory.Items.Add(null);

                    folderDirectory.Expanded += FolderExpanded;
                    folderItem.Items.Add(folderDirectory);
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
            try
            {
                foreach (var file in Directory.GetFiles(fullPath))
                {
                    var fileItem = new TreeViewItem();
                    fileItem.Header = GetFileFolderName(file);
                    fileItem.Tag = file;
                     
                    folderItem.Items.Add(fileItem);
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }

        }

        private void FolderOpened(object sender, RoutedEventArgs e)
        {
            var folder = (TreeViewItem)sender;
            if (folder.IsExpanded)
            {
                Tag = "Open";
            }
             
        }

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
    }
}

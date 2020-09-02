using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TreeViews.Demo.Commands;
using TreeViews.Demo.Processors;

namespace TreeViews.Demo.Contracts.ViewModels
{

    public class DirectoryItemViewModel : BaseViewModel
    {
        #region Constructor
        public DirectoryItemViewModel( string FullPath , DirectoryItemType Type)
        {
            ExpandedCommand = new RelayCommand(Expand);
            this.FullPath = FullPath;
            this.Type = Type;
            ClearChildren();
        }
        #endregion
        #region Public Properties
        public DirectoryItemType Type { get; set; }
        public string ImageName => Type == DirectoryItemType.Drive ? "Drive" : (Type == DirectoryItemType.File ? "file" : (IsExpanded ? "folderOpen" : "folder"));

        public string FullPath { get; set; }
        public string Name { get => Type == DirectoryItemType.Drive ? FullPath : DirectoryProcessor.GetFileFolderName(FullPath); }

        // A List of Children of This Item
        // Drive {Folder A  {File A , Folder G}, Folder B , Folder C , File B}
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }
        public bool CanExpand { get => Type != DirectoryItemType.File;  }

        public bool IsExpanded
        {
            get => Children?.Count(f => f != null) > 0;
            set
            {
                if (value == true)
                    Expand();
                else
                {
                    ClearChildren();
                }
            }
        }
        #endregion

        #region Commands
        public ICommand ExpandedCommand { get; set; }
        #endregion


        private void ClearChildren()
        {
            Children = new ObservableCollection<DirectoryItemViewModel>();
            if (Type != DirectoryItemType.File)
                Children.Add(null);
                    
        }

        private void Expand()
        {
            if (Type == DirectoryItemType.File)
                return;
            var childrens = DirectoryProcessor.GetDirectoryContents(FullPath);
            Children = new ObservableCollection<DirectoryItemViewModel>(
               childrens.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));


        }
    }
}

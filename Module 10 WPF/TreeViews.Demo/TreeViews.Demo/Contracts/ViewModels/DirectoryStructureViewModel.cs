using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TreeViews.Demo.Processors;

namespace TreeViews.Demo.Contracts.ViewModels
{
    public class DirectoryStructureViewModel : BaseViewModel
    {
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        public DirectoryStructureViewModel()
        {
            var children = DirectoryProcessor.GetLogicelDrives();
            Items = new ObservableCollection<DirectoryItemViewModel>(children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));

        }
    }
}

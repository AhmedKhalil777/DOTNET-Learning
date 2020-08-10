using TreeViews.Demo.Processors;

namespace TreeViews.Demo.Contracts
{
    public class DirectoryItem
    {
        public DirectoryItemType Type { get; set; }
        public string FullPath { get; set; }
        public string Name { get => Type == DirectoryItemType.Drive? FullPath: DirectoryProcessor.GetFileFolderName(FullPath);  }
    }
}

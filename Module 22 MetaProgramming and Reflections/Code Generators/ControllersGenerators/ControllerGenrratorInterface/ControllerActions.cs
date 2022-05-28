using System;

namespace ControllersGenerators.Attributes
{
    [Flags]
    public enum ControllerActions
    {
        List = 1,
        Get = 2,
        Post = 4,
        Put = 8,
        Delete = 16,
        All = List | Get | Post| Put | Delete
    }
}

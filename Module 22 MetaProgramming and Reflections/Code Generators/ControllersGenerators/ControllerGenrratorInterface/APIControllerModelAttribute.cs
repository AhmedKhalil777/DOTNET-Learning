using System;

namespace ControllersGenerators.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited =false, AllowMultiple =false)]
    public sealed class APIControllerModelAttribute : Attribute
    {
        public ControllerActions Actions { get; set; }
        public APIControllerModelAttribute(ControllerActions actions)
        {
            Actions = actions;
        }
    }
}

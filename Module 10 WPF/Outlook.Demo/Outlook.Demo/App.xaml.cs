using Outlook.Demo.Calander;
using Outlook.Demo.Contacts;
using Outlook.Demo.Mail;
using Outlook.Demo.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace Outlook.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MailModule>();
            moduleCatalog.AddModule<CalanderModule>();
            moduleCatalog.AddModule<ContactsModule>();
        }
    }
}

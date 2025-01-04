using CommunityToolkit.Mvvm.DependencyInjection;
using DialogSample.Dialogs;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DialogSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var window = new MainWindow();
            

            var dialogService = new DialogService(window);
            dialogService.Register<PersonDialogViewModel, PersonDialog>();

            var service=new ServiceCollection();
            service.AddSingleton<IDialogService>(dialogService);
            service.AddSingleton<MainViewModel>();
            Ioc.Default.ConfigureServices(service.BuildServiceProvider());
            window.DataContext = Ioc.Default.GetRequiredService<MainViewModel>();
            window.Show();
        }
    }

}

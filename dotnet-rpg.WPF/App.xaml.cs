using System;
using System.Threading.Tasks;
using System.Windows;
using dotnet_rpg.WPF.MVVM.ViewModels;
using dotnet_rpg.WPF.MVVM.Views;
using dotnet_rpg.WPF.Store;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;

namespace dotnet_rpg.WPF {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App {
        private readonly IHost _host;

        public App() {
            _host = Host.CreateDefaultBuilder().ConfigureServices(
                (context, services) => {
                    services.AddSingleton<NavigationStore>();
                    services.AddSingleton<ModalNavigationStore>();
                    services.AddSingleton<AuthentificationStore>();

                    services.AddSingleton(
                        s => new NavigationService<RegisterVm>(
                            s.GetRequiredService<NavigationStore>(),
                            () => new RegisterVm(s.GetRequiredService<AuthentificationStore>(), s.GetRequiredService<NavigationService<LoginVm>>())
                        )
                    );

                    services.AddSingleton(
                        s => new NavigationService<LoginVm>(
                            s.GetRequiredService<NavigationStore>(),
                            () => new LoginVm(
                                s.GetRequiredService<AuthentificationStore>(), s.GetRequiredService<NavigationService<RegisterVm>>(),
                                s.GetRequiredService<NavigationService<HomeVm>>()
                            )
                        )
                    );

                    services.AddSingleton(
                        s => new NavigationService<HomeVm>(
                            s.GetRequiredService<NavigationStore>(),
                            () => HomeVm.LoadVm(s.GetRequiredService<AuthentificationStore>(), s.GetRequiredService<NavigationService<LoginVm>>())
                        )
                    );

                    services.AddSingleton<MainVm>();

                    services.AddSingleton(s => new MainWindow() { DataContext = s.GetRequiredService<MainVm>() });
                }
            ).Build();
        }

        protected override async void OnStartup(StartupEventArgs e) {
            await Initialize();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        private async Task Initialize() {
            AuthentificationStore authentificationStore = _host.Services.GetRequiredService<AuthentificationStore>();
            
            try {

                if (authentificationStore.IsLoggedIn) {
                    var navigationService = _host.Services.GetRequiredService<NavigationService<HomeVm>>();
                    navigationService.Navigate();
                } else {
                    var navigationService = _host.Services.GetRequiredService<NavigationService<LoginVm>>();
                    navigationService.Navigate();
                }
            } catch (Exception) {
                MessageBox.Show("Failed to load application.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
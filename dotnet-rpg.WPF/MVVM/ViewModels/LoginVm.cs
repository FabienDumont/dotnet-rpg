using System.Windows.Input;
using dotnet_rpg.WPF.Commands;
using dotnet_rpg.WPF.Store;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;

namespace dotnet_rpg.WPF.MVVM.ViewModels;

public class LoginVm : BaseVm {
    private string _username;

    public string Username {
        get => _username;
        set {
            _username = value;
            OnPropertyChanged();
        }
    }

    private string _password;

    public string Password {
        get => _password;
        set {
            _password = value;
            OnPropertyChanged();
        }
    }

    public ICommand SubmitCommand { get; }
    public ICommand NavigateRegisterCommand { get; }

    public LoginVm(
        AuthentificationStore authentificationStore, INavigationService registerNavigationService, INavigationService homeNavigationService
    ) {
        _username = "Joueur1";
        _password = "123456";

        SubmitCommand = new LoginCommand(this, authentificationStore, homeNavigationService);
        NavigateRegisterCommand = new NavigateCommand(registerNavigationService);
    }
}
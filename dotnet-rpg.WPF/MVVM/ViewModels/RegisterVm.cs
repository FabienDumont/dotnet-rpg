using System.Windows.Input;
using dotnet_rpg.WPF.Commands;
using dotnet_rpg.WPF.Store;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;

namespace dotnet_rpg.WPF.MVVM.ViewModels;

public class RegisterVm : BaseVm {

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

    private string _confirmedPassword;

    public string ConfirmedPassword {
        get => _confirmedPassword;
        set {
            _confirmedPassword = value;
            OnPropertyChanged();
        }
    }

    public ICommand SubmitCommand { get; }
    public ICommand NavigateLoginCommand { get; }

    public RegisterVm(AuthentificationStore authentificationStore, INavigationService loginNavigationService) {
        _username = "Joueur3";
        _password = "123456";
        _confirmedPassword = "123456";

        SubmitCommand = new RegisterCommand(this, authentificationStore, loginNavigationService);
        NavigateLoginCommand = new NavigateCommand(loginNavigationService);
    }
}
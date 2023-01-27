using System.Windows.Input;
using dotnet_rpg.WPF.Commands;
using dotnet_rpg.WPF.Store;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;

namespace dotnet_rpg.WPF.MVVM.ViewModels; 

public class PasswordResetVm : BaseVm {
    private string _email;

    public string Email {
        get => _email;
        set {
            _email = value;
            OnPropertyChanged();
        }
    }

    public ICommand SendPasswordResetEmailCommand { get; }
    public ICommand NavigateLoginCommand { get; }

    public PasswordResetVm(AuthentificationStore authentificationStore, INavigationService loginNavigationService) {

        _email = "";
        
        SendPasswordResetEmailCommand = new SendPasswordResetEmailCommand(this, authentificationStore, loginNavigationService);
        NavigateLoginCommand = new NavigateCommand(loginNavigationService);
    }
}
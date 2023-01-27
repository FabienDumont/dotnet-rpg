using System.Windows.Input;
using dotnet_rpg.WPF.Commands;
using dotnet_rpg.WPF.Store;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;

namespace dotnet_rpg.WPF.MVVM.ViewModels; 

public class HomeVm : BaseVm {
    private readonly AuthentificationStore _authentificationStore;
    
    public string Username => _authentificationStore.Username;

    private string _message;

    public string Message {
        get => _message;
        set {
            _message = value;
            OnPropertyChanged();
        }
    }
    
    public ICommand LoadMessageCommand { get; }
    public ICommand LogoutCommand { get; }
    
    public HomeVm(AuthentificationStore authentificationStore, INavigationService loginNavigationService) {
        _authentificationStore = authentificationStore;

        _message = "";

        LoadMessageCommand = new LoadMessageCommand(this);
        LogoutCommand = new LogoutCommand(authentificationStore, loginNavigationService);
    }

    public static HomeVm LoadVm(
        AuthentificationStore authentificationStore, INavigationService loginNavigationService
    ) {
        HomeVm homeVm = new HomeVm(authentificationStore, loginNavigationService);
        
        homeVm.LoadMessageCommand.Execute(null);

        return homeVm;
    }
}
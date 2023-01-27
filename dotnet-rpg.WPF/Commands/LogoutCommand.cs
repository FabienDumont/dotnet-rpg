using System;
using dotnet_rpg.WPF.Store;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;

namespace dotnet_rpg.WPF.Commands; 

public class LogoutCommand : BaseCommand {
    private readonly AuthentificationStore _authentificationStore;
    private readonly INavigationService _loginNavigationService;

    public LogoutCommand(AuthentificationStore authentificationStore, INavigationService loginNavigationService) {
        _authentificationStore = authentificationStore;
        _loginNavigationService = loginNavigationService;
    }

    public override void Execute(object? parameter) {
        _authentificationStore.Username = String.Empty;
        _loginNavigationService.Navigate();
    }
}
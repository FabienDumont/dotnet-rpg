using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using dotnet_rpg.API.DTOs.User;
using dotnet_rpg.WPF.MVVM.ViewModels;
using dotnet_rpg.WPF.Store;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;

namespace dotnet_rpg.WPF.Commands; 

public class LoginCommand : BaseAsyncCommand {
    private readonly LoginVm _loginVm;
    private readonly AuthentificationStore _authentificationStore;
    private readonly INavigationService _homeNavigationService;

    public LoginCommand(LoginVm loginVm, AuthentificationStore authentificationStore, INavigationService homeNavigationService) {
        _loginVm = loginVm;
        _authentificationStore = authentificationStore;
        _homeNavigationService = homeNavigationService;
    }

    protected override async Task ExecuteAsync(object? parameter) {
        using (HttpClient client = new HttpClient()) {
            UserLoginDto user = new UserLoginDto {
                Username = _loginVm.Username,
                Password = _loginVm.Password
            };
            var response = await client.PostAsJsonAsync("http://localhost:5030/Auth/Login", user);
            
            if (response.IsSuccessStatusCode) {
                MessageBox.Show("Successfully logged in!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                _authentificationStore.Username = _loginVm.Username;
                _homeNavigationService.Navigate();
            } else {
                MessageBox.Show("Login failed. Please check your information or try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
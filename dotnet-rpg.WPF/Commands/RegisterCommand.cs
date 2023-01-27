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

public class RegisterCommand : BaseAsyncCommand {
    private readonly RegisterVm _registerVm;
    private readonly AuthentificationStore _authentificationStore;
    private readonly INavigationService _loginNavigationService;

    public RegisterCommand(RegisterVm registerVm, AuthentificationStore authentificationStore, INavigationService loginNavigationService) {
        _registerVm = registerVm;
        _authentificationStore = authentificationStore;
        _loginNavigationService = loginNavigationService;
    }

    protected override async Task ExecuteAsync(object? parameter) {
        string? password = _registerVm.Password;
        string? confirmedPassword = _registerVm.ConfirmedPassword;
        if (!password.Equals(confirmedPassword)) {
            MessageBox.Show("Password and confirmed password must match.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        } else {
            using (HttpClient client = new HttpClient()) {
                UserRegisterDto user = new UserRegisterDto { Username = _registerVm.Username, Password = password };
                var response = await client.PostAsJsonAsync("http://localhost:5030/Auth/Register", user);
                if (response.IsSuccessStatusCode) {
                    MessageBox.Show("Successfully registered!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    _loginNavigationService.Navigate();
                } else {
                    MessageBox.Show("Registration failed. Please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
using System;
using System.Threading.Tasks;
using System.Windows;
using dotnet_rpg.WPF.MVVM.ViewModels;
using dotnet_rpg.WPF.Store;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;

namespace dotnet_rpg.WPF.Commands; 

public class SendPasswordResetEmailCommand : BaseAsyncCommand {
    private readonly PasswordResetVm _passwordResetVm;
    private readonly AuthentificationStore _authentificationStore;
    private readonly INavigationService _loginNavigationService;

    public SendPasswordResetEmailCommand(
        PasswordResetVm passwordResetVm, AuthentificationStore authentificationStore, INavigationService loginNavigationService
    ) {
        _passwordResetVm = passwordResetVm;
        _authentificationStore = authentificationStore;
        _loginNavigationService = loginNavigationService;
    }

    protected override async Task ExecuteAsync(object? parameter) {
        string email = _passwordResetVm.Email;
        try {
            await _authentificationStore.SendPasswordResetEmail(email);
            MessageBox.Show(
                "Successfully sent password reset email. Check your email to finish resetting your password.", "Success", MessageBoxButton.OK,
                MessageBoxImage.Information
            );
            _loginNavigationService.Navigate();
        } catch (Exception e) {
            MessageBox.Show("Failed to send password reset email. Please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
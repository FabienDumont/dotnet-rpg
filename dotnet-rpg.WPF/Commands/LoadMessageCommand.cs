using System;
using System.Threading.Tasks;
using System.Windows;
using dotnet_rpg.WPF.MVVM.ViewModels;
using MVVMEssentials.Commands;

namespace dotnet_rpg.WPF.Commands; 

public class LoadMessageCommand : BaseAsyncCommand {
    private readonly HomeVm _homeVm;
    
    public LoadMessageCommand(HomeVm homeVm) {
        _homeVm = homeVm;
    }

    protected override async Task ExecuteAsync(object? parameter) {

        try {
            _homeVm.Message = "Coucou";
        } catch (Exception e) {
            MessageBox.Show("Unable to load data from API. Please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
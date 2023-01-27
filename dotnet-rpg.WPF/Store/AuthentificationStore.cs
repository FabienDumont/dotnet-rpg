using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using dotnet_rpg.API.DTOs.User;

namespace dotnet_rpg.WPF.Store;

public class AuthentificationStore {
    private string _username = string.Empty;

    public string Username {
        get => _username;
        set { _username = value; }
    }

    public bool IsLoggedIn => !_username.Equals(String.Empty);

    public async Task Login(string username, string password) { }

    public async Task Register(string email, string password, string username) { }

    public async Task SendPasswordResetEmail(string email) { }

    public void Logout() { }
}
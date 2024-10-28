using Blazored.LocalStorage;

public class AuthService
{
    private readonly ILocalStorageService _localStorage;

    private const string TokenKey = "authToken";

    private string _username;
    public string Username => _username;
    public event Action OnAuthStateChanged;

    public AuthService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<bool> Login(string username, string password)
    {
        if (username == "admin" && password == "password")
        {
            _username = username;
            await _localStorage.SetItemAsync(TokenKey, "fake-jwt-token");
            NotifyAuthStateChanged();
            return true;
        }
        return false;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync(TokenKey);
        NotifyAuthStateChanged();
    }

    public async Task<bool> IsAuthenticated()
    {
        var token = await _localStorage.GetItemAsync<string>(TokenKey);
        return !string.IsNullOrEmpty(token);
    }

    private void NotifyAuthStateChanged()
    {
        OnAuthStateChanged.Invoke();
    }
}
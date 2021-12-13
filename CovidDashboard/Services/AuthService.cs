using CovidDashboard.Settings;

namespace CovidDashboard.Services;

public class AuthService
{

    public bool CheckSecret(string password)
    {
        return password.Equals("password");
    }
}

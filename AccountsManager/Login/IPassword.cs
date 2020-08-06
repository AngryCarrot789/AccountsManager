using System.Security;

namespace AccountsManager.Login
{
    public interface IPassword
    {
        SecureString Password { get; }
    }
}

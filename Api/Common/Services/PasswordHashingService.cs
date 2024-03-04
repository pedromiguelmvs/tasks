using Api.Common.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Api.Common.Services
{
  public class PasswordHashingService : IPasswordHashingService
  {

    private readonly PasswordHasher<User> _passwordHasher;

    public PasswordHashingService()
    {
        _passwordHasher = new PasswordHasher<User>();
    }

    public string Hash(string password)
    {
        return _passwordHasher.HashPassword(null, password);
    }

    public PasswordVerificationResult Verify(string hashedPassword, string providedPassword)
    {
        return _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
    }
  }
}
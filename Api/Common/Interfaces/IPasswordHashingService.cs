using Microsoft.AspNetCore.Identity;

namespace Api.Common.Interfaces
{
  public interface IPasswordHashingService
  {
    string Hash(string password);
    PasswordVerificationResult Verify(string hashedPassword, string providedPassword);
  }
}
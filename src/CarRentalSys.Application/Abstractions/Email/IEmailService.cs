namespace CarRentalSys.Application.Abstractions.Email;

public interface IEmailService
{
  Task SendAsync(string email, string recipient, string body);
}

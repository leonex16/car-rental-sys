using CarRentalSys.Application.Abstractions.Email;

namespace CarRentalSys.Infrastructure.Abstractions.Email;

internal sealed class EmailService : IEmailService
{
  public Task SendAsync(string email, string recipient, string body)
  {
    Console.WriteLine($"Email: {email}");
    Console.WriteLine($"Recipient: {recipient}");
    Console.WriteLine($"Body: {body}");
    Console.WriteLine("Successfully Sent!");
    return Task.CompletedTask;
  }
}

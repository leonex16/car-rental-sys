using CarRentalSys.Application.Abstractions.Email;
using CarRentalSys.Domain.Core.Rents;
using CarRentalSys.Domain.Core.Rents.Events;
using CarRentalSys.Domain.Core.Users;
using MediatR;

namespace CarRentalSys.Application.Core.Rent.Reserve;

public sealed class ReserveDomainEventHandler(
  IRentRepository rentRepository,
  IUserRepository userRepository,
  IEmailService emailService)
  : INotificationHandler<Reserved>
{
  public async Task Handle(Reserved notification, CancellationToken cancellationToken)
  {
    var rent = await rentRepository.GetByIdAsync(notification.Identifier, cancellationToken);
    if (rent is null) return;

    var user = await userRepository.GetByIdAsync(rent.UserId, cancellationToken);
    if (user is null) return;

    await emailService.SendAsync(user.Email, "Rental Successfully Reserved!", "Enjoy!");
  }
}

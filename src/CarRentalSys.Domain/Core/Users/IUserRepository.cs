namespace CarRentalSys.Domain.Core.Users;

public interface IUserRepository
{
  Task<User?> GetByIdAsync(Guid identifier, CancellationToken cancellationToken = default);
  void Add(User user);
}
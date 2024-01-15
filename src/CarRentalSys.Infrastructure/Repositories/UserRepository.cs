using CarRentalSys.Domain.Core.Users;

namespace CarRentalSys.Infrastructure.Repositories;

public sealed class UserRepository(ApplicationDbContext dbContext) : Repository<User>(dbContext), IUserRepository;

using CarRentalSys.Domain.Abstractions;
using CarRentalSys.Domain.Core.Rents;
using CarRentalSys.Domain.Core.Rents.Enums;
using CarRentalSys.Domain.Core.Reviews.Events;

namespace CarRentalSys.Domain.Core.Reviews;

public sealed class Review : Entity
{
  public Guid RentId { get; private set; }
  public Guid VehicleId { get; private set; }
  public int Rating { get; private set; }
  public string Comment { get; private set; }
  public DateTime CreatedAt { get; private set; }

  private Review(Guid rentId, Guid vehicleId, int rating, string comment, DateTime createdAt)
  {
    RentId = rentId;
    VehicleId = vehicleId;
    Rating = rating;
    Comment = comment;
    CreatedAt = createdAt;

    AddDomainEvent(new Created(Identifier));
  }

  public static Result<Review> Create(Rent rent, int rating, string comment, DateTime createdAt)
  {
    if (rent.Status != Status.Completed) return Result.Failure<Review>(Errors.NotEligible);

    var review = new Review(rent.Identifier, rent.VehicleId, rating, comment, createdAt);

    return Result.Success(review);
   }
}

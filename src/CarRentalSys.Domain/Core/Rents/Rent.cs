using CarRentalSys.Domain.Abstractions;
using CarRentalSys.Domain.Core.Rents.Enums;
using CarRentalSys.Domain.Core.Rents.Events;
using CarRentalSys.Domain.Core.Rents.ValueObjects;

namespace CarRentalSys.Domain.Core.Rents;

public sealed class Rent : Entity
{
  public Guid UserId { get; private set; }
  public Guid VehicleId { get; private set; }
  public DetailPrice DetailPrice { get; private set; }
  public DateTime CreatedAt { get; private set; }
  public DateTime? CancellationAt { get; private set; }
  public DateTime? RejectedAt { get; private set; }
  public DateTime? ConfirmedAt { get; private set; }
  public DateTime? CompletedAt { get; private set; }
  public DateRange Range { get; private set; }
  public Status Status { get; private set; }

  private Rent(Guid userId,
    Guid vehicleId,
    DetailPrice detailPrice,
    DateTime createdAt,
    DateRange range,
    Status status)
  {
    UserId = userId;
    VehicleId = vehicleId;
    DetailPrice = detailPrice;
    CreatedAt = createdAt;
    Range = range;
    Status = status;

    AddDomainEvent(new Reserved(Identifier));
  }
  
  public static Rent Create(Guid userId, Guid vehicleId,DetailPrice detailPrice,DateRange range)
  {
    
    var rent = new Rent(userId, vehicleId, detailPrice, DateTime.UtcNow, range, Status.Reserved);

    return rent;
  }

  public Result Confirm(DateTime utcNow)
  {
    if (this.Status != Status.Reserved) return Result.Failure(Errors.NotReserved);

    this.Status = Status.Confirmed;
    this.ConfirmedAt = utcNow;

    AddDomainEvent(new Confirmed(Identifier));

    return Result.Success();
  }
  
  public Result Reject(DateTime utcNow)
  {
    if (this.Status != Status.Reserved) return Result.Failure(Errors.NotReserved);

    this.Status = Status.Rejected;
    this.RejectedAt = utcNow;

    AddDomainEvent(new Rejected(Identifier));

    return Result.Success();
  }
  
  public Result Cancel(DateTime utcNow)
  {
    if (this.Status != Status.Confirmed) return Result.Failure(Errors.NotConfirmed);

    this.Status = Status.Cancelled;
    this.CancellationAt = utcNow;

    var currentDate = DateOnly.FromDateTime(utcNow);

    if (currentDate > Range.From) Result.Failure(Errors.AlreadyStarted);

    AddDomainEvent(new Cancelled(Identifier));

    return Result.Success();
  }
  
  public Result Complete(DateTime utcNow)
  {
    if (this.Status != Status.Confirmed) return Result.Failure(Errors.NotConfirmed);

    this.Status = Status.Completed;
    this.CompletedAt = utcNow;

    AddDomainEvent(new Completed(Identifier));

    return Result.Success();
  }
}

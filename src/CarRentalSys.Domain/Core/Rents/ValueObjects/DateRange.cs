namespace CarRentalSys.Domain.Core.Rents.ValueObjects;

public record DateRange
{
  public static DateRange Create(DateTime from, DateTime to)
  {
    if (from < to) return new DateRange(DateOnly.FromDateTime(from), DateOnly.FromDateTime(to));
    throw new ApplicationException("The end date cannot be earlier than the start date");
  }

  public static DateRange Create(DateOnly from, DateOnly to)
  {
    if (from < to) return new DateRange(from, to);
    throw new ApplicationException("The end date cannot be earlier than the start date");
  }

  private DateRange(DateOnly From, DateOnly To)
  {
    this.From = From;
    this.To = To;
  }

  public DateOnly From { get; init; }
  public DateOnly To { get; init; }

  public int DiffDays => To.DayNumber - From.DayNumber;
};


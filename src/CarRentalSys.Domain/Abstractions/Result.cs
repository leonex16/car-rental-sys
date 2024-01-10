using System.Diagnostics.CodeAnalysis;

namespace CarRentalSys.Domain.Abstractions;

public class Result
{
  public bool IsSuccess { get; }
  public bool IsFailure => !IsSuccess;
  public Error Error { get; }

  protected Result(bool isSuccess, Error error)
  {
    if (isSuccess && error != Error.None)
    {
      throw new InvalidOperationException();
    }

    if (isSuccess == false && error == Error.None)
    {
      throw new InvalidOperationException();
    }

    IsSuccess = isSuccess;
    Error = error;
  }

  public static Result Success() => new(true, Error.None);
  
  public static Result<TValue> Success<TValue>(TValue value) => new(true, Abstractions.Error.None, value);

  public static Result Failure(Error error) => new(false, error);

  public static Result<TValue> Failure<TValue>(Error error) => new(false, error, default!);

  public static Result<TValue> Create<TValue>(TValue? value) =>
    value is not null
      ? Success<TValue>(value)
      : Failure<TValue>(Error.NullValue);
}

public class Result<TValue> : Result
{
  private readonly TValue _value;

  protected internal Result(bool isSuccess, Error error, TValue value) : base(isSuccess, error)
  {
    _value = value;
  }

  [MemberNotNull]
  public TValue Value => IsSuccess ? _value : throw new InvalidOperationException();

  public static implicit operator Result<TValue>(TValue value) => Create(value);
}

using LaYumba.Functional;

namespace FP._2.fp_pattern;

public static class Errors
{
    public static InvalidBic InvalidBic => new InvalidBic();
    public static TransferDateIsPast TransferDateIsPast => new TransferDateIsPast();
}

public sealed class InvalidBic : Error
{
    public override string Message { get; } ="InvalidBic";
}

public sealed class TransferDateIsPast : Error
{
    public override string Message { get; } ="TransferDateIsPast";
}
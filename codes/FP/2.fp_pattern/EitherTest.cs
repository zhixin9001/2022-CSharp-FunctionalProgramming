using LaYumba.Functional;
using static System.Console;
using static LaYumba.Functional.F;

namespace FP._2.fp_pattern;

public class EitherTest
{
    public static void Entry()
    {
        // WriteLine(Right(12));
        // WriteLine(Left("oops"));
        
        // WriteLine(Render(Right(12d)));
        // WriteLine(Render(Left("oops")));
        // WriteLine(Render(12d));
        // WriteLine(Render("oops"));
        
        WriteLine(Calc(3,0));
        WriteLine(Calc(3,-3));
        WriteLine(Calc(27,3));

        
    }
    
    private Func<Candidate, bool> IsEligible;
    private Func<Candidate, Either<Rejection, Candidate>> TechTest;
    private Func<Candidate, Either<Rejection, Candidate>> Interview;

    Either<Rejection, Candidate> CheckEligibility(Candidate c)
        => IsEligible(c) ? c : new Rejection("Not eligible");

    Either<Rejection, Candidate> Recruit(Candidate c)
        => Right(c)
            .Bind(CheckEligibility)
            .Bind(TechTest)
            .Bind(Interview);

    static string Render(Either<string, double> val)
        => val.Match(
            Left: l => $"Invalid value: {l}",
            Right: r => $"The result is: {r}");

    static Either<string, double> Calc(double x, double y)
    {
        if (y == 0) return "y cannot be 0";
        if (x != 0 && Math.Sign(x) != Math.Sign(y))
            return "x/y cannot be negative";
        return Math.Sqrt(x / y);
    }
}

public class Candidate
{
}

public class Rejection
{
    public Rejection(string reason)
    {
        reason = reason;
    }
    public string reason { get; }
}
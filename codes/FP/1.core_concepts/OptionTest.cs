using FP.ZhiXin.FP;
namespace FP;
using static Console;

public class OptionTest
{
    public static void AgeCompare()
    {
        WriteLine(new Age(32) > new Age(33));
    }

    public static void Entry()
    {
        Option.
    }
}



public class Age
{
    public Age(int age)
    {
        Value = age;
    }

    private int Value { get; }

    public static bool operator <(Age l, Age r)
        => l.Value < r.Value;

    public static bool operator >(Age l, Age r)
        => l.Value > r.Value;

    public static bool operator <(Age l, int r)
        => l < new Age(r);

    public static bool operator >(Age l, int r)
        => l > new Age(r);
}
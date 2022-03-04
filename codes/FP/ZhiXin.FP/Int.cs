namespace LaYumba.Functional;

using static LaYumba.Functional.F;

public static class Int
{
    public static Option<int> Parse(string s)
        => int.TryParse(s, out var result)
            ? Some(result)
            : None;
}
using System.Collections.Immutable;
using FP;

namespace LaYumba.Functional;
using Unit = System.ValueTuple;

public static partial class F
{
    public static Unit Unit() => default(Unit);
    
    
    public static IEnumerable<T> List<T>(params T[] items)
        => items.ToImmutableList();
    
}
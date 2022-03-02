using System.Diagnostics;
using FP.ZhiXin.FP;

namespace FP;
using static Console;

public class UnitTest
{
    public static void Entry()
    {
        // var a = Time<int>(() => 1);
        // Time(() => WriteLine("aaaa"));
        var unit=F.Unit();
        Action action = () => WriteLine("aaaa");
        Time(action.ToFunc());
        
    }

    public static T Time<T>(Func<T> f)
    {
        var sw = new Stopwatch();
        sw.Start();
        T t = f();

        sw.Stop();
        WriteLine($"Elapsed {sw.ElapsedMilliseconds}ms");
        return t;
    }
    
    public static void Time(Action f)
    {
        var sw = new Stopwatch();
        sw.Start();
        f();

        sw.Stop();
        WriteLine($"Elapsed {sw.ElapsedMilliseconds}ms");
    }
}

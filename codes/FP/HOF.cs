namespace FP;

using static System.Linq.Enumerable;
using static System.Console;

public class HOF
{
    public static void CreateFunc()
    {
        Func<int, bool> isMod(int n) => i => i % n == 0;
        var a = Range(1, 20).Where(isMod(2));
        a = Range(1, 20).Where(isMod(3));
        foreach (var i in a)
        {
            WriteLine(i);
        }
    }

    public static void RemoveDuplicate()
    {
        string path = "";

        Action<FileStream> readFile = sw => { sw.Read(null); };

        using (var sw = File.OpenRead(path))
        {
            readFile(sw);
        }


        Using(File.OpenRead(path), readFile);
    }


    static void Using<TDisp>(TDisp disposable, Action<TDisp> f) where TDisp : IDisposable
    {
        using (disposable) f(disposable);
    }
}
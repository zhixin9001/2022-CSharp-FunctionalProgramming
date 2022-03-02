namespace FP;
using static System.Linq.Enumerable;
using static System.Console;

public class ParallelCode
{
    public static void Format()
    {
        var shoppingList = new List<string>()
        {
            "coffee beans",
            "BANANAs",
            "Loulian"
        };
        
        // new ListFormatter().Format(shoppingList).ForEach(WriteLine);
         // ListFormatter.Format1(shoppingList).ForEach(WriteLine);
         ListFormatter.Format2(shoppingList).ForEach(WriteLine);
    }
}

class ListFormatter
{
    private int counter;

    string template(string s) => $"{++counter}. {s}";

    public List<string> Format(List<string> list)
        => list
            // .Select(StringExt.ToSentenceCase)
            // .AsParallel()
            .Select(template).ToList();

    public static List<string> Format1(List<string> list)
    {
        var right = list.Select(StringExt.ToSentenceCase);
        var left = Range(1, list.Count);
        var zipped = Enumerable.Zip(left, right, (l, r) => $"{l}. {r}");
        return zipped.ToList();
    }

    public static List<string> Format2(List<string> list)
        => list.AsParallel().Select(StringExt.ToSentenceCase)
            .Zip(ParallelEnumerable.Range(1, list.Count), (l, r) => $"{r}. {l}")
            .ToList();
}

static class StringExt
{
    public static string ToSentenceCase(this string s)
        => s.ToUpper()[0] + s.ToLower().Substring(1);
}
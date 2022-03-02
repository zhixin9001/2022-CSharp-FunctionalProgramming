namespace FP;

public class Pure
{
    public static int ComputeTotal(List<int> orders, List<int> tobeRemoved)
    {
        var sum = 0;
        orders.ForEach(o =>
        {
            if (o == 0)
            {
                tobeRemoved.Add(o);
            }
            else
            {
                sum += o;
            }
        });
        return sum;
    }

    public static (int, List<int> tobeRemoved) ComputeTotal1(List<int> order) =>
        (order.Sum(o => o), order.Where(o => o == 0).ToList());
    
    
}

public interface ISortAlg
{
    void Sort(int[] arr);
}

public class SortStrategy
{
    public ISortAlg SortAlg { get; set; }
    public SortStrategy(ISortAlg sortAlg)
    {
        this.SortAlg = sortAlg;
    }

    public void Sort(int[] arr)
    {
        SortAlg?.Sort(arr);
    }
}
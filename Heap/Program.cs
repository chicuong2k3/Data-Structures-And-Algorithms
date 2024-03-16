
public class Program
{
    public static void Main() 
    {
        
        var q = TopKElements(new List<int>() { 4, 7, 14, 2, 9, 6 }, 3);
        System.Console.WriteLine(q.Peek());
        q.Dequeue();
        System.Console.WriteLine(q.Peek());
        q.Dequeue();
        System.Console.WriteLine(q.Peek());

    }

    static PriorityQueue<int, int> TopKElements(List<int> arr, int k)
    {
        var pQueue = new PriorityQueue<int, int>();
        for (int i = 0; i < k; i++)
        {
            pQueue.Enqueue(arr[i], arr[i]);
        }

        for (int i = k; i < arr.Count(); i++)
        {
            if (arr[i] > pQueue.Peek())
            {
                pQueue.Dequeue();
                pQueue.Enqueue(arr[i], arr[i]);
            }
        }

        return pQueue;
    }
}


public class Program
{
    public static void Main() 
    {
       var graph = new AdjMatGraph(new int[] { 0, 1, 2, 3, 4 });
        graph.AddVertex(5);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 4);
        graph.AddEdge(4, 5);
        graph.RemoveEdge(5, 4);
        graph.RemoveVertex(1);
        graph.Print();
    }

}

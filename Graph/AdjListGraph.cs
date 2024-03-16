

public class AdjMatGraph
{
    List<int> vertices;
    List<List<int>> adjMat;
    public AdjMatGraph(int[] vertices)
    {


    }

    public int Size() => vertices.Count();
    public void AddVertex(int v)
    {
        
    }

    public void RemoveVertex(int index)
    {
        
    }

    public void AddEdge(int i, int j)
    {
        
    }

    public void RemoveEdge(int i, int j)
    {
        
    }

    public void Print()
    {
        foreach (var row in adjMat)
        {
            foreach (var v in row)
            {
                System.Console.Write($"{v} ");
            }
            System.Console.WriteLine();
        }
        System.Console.WriteLine();
    }

}
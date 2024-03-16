

public class AdjMatGraph
{
    List<int> vertices;
    List<List<int>> adjMat;
    public AdjMatGraph(int[] vertices)
    {
        this.vertices = new List<int>();
        adjMat = new List<List<int>>();
        foreach (var v in vertices)
        {
            AddVertex(v);
        }

    }

    public int Size() => vertices.Count();
    public void AddVertex(int v)
    {
        var n = Size();
        vertices.Add(v);
        var newRow = new List<int>();
        
        for (int i = 0; i < n; i++)
        {
            newRow.Add(0);
        }

        adjMat.Add(newRow);

        foreach (var row in adjMat)
        {
            row.Add(0);
        }
    }

    public void RemoveVertex(int index)
    {
        if (index >= Size()) throw new IndexOutOfRangeException();
        
        vertices.RemoveAt(index);
        adjMat.RemoveAt(index);

        foreach (var row in adjMat)
        {
            row.RemoveAt(index);
        }
    }

    public void AddEdge(int i, int j)
    {
        if (i < 0 || j < 0 || i >= Size() || j >= Size() || i == j) 
            throw new IndexOutOfRangeException();

        adjMat[i][j] = 1;
        adjMat[j][i] = 1;
    }

    public void RemoveEdge(int i, int j)
    {
        if (i < 0 || j < 0 || i >= Size() || j >= Size() || i == j) 
            throw new IndexOutOfRangeException();

        adjMat[i][j] = 0;
        adjMat[j][i] = 0;
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
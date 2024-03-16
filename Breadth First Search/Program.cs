
public class Program
{
    public static void Main() 
    {
        var tree = new BinarySearchTree();
        tree.Add(3);
        tree.Add(2);
        tree.Add(7);
        tree.Add(5);
        tree.Add(4);
        tree.Add(8);
        tree.Add(1);
        tree.Add(0);
        tree.Add(6);

        tree.Remove(5);
        foreach (var item in LevelOrder(tree.Root))
        {
            System.Console.Write($"{item} ");
        }
    }

    public static List<int> LevelOrder(TreeNode root)
    {
        var result = new List<int>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count() > 0)
        {
            var node = queue.Dequeue();
            result.Add(node.Data);
            if (node.Left != null)
            {
                queue.Enqueue(node.Left);
            }

            if (node.Right != null)
            {
                queue.Enqueue(node.Right);
            }
        }
        return result;
    }
}

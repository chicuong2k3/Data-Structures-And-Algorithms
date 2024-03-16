

public class TreeNode
{
    public int Data { get; set; }
    public TreeNode? Left { get; set; }
    public TreeNode? Right { get; set; }
    public TreeNode(int val)
    {
        Left = null;
        Right = null;
        Data = val;
    }
}
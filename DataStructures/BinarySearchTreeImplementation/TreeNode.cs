namespace DataStructures.BinarySearchTreeImplementation
{
    public class TreeNode
    {
        public int Key { get; set; }
        public TreeNode? Parent { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }
        public TreeNode(int key, TreeNode? parent = null, TreeNode? left = null, TreeNode? right = null)
        {
            Key = key;
            Parent = parent;
            Left = left;
            Right = right;
        }
    }
}

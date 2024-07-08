using DataStructures.BinarySearchTreeImplementation;

namespace DataStructures.Abstracts
{
    public abstract class TreeNode
    {
        public int Key { get; set; }
        public TreeNode? Parent { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }
    }
}

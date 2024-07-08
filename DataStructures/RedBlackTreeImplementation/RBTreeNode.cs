using DataStructures.Abstracts;

namespace DataStructures.RedBlackTreeImplementation
{
    public class RBTreeNode : TreeNode
    {
        public bool IsRed { get; set; }
        public RBTreeNode(int key, RBTreeNode? parent = null, RBTreeNode? left = null, RBTreeNode? right = null)
        {
            Key = key;
            Parent = parent;
            Left = left;
            Right = right;
            IsRed = true;
        }

        public override string ToString()
        {
            var colour = IsRed ? "R" : "B";
            return $"{Key}({colour})";
        }
    }

}

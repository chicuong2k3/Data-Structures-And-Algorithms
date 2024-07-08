using DataStructures.Abstracts;

namespace DataStructures.BinarySearchTreeImplementation
{
    public class BSTTreeNode : TreeNode
    {
        
        public BSTTreeNode(int key, BSTTreeNode? parent = null, BSTTreeNode? left = null, BSTTreeNode? right = null)
        {
            Key = key;
            Parent = parent;
            Left = left;
            Right = right;
        }

        public override string ToString()
        {
            return Key.ToString();
        }
    }
}

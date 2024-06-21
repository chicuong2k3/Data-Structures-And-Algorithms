using DataStructures.BinarySearchTreeImplementation;

namespace DataStructures.BinarySearchTree
{
    public class BST
    {
        public TreeNode? Root { get; set; }
        public BST(TreeNode? root = null)
        {
            Root = root;
        }

        private TreeNode GetMinNode(TreeNode subtreeRoot)
        {
            while (subtreeRoot.Left != null)
            {
                subtreeRoot = subtreeRoot.Left;
            }

            return subtreeRoot;
        }
        private TreeNode GetMaxNode(TreeNode subtreeRoot)
        {
            while (subtreeRoot.Right != null)
            {
                subtreeRoot = subtreeRoot.Right;
            }

            return subtreeRoot;
        }

        private TreeNode? GetSuccessor(TreeNode node)
        {
            if (node.Right != null) return GetMinNode(node.Right);

            TreeNode? accessor = node.Parent;
            while (accessor != null && node == accessor.Right)
            {
                node = accessor;
                accessor = accessor.Parent;
            }

            return accessor;
        }
        private TreeNode? GetPredecessor(TreeNode node)
        {
            if (node.Left != null) return GetMaxNode(node.Left);

            TreeNode? accessor = node.Parent;
            while (accessor != null && node == accessor.Left)
            {
                node = accessor;
                accessor = accessor.Parent;
            }

            return accessor;
        }
        public TreeNode? Find(int key)
        {
            TreeNode? temp = Root;
            while (temp != null && temp.Key != key)
            {
                if (temp.Key > key) temp = temp.Left;
                else temp = temp.Right;
            }

            return temp;
        }

        public void Insert(TreeNode node)
        {
            TreeNode? prev = null;
            TreeNode? temp = Root;
            while (temp != null)
            {
                prev = temp;
                if (temp.Key > node.Key) temp = temp.Left;
                else if (temp.Key < node.Key) temp = temp.Right;
                else throw new Exception("Key duplicate exception.");
            }

            node.Parent = prev;

            if (prev == null)
            {
                Root = node;
            }
            else if (prev.Key > node.Key) prev.Left = node;
            else prev.Right = node;
        }

        public void Delete(TreeNode node)
        {
            TreeNode? temp = Root;
        }

        private void InorderTravesalHelper(TreeNode? node, Action<TreeNode> action)
        {
            if (node != null)
            {
                InorderTravesalHelper(node.Left, action);
                action(node);
                InorderTravesalHelper(node.Right, action);
            }

        }
        public void InorderTravesal(Action<TreeNode> action)
        {
            InorderTravesalHelper(Root, action);
        }
    }
}

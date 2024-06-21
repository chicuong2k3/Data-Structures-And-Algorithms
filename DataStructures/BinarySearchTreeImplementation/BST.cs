namespace DataStructures.BinarySearchTreeImplementation
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

        private void ReplaceSubtree(TreeNode node1, TreeNode? node2)
        {
            if (node1.Parent == null) Root = node2;
            else if (node1 == node1.Parent.Left) // if node1 is left child of its parent
            {
                node1.Parent.Left = node2;
            }
            else // if node1 is right child of its parent
            {
                node1.Parent.Right = node2;
            }

            if (node2 != null) node2.Parent = node1.Parent;
        }

        public void Delete(TreeNode node)
        {

            if (node.Left == null) // Case 1: node has no left child (right child maybe null).
            {
                ReplaceSubtree(node, node.Right);
            }
            else if (node.Right == null) // Case 2: node has only one child and this child is its left child.
            {
                ReplaceSubtree(node, node.Left);
            }
            else // Case 3: node has both left child and right child.
            {

                TreeNode? successor = GetSuccessor(node);

                // in this case, successor cannot be null
                if (successor != null) // this check only helps avoid warnings
                {
                    // if successor is right child of node, then replace node by it
                    if (successor.Parent == node)
                    {
                        ReplaceSubtree(node, successor);
                        successor.Left = node.Left;
                        successor.Left.Parent = successor;
                    }
                    else // if successor isn't right child of node
                    {
                        // and it's also not left child of node
                        if (successor.Parent != node)
                        {
                            ReplaceSubtree(successor, successor.Right);
                            successor.Right = node.Right;
                            successor.Right.Parent = successor;

                            // set successor to be child of node's parent
                            ReplaceSubtree(node, successor);

                            // set successor to be parent of the left child of node
                            successor.Left = node.Left;
                            successor.Left.Parent = successor;
                        }
                    }
                }
            }
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

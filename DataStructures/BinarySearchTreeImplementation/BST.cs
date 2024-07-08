using DataStructures.RedBlackTreeImplementation;

namespace DataStructures.BinarySearchTreeImplementation
{
    public class BST
    {
        public BSTTreeNode? Root { get; set; }
        public BST(BSTTreeNode? root = null)
        {
            Root = root;
        }

        private BSTTreeNode GetMinNode(BSTTreeNode? subtreeRoot)
        {
            while (subtreeRoot!.Left != null)
            {
                subtreeRoot = subtreeRoot.Left as BSTTreeNode;
            }

            return subtreeRoot;
        }
        private BSTTreeNode GetMaxNode(BSTTreeNode? subtreeRoot)
        {
            while (subtreeRoot!.Right != null)
            {
                subtreeRoot = subtreeRoot.Right as BSTTreeNode;
            }

            return subtreeRoot;
        }

        private BSTTreeNode? GetSuccessor(BSTTreeNode node)
        {
            if (node.Right != null) return GetMinNode(node.Right as BSTTreeNode);

            BSTTreeNode? accessor = node.Parent as BSTTreeNode;
            while (accessor != null && node == accessor.Right)
            {
                node = accessor;
                accessor = accessor.Parent as BSTTreeNode;
            }

            return accessor;
        }
        private BSTTreeNode? GetPredecessor(BSTTreeNode node)
        {
            if (node.Left != null) return GetMaxNode(node.Left as BSTTreeNode);

            BSTTreeNode? accessor = node.Parent as BSTTreeNode;
            while (accessor != null && node == accessor.Left)
            {
                node = accessor;
                accessor = accessor.Parent as BSTTreeNode;
            }

            return accessor;
        }
        public BSTTreeNode? Find(int key)
        {
            BSTTreeNode? temp = Root;
            while (temp != null && temp.Key != key)
            {
                if (temp.Key > key) temp = temp.Left as BSTTreeNode;
                else temp = temp.Right as BSTTreeNode;
            }

            return temp;
        }

        public void Insert(BSTTreeNode node)
        {
            BSTTreeNode? prev = null;
            BSTTreeNode? temp = Root;
            while (temp != null)
            {
                prev = temp;
                if (temp.Key > node.Key) temp = temp.Left as BSTTreeNode;
                else if (temp.Key < node.Key) temp = temp.Right as BSTTreeNode;
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

        private void ReplaceSubtree(BSTTreeNode node1, BSTTreeNode? node2)
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

        public void Delete(BSTTreeNode node)
        {

            if (node.Left == null) // Case 1: node has no left child (right child maybe null).
            {
                ReplaceSubtree(node, node.Right as BSTTreeNode);
            }
            else if (node.Right == null) // Case 2: node has only one child and this child is its left child.
            {
                ReplaceSubtree(node, node.Left as BSTTreeNode);
            }
            else // Case 3: node has both left child and right child.
            {

                BSTTreeNode? successor = GetSuccessor(node);

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
                            ReplaceSubtree(successor, successor.Right as BSTTreeNode);
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

        private void InorderTravesalHelper(BSTTreeNode? node, Action<BSTTreeNode> action)
        {
            if (node != null)
            {
                InorderTravesalHelper(node.Left as BSTTreeNode, action);
                action(node);
                InorderTravesalHelper(node.Right as BSTTreeNode, action);
            }

        }
        public void InorderTravesal(Action<BSTTreeNode> action)
        {
            InorderTravesalHelper(Root, action);
        }
    }
}

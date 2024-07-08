namespace DataStructures.TreapImplementation
{
    public class Treap
    {
        public TreapNode? Root { get; set; }

        public Treap(TreapNode? root = null)
        {
            Root = root;
        }

        private void RotateLeft(TreapNode node)
        {
            TreapNode? rightChild = node.Right as TreapNode;
            if (rightChild == null)
                throw new ArgumentException("The node must have right child to perform left rotation.");

            // turn left subtree of right child into right subtree of node
            node.Right = rightChild.Left;
            if (rightChild.Left != null)
            {
                rightChild.Left.Parent = node;
            }

            rightChild.Parent = node.Parent;
            // if node is Root
            if (node.Parent == null)
            {
                Root = rightChild;
            }
            else if (node == node.Parent.Left) // if node is the left child of its parent
            {
                node.Parent.Left = rightChild;
            }
            else // if node is the left child of its parent
            {
                node.Parent.Right = rightChild;
            }

            // turn node into left child of the rightChild
            rightChild.Left = node;
            node.Parent = rightChild;
        }

        private void RotateRight(TreapNode node)
        {
            TreapNode? leftChild = node.Left as TreapNode;
            if (leftChild == null)
                throw new ArgumentException("The node must have left child to perform right rotation.");

            // turn right subtree of left child into left subtree of node
            node.Left = leftChild.Right;
            if (leftChild.Right != null)
            {
                leftChild.Right.Parent = node;
            }

            leftChild.Parent = node.Parent;
            // if node is Root
            if (node.Parent == null)
            {
                Root = leftChild;
            }
            else if (node == node.Parent.Left) // if node is the left child of its parent
            {
                node.Parent.Left = leftChild;
            }
            else // if node is the left child of its parent
            {
                node.Parent.Right = leftChild;
            }

            // turn node to right child of the leftChild
            leftChild.Right = node;
            node.Parent = leftChild;
        }

        // Like search in BST
        public TreapNode? Find(int key)
        {
            TreapNode? temp = Root;
            while (temp != null && temp.Key != key)
            {
                if (temp.Key > key) temp = temp.Left as TreapNode;
                else temp = temp.Right as TreapNode;
            }

            return temp;
        }

        public void Insert(TreapNode node)
        {
            // Stardard BST insert
            TreapNode? prev = null;
            TreapNode? temp = Root;
            while (temp != null)
            {
                prev = temp;
                if (temp.Key > node.Key) temp = temp.Left as TreapNode;
                else if (temp.Key < node.Key) temp = temp.Right as TreapNode;
                else throw new Exception("Key duplicate exception.");
            }

            node.Parent = prev;

            if (prev == null)
            {
                Root = node;
            }
            else if (prev.Key > node.Key) prev.Left = node;
            else prev.Right = node;

            // Move up by rotating node
            var parent = node.Parent as TreapNode;
            while (parent != null && node.Priority < parent.Priority)
            {
                if (node == parent.Left)
                {
                    RotateRight(parent);
                }
                else
                {
                    RotateLeft(parent);
                }

            }

        }

        public void Delete(TreapNode node)
        {
            while (node.Left != null || node.Right != null)
            {
                if (node.Left != null && node.Right  != null)
                {
                    var left = node.Left as TreapNode;
                    var right = node.Right as TreapNode;
                    if (left!.Priority < right!.Priority)
                    {
                        RotateRight(node);
                    }
                    else
                    {
                        RotateLeft(node);
                    }
                }
                else if (node.Left != null)
                {
                    RotateRight(node);
                }
                else
                {
                    RotateLeft(node);
                }
            }
        }

        public void Split()
        {

        }

        public void Merge()
        {

        }
    }
}

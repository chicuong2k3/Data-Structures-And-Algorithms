namespace DataStructures.RedBlackTreeImplementation
{
    public class RedBlackTree
    {
        public RBTreeNode? Root { get; set; }
        private void RotateLeft(RBTreeNode? node)
        {
            if (node == null) return;

            RBTreeNode? rightChild = node.Right as RBTreeNode;
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

        private void RotateRight(RBTreeNode? node)
        {
            if (node == null) return;

            RBTreeNode? leftChild = node.Left as RBTreeNode;
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

        public RBTreeNode? Find(int key)
        {
            RBTreeNode? temp = Root;
            while (temp != null && temp.Key != key)
            {
                if (temp.Key > key) temp = temp.Left as RBTreeNode;
                else temp = temp.Right as RBTreeNode;
            }

            return temp;
        }

        private void InsertFixUp(RBTreeNode newNode)
        {
            RBTreeNode? parent = newNode.Parent as RBTreeNode;

            // the parent is red
            while (parent!.IsRed)
            {
                // the parent cannot be the root because the root must be black
                // so the node must have a grandparent 
                RBTreeNode? grandparent = parent!.Parent as RBTreeNode;

                // because parent is red, the grandparent must be black

                if (parent == (grandparent!.Left as RBTreeNode))
                {
                    RBTreeNode? uncle = grandparent!.Right as RBTreeNode;

                    // uncle is red
                    if (uncle != null && uncle!.IsRed)
                    {
                        grandparent.IsRed = true; 
                        parent.IsRed = false;
                        uncle.IsRed = false;
                    }
                    // uncle is black
                    else
                    {
                        if (newNode == (parent.Right as RBTreeNode))
                        {
                            newNode = parent;
                            RotateLeft(newNode);
                        }
                        (newNode.Parent as RBTreeNode)!.IsRed = false;
                        (newNode.Parent.Parent as RBTreeNode)!.IsRed = true;

                        RotateRight(newNode.Parent.Parent as RBTreeNode);
                    }
                }
                else
                {
                    RBTreeNode? uncle = grandparent!.Left as RBTreeNode;

                    // uncle is red
                    if (uncle != null && uncle!.IsRed)
                    {
                        grandparent.IsRed = true;
                        parent.IsRed = false;
                        uncle.IsRed = false;
                    }
                    // uncle is black
                    else
                    {
                        if (newNode == (parent.Left as RBTreeNode))
                        {
                            newNode = parent;
                            RotateRight(newNode);
                        }
                        (newNode.Parent as RBTreeNode)!.IsRed = false;
                        (newNode.Parent.Parent as RBTreeNode)!.IsRed = true;
                        RotateLeft(newNode.Parent.Parent as RBTreeNode);
                    }
                }
            }


            Root!.IsRed = false;
        }
        public void Insert(RBTreeNode node)
        {

            // note: the inserted node is always red

            // perform stardard BST insert
            RBTreeNode? prev = null;
            RBTreeNode? temp = Root;
            while (temp != null)
            {
                prev = temp;
                if (temp.Key > node.Key) temp = temp.Left as RBTreeNode;
                else if (temp.Key < node.Key) temp = temp.Right as RBTreeNode;
                else throw new Exception("Key duplicate exception.");
            }

            node.Parent = prev;

            if (prev == null)
            {
                Root = node;
            }
            else if (prev.Key > node.Key) prev.Left = node;
            else prev.Right = node;

            if (node.Parent == null)
            {
                node.IsRed = false;
                return;
            }

            InsertFixUp(node);

        }

    }
}

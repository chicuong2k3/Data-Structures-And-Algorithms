namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BST<int> binarySearchTree = new BST<int>(new TreeNode<int>(10));

            binarySearchTree.Insert(8);
            binarySearchTree.Insert(5);
            binarySearchTree.Insert(7);

            binarySearchTree.Insert(16);
            binarySearchTree.Insert(12);
            binarySearchTree.Insert(15);
            binarySearchTree.Insert(14);
            binarySearchTree.Insert(11);

            //var found = binarySearchTree.Find(8);

            //if (found != null)
            //{
            //    Console.WriteLine(found.Value);
            //}

            binarySearchTree.InorderTravesal((node) =>
            {
                Console.WriteLine(node.Key);
            });
        }
    }
}

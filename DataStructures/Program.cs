

using DataStructures.BinarySearchTreeImplementation;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BST binarySearchTree = new BST(new TreeNode(10));

            binarySearchTree.Insert(new TreeNode(8));
            binarySearchTree.Insert(new TreeNode(5));
            binarySearchTree.Insert(new TreeNode(7));

            binarySearchTree.Insert(new TreeNode(18));
            binarySearchTree.Insert(new TreeNode(12));
            binarySearchTree.Insert(new TreeNode(15));
            binarySearchTree.Insert(new TreeNode(14));
            binarySearchTree.Insert(new TreeNode(11));
            binarySearchTree.Insert(new TreeNode(6));
            binarySearchTree.Insert(new TreeNode(17));
            binarySearchTree.Insert(new TreeNode(16));

            Console.Write("Before deleting: ");
            binarySearchTree.InorderTravesal((node) =>
            {
                Console.Write($"{node.Key} ");
            });
            Console.WriteLine();

            TreeNode? nodeToDelete = binarySearchTree.Find(12);
            if (nodeToDelete != null)
            {
                binarySearchTree.Delete(nodeToDelete);
            }

            Console.Write("After deleting:  ");
            binarySearchTree.InorderTravesal((node) =>
            {
                Console.Write($"{node.Key} ");
            });
        }
    }
}

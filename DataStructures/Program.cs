

using DataStructures.BinarySearchTreeImplementation;
using DataStructures.RedBlackTreeImplementation;
using DataStructures.TreapImplementation;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cont = true;
            while (true)
            {
                Console.WriteLine("1. Binary Search Tree");
                Console.WriteLine("2. Red-Black Tree");
                Console.WriteLine("3. Treap");
                Console.Write("Enter your choice: ");
                var choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        var binarySearchTree = new BST();
                        cont = true;
                        while (cont)
                        {
                            Console.WriteLine("BINARY SEARCH TREE");
                            Console.WriteLine("\t1. Insert a node.");
                            Console.WriteLine("\t2. Delete a node.");
                            Console.WriteLine("\t3. Exit.");
                            Console.Write("\tEnter your choice: ");
                            var c = Convert.ToInt32(Console.ReadLine());
                            switch (c)
                            {
                                case 1:
                                    Console.Write("Enter node's key: ");
                                    var insertData = Convert.ToInt32(Console.ReadLine());
                                    binarySearchTree.Insert(new BSTTreeNode(insertData));
                                    Console.Clear();
                                    binarySearchTree.Print();
                                    break;
                                case 2:
                                    Console.Write("Enter node's key: ");
                                    var deleteData = Convert.ToInt32(Console.ReadLine());
                                    var nodeToDelete = binarySearchTree.Find(deleteData);
                                    if (nodeToDelete != null)
                                    {
                                        binarySearchTree.Delete(nodeToDelete);
                                    }
                                    Console.Clear();
                                    binarySearchTree.Print();
                                    break;
                                case 3:
                                    cont = false;
                                    Console.Clear();
                                    break;
                            }
                        }
                        break;
                    case 2:
                        var rbTree = new RedBlackTree();
                        cont = true;
                        while (cont)
                        {

                            Console.WriteLine("RED-BLACK TREE");
                            Console.WriteLine("\t1. Insert a node.");
                            Console.WriteLine("\t2. Delete a node.");
                            Console.WriteLine("\t3. Exit.");
                            Console.Write("\tEnter your choice: ");
                            var c = Convert.ToInt32(Console.ReadLine());
                            switch (c)
                            {
                                case 1:
                                    Console.Write("Enter node's key: ");
                                    var insertData = Convert.ToInt32(Console.ReadLine());
                                    rbTree.Insert(new RBTreeNode(insertData));
                                    Console.Clear();
                                    rbTree.Print();
                                    break;
                                case 2:
                                    Console.Write("Enter node's key: ");
                                    var deleteData = Convert.ToInt32(Console.ReadLine());
                                    var nodeToDelete = rbTree.Find(deleteData);
                                    if (nodeToDelete != null)
                                    {
                                        //rbTree.Delete(nodeToDelete);
                                    }
                                    Console.Clear();
                                    rbTree.Print();
                                    break;
                                case 3:
                                    cont = false;
                                    Console.Clear();
                                    break;
                            }
                        }
                        break;
                    case 3:
                        var treap = new Treap();
                        cont = true;
                        while (cont)
                        {

                            Console.WriteLine("TREAP");
                            Console.WriteLine("\t1. Insert a node.");
                            Console.WriteLine("\t2. Delete a node.");
                            Console.WriteLine("\t3. Exit.");
                            Console.Write("\tEnter your choice: ");
                            var c = Convert.ToInt32(Console.ReadLine());
                            switch (c)
                            {
                                case 1:
                                    Console.Write("Enter node's key: ");
                                    var insertData = Convert.ToInt32(Console.ReadLine());
                                    treap.Insert(new TreapNode(insertData));
                                    Console.Clear();
                                    treap.Print();
                                    break;
                                case 2:
                                    Console.Write("Enter node's key: ");
                                    var deleteData = Convert.ToInt32(Console.ReadLine());
                                    var nodeToDelete = treap.Find(deleteData);
                                    if (nodeToDelete != null)
                                    {
                                        treap.Delete(nodeToDelete);
                                    }
                                    Console.Clear();
                                    treap.Print();
                                    break;
                                case 3:
                                    cont = false;
                                    Console.Clear();
                                    break;
                            }
                        }
                        break;

                }
            }
        }
    }
}

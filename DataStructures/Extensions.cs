using DataStructures.Abstracts;
using DataStructures.BinarySearchTreeImplementation;
using DataStructures.RedBlackTreeImplementation;
using DataStructures.TreapImplementation;

namespace DataStructures
{
    public static class Extensions
    {
        // Source: https://stackoverflow.com/questions/4965335/how-to-print-binary-tree-diagram-in-java
        public static void PrintNode(TreeNode? root)
        {
            int maxLevel = MaxLevel(root);
            PrintNodeInternal(new List<TreeNode?> { root }, 1, maxLevel);
        }

        private static bool IsAllElementsNull(List<TreeNode?> list)
        {
            foreach (var element in list)
            {
                if (element != null)
                    return false;
            }

            return true;
        }

        private static void PrintNodeInternal(List<TreeNode?> nodes, int level, int maxLevel)
        {
            if (nodes == null || !nodes.Any() || IsAllElementsNull(nodes))
                return;

            int floor = maxLevel - level;
            int edgeLines = (int)Math.Pow(2, Math.Max(floor - 1, 0));
            int firstSpaces = (int)Math.Pow(2, floor) - 1;
            int betweenSpaces = (int)Math.Pow(2, floor + 1) - 1;

            PrintWhitespaces(firstSpaces);

            var newNodes = new List<TreeNode?>();
            foreach (var node in nodes)
            {
                if (node != null)
                {
                    Console.Write(node.ToString());
                    newNodes.Add(node.Left);
                    newNodes.Add(node.Right);
                }
                else
                {
                    newNodes.Add(null);
                    newNodes.Add(null);
                    Console.Write(" ");
                }

                PrintWhitespaces(betweenSpaces);
            }
            Console.WriteLine();

            for (int i = 1; i <= edgeLines; i++)
            {
                for (int j = 0; j < nodes.Count; j++)
                {
                    PrintWhitespaces(firstSpaces - i);
                    if (nodes[j] == null)
                    {
                        PrintWhitespaces(edgeLines + edgeLines + i + 1);
                        continue;
                    }

                    if (nodes[j]!.Left != null)
                        Console.Write("/");
                    else
                        PrintWhitespaces(1);

                    PrintWhitespaces(i + i - 1);

                    if (nodes[j]!.Right != null)
                        Console.Write("\\");
                    else
                        PrintWhitespaces(1);

                    PrintWhitespaces(edgeLines + edgeLines - i);
                }

                Console.WriteLine();
            }

            PrintNodeInternal(newNodes, level + 1, maxLevel);
        }

        private static void PrintWhitespaces(int count)
        {
            for (int i = 0; i < count; i++)
                Console.Write(" ");
        }

        private static int MaxLevel(TreeNode? node)
        {
            if (node == null)
                return 0;

            return Math.Max(MaxLevel(node.Left), MaxLevel(node.Right)) + 1;
        }
       
        public static void Print(this BST tree)
        {
            PrintNode(tree.Root);
        }

        public static void Print(this RedBlackTree tree)
        {
            PrintNode(tree.Root);
        }

        public static void Print(this Treap tree)
        {
            PrintNode(tree.Root);
        }
    }
}

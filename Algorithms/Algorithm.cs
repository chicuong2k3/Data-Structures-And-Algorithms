namespace Algorithms
{
    public static class Algorithm
    {
        static (int, int) TwoSumHashTable(int[] arr, int target)
        {
            Dictionary<int, int> table = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (table.ContainsKey(target - arr[i])) return (i, table[target - arr[i]]);
            }
            return (-1, -1);
        }

        static (int, int) TwoSumBruteForce(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == target) return (i, j);
                }
            }
            return (-1, -1);
        }

        static int BinarySearchLeftEdge(int[] arr, int target)
        {
            int i = BinarySearchInsertion(arr, target);
            if (i == arr.Length || arr[i] != target)
            {
                return -1;
            }
            return i;
        }

        static int BinarySearchInsertion(int[] arr, int target)
        {
            int r = arr.Length - 1;
            int l = 0;
            while (r >= l)
            {
                int m = l + (r - l) / 2;
                if (arr[m] < target)
                {
                    l = m + 1;
                }
                else r = m - 1;

            }
            return l;
        }
    }
}

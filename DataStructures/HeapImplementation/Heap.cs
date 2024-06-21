namespace DataStructures.HeapImplementation
{
    public class MaxHeap
    {
        public List<int> HeapArray { get; set; }
        public MaxHeap()
        {
            HeapArray = new List<int>();
        }

        public MaxHeap(IEnumerable<int> list)
        {
            HeapArray = new List<int>(list);
            int lastNonLeaf = Parent(Size() - 1);
            for (int i = lastNonLeaf; i >= 0; i--)
            {
                SiftDown(i);
            }
        }

        public int Size() => HeapArray.Count();

        private int Parent(int i)
        {
            return (i - 1) / 2;
        }

        private int LeftChild(int i)
        {
            return 2 * i + 1;
        }

        private int RightChild(int i)
        {
            return 2 * i + 2;
        }

        private void SiftUp(int i)
        {
            while (true)
            {
                int p = Parent(i);
                if (p < 0 || HeapArray[p] >= HeapArray[i]) break;
                Swap(i, p);
                i = p;
            }
        }

        private void SiftDown(int i)
        {
            while (true)
            {
                int maxIdx = i;
                int left = LeftChild(i);
                int right = RightChild(i);
                if (left < Size() && HeapArray[left] > HeapArray[maxIdx])
                    maxIdx = left;

                if (right < Size() && HeapArray[right] > HeapArray[maxIdx])
                    maxIdx = right;

                if (i == maxIdx) break;

                Swap(i, maxIdx);
                i = maxIdx;
            }
        }
        private void Swap(int i, int j)
        {
            int temp = HeapArray[i];
            HeapArray[i] = HeapArray[j];
            HeapArray[j] = temp;
        }

        public void Push(int val)
        {
            HeapArray.Add(val);
            SiftUp(Size() - 1);
        }

        public int Pop()
        {
            if (Size() == 0) throw new IndexOutOfRangeException();
            int rootVal = HeapArray[0];
            Swap(0, Size() - 1);
            HeapArray.RemoveAt(Size() - 1);
            SiftDown(0);
            return rootVal;
        }

        public int Peek() => HeapArray[0];

        public void Traversal()
        {
            foreach (var item in HeapArray)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
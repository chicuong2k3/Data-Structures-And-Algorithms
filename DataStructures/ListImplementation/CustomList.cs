namespace DataStructures.ListImplementation
{
    public class CustomList
    {
        private int[] arr;
        private int capacity;
        private int length;
        private readonly int extendRatio;
        public CustomList()
        {
            length = 0;
            capacity = 10;
            extendRatio = 2;
            arr = new int[capacity];
        }

        public int Count() => length;

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= length)
                {
                    throw new IndexOutOfRangeException();
                }
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= length)
                {
                    throw new IndexOutOfRangeException();
                }
                arr[index] = value;
            }
        }

        public void Add(int value)
        {
            if (length == capacity) ExtendCapacity();
            arr[length] = value;
            length++;
        }

        public void InsertAt(int index, int value)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
            }

            if (length == capacity) ExtendCapacity();

            for (int i = length - 1; i > index; i--)
            {
                arr[i + 1] = arr[i];
            }

            arr[index] = value;
            length++;
        }

        public int RemoveAt(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
            }

            int value = arr[index];

            for (int i = index; i < length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            length--;
            return value;
        }

        private void ExtendCapacity()
        {
            Array.Resize(ref arr, capacity *= extendRatio);
            capacity = arr.Length;
        }

    }
}
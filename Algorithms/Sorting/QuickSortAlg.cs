

public class QuickSortAlg : ISortAlg
{
    int Partition(int[] arr, int left, int right)
    {
        int i = left, j = right;
        while (i < j)
        {
            while (i < right && arr[i] <= arr[left])
            {
                i++;
            }
            while (j >= 0 && arr[j] >= arr[right])
            {
                j--;
            }
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }
        (arr[i], arr[left]) = (arr[left], arr[i]);
        return i;
    }

    void QuickSort(int[] arr, int left, int right)
    {
        if (left >= right)
            return;
        int pivot = Partition(arr, 0, arr.Length - 1);
        QuickSort(arr, 0, pivot - 1);
        QuickSort(arr, pivot + 1, arr.Length - 1);
    }
    public void Sort(int[] arr)
    {
        QuickSort(arr, 0, arr.Length - 1);
    }
}
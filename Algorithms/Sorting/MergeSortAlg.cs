

public class MergeSortAlg : ISortAlg
{

    void MergeSort(int[] arr, int left, int right) 
    {
        if (left >= right) return;
        int mid = (left + right) / 2;
        MergeSort(arr, left, mid);
        MergeSort(arr, mid + 1, right);
        Merge(arr, left, mid, right);
    }

    private void Merge(int[] arr, int left, int mid, int right)
    {
        int[] temp = new int[right - left + 1];
        int i = left, j = mid + 1, k = 0;
        while (i <= mid && j <= right)
        {
            if (arr[i] <= arr[j]) temp[k++] = arr[i++];
            else temp[k++] = arr[j++];
        }

        while (i <= mid)
        {
            temp[k++] = arr[i++];
        }
        while (j <= right)
        {
            temp[k++] = arr[j++];
        }

        for (int x = 0; x < temp.Length; x++)
        {
            arr[x] = temp[x];
        }
    }

    public void Sort(int[] arr)
    {
        MergeSort(arr, 0, arr.Length - 1);
    }
}
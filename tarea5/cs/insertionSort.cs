using System;

class InsertionSort
{
    static void Sort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int temp = arr[i];
            int j = i - 1;
            while (j >= 0 && temp < arr[j])
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = temp;
        }
        Console.WriteLine(string.Join(", ", arr));
    }

    static void Main()
    {
        int[] arreglo = {20, 50, 60, 30, 40, 10};
        Sort(arreglo);
    }
}

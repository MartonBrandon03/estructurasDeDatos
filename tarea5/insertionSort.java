import java.util.Arrays;
public class InsertionSort 
{
    public static void main(String[] args)
    {
        int[] arreglo = {20,50,60,30,40,10};
        sort(arreglo);
    }
    public static void sort(int[] arr)
        {
            for(int i = 0; i < arr.length; i++)
            {
                int temp = (arr[i]);
                int j = i - 1;
                while (j >= 0 && temp < arr[j])
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
                System.out.println(Arrays.toString(arr));
        }
}
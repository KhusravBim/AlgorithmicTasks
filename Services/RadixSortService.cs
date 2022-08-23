namespace AlgorithmicTasks.Services;

public class RadixSortService
{
    public static int[] Sort(int[] arr)
    {
        if (arr is { Length: 0 })
            return arr;

        int i, j;
        var tmp = new int[arr.Length];
        for (int shift = sizeof(int) * 8 - 1; shift > -1; --shift)
        {
            j = 0;
            for (i = 0; i < arr.Length; ++i)
            {
                var move = (arr[i] << shift) >= 0;
                if (shift == 0 ? !move : move)
                    arr[i - j] = arr[i];
                else
                    tmp[j++] = arr[i];
            }

            Array.Copy(tmp, 0, arr, arr.Length - j, j);
        }

        return arr;
    }
}
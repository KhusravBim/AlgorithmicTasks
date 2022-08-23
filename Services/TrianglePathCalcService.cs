namespace AlgorithmicTasks.Services;

public class TrianglePathCalcService
{
    public static int GetMaxPathSumFromFileWithTriangleOfDigits(string filePath)
    {
        var array = ReadValuesFromFileToArray(filePath);

        return GetMaxPathSum(array);
    }

    public static int GetMaxPathSum(int[,] array)
    {
        for (var i = array.GetLength(0) - 2; i >= 0; i--)
        {
            for (var j = 0; j <= i; j++)
            {
                if (array[i + 1, j] >
                       array[i + 1, j + 1])
                    array[i, j] +=
                           array[i + 1, j];
                else
                    array[i, j] +=
                       array[i + 1, j + 1];
            }
        }

        return array[0, 0];
    }

    private static int[,] ReadValuesFromFileToArray(string filePath)
    {
        var listOfLines = new List<string>();
        char[] delimiterChars = { ' ' };
        using (var file = new StreamReader(filePath))
        {
            string line;

            while ((line = file.ReadLine()) != null)
            {
                listOfLines.Add(line);
            }
        }

        int maxCount = listOfLines
                        .Select(x => x.Split(delimiterChars))
                        .OrderByDescending(x => x.Length)
                        .FirstOrDefault()
                        .Length;

        var array = new int[listOfLines.Count, maxCount];

        for (int i = 0; i <= listOfLines.Count - 1; i++)
        {
            var values = listOfLines[i].Split(delimiterChars);
            for (int j = 0; j < values.Length; j++)
            {
                int x = 0;
                int.TryParse(values[j], out x);
                array[i, j] = x;
            }
        }

        return array;
    }
}
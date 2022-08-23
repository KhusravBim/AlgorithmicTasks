using AlgorithmicTasks.Services;

Console.WriteLine("Easy triangle finding max path sum of array: ");
Console.WriteLine(Environment.NewLine);

int[,] easyArray = { {1, 0, 0},
                     {4, 8, 0},
                     {1, 5, 3} };

Print2DArray(easyArray);
Console.WriteLine(Environment.NewLine);
Console.WriteLine($"Max path sum: {TrianglePathCalcService.GetMaxPathSum(easyArray)}");
Console.WriteLine(Environment.NewLine);

Console.WriteLine("Difficult triangle finding max path sum of array: ");
Console.WriteLine(Environment.NewLine);

int[,] difficultArray =
{{75,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{95,64,0,0,0,0,0,0,0,0,0,0,0,0,0},
{17,47,82,0,0,0,0,0,0,0,0,0,0,0,0},
{18,35,87,10,0,0,0,0,0,0,0,0,0,0,0},
{20,04,82,47,65,0,0,0,0,0,0,0,0,0,0},
{19,01,23,75,03,34,0,0,0,0,0,0,0,0,0},
{88,02,77,73,07,63,67,0,0,0,0,0,0,0,0},
{99,65,04,28,06,16,70,92,0,0,0,0,0,0,0},
{41,41,26,56,83,40,80,70,33,0,0,0,0,0,0},
{41,48,72,33,47,32,37,16,94,29,0,0,0,0,0},
{53,71,44,65,25,43,91,52,97,51,14,0,0,0,0},
{70,11,33,28,77,73,17,78,39,68,17,57,0,0,0},
{91,71,52,38,17,14,91,43,58,50,27,29,48,0,0},
{63,66,04,68,89,53,67,30,73,16,69,87,40,31,0},
{04,62,98,27,23,09,70,98,73,93,38,53,60,04,23}};


Print2DArray(difficultArray);
Console.WriteLine(Environment.NewLine);
Console.WriteLine($"Max path sum: {TrianglePathCalcService.GetMaxPathSum(difficultArray)}");
Console.WriteLine(Environment.NewLine);


Console.WriteLine("Triangle finding max path sum of array from file 1.triangle.txt: ");
Console.WriteLine(Environment.NewLine);

var path = Path.Combine(Environment.CurrentDirectory, "1.triangle.txt");
var result = TrianglePathCalcService.GetMaxPathSumFromFileWithTriangleOfDigits(path);

Console.WriteLine($"Max path sum: {result}");
Console.WriteLine(Environment.NewLine);

var reversePolishExpresiion = "1 2 + 4 * 3 + ";

Console.WriteLine($"Get result of reverse polish notation expression: {reversePolishExpresiion}");
Console.WriteLine(Environment.NewLine);

Console.WriteLine($"Result: {RPNService.GetRPNResult(reversePolishExpresiion)}");
Console.WriteLine(Environment.NewLine);

var arrayForSort = new int[] { 345, 212, 131, 149 };

Console.WriteLine($"Get result of radix sort of array:");
Console.WriteLine(Environment.NewLine);

PrintArray(arrayForSort);

Console.WriteLine(Environment.NewLine);

Console.WriteLine($"Result array: ");
PrintArray(RadixSortService.Sort(arrayForSort));

Console.ReadKey();


static void Print2DArray<T>(T[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}

static void PrintArray<T>(T[] array)
{
    foreach (var item in array)
    {
        Console.Write(item + " ");
    }
}
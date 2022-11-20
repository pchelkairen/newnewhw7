// Урок 7. Как не нужно писать код. Часть 1
//1. Показать двумерный массив размером m×n заполненный вещественными числами

void PrintArray(int[,] arr)
{
  for(int i = 0; i < arr.GetLength(0); i++)
{
    for(int j = 0; j < arr.GetLength(1); j++)
    {
        Console.Write($"{arr[i,j]}");
    }
Console.WriteLine();
}  
}

void FillArray(int[,] arr)
{
 for(int i = 0; i < arr.GetLength(0); i++)
{
    for(int j = 0; j < arr.GetLength(1); j++)
    {
        arr[i,j] = new Random().Next(1,5);
    }   
}
}

// 2. Задать двумерный массив следующим правилом: Aₘₙ = m+n


void FillArr1(int[,] Arr1)
{
    for (int i = 0; i < Arr1.GetLength(0); i++)
    {
        for (int j = 0; j < Arr1.GetLength(1); j++)
            Arr1[i, j] = i + j;
    }
}

void PrintArr1(int[,] Arr1)
{
    for (int i = 0; i < Arr1.GetLength(0); i++)
    {
        for (int j = 0; j < Arr1.GetLength(1); j++)
            Console.Write($"{Arr1[i, j]} ");
        Console.WriteLine();
    }
}



// 3.  В двумерном массиве заменить элементы, у которых оба индекса чётные на их квадраты

void FillMatrix(int[,] matrix, int min, int max)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            matrix[i, j] = new Random().Next(min, max);
    }
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]} ");
    Console.WriteLine();
    }
}

void NewMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i % 2 == 0 && j % 2 == 0)
            {
                matrix[i, j] = matrix[i, j] * matrix[i, j];
            }
        }
    }
}



//4. В двумерном массиве показать позиции числа, заданного пользователем или указать, что такого элемента нет
 int[] FindIndex(int[,] arr, int number)
{
    for (int i = 0; i < arr.GetLength(0); i++)
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if (arr[i, j] == number)
                return new int[2] { i, j }; 
        }
    return new int[2] { -1, -1 };
}

//5. В матрице чисел найти сумму элементов главной диагонали
int SumDiagonal(int[,] arr)
{
    int sum = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
        for (int j = 0; j < arr.GetLength(1); j++)
            if (i == j) 
                sum += arr[i, j];
    return sum;
}
//6. Дан целочисленный массив. Найти среднее арифметическое каждого из столбцов.

double [] Sum(int[,] arr)
{
    double[] result = new double[arr.GetLength(1)];
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
            result[j] += arr[i, j];
        result[j] /= arr.GetLength(0);
    }
    return result;
}

// 7. Написать программу, которая обменивает элементы первой строки и последней строки
int[,] ChangeFirstAndLast(int[,] arr)
{
    
    int temp = 0;
    for (int i = 0; i < arr.GetLength(1); i++)
    {
        temp = arr[0, i];
        arr[0, i] = arr[arr.GetLength(0) - 1, i];
        arr[arr.GetLength(0) - 1, i] = temp;
    }
    return arr;
}

//8. В прямоугольной матрице найти строку с наименьшей суммой элементов.
int Min(int[,] arr)
{
    int minSum = 0;
    int minStroke = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < arr.GetLength(1); j++)
            sum += arr[i, j];

        if (sum < minSum||i==0)
        {
            minSum = sum;
            minStroke = i;
        }
    }
    return minStroke;
}

Console.WriteLine("Введите количество строк: ");
int m = int.Parse(Console.ReadLine() ?? "0");
Console.WriteLine("Введите количество столбцов: ");
int n = int.Parse(Console.ReadLine() ?? "0");
int[,] array = new int[m,n];
FillArray(array);
PrintArray(array);

Console.WriteLine("Задайте количество строк ");
int m1 = int.Parse(Console.ReadLine() ?? "0");
Console.WriteLine("Задайте количество столбцов ");
int n1 = int.Parse(Console.ReadLine() ?? "0");
int[,] Arr1 = new int[m1, n1];

FillArr1(Arr1);
PrintArr1(Arr1);

Console.WriteLine("Задайте количество строк ");
int x = int.Parse(Console.ReadLine() ?? "0");
Console.WriteLine("Задайте количество столбцов ");
int y = int.Parse(Console.ReadLine() ?? "0");
int[,] matrix = new int[x, y];

Console.WriteLine("Заданная матрица");
FillMatrix(matrix, 0, 10);
PrintMatrix(matrix);
Console.WriteLine();
Console.WriteLine("Итоговая матрица");
NewMatrix(matrix);
PrintMatrix(matrix);

Console.WriteLine("Введите число: ");
int number = int.Parse(Console.ReadLine() ?? "0");
var index = FindIndex(array, number);
Console.WriteLine($"позиция числа {index[0]},{index[1]}");
Console.WriteLine($"Сумма элементов главной диагонали: {SumDiagonal(array)}");
var avereageArray = Sum(array);
foreach(var avereage in avereageArray)
Console.Write(avereage+ "\t");
Console.WriteLine();
PrintArray(ChangeFirstAndLast(array));
Console.WriteLine($" строка с наименьшей суммой элементов {Min(array)}");
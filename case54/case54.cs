// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2 
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

void FillArray(int[,] array, int[] oneDim)
{
    int x = 0;
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(-10, 11);
            oneDim[x] = array[i, j];
            x++;
        }
}

void PrintArray(int[,] array)
{
    Console.WriteLine("Двумерный массив из случаных чисел: ");
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j],2}\t");
        Console.WriteLine();
    }
}

void Sort(int[] array, int cols)
{
    int num = 0;
    while (num <= array.Length - cols)
    {
        for (int i = num; i < num + cols; i++)
            for (int j = num + 1; j < num + cols; j++)
                if (array[j] > array[j - 1])
                    (array[j], array[j - 1]) = (array[j - 1], array[j]);
        num += cols;
    }
}

void PrintNewArray(int[,] array, int[] arr)
{
    Console.WriteLine("Отсортированный по убыванию построчно массив: ");
    int x = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = arr[x];
            Console.Write($"{array[i, j],2}\t");
            x++;
        }
        Console.WriteLine();
    }
}


Console.Write("Введите количество строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
int cols = Convert.ToInt32(Console.ReadLine());
int[,] array = new int[rows, cols];
int[] oneDim = new int[rows * cols];
FillArray(array, oneDim);
PrintArray(array);
Sort(oneDim, cols);
PrintNewArray(array, oneDim);

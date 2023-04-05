// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

void FillArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            array[i, j] = new Random().Next(0, 10);
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

int[] GetSum(int[,] array, int rows)
{
    int check = 0;
    int sum = 0;
    int[] sums = new int[rows];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (check == i)
            {
                sum += array[i, j];
                sums[check] = sum;
            }
            else
            {
                check++;
                sum = array[i, j];
            }
        }
        //Console.WriteLine("Сумма {0} строки = {1}", i + 1, sums[check]); // проверочный вывод суммы строки
    }
    return sums;
}

int FindMin(int[,] array, int rows)
{
    int[] sums = GetSum(array, rows);
    int min = sums[0];
    int imin = 0;
    for (int i = 0; i < sums.Length; i++)
        if (min > sums[i])
        {
            min = sums[i];
            imin = i;
        }
    return imin + 1;
}

Console.Write("Введите количество строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
int cols = Convert.ToInt32(Console.ReadLine());
if (rows == cols)
    Console.WriteLine("Массив должен быть прямогульным.");
else
{
    int[,] array = new int[rows, cols];
    int[] oneDim = new int[rows * cols];
    FillArray(array);
    PrintArray(array);
    Console.WriteLine($"Номер строки с наименьшей суммой элементов: {FindMin(array, rows)}");
}
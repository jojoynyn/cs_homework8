// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

void FillArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            array[i, j] = new Random().Next(1, 6);
}

void PrintArray(int[,] array, string message)
{
    Console.WriteLine(message);
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j],2}\t");
        Console.WriteLine();
    }
}

int[,] Multiply1(int[,] matrix1, int[,] matrix2)
{
    int[,] mult = new int[matrix1.GetLength(1), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
        for (int j = 0; j < matrix2.GetLength(1); j++)
            for (int k = 0; k < matrix2.GetLength(0); k++)
                mult[i, j] += matrix1[i, k] * matrix2[k, j];
    return mult;
}

int[,] Multiply2(int[,] matrix1, int[,] matrix2)
{
    int[,] mult = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
        for (int j = 0; j < matrix2.GetLength(1); j++)
            for (int k = 0; k < matrix1.GetLength(1); k++)
                mult[i, j] += matrix1[i, k] * matrix2[k, j];
    return mult;
}



Console.Write("Введите количество строк 1-й матрицы: ");
int rows1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов 1-й матрицы: ");
int cols1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов 2-й матрицы: ");
int cols2 = Convert.ToInt32(Console.ReadLine());
int rows2 = cols1;
int[,] matrix1 = new int[rows1, cols1];
int[,] matrix2 = new int[rows2, cols2];
FillArray(matrix1); PrintArray(matrix1, "Матрица 1: ");
FillArray(matrix2); PrintArray(matrix2, "Матрица 2: ");
int[,] mult = (rows1 > cols2) ? Multiply1(matrix1, matrix2) : Multiply2(matrix1, matrix2);
PrintArray(mult, "Произведение матриц: ");
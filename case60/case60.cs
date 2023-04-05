// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
//Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

bool CheckArray(int[] array, int rand)
{
    foreach (int item in array)
    {
        if (rand == item)
            return false;
    }
    return true;
}

void CheckOneDimArray(int[] array)
{
    int i = 0;
    do
    {
        int rand = new Random().Next(10, 100);
        if(CheckArray(array, rand))
        {
            array[i] = rand;
            i++;
        }
    }
    while(i < array.Length);
}

void FillArray(int[,,] array, int[] oneDim)
{
    int count = 0;
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = oneDim[count];
                count++;
            }
}

void PrintResult(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
                Console.Write($"{array[i, j, k],2} ({i}, {j}, {k})\t");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

Console.Write("Введите количество элементов 1-го измерения: ");
int dim1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество элементов 2-го измерения: ");
int dim2 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество элементов 3-го измерения: ");
int dim3 = Convert.ToInt32(Console.ReadLine());
int[,,] array = new int[dim1, dim2, dim3];
int[] oneDim = new int[dim1 * dim2 * dim3];
CheckOneDimArray(oneDim);
FillArray(array, oneDim);
PrintResult(array);
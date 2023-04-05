// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

void PrintArray(int[,] array, int n)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j],2}\t");
        Console.WriteLine();
    }
}

void FillArray(int[,] array, int n)
{
    int counter = 1;
    int zero = 0; // счетчик начала 
    int num = n - 1; // счетчик конца 
    int i = 0; 
    int j = 0; 
    bool dir = true;  // возрастающий индекс строки или столбца
    while (counter <= n * n)
    {
        array[i, j] = counter;
        if (dir)
        {
            if (j < num)
            {
                j++;
                counter++;
            }
            else
            {
                if (i < num)
                {
                    i++;
                    counter++;
                }
                else
                    dir = false;
            }
        }
        else
        {
            if (j > zero)
            {
                j--;
                counter++;
            }
            else
            {
                if (i > zero + 1)
                {
                    i--;
                    counter++;
                }
                else
                {
                    j++;
                    counter++;
                    zero++;
                    num--;
                    dir = true;
                }
            }
        }

    }
}

Console.Write("Введите число: ");
int n = Convert.ToInt32(Console.ReadLine());
int[,] array = new int[n, n];
FillArray(array, n);
PrintArray(array, n);
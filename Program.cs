// Task 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет 
//построчно выводить массив, добавляя индексы каждого элемента.
Console.Clear();
Console.WriteLine("This program generates 3D array with non-repeating two-digit numbers.");
Console.WriteLine();
int dimensionX = EnterUserData("Enter lenght of the X dimension:");
int dimensionY = EnterUserData("Enter lenght of the Y dimension:");
int dimensionZ = EnterUserData("Enter lenght of the Z dimension:");
int[,,] randomArray = new int[dimensionX, dimensionY, dimensionZ];
Console.WriteLine();

if ((dimensionX * dimensionY * dimensionZ) > 90)//If size of our array is greater than the number of two-digit numbers then break.
{
    Console.WriteLine("It's impossible to fill the entered array with non-repeating two-digit numbers! Check size of the entered array.");
    return;
}
FillArray(randomArray, dimensionX, dimensionY, dimensionZ);
Console.WriteLine();
Console.WriteLine("The entered 3D array is:");
Console.WriteLine();
PrintArray(randomArray);

int[,,] FillArray(int[,,] array, int dimensionX, int dimensionY, int dimensionZ)
{
    int referenceArrayRow = 9;
    int referenceArrayCol = 10;
    int offset = 10;
    int[,] referenceArray = new int[referenceArrayRow, referenceArrayCol];
    Console.WriteLine("The reference array is:");
    Console.WriteLine();
    for (int i = 0; i < referenceArray.GetLength(0); i++)//fill reference array up
    {
        for (int j = 0; j < referenceArray.GetLength(1); j++)
        {
            referenceArray[i, j] = offset;
            Console.Write(referenceArray[i, j] + " ");
            offset++;
        }
        Console.WriteLine();
    }
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int n = 0; n < array.GetLength(2); n++)
            {
            OnceAgain:
                int referenceArrayRowIndex = new Random().Next(0, 9);
                int referenceArrayColIndex = new Random().Next(0, 10);
                if (referenceArray[referenceArrayRowIndex, referenceArrayColIndex] != 0)
                {
                    array[i, j, n] = referenceArray[referenceArrayRowIndex, referenceArrayColIndex];
                    referenceArray[referenceArrayRowIndex, referenceArrayColIndex] = 0;
                }
                else
                {
                    goto OnceAgain;
                }
            }
        }
    }
    return array;
}

void PrintArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int n = 0; n < array.GetLength(2); n++)
            {
                Console.Write($"{array[i, j, n]}[{i},{j},{n}] ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

int EnterUserData(string nameUserData)
{
    Console.Write($"{nameUserData}");
    return Convert.ToInt32(Console.ReadLine());
}
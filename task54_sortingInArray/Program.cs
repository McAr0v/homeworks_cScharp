// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

// В итоге получается вот такой массив:

// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

int EnterValueInt (string text)
{
    Console.Write(text);
    int value = Convert.ToInt32(Console.ReadLine());

    return value;
}

// -- Генератор массива со случайными числами ---- 

int [,] GenerateDoubleArray (int row, int column, int startLimit, int endLimit)
{
    int [,] array = new int [row , column];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i,j] = new Random().Next(startLimit, endLimit + 1);
        }
    }
    
    return array;

}

// ---- Выводит массив в консоль -----

void ShowArray (int [,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i,j]} ");
        }
        Console.WriteLine();
    }
}

// ----- Сортировка массива -----

void SortingArray(int[,] array)
{
    // ---- Принцип всплювающего пузырька ------

    // --- Перебираем строки -----
    for (int row1 = 0; row1 < array.GetLength(0); row1++)
    {
        // ----- Количество проходов по стобцам -------
        for (int numberOfActions = 0; numberOfActions < array.GetLength(1); numberOfActions++)
        {
            // ------ Перебираем столбцы --------
            for (int columns = 0; columns < array.GetLength(1)-1; columns++)
            {
                // ---- Если текущее число меньше следующего ----
                if (array[row1, columns]<array[row1, columns+1])
                {
                    // ---- Меняем их местами -----
                    int temp = array[row1, columns];
                    array[row1, columns] = array[row1, columns+1];
                    array[row1, columns+1] = temp;
                }
            }
        }    
    }
}



// ---- Начало программы -----

// ----Вводим количество строк и колонок в массиве ----

int row = EnterValueInt("Ввведите количество строк -> ");
int column = EnterValueInt("Ввведите количество колонок -> ");

// ---- Вводим пределы генерации чисел ----

int startLimit = EnterValueInt("Ввведите начало предела генерации -> ");
int endLimit = EnterValueInt("Ввведите конец предела генерации -> ");

// ---- Генерируем массив ----

int [,] doubleArray = GenerateDoubleArray(row, column, startLimit, endLimit);

// ---- Показываем массив -----

ShowArray(doubleArray);
Console.WriteLine();

// ---- Сортируем массив -----
SortingArray(doubleArray);

// ----- Опять показываем массив -----
ShowArray(doubleArray);
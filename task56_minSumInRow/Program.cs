// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

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

// ---- Функция подсчета сумм в строках ------

int [] MinSumInRow (int [,] array)
{
    int [] result = new int [2] {0,0}; // по умолчанию 0 индекс - сумма, 1 индекс - индекс строки
    int sum = 0; // переменная, в которую помещается сумма строк
    int sumMin = 0; // если сумма минимальная - будет помещаться сюда


    // ---- Перебираем строки -----

    for (int rows = 0; rows < array.GetLength(0); rows++)
    {
        // ---- Перебираем колонки ------

        for (int columns = 0; columns < array.GetLength(1); columns++)
        {
            // --- Складываем в переменную элементы массива из строки----
            sum = sum + array[rows, columns];
            
        }

        // --- Если это первая строка ----

        if (rows == 0) 
        {
            sumMin =sum; // ---- По умолчанию ставим сумму элементов как минимальную сумму
            result[0] = sumMin; // ----- Помещаем в 0 индекс минимальную сумму
            result[1] = rows; // ---- Помещаем в 1 индекс индекс строки, у которой минимальная сумма
        }
        

        // ------ Если строка не первая -----
        // ---- И если сумма в строке меньше суммы минимальной

        if (sum < sumMin) 
        {
            // ---- Меняем все данные на новые ----
            sumMin =sum;
            result[0] = sumMin;
            result[1] = rows;
        }
        
        // ---- Перед переходом на новую строчку обнуляем переменную суммы ----

        sum = 0;
    }

    return result;
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

// ---- Считаем суммы строк и возвращаем данные о строке с минимальной суммой элементов ----

int [] result = MinSumInRow(doubleArray);

// ----- Выводим результат в консоль ----

Console.WriteLine($"{result[1]+1} строка имеет наименьшую сумму - {result[0]}");
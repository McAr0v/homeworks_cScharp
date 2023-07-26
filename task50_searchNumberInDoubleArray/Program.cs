// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
// и возвращает значение этого элемента или же указание, что такого элемента нет.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

int EnterValueInt (string text)
{
    Console.Write(text);
    int value = Convert.ToInt32(Console.ReadLine());

    return value;
}


// -- Генератор массива ---- 

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

// ---- Поиск числа в массиве по индексам -----

void SearchNumberInArray(int [,] array, int row, int column)
{
    // ---- Если введенные индексы больше чем размер массива: ------

    if (array.GetLength(0)<=row || array.GetLength(1)<=column)
    {
        // ---- Выводим "Ошибку" -----
        Console.WriteLine("Такого адреса не существует :( ");
    }
    else 
    {
        // --- Если индексы входят в размер массива, то выводим значение -----
        Console.WriteLine($"Значение по адресу {row}:{column} -> {array[row, column]}");
    }

}

// ---- Начало программы -----

// ----Вводим количество строк и колонок в массиве ----

int row = EnterValueInt("Ввведите количество строк -> ");
int column = EnterValueInt("Ввведите количество колонок -> ");

// ---- Вводим пределы генерации чисел ----

int startLimit = EnterValueInt("Ввведите начало предела генерации -> ");
int endLimit = EnterValueInt("Ввведите конец предела генерации -> ");

// ---- Вводим адрес искомой ячейки ----

int searchRow = EnterValueInt("Введите индекс строки поиска (отсчет от 0)-> ");
int searchColumn = EnterValueInt("Введите индекс столбца поиска (отсчет от 0) -> ");

// ---- Генерируем массив ----

int [,] doubleArray = GenerateDoubleArray(row, column, startLimit, endLimit);

// ---- Показываем массив -----

ShowArray(doubleArray);
Console.WriteLine();

// ---- Ищем значение по адресу -----

SearchNumberInArray(doubleArray, searchRow, searchColumn);



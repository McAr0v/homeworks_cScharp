// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

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

// ---- Подсчет средней арифметической в столбце -----

double AverageSumOfColumsInArray (int [,] array, int column)
{
    // Передаю сюда колонку, убирая замешательство и делая
    // функцию понятнее и проще

    // Остается 1 цикл for, бегающий по строкам

    double sum = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        // строки перебираются, а колонка закреплена
        // колонки перебираем в другом месте))

        sum += array[i, column]; // здесь в сумму складываем числа
    }

    double result = sum / array.GetLength(0); // получаем среднеарифметическое

    return Math.Round(result, 2); // округляем double до 2х после запятой

}

// ---- Функция вывода среднеарифметических в консоль -----

void ShowAverage (int [,] doubleArray)
{

    Console.Write("["); // для красоты ставим квадратную скобочку)))

    // ---- ВОТ ТУТ ПЕРЕБИРАЕМ СТОЛБЦЫ :) ----

    for (int i = 0; i < doubleArray.GetLength(1); i++)
    {
    Console.Write($"Столбец {i+1} -> {AverageSumOfColumsInArray(doubleArray, i)}; ");    
    }

    Console.Write("\b\b]"); // у последнего элемента убираем ; и ставим ]
    Console.WriteLine(); // убираем артефакт((
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

// ---- Выводим среднеарифметические по колонкам в терминал ----

ShowAverage(doubleArray);



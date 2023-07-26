// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

// --- Для ввода значений int ----

int EnterValueInt (string text)
{
    Console.Write(text);
    int value = Convert.ToInt32(Console.ReadLine());

    return value;
}

// ---- Для ввода значений double -----

double EnterValueDouble (string text)
{
    Console.Write(text);
    double value = Convert.ToDouble(Console.ReadLine());

    return value;
}

// ---- Генератор пустого массива ------

double [,] GenerateDoubleArray (int row, int column)
{
    return new double [row , column];
}

// ---- Генератор чисел Double -----

double NumberGeneration (double startLimit, double endLimit)
{
    // Так заморачиваюсь с переводом double в int, потому что я хочу
    // контрлировать диапазон double-генерации, а не довольствоваться
    // тем, что удумает обычный генератор double))))

    int startGenerationNumber = Convert.ToInt32(startLimit*100);
    int endGenerationNumber = Convert.ToInt32(endLimit*100);

    double randomNumber = new Random().Next(startGenerationNumber, endGenerationNumber + 1) * 0.01;

    return Math.Round(randomNumber, 2);
}

// ----- Заполнитель массива случайными числами Double -------

void FillRandomNumbersInDoubleArray (double [,] array, double startLimit, double endLimit)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i,j] = NumberGeneration(startLimit, endLimit);
        }
    }
}

// ----- Функция, выводящая массив в консоль -----

void ShowArray (double [,] array)
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

// ----- Начало программы ------

// ---- Задаем размеры массива ------

int row = EnterValueInt("Ввведите количество строк -> ");
int column = EnterValueInt("Ввведите количество колонок -> ");

// ---- Задаем пределы генерации чисел -----

double startLimit = EnterValueDouble("Ввведите начало предела генерации (Например 0,9) -> ");
double endLimit = EnterValueDouble("Ввведите конец предела генерации (Например 1,9) -> ");

// ---- Генерируем пустой массив -----
double [,] doubleArray = GenerateDoubleArray(row, column);

// ---- Показываем, что массив создался и заполнился 0 ------
ShowArray(doubleArray);
Console.WriteLine();

// ---- Заполняем массив рандомными числами -----

FillRandomNumbersInDoubleArray(doubleArray, startLimit, endLimit);

// ---- Показываем заполненный массив ------

ShowArray(doubleArray);
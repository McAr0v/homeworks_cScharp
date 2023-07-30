// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

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

// -- Функция умножения матриц ------

int [,] MatrixMultiple(int [,] firstMatrix, int [,] secondMatrix)
{
    // --- Генерируем правильные размеры матрицы-результата ----
    // Результатом умножения матриц Am×n и Bn×k будет матрица Cm×k 

    int [,]result = new int [firstMatrix.GetLength(0), secondMatrix.GetLength(1)];

    // ---- Перебираем строки матрицы-результата ----

    for (int i = 0; i < result.GetLength(0); i++)
    {
        // ---- Перебираем столбцы матрицы-результата

        for (int j = 0; j < result.GetLength(1); j++)
        {
            int sum = 0; // Переменная для вычесления произведения. В начале цикла всегда должна быть равна 0

            for (int n = 0; n < firstMatrix.GetLength(1); n++) 
            {
                sum += firstMatrix[i, n]*secondMatrix[n, j]; // Умножаем соответствующие строки на  соответствующие столбцы и добавляем в сумму
            }

            result[i,j] = sum; // После перменожения всех элементов, сумму записываем в ячейку

        }
        
    }

    return result;
}

// ---- Начало программы -----

// ----Вводим количество строк и колонок в массивах-матрицах ----

int m = EnterValueInt("Ввведите количество строк 1 матрицы -> ");
int n1 = EnterValueInt("Ввведите количество колонок 1 матрицы -> ");

int n2 = EnterValueInt("Ввведите количество строк 2 матрицы -> ");
int k = EnterValueInt("Ввведите количество колонок 2 матрицы -> ");

// ---- Вводим пределы генерации чисел ----

int startLimit = EnterValueInt("Ввведите начало предела генерации -> ");
int endLimit = EnterValueInt("Ввведите конец предела генерации -> ");

// ---- Генерируем массивы ----

int [,] firstMatrix = GenerateDoubleArray(m, n1, startLimit, endLimit);
int [,] secondMatrix = GenerateDoubleArray(n2, k, startLimit, endLimit);

// ---- Показываем массивы -----

ShowArray(firstMatrix);
Console.WriteLine();
ShowArray(secondMatrix);


// -- По условию задачи, если количество столбцов 1 матрицы равно количеству строк второй матрицыё
// --- Только тогда можно производить умножение

if (n1 == n2)
{

    // Вызываем функцию умножения матриц и получаем результат

    int [,] result = MatrixMultiple(firstMatrix, secondMatrix);

    // Выводим в консоль

    Console.WriteLine();
    ShowArray(result);
       
}
else Console.WriteLine("Такие матрицы перемножить нельзя!"); // когда матрицы нельзя умножать
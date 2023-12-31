﻿// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

// ---- Функция ввода в консоль ----
int EnterValueInt(string text)
{
    Console.Write(text);
    int value = Convert.ToInt32(Console.ReadLine());

    return value;
}

// Выводит массив в консоль

void ShowArrayString(string[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

// -----  Конвертер чисел int в string -----

string ConvertNumberToString(int number)
{
    if (number < 10) return Convert.ToString("0" + number);
    else return Convert.ToString(number);

}

bool CheckNumber (int n, int m)
{
    if (m>n)
    {
        int temp = m;
        m = n;
        n = temp;
    }

    if (n%2 == 0)
    {
        if ((n-m) > 1) return true;
        else return false;
    }
    else return false;
}

bool CheckNumberTwo (int n, int m)
{
    if (m>n)
    {
        int temp = m;
        m = n;
        n = temp;
    }

    if (n%2 != 0)
    {
        if ((n-m) > 1) return true;
        else return false;
    }
    else return false;
}

// ---- Заполнение массива по спирали ----

string[,] FillArray(int n, int m)
{
    // n - количество строк
    // m - количество столбцов

    // создаем массив размерами n, m
    // Да-да, можно заполнить массив любого размера))))

    string [,] matrix = new string [n, m];

    // Определяем количество "колец".
    // т.е условно, весь массив можно представить как
    // кольца - внешнее, следующее внутри внешнего, следующее внутри внутреннего внешнего и тд
    
    int roundsCounter = n / 2; // по умолчанию кол-во колец - количество строк / 2. 
    //Деленное на 2, потому что кольцо состоит из 2х строк

    if (m < n) roundsCounter = m/2; // если количество столбцов меньше чем строк, то тогда будем считать кольца по столбцам

    if (CheckNumber(n,m)) roundsCounter = roundsCounter-1;

    int number = 1; // первое число в матрице - 1

    // Запускаем цикл перебора колец
    // От переменной rounds зависят координаты числа, в которое будет вставлять значение

    for (int rounds = 0; rounds <= roundsCounter; rounds++)
    {
        // Переменные ниже вычислены опытным путем
        // Я наприсовал на бумаге матрицу 5х5 с числами, заполненными как надо
        // и выписал координаты, по которым лежат числа
        // Я заметил закономерность, которую смог записать в переменных ниже
        // в зависимости от того, какой круг пошел,
        // можно задать координаты

        int xStart = 0 + rounds; // стартовая координата для каждого круга, чтобы было движение по горизонтали
        int yStart = 0 + rounds; // стартовая координата для каждого круга, чтобы было движение по вертикали
        int xFinish = n - 1 - rounds; // конечная координата для каждого круга, чтобы было движение по горизонтали
        int yFinish = m - 1 - rounds; // конечная координата для каждого круга, чтобы было движение по вертикали

        // Если матрица нечетная и квадратная, то прямо по центру не вставляет число. 
        // Для этого числа отдельная координата на последнем круге заполнения

        if (n % 2 != 0 && m == n) if (rounds == roundsCounter) matrix[roundsCounter, roundsCounter] 
        = ConvertNumberToString (number);

        // --- НАЧИНАЕМ ЗАПОЛНЯТЬ КОЛЬЦА ------

        // Запускаем движение по горизонтали, слева направо
        
        for (int i = yStart; i < yFinish; i++)
        {   
            matrix[xStart, i] = ConvertNumberToString (number); // выбираем ячейку и кладем туда конвертированное число
            number++; // Добавляем к числу 1, так как следующее число должно быть по порядку
        }

        // Когда дошли по горизонтали до последнего элемента, начинаем двигаться сверху вниз

        // Далее принцип как описан в прошлом цикле, только движение по вертикали сверху вниз
        for (int j = xStart; j < xFinish; j++)
        {
            matrix[j, yFinish] = ConvertNumberToString (number);
            number++;
            
        }

        // Как дошли до низу, начинаем движение по горизонтали справа налево

        for (int k = yFinish; k > yStart; k--)
        {
            matrix[xFinish, k] = ConvertNumberToString (number);
            number++;

        }

        // как дошли до крайней точки по горизонтали, поднимаемся снизу вверх

        for (int l = xFinish; l > xStart; l--)
                {
                    matrix[l, yStart] = ConvertNumberToString (number);
                    number++;
                    
                }
        
        
        // После заполнения кольца, выбираем следующее кольцо и тд до конца

        if (CheckNumberTwo(n,m) && roundsCounter == rounds) {matrix[n/2, m/2] = ConvertNumberToString (number-3);}

    }

    


    return matrix;
}

// --- НАЧАЛО ПРОГРАММЫ ----

// --- Вводим размер матрицы ----
// ---- Да да, я сделал чтобы можно было заполнить матрицу любого размера, не только 4х4

int n = EnterValueInt("Введи количество строк массива -> ");
int m = EnterValueInt("Введи количество столбцов массива -> ");

// --- Заполняем матрицу ----

string[,] numbersArray = FillArray(n, m);

// --- Выводим в консоль -----
Console.WriteLine("");
ShowArrayString(numbersArray);



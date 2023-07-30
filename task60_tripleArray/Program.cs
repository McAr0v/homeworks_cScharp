// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

// --- Функция ввода в консоль значений ----

int EnterValueInt (string text)
{
    Console.Write(text);
    int value = Convert.ToInt32(Console.ReadLine());

    return value;
}

// ---- Функция генерации чисел -----

int GenerateNumber (int [] numbers, int startLimit, int endLimit)
{
    // ---- Генерируем число ----

    int number = new Random().Next(startLimit, endLimit + 1);

    // --- Проверяем число, есть ли уже такое? ---
    // -- По условию было сказано, что оно НЕ ДОЛЖНО ПОВТОРЯТЬСЯ ----

    for (int i = 0; i < numbers.Length; i++)
    {
        // ---- Проверяем массив с ранее сгенерированными числами
        // -- Если сгенерированное число уже ранее встречалось, то генерируем заново
        // Рекурсия, епта XD
        
        if (numbers[i] == number) number = GenerateNumber(numbers, startLimit, endLimit);
    }

    return number;
}

// -- Генератор массива со случайными числами ---- 

int [,,] GenerateTripleArray (int row, int column, int heigth, int startLimit, int endLimit)
{
    // Создаем массив с генерированными числами, чтобы проверять, не повторяется ли сгенерированное число
    // Размер массива - произведение ширины, высоты и длины массива (именно столько чисел будет в массиве)
    int [] numbers = new int [row*column*heigth];
    int numbersIndex = 0; // индекс массива с числами для проверки. Чтобы засовывать в него новое сгенерированное число
    int [,,] array = new int [row , column, heigth]; // Генерируем сам трехмерный массив

    // --- Перебираем строки, столбцы и ... высотцы?)))))
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                // По адресу вставляем сгенерированное число
                // ПО условию задачи, число не должно повторяться
                // поэтому смотри функцию GenetateNumber
                array[i,j,k] = GenerateNumber(numbers, startLimit, endLimit);

                // Если число подходит, добавляем его в массив "запоминалку" прошлых сгенерированных чисел
                numbers[numbersIndex] = array[i,j,k];
                numbersIndex++;

                // Вывод numbers писался для проверки, что числа реально не повторяются
                // отслеживал, как изменяется массив с сгенерированными числами и каждое новое добавленное число в консоли
                // Console.WriteLine($"[{string.Join(", ", numbers)}]"); 
                
            }
            
        }
    }
    
    return array;

}

// ---- Выводит массив в консоль -----

void ShowArray (int [,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.WriteLine($"По адресу ({i}, {j}, {k}) находится значнеие - {array[i,j, k]} ");
            }
            
        }
        Console.WriteLine();
    }
}

// Задаем размеры
int length = EnterValueInt("Введите длину массива -> ");
int width = EnterValueInt("Введите ширину массива -> ");
int height = EnterValueInt("Введите высоту массива -> ");

// Генерируем массив
// По условию задачи, числа двухзначные должны быть, поэтому предел генерации - 10...99
int [,,] tripleArray = GenerateTripleArray(length, width, height, 10, 99);

// Выводим массив
ShowArray(tripleArray);
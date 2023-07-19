// Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.
// [345, 897, 568, 234] -> 2

// Функция, которая генерирует массив

int[] ArrayGenerator(int massiveSize, int startNumber, int finishNumber)
{
    int[] array = new int[massiveSize];

    for (int i = 0; i < array.Length; i++)
    {
        array[i] = new Random().Next(startNumber, finishNumber + 1);
    }

    return array;
}

// Функция ввода значения

int EnterValue (string text)
{
    Console.Write(text);
    int value = Convert.ToInt32(Console.ReadLine());

    return value;
}

// Функция проверки - трехзначное ли число?

bool CheckNumber(int number)
{
    if (number<= 999 && number>=100) return true;
    else return false;
}

// Функция проверки - четное ли число?

bool EvenNumber (int number)
{
    if (number%2 == 0) return true;
    else return false;
}

// ----- Начало программы --------

int arraySize = EnterValue("Введите размер массива -> ");
int minLimit = EnterValue("Введите нижний предел чисел массива (число должно быть ТРЕХЗНАЧНЫМ) -> ");
int maxLimit = EnterValue("Введите верхний предел чисел массива (число должно быть ТРЕХЗНАЧНЫМ) -> ");
int counter = 0; // счетчик четных чисел

if (CheckNumber(minLimit) && CheckNumber(maxLimit)) // Если числа пределов массива трехзначные
{
    int[] array = ArrayGenerator(arraySize, minLimit, maxLimit); // генерируем массив
    Console.WriteLine($"Массив -> [{string.Join(", ", array)}]"); // выводим в консоль

    // Запускаем цикл перебора значений массива
    for (int i = 0; i < array.Length; i++)
    {
        if (EvenNumber(array[i])) counter++; // Если функция определения четного числа возвращает true, то к счетчику добавляем 1
    }

    Console.WriteLine($"Количество четных чисел в массиве -> {counter}"); // После завершения цикла выводим в консоль счетчик - сколько он насчитал четных чисел

}
else // Если какое либо число предела массива не трехзначное
{
    Console.WriteLine("Одно из чисел предела не трехзначное!");
}




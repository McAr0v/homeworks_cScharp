// Задача 36: Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.
// [3, 7, 23, 12] -> 19
// [-4, -6, 89, 6] -> 0

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

// Функция подсчета чисел в массиве

int SumOfNumbersInArray (int[] array, int startIndex, int step)
{
    int sum = 0;
    for (int i = startIndex; i < array.Length; i += step)
    {
        sum += array[i];
    }

    return sum;
}

// ----- Начало программы --------

int arraySize = EnterValue("Введите размер массива -> ");
int minLimit = EnterValue("Введите нижний предел чисел массива -> ");
int maxLimit = EnterValue("Введите верхний предел чисел массива -> ");


int[] array = ArrayGenerator(arraySize, minLimit, maxLimit); // Генерируем массив
Console.WriteLine($"Массив -> [{string.Join(", ", array)}]"); // выводим сгенерированный массив в консоль

// запускаем функцию подсчета чисел в массиве, где
// 1 -> Начальный индекс - по условию задачи мы должны брать нечетные индексы в массиве
// 2 -> Шаг - чтобы брал только нечетные индексы - 1, 3, 5 и тд
// array -> Сам массив

int sumOfNumbers = SumOfNumbersInArray(array, 1, 2); 

Console.WriteLine($"Сумма чисел на нечетных позициях в массиве -> {sumOfNumbers}");

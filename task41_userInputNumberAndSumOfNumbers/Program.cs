// Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
// 0, 7, 8, -2, -2 -> 2
// 1, -7, 567, 89, 223-> 3

int EnterValueInt (string text)
{
    Console.Write(text);
    int value = Convert.ToInt32(Console.ReadLine());

    return value;
}

int[] FillArray (int limit)
{
    int [] array = new int [limit];

    for (int i = 0; i < array.Length; i++)
    {
        array[i] = EnterValueInt($"Введите {i+1} число в массиве -> ");

    }

    return array;
}

int Counter (int [] array)
{
    int counter = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i]>0) counter++;
    }

    return counter;
}

int n = EnterValueInt("Введите количество элементов массива -> ");

int[] array = FillArray(n);

int counter = Counter(array);

Console.WriteLine($"В массиве [{string.Join(", ", array)}] -> {counter} чисел больше нуля");


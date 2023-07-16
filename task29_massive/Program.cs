// Задача 29: Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.
// 1, 2, 5, 7, 19 -> [1, 2, 5, 7, 19]
// 6, 1, 33 -> [6, 1, 33]

int EnterValue (string text)
{
    Console.Write(text);
    int value = Convert.ToInt32(Console.ReadLine());

    return value;
}

int NumberGeneration (int firstNumber, int secondNumber)
{
    return new Random().Next(firstNumber, secondNumber + 1);
}

int massiveCounter = EnterValue("Ввведите длину массива: ");
int startRange = EnterValue("Введите нижний предел чисел: ");
int finishRange = EnterValue("Введите верхний предел чисел: ");

int [] massive = new int[massiveCounter];

for (int i = 0; i < massiveCounter; i++)
{
    massive[i] = NumberGeneration(startRange, finishRange);
    
}

Console.WriteLine($"[{string.Join(", ", massive)}]");


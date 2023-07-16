// Задача 25: Напишите цикл, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B.
// 3, 5 -> 243 (3⁵)
// 2, 4 -> 16

int EnterValue (string text)
{
    Console.Write(text);
    int value = Convert.ToInt32(Console.ReadLine());

    return value;
}

int number = EnterValue ("Введите число, которое будет возводить в степень: ");
int exponenta = EnterValue ("Введите, в какую стень буде возводить число? -> ");

int result = 1;

for (int i = 0; i < exponenta ; i++)
{
    result = result*number;
}

Console.WriteLine($"{number} в степени {exponenta} -> {result}");
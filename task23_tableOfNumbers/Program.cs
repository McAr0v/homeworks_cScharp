// Задача 23
// Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
// 3 -> 1, 8, 27
// 5 -> 1, 8, 27, 64, 125

// Функция отображения вводного текста ввода числа
int EnterValue (string text)
{
    Console.Write(text);
    int value = Convert.ToInt32(Console.ReadLine());

    return value;
}

bool CheckNumber (int number)
{
    if (number>0) return true;
    else return false;
}

int num3 = 0;
int inputNumber = EnterValue("Введите любое положительное число: ");

if (CheckNumber(inputNumber))
{

    for (int i = 1; i<=inputNumber; i++)
    {
        num3 = i*i*i;
        Console.Write($"{num3}, ");
    }

    Console.Write("\b\b ");

}
else Console.WriteLine("Введите число БОЛЬШЕ нуля!!!");

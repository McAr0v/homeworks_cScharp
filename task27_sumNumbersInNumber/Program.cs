// Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
// 452 -> 11
// 82 -> 10
// 9012 -> 12

int EnterValue (string text)
{
    Console.Write(text);
    int value = Convert.ToInt32(Console.ReadLine());

    return value;
}

int number = EnterValue("Введите число: ");

if (number<0) number = number*(-1);

int result = 0;

while (number>0)
{
    result = result + (number%10);
    number/= 10;

}

Console.WriteLine(result);
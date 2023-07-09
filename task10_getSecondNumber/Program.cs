// Задача 10: Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает вторую цифру этого числа.
// 456 -> 5
// 782 -> 8
// 918 -> 1

Console.Write("Введите трехзначное число ");
int number1 = Convert.ToInt32(Console.ReadLine());

if (number1<100 || number1>999) Console.WriteLine("Нужно было ввести 3х значное число!!");
else {
    int number2 = number1 / 10;
    int finishNumber = number2%10;
    Console.WriteLine(finishNumber);
}

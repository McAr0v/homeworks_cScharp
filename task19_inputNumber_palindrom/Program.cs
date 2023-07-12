// Задача 19
// Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.
// 14212 -> нет
// 12821 -> да
// 23432 -> да

// Функция отображения вводного текста ввода числа
int EnterValue (string text)
{
    Console.Write(text);
    int value = Convert.ToInt32(Console.ReadLine());

    return value;
}

// Функция проверки - является ли число пятизначным
bool NumberIsCorrect (int number)
{
    if (number > 9999 && number <= 99999) return true;
    else return false;
}

// Функция получения остатка от деления

int Modulo(int inputNumber, int module)
{
    return inputNumber%module;
}

// Функция деления числа на нужное

int NumberDivision (int inputNumber, int divider)
{
    return inputNumber / divider;
}

int number = EnterValue("Введите пятизначное число: "); // Начинаем программу

// Если число пятизначное
if (NumberIsCorrect(number))
{
    // делим введенное число на 2 части
    int firstHalf = NumberDivision(number, 1000); // левая пара чисел 
    int secondHalf = Modulo(number, 100); // правая пара чисел

    // Достаем первые числа из пар
    int numberFirst = NumberDivision(firstHalf, 10);
    int numberThird = NumberDivision(secondHalf, 10);

    // Достаем вторые числа из пар
    int numberSecond = Modulo(firstHalf, 10);
    int numberFourth = Modulo (secondHalf, 10);

    // Сравниваем числа - если первое число из первой пары и второе из второй пары одинаковы
    // и второе число из первой пары и первое число из второй пары одинаковы, то оно палиндром

    if (numberFirst == numberFourth && numberSecond == numberThird) Console.WriteLine($"Число {number} - палиндром");
    else Console.WriteLine($"Число {number} - НЕ палиндром"); // если нет - то не палиндром

}
else Console.WriteLine("Число должно быть пятизначным!!"); // вывод в консоль, если число не пятизначное
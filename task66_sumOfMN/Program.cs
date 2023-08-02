// Задача 66: Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.
// M = 1; N = 15 -> 120
// M = 4; N = 8. -> 30

// --- Функция вывода надписи в консоль и ввода значений ----

int EnterValueInt (string text)
{
    Console.Write(text);
    int value = Convert.ToInt32(Console.ReadLine());

    return value;
}

// --- Рекурсивная функция подсчета суммы чисел в промежутке ---

int SumOfNumbers(int startNumber, int finishNumber)
{
    // ---- Выход из рекурсии -> если конечное число == стартовое число, то возвращаем стартовое число
    if ( finishNumber == startNumber) return startNumber;

    // ---- В остальных случаях к финишному числу прибавляем "финишное число - 1" (предыдущее как бы)
    // -- Так двигаемся до тех пор, пока не дойдем до стартового числа

    return (finishNumber+SumOfNumbers(startNumber, finishNumber-1)); 
}

// --- Начало программы ----

// ---- Вводим значения ----
int m = EnterValueInt("Введите число M -> ");
int n = EnterValueInt("Введите число N -> ");

// ---- Если вдруг ввели числа наоборот, сначала большее а потом меньшее
// --- То просто поменяем их местами ---

if (m>n)
{
    int temp = m;
    m = n;
    n = temp;
}

// Получаем сумму чисел
int sum = SumOfNumbers(m,n);

// Выводим в консоль 
Console.WriteLine(sum);
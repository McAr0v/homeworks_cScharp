// Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
// m = 2, n = 3 -> A(m,n) = 9
// m = 3, n = 2 -> A(m,n) = 29

// --- Ввод значений. СДЕЛАЛ КАК РЕКУРСИЮ! -----

int EnterValueInt (string text, string numberName)
{
    // Выводится текст в консоль
    Console.Write(text);

    // Пользователь вводит число
    int value = Convert.ToInt32(Console.ReadLine());

    // Если число меньше 0, то такое число не пойдет. Заново вызываем ввод значения

    if (value<0) return EnterValueInt($"Число {numberName} должно быть не меньше 0! Введите заново -> ", numberName);

    // А если больше, то просто возвращаем

    return value;
}

// --- Рекурсивная функция Акермана. Условия прописаны согласно условиям функции Акермана

int AckermanFun (int m, int n)
{
    if(m==0) return n+1;
    if (m>0 && n == 0) return AckermanFun(m-1, 1);
    return AckermanFun(m-1, AckermanFun(m,n-1));
}

// --- Начало программы ----

// ---- Вводим значения ----
int m = EnterValueInt("Введите число M -> ", "M");
int n = EnterValueInt("Введите число N -> ", "N");

// ---- Получаем резульат функции Акермана ---
int result = AckermanFun(m,n);

// --- Выводим результат -----
Console.WriteLine(result);
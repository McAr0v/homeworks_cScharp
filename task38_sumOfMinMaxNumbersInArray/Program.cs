// Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
// [3.22, 4.2, 1.15, 77.15, 65.2] => 77.15 - 1.15 = 76

// Генератор массива с числами Double

double[] ArrayGenerator(int massiveSize, double startNumber, double finishNumber)
{
    // Принцип работы функции:

        // 0 - Генерируем пустой массив
        // 1 - мы конвертируем double числа предела генерации в int, умножив на 100 (функция DoubleToInt). Т.е например, 1.21 -> 121 и 5.31 -> 531
            // Это нужно для функции генерации .Next - она принимает только int
        // 2 - Генератор генерирует случайные числа в этом пределе (121, 531)
        // 3 - Берем сгенерированное число и умножаем на 0.01 чтобы вернуть 2 знака после запятой после конвертации обратно в double 
        // 341 -> 3.41
        // 4 - Помещаем сгенерированное число в массив

    double[] array = new double[massiveSize]; // 0 - Генерируем массив с нулями
    
    // 1 - мы конвертируем double числа предела генерации в int, умножив на 100 (функция DoubleToInt) Т.е например, 1.21 -> 121 и 5.31 -> 531

    int doubleToIntStart = DoubleToInt(startNumber); // Делаем из числа нижнего предела массива double -> int. 
    int doubleToIntFinish = DoubleToInt(finishNumber); // тоже самое для верхнего предела генерации массива

    // --- заполняем массив сгенерированными числами -----

    for (int i = 0; i < array.Length; i++)
    {
        
        double randomNumber = new Random().Next(doubleToIntStart, doubleToIntFinish) * 0.01; // 2-3 - Генерируем число и возвращаем его обратно в double  
        
        array[i] = RoundNumber(randomNumber, 2); // Округляем double до 2х знаков после запятой (иногда выдавал больше), и помещаем в массив
    }

    return array;
}

// ----- Функция конвертации double в int для генерации случайных чисел ---------

int DoubleToInt (double number)
{
    return Convert.ToInt32(number*100); // Чтобы сохранить 2 знака после запятой, умножаем на 100
}

// Функция округления чисел Double до нужного количества знаков после запятой

double RoundNumber (double number, int afterDecimal)
{
    return Math.Round(number, afterDecimal);
}

// Функция ввода значений Double

double EnterValueDouble (string text)
{
    Console.Write(text);
    double value = Convert.ToDouble(Console.ReadLine());

    return value;
}

// Функция ввода значений Int

int EnterValueInt (string text)
{
    Console.Write(text);
    int value = Convert.ToInt32(Console.ReadLine());

    return value;
}

// ---- НАЧАЛО ПРОГРАММЫ -------

int arraySize = EnterValueInt("Введите размер массива -> ");
double minLimit = EnterValueDouble("Введите нижний предел чисел массива (например, 1,22) -> ");
double maxLimit = EnterValueDouble("Введите верхний предел чисел массива (например, 1,23) -> ");

double[] array = ArrayGenerator(arraySize, minLimit, maxLimit); // Генерируем массив
Console.WriteLine($"Массив -> [{string.Join("; ", array)}]"); // выводим сгенерированный массив в консоль

double minNumber = array[0]; // Объявляем переменную минимального значения. По умолчанию, первый элемент в массиве
double maxNumber = array[0]; // Объявляем переменную максимального значения. По умолчанию, первый элемент в массиве

for (int i = 0; i < array.Length; i++)
{
    if (array[i] < minNumber) minNumber = array[i]; // Если элемент в массиве меньше минимального значения, то указываем, что теперь этот элемент самый минимальный
    if (array[i] > maxNumber) maxNumber = array[i]; // Тот же принцип, только с максимальным значением
}

double dif = RoundNumber(maxNumber - minNumber, 2); // Вычисляем разницу и сразу округляем результат до 2х знаков после запятой

Console.WriteLine($"Min -> {minNumber}, Max -> {maxNumber}, Разница -> {dif}"); // Выводим все в консоль

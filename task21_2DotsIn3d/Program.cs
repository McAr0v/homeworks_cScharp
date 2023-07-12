// Задача 21
// Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
// A (3,6,8); B (2,1,-7), -> 15.84
// A (7,-5, 0); B (1,-1,9) -> 11.53

// Функция отображения вводного текста ввода числа
int EnterValue (string text)
{
    Console.Write(text);
    int value = Convert.ToInt32(Console.ReadLine());

    return value;
}

int ax = EnterValue("Введите координату X для первой точки: ");
int ay = EnterValue("Введите координату Y для первой точки: ");
int az = EnterValue("Введите координату Z для первой точки: ");
int bx = EnterValue("Введите координату X для второй точки: ");
int by = EnterValue("Введите координату Y для второй точки: ");
int bz = EnterValue("Введите координату Z для второй точки: ");

double distance = Math.Sqrt(Math.Pow((ax-bx),2) + Math.Pow((ay-by),2) + Math.Pow((az-bz),2));
Console.Write($"Расстояние между точками равно:{Math.Round(distance,2)}");
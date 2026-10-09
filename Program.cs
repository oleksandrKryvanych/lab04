using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Окреме введення коефіцієнтів
        Console.Write("a = ");
        if (!double.TryParse(Console.ReadLine(), out double a)) return;

        Console.Write("b = ");
        if (!double.TryParse(Console.ReadLine(), out double b)) return;

        Console.Write("c = ");
        if (!double.TryParse(Console.ReadLine(), out double c)) return;

        double count = 0; // Кількість коренів

        if (Math.Abs(a) < 1e-9) // Лінійне рівняння (a = 0)
        {
            if (Math.Abs(b) < 1e-9)
                Console.WriteLine(Math.Abs(c) < 1e-9 ? "Безліч розв'язків" : "Коренів немає");
            else
            {
                Console.WriteLine($"Лінійне рівняння, x = {-c / b:F2}");
                count = 1;
            }
        }
        else // Квадратне рівняння
        {
            double D = b * b - 4 * a * c;
            Console.WriteLine($"D = {D:F2}");

            if (D > 1e-9)
            {
                Console.WriteLine($"x1 = {(-b + Math.Sqrt(D)) / (2 * a):F2}\nx2 = {(-b - Math.Sqrt(D)) / (2 * a):F2}");
                count = 2;
            }
            else if (Math.Abs(D) <= 1e-9)
            {
                Console.WriteLine($"x = {-b / (2 * a):F2}");
                count = 1;
            }
            else Console.WriteLine("Дійсних коренів немає");
        }

        // Рівень Б: switch із реляційними зразками та when
        string cat = count switch
        {
            2 when Math.Abs(a) > 100 => "2 корені (великий коефіцієнт a)",
            2 => "2 корені",
            1 => "1 корінь",
            0 => "Без коренів",
            _ => "Безліч розв'язків"
        };

        Console.WriteLine($"Категорія: {cat}");
    }
}

using System;

class Task2
{
    public void size()
    {
        Console.WriteLine("Ведите размер в байтах: ");
        if (!double.TryParse(Console.ReadLine(), out double bytes) || bytes < 0)
        {
            Console.WriteLine("Ошибка: введено некорректное число.");
            return;
        }
        
        double kb1000 = bytes / 1000;
        double mb1000 = kb1000 / 1000;
        double gb1000 = mb1000 / 1000;
        
        double kb1024 = bytes / 1024;
        double mb1024 = kb1000 / 1024;
        double gb1024 = mb1000 / 1024;
        
        Console.WriteLine("\nРезультаты конвертации:");
        Console.WriteLine(new string('-', 50));
        
        Console.WriteLine("\nРезультаты конвертации:");
        Console.WriteLine(new string('-', 50));
        
        Console.WriteLine($"{"Единица",-15} | {"Деление на 1000",-15} | {"Деление на 1024",-15}");
        Console.WriteLine(new string('-', 50));
        
        Console.WriteLine($"{"Килобайты (KB)",-15} | {kb1000,15:0.00} | {kb1024,15:0.00}");
        Console.WriteLine($"{"Мегабайты (MB)",-15} | {mb1000,15:0.00} | {mb1024,15:0.00}");
        Console.WriteLine($"{"Гигабайты (GB)",-15} | {gb1000,15:0.00} | {gb1024,15:0.00}");
        
        Console.WriteLine(new string('-', 50));
        

    }
}
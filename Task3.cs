using System;
using System.Globalization;

class Task3
{
    public void calculate()
    {
        // Настройка точки в качестве разделителя для дробных чисел
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Введите объём накопителя в ГБ (как на коробке): ");
        string input = Console.ReadLine();

        // Проверяем корректность ввода
        if (!double.TryParse(input, out double marketGb))
        {
            Console.WriteLine("Ошибка: введено некорректное число.");
            return;
        }

        if (marketGb <= 0)
        {
            Console.WriteLine("Ошибка: объём должен быть больше нуля.");
            return;
        }

        
        double totalBytes = marketGb * 1_000_000_000;
        double windowsGb = totalBytes / 1_073_741_824;
        
        double differenceGb = marketGb - windowsGb;
        double differencePercent = (differenceGb / marketGb) * 100;
        
        long totalWindowsMb = (long)(windowsGb * 1024);
        long photoSizeMb = 4;

        long photosCount = totalWindowsMb / photoSizeMb; 
        long remainingMb = totalWindowsMb % photoSizeMb; 
        double remainingGb = (double)remainingMb / 1024;
        
        Console.WriteLine("\n=== РЕЗУЛЬТАТЫ РАСЧЁТА ===");
        Console.WriteLine($"Объём в Windows: {windowsGb:F2} ГБ");
        Console.WriteLine($"Меньше на: {differenceGb:F2} ГБ ({differencePercent:F2}%)");
        
        Console.WriteLine("\n=== МЕСТО ДЛЯ ФОТОГРАФИЙ ===");
        Console.WriteLine($"Поместится фото (по 4 МБ): {photosCount} шт.");
        Console.WriteLine($"Останется свободного места: {remainingMb} МБ ({remainingGb:F4} ГБ)");
        
        Console.WriteLine("\n=== ОБЪЯСНЕНИЕ ===");
        Console.WriteLine("На самом деле память никуда не пропала. Производители накопителей");
        Console.WriteLine("считают объём в десятичной системе (1 ГБ = 10^9 байт). Операционная");
        Console.WriteLine("система Windows считает в двоичной системе (1 ГБ = 2^30 байт).");
        Console.WriteLine("Из-за этой разницы в формулах возникает разница в отображении.");
    }
}

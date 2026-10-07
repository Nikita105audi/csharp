using System;
using System.Globalization;

class Task4
{
    public void download()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Введите размер файла в ГБ: ");
        if (!double.TryParse(Console.ReadLine(), out double fileSizeGb) || fileSizeGb <= 0)
        {
            Console.WriteLine("Ошибка: некорректный размер файла.");
            return;
        }

        Console.Write("Введите скорость тарифа в Мбит/с: ");
        if (!double.TryParse(Console.ReadLine(), out double speedMbps) || speedMbps <= 0)
        {
            Console.WriteLine("Ошибка: некорректная скорость.");
            return;
        }
        
        double speedMBps = speedMbps / 8;
        
        double fileSizeMb = fileSizeGb * 1024;
        
        double totalSecondsExact = fileSizeMb / speedMBps;
        long totalSeconds = (long)Math.Ceiling(totalSecondsExact);
        
        long hours = totalSeconds / 3600;
        long remainderMinutes = totalSeconds % 3600;
        long minutes = remainderMinutes / 60;
        long seconds = remainderMinutes % 60;

        // Вывод результатов
        Console.WriteLine("\n=== РЕЗУЛЬТАТЫ РАСЧЁТА ===");
        Console.WriteLine($"Скорость скачивания: {speedMBps:F2} МБ/с");
        Console.WriteLine($"Время скачивания: {hours} час(ов) {minutes} минут(ы) {seconds} секунд(ы)");
    }
}
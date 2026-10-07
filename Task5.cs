using System;

class Task5
{
    public void utf()
    {
        // Включаем поддержку кириллицы в консоли, если она не настроена
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Write("Введите строку для анализа: ");
        string input = Console.ReadLine();

        if (input == null) return;

        // Переменные для подсчета типов символов
        int russianLetters = 0;
        int latinLetters = 0;
        int digits = 0;
        int spaces = 0;
        int punctuation = 0;
        int otherSymbols = 0;

        // Анализируем каждый символ в строке
        foreach (char c in input)
        {
            // 1. Русские буквы (Кириллица: А-Я, а-я, а также Ё и ё)
            if ((c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я') || c == 'Ё' || c == 'ё')
            {
                russianLetters++;
            }
            // 2. Латинские буквы (A-Z, a-z)
            else if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
            {
                latinLetters++;
            }
            // 3. Цифры
            else if (char.IsDigit(c))
            {
                digits++;
            }
            // 4. Пробелы и скрытые символы разметки
            else if (char.IsWhiteSpace(c))
            {
                spaces++;
            }
            // 5. Знаки препинания
            else if (char.IsPunctuation(c))
            {
                punctuation++;
            }
            // 6. Прочие символы (эмодзи, математические знаки, спецсимволы вроде ©)
            else
            {
                otherSymbols++;
            }
        }

        // Подсчет реальных байт в UTF-8
        int realBytesCount = Encoding.UTF8.GetByteCount(input);

        // Расчет ожидаемых байт по правилу из теории:
        // Русские буквы — 2 байта, латиница, цифры, пробелы и пунктуация — 1 байт.
        // Для "прочих символов" (например, эмодзи) теория может не работать, но базовое правило учитываем так:
        int expectedBytesCount = (russianLetters * 2) + latinLetters + digits + spaces + punctuation + otherSymbols;

        // Вывод результатов
        Console.WriteLine("\n=== СТАТИСТИКА СТРОКИ ===");
        Console.WriteLine($"Всего символов: {input.Length}");
        Console.WriteLine($"Русских букв:   {russianLetters}");
        Console.WriteLine($"Латинских букв: {latinLetters}");
        Console.WriteLine($"Цифр:           {digits}");
        Console.WriteLine($"Пробелов:       {spaces}");
        Console.WriteLine($"Знаков препинания: {punctuation}");
        Console.WriteLine($"Прочих символов: {otherSymbols}");

        Console.WriteLine("\n=== ПРОВЕРКА ТЕОРИИ UTF-8 ===");
        Console.WriteLine($"Реальное количество байт (UTF-8): {realBytesCount}");
        Console.WriteLine($"Ожидаемое количество байт:        {expectedBytesCount}");

        if (realBytesCount == expectedBytesCount)
        {
            Console.WriteLine("✅ Правило подтверждено! Ожидаемый и реальный объемы совпадают.");
        }
        else
        {
            Console.WriteLine("❌ Внимание! Объемы расходятся.");
            Console.WriteLine("Объяснение: Прочие символы (например, эмодзи или редкие знаки) могут занимать от 3 до 4 байт в UTF-8.");
        }
    }
}

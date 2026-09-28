using System;

class Task1
{
    public void hellow()
    {
        Console.WriteLine("Ваше имя?");
        string name = Console.ReadLine();
        name = (name ?? " ").Trim();
        Console.WriteLine($"Здравствуйте {name}");

        if (name.Length == 0)
        {
            Console.WriteLine("Администратор");
        }
        
        Console.WriteLine();
        Console.WriteLine(DateTime.Now);
        Console.WriteLine(name.Length);
    }
}
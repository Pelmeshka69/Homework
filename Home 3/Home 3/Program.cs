using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть числа через кому:");
            var input = Console.ReadLine();
            var numbers = input.Split(',').Select(int.Parse).ToList();

            while (true)
            {
                Console.WriteLine("\nОберіть операцію:");
                Console.WriteLine("1. Фільтрація");
                Console.WriteLine("2. Сортування");
                Console.WriteLine("3. Вихід");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Введіть число для фільтрації:");
                        var filter = int.Parse(Console.ReadLine());
                        var filtered = numbers.Where(n => n > filter);
                        Console.WriteLine($"Числа більші за {filter}: {string.Join(", ", filtered)}");
                        break;
                    case "2":
                        var sorted = numbers.OrderBy(n => n);
                        Console.WriteLine($"Відсортовані числа: {string.Join(", ", sorted)}");
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Невідома опція");
                        break;
                }
            }
        }
    }
}
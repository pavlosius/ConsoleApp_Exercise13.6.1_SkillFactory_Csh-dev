using System.Diagnostics;

var filePath = "Text1.txt";
var location = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
var path = Path.Combine(location, filePath);
Console.WriteLine($"Путь к файлу: {path}");
if (File.Exists(filePath))
{
    string text;
    using (StreamReader sr = File.OpenText(filePath))
    {
        text = sr.ReadToEnd();
    }
    var characters = text.ToCharArray();
    var symbols = new LinkedList<char>();
    var symbolsCount = characters.Length;
    Console.Write($"Время вставки всех символов ({symbolsCount} шт.) по очереди в конец списка LinkedList<char>: ");
    var stopWatch = Stopwatch.StartNew();
    foreach (var symbol in characters)
    {
        symbols.AddLast(symbol);
    }
    Console.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds}  мс");
    Console.Write($"Время вставки всех символов ({symbolsCount} шт.) по очереди во вторую позицию списка LinkedList<char>: ");
    var symbols2 = new LinkedList<char>();
    stopWatch = Stopwatch.StartNew();
    symbols2.AddFirst(characters[0]);
    for (int i = 1; i < symbolsCount; i++)
    {
        symbols2.AddAfter(symbols2.First, characters[i]);
    }
    Console.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds}  мс");
    Console.Write($"Время вставки всех символов ({symbolsCount} шт.) по очереди в предпоследнюю позицию списка LinkedList<char>: ");
    var symbols3 = new LinkedList<char>();
    stopWatch = Stopwatch.StartNew();
    symbols3.AddFirst(characters[0]);
    for (int i = 1; i < symbolsCount; i++)
    {
        symbols3.AddBefore(symbols3.Last, characters[i]);
    }
    Console.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds}  мс");
}
else
{
    Console.WriteLine("По заданному пути файл не существует.");
}
Console.WriteLine("Программа завершена");
Console.ReadKey();

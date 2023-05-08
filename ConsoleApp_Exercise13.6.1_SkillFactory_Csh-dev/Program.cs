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
    var symbols = new List<char>();
    var symbolsCount = characters.Length;
    Console.Write($"Время вставки всех символов ({symbolsCount} шт.) по очереди в конец списка List<char>: ");
    var stopWatch = Stopwatch.StartNew();
    foreach (var symbol in characters)
    {
        symbols.Add(symbol);
    }
    Console.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds}  мс");
    Console.Write($"Время вставки всех символов ({symbolsCount} шт.) по очереди во вторую позицию списка List<char>: ");
    var symbols2 = new List<char>();
    stopWatch = Stopwatch.StartNew();
    symbols2.Add(characters[0]);
    for (int i = 1; i < symbolsCount; i++)
    {
        symbols2.Insert(1, characters[i]);
    }
    Console.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds}  мс");
    Console.Write($"Время вставки всех символов ({symbolsCount} шт.) по очереди в предпоследнюю позицию списка List<char>: ");
    var symbols3 = new List<char>();
    stopWatch = Stopwatch.StartNew();
    symbols3.Add(characters[0]);
    for (int i = 1; i < symbolsCount; i++)
    {
        symbols3.Insert(i-1, characters[i]);
    }
    Console.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds}  мс");
}
else
{
    Console.WriteLine("По заданному пути файл не существует.");
}
Console.WriteLine("Программа завершена");
Console.ReadKey();

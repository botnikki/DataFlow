using DataFlow.Core;
public class Program
{
    //ШАГ 7
    public abstract class Animal
    {
        public string Name { get; set; } = "";
        public override string ToString() => $"{GetType().Name} по имени {Name}";
    }
    public sealed class Dog : Animal
    {
    }
    public static void Main(string[] args)
    {
        //ШАГ 1
        var probe = new Buffer<int>();
        Console.WriteLine(probe.TryAdd(1));
        Console.WriteLine(probe.TryAdd(2));
        Console.WriteLine(probe.TryAdd(3));
        Console.WriteLine(probe.Count);
        //ШАГ 2
        var labels = new LabeledBuffer();
        labels.TryAdd("привет");
        labels.TryAdd("мир");
        labels.TryAdd("отчёт");
        labels.PrintAllUpper();
        Console.WriteLine($"LabeledBuffer.Count = {labels.Count}");
        //ШАГ 3
        var numbers = new GuardedBuffer<int>(x => x > 0);
        Console.WriteLine(numbers.TryAdd(5));
        Console.WriteLine(numbers.TryAdd(-3));
        Console.WriteLine(numbers.TryAdd(100));
        Console.WriteLine($"Count = {numbers.Count}, AcceptedCount = {numbers.AcceptedCount}");
        var words = new GuardedBuffer<string>(s => !string.IsNullOrWhiteSpace(s));
        Console.WriteLine(words.TryAdd("обобщение"));
        Console.WriteLine(words.TryAdd(" "));
        Console.WriteLine($"Count = {words.Count}, AcceptedCount = {words.AcceptedCount}");
        Console.WriteLine($"numbers.AcceptedCount = {numbers.AcceptedCount}");
        //ШАГ 4
        var temperature = new Record<double>(20, "°C");
        Console.WriteLine($"Исходная запись: {temperature}");
        var fahrenheit = RecordMapper.Map(
        temperature, (double c) => c * 9 / 5 + 32, "°F");
        Console.WriteLine($"double → double: {fahrenheit}");
        var category = RecordMapper.Map(
        temperature, (double c) => c >= 15 ? "тепло" : "холодно", "Категория");
        Console.WriteLine($"double → string: {category}");
        var health = new Record<int>(50, "Здоровье");
        Console.WriteLine($"int → int: {RecordMapper.Map(health, (int h) => h + 10, "Здоровье с бонусом")}");
        Console.WriteLine($"int → bool: {RecordMapper.Map(health, (int h) => h >= 50, "В норме")}");
        //ШАГ 7
        var container = new Container<Dog>(new Dog { Name = "Шарик" });
        IContainer<Animal> animal = container;
        Console.WriteLine($"IContainer<Animal>.GetItem() = {animal.GetItem()}");
        //ШАГ 8
        var nums = new List<int> { 5, 9, 2 };
        Console.WriteLine($"FindMax на List<int> = {nums.FindMax()}");
        Console.WriteLine($"FindMax на пустом List<string> = {(new List<string>().FindMax() is
        null ? "null" : "ошибка")}");
        Console.WriteLine($"FindMax на пустом List<int> = {new List<int>().FindMax()}");
        nums.PrintAll("Элемент: ");
        new List<string>().PrintAll("Элемент: ");
        Console.WriteLine("(пустой список ничего не напечатал)");
    }
}
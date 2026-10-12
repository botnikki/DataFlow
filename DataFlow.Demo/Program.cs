using DataFlow.Core;
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
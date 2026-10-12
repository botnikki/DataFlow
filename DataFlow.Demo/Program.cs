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
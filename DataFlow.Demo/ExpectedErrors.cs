using DataFlow.Core;
using static DataFlow.Demo.Domain;
/*


namespace DataFlow.Demo;
// ОШИБКА 1 — инвариантность обобщённого класса
// Ожидается: CS0029
public class Error1
{
    public static void Check()
    {
        Container<Animal> box = new Container<Dog>(new Dog { Name = "Шарик" });
        Console.WriteLine(box);
    }
}

// ОШИБКА 2 — нарушение ковариантности
// Файл временно кладём рядом с Container.cs в DataFlow.Core
// Ожидается: CS1961
public interface IProbeContainer<out T>
{
T GetItem();
void Put(T item);
}

// ОШИБКА 3 — нарушение ограничения типа
// Ожидается: CS0311
public class Error3
{
public static void Check()
{
var repo = new InMemoryRepository<string>();
Console.WriteLine(repo);
}
}

*/
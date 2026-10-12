namespace DataFlow.Core;

public sealed class Container<T> : IContainer<T>
{
    private readonly T item;
    public Container(T item)
    {
        this.item = item;
    }
    public T GetItem() => item;

    public static implicit operator Container<T>(Container<DataFlow.Demo.Domain.Dog> v)
    {
        throw new NotImplementedException();
    }
}

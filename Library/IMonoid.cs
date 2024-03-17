namespace Library;

public interface IMonoid<T>
{
    T IdentityElement { get; }
    T Operate(T a, T b);
}
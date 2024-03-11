namespace Library;

public interface IOracle<TMonoid>
{
    TMonoid IdentityElement { get; }
    TMonoid Operate(TMonoid a, TMonoid b);
}
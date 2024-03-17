namespace Library;

public class ModularArithmetic
{
    private int _mod { get; set; }

    public ModularArithmetic(int mod)
    {
        _mod = mod;
    }
    
    public int Add(int a, int b)
    {
        a += b;
        if (a > _mod)
        {
            a -= _mod;
        }

        return a;
    }

    public long DivideCeiling(long a, long b)
    {
        return (a >= 0 ? a+b-1 : a)/b;
    }
}
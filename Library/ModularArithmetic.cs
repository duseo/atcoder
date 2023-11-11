namespace Library;

public class ModularArithmetic
{
    private int _mod { get; set; }

    public ModularArithmetic(int mod)
    {
        _mod = mod;
    }
    
    public void Add(ref int a, int b)
    {
        a += b;
        if (a > _mod)
        {
            a -= _mod;
        }
    }
}
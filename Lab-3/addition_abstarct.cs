abstract class  addition_abstract
{
    public abstract int addd(int a, int b);
    public abstract int addd(int a, int b, int c);
}

class addition : addition_abstract
{
    public override int addd(int a, int b)
    {
        return a + b;
    }
    public override int addd(int a, int b, int c)
    {
        return a + b + c;
    }
}
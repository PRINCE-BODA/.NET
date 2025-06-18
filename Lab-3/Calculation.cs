interface Calculate
{
    void Addition(int a, int b);
    void Subtraction(int a, int b);
}

class Result : Calculate
{
    public void Addition(int a, int b)
    {
        int sum = a + b;
        Console.WriteLine("Addition: " + sum);
    }

    public void Subtraction(int a, int b)
    {
        int diff = a - b;
        Console.WriteLine("Subtraction: " + diff);
    }
}
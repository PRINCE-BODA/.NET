//Create a class named RBI with calculateInterest() method. Create another    
//classes HDFC, SBI, ICICI which overrides calculateInterest() method.

class RBI
{
    public virtual void CalculateIterest(double p , double r,double t)
    {
       Console.WriteLine("Interest is: " + (p * r * t) / 100);
    }

}

class HDFC : RBI
{
    public override void CalculateIterest(double p, double r, double t)
    {
       Console.WriteLine("HDFC Interest is: " + (p * r * t) / 100);
    }
}
class SBI : RBI
{
    public override void CalculateIterest(double p, double r, double t)
    {
       Console.WriteLine("SBI Interest is: " + (p * r * t) / 100);
    }
}
class ICICI : RBI
{
    public override void CalculateIterest(double p, double r, double t)
    {
       Console.WriteLine("ICICI Interest is: " + (p * r * t) / 100);
    }
}
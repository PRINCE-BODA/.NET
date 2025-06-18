using System;
class Staff
{
    public String  Name;
    public string desc;
    public int exp;
    public string Email;
    public void  GetDetails()
    {
        Console.WriteLine("Enter Name: ");
        Name = Console.ReadLine();
        Console.WriteLine("Enter discription: ");
        desc = Console.ReadLine();
        Console.WriteLine("Enter Expirience: ");
        exp = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Email: ");
        Email = Console.ReadLine();
    }
    public void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}, Name: {Name}, Age: {desc}, Email: {Email}");
    }
}
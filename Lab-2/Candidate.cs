using System;

public class Candidate
{
    public int Id;
    public string Name;
    public int Age;
    public string Weight;

    public void getdetails(int id, string name, int age, string weight)
    {
        Id = id;
        Name = name;
        Age = age;
        Weight = weight;
    }
    public void DisplayDetails()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}, Age: {Age}, Weight: {Weight}");
    }
}

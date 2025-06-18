using System;
public class Student
{
    int rollNumber;
    string name;
    int semester;
    int cpi;
    int spi;
    public void GetDetails(int rollNumber, string name, int semester, int cpi, int spi)
    {
        this.rollNumber = rollNumber;
        this.name = name;
        this.semester = semester;
        this.cpi = cpi;
        this.spi = spi;
    }
    public void DisplayDetails()
    {
        Console.WriteLine($"Roll Number: {rollNumber}, Name: {name}, Semester: {semester}, CPI: {cpi}, SPI: {spi}");
    }
}
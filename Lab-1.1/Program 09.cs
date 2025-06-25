
Console.WriteLine("Enter Number : ");
int num1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Number : ");
int num2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Number : ");
int num3 = Convert.ToInt32(Console.ReadLine());

if (num1 > num2 && num1 > num3)
    Console.WriteLine(num1 + " Is Greater");
else if (num2 > num3)
    Console.WriteLine(num2 + " Is Greater");
else
    Console.WriteLine(num3 + " Is Greater");

Console.Write("Enter Farenheit : ");
int f = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter  Celsius : ");
int c = Convert.ToInt32(Console.ReadLine());

int f2 = (9 / 5) * c + 32;
int c2 = (f - 32) * 5 / 9;

Console.WriteLine("F to C : " + c2);
Console.WriteLine("C to F : " + f2);
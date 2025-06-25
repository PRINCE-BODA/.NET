
Console.WriteLine("Enter First Number : ");
int num1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Second Number : ");
int num2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Choice : ");
char choice = Convert.ToChar(Console.ReadLine());
if (choice == '+')
    Console.WriteLine("Addition : " + (num1 + num2));
else if (choice == '-')
    Console.WriteLine("Subtraction : " + (num1 - num2));
else if (choice == '*')
    Console.WriteLine("Multiplication : " + (num1 * num2));
else if (choice == '/')
    Console.WriteLine("Division : " + (num1 / num2));
else if (choice == '%')
    Console.WriteLine("Modulo : " + (num1 % num2));
else
    Console.WriteLine("Enter valid operation");
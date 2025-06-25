
Console.WriteLine("Enter First Number : ");
int num1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Second Number : ");
int num2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Choice : ");
char choice = Convert.ToChar(Console.ReadLine());
switch (choice)
{
    case '+':
        Console.WriteLine("Addition : " + (num1 + num2));
        break;

    case '-':
        Console.WriteLine("Subtraction : " + (num1 - num2));
        break;

    case '*':
        Console.WriteLine("Multiplication : " + (num1 * num2));
        break;

    case '/':
        Console.WriteLine("Division : " + (num1 / num2));
        break;

    case '%':
        Console.WriteLine("Modulo : " + (num1 % num2));
        break;

    default:
        Console.WriteLine("Enter valid Choice");
}

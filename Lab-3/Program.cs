// class Program
//{
//    public static void Main(String[] args)
//    {
//        int number1 = 10;
//        int number2 = 0;
//        int result;

//        try
//        {
//            result = number1 / number2;
//            Console.Write("Result: " + result);
//        }
//        catch (ArithmeticException e)
//        {
//            Console.Write("Error: Cannot divide by zero.");
//        }
//    }
//}




//class program
//{
//    public static void Main(String[] args)
//    {
//       int[] numbers = new int[5];
//        for(int i = 0; i <= 5; i++)
//        {
//            try
//            {
//                Console.Write("Enter number " + (i + 1) + ": ");
//                numbers[i] = int.Parse(Console.ReadLine());
//            }
//            catch (IndexOutOfRangeException e)
//            {
//                Console.WriteLine("Error: Index out of range.");
//            }
//        }
//    }
//}



//using System.Runtime.InteropServices;

//class program
//{
//    public static void Main(String[] args)
//    {
//        addition add = new addition();
//         Console.WriteLine("Addition of 2 numbers: " + add.addd(10, 20));
//         Console.WriteLine("Addition of 3 numbers: " + add.addd(10, 20, 30));
//    }
//}





//class Program
//{
//    static void Main()
//    {
//        Result obj = new Result();

//        Console.Write("Enter first number: ");
//        int num1 = Convert.ToInt32(Console.ReadLine());

//        Console.Write("Enter second number: ");
//        int num2 = Convert.ToInt32(Console.ReadLine());

//        obj.Addition(num1, num2);
//        obj.Subtraction(num1, num2);
//    }
//}



//class program
//{
//    public static void Main(String[] args)
//    {
//        Console.WriteLine("ENter String");
//        String str = Console.ReadLine();
//        Console.WriteLine("Length of String: " + str.Length);
//        Console.WriteLine("Uppercase: " + str.ToUpper());
//        Console.WriteLine("Lowercase: " + str.ToLower());
//        Console.WriteLine("Substring (0, 5): " + str.Substring(0, 5));
//    }
//}




//. Write a program to Replace lower case characters to upper case and     
//Vice-versa. 
//class program
//{
//    public static void Main(String[] args)
//    {
//        Console.WriteLine("Enter String:");
//        String str = Console.ReadLine();

//        char[] charArray = str.ToCharArray();
//        for (int i = 0; i < charArray.Length; i++)
//        {
//            if (char.IsLower(charArray[i]))
//            {
//                charArray[i] = char.ToUpper(charArray[i]);
//            }
//            else if (char.IsUpper(charArray[i]))
//            {
//                charArray[i] = char.ToLower(charArray[i]);
//            }
//        }

//        String result = new String(charArray);
//        Console.WriteLine("New String: " + result);
//    }
//}



//class Program
//{
//    public static void Main()
//    {
//        Geometry obj = new Geometry();

//        Console.Write("Enter radius of circle: ");
//        double r = Convert.ToDouble(Console.ReadLine());
//        obj.Circle(r);

//        Console.Write("Enter base of triangle: ");
//        double b = Convert.ToDouble(Console.ReadLine());
//        Console.Write("Enter height of triangle: ");
//        double h = Convert.ToDouble(Console.ReadLine());
//        obj.Triangle(b, h);

//        Console.Write("Enter side of square: ");
//        double s = Convert.ToDouble(Console.ReadLine());
//        obj.Square(s);
//    }
//}




//class program
//{
//   public  static void Main()
//    {
//        try
//        {
//            Console.Write("Enter a number: ");
//            int number = Convert.ToInt32(Console.ReadLine());

//            if (number % 2 != 0)
//            {
//                throw new Exception("The number is not even!");
//            }

//            Console.WriteLine("The number is even.");
//        }

//        catch (Exception e)
//        {
//            Console.WriteLine("Error: " + e.Message);
//        }
//    }
//}



// This program takes a string input from the user, splits it into words, and finds the longest word along with its
// length. It handles various delimiters like spaces, punctuation, etc. The result is printed to the console.

//class program
//{
//    public static void Main()
//    {
//        Console.Write("Enter a string: ");
//        string input = Console.ReadLine();
//        String[] words = input.Split(" ");
//        string longestWord = "";
//        int maxLength = 0;
//        for (int i = 0; i < words.Length; i++)
//        {
//            if (words[i].Length > maxLength)
//            {
//                maxLength = words[i].Length;
//                longestWord = words[i];
//            }
//        }
//        Console.WriteLine("Longest word: " + longestWord);
//        Console.WriteLine("Length: " + maxLength);
//    }

//}

//10.Write a program to change the case of entered character. 
class program
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter String:");
        String str = Console.ReadLine();

        char[] charArray = str.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            if (char.IsLower(charArray[i]))
            {
                charArray[i] = char.ToUpper(charArray[i]);
            }
            else if (char.IsUpper(charArray[i]))
            {
                charArray[i] = char.ToLower(charArray[i]);
            }
        }

        String result = new String(charArray);
        Console.WriteLine("New String: " + result);
    }
}
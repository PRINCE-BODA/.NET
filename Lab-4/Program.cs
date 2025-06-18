//public class Program
//{
//    public static void Main(string[] args)
//    {
//        Addition_overloading add = new Addition_overloading();
//        int intresult = add.addd(5, 10);
//        float floatresuklt = add.addd(10.2f, 15.15f);
//        Console.WriteLine(floatresuklt);
//        Console.WriteLine(intresult);
//    }
//}



//public class Program
//{
//    public static void Main(string[] args)
//    {
//        tri_sqare ts = new tri_sqare();
//        int squareArea = ts.Area(5);
//        int rectangleArea = ts.Area(5, 10);
//        Console.WriteLine("Area of Square: " + squareArea);
//        Console.WriteLine("Area of Rectangle: " + rectangleArea);
//    }
//}


//public class Program
//{
//    public static void Main(string[] args)
//    {
//        RBI rbi = new RBI();
//        rbi.CalculateIterest(1000, 5, 2);
//        HDFC hdfc = new HDFC();
//        hdfc.CalculateIterest(1000, 5, 3);
//        SBI sbi = new SBI();
//        sbi.CalculateIterest(1000, 5, 4);
//        ICICI icici = new ICICI();
//        icici.CalculateIterest(1000, 5, 5);
//    }
//}


//public class Program
//{
//    public static void Main(string[] args)
//    {
//        Hospital hospital = new Hospital();
//        hospital.HospitalDetails();
//        Apollo apollo = new Apollo();
//        apollo.HospitalDetails();
//        Wockhardt wockhardt = new Wockhardt();
//        wockhardt.HospitalDetails();
//        Gokul_Superspeciality gokul = new Gokul_Superspeciality();
//        gokul.HospitalDetails();
//    }
//}


//class program
//{
//    public static void Main(string[] args)
//    {
//        Areaof3 area = new Areaof3();
//        double circleArea = area.Area(5); 
//        Console.WriteLine("Area of Circle: " + circleArea);
//        Areaof3_Square square = new Areaof3_Square();
//        double squareArea = square.Area(4);
//        Console.WriteLine("Area of Square: " + squareArea);
//        Areaof3_Rectangle rectangle = new Areaof3_Rectangle();
//        double rectangleArea = rectangle.Area(5, 10);
//        Console.WriteLine("Area of Rectangle: " + rectangleArea);
//        Areaof3_Circle circle = new Areaof3_Circle();
//        double circleArea2 = circle.Area(7);
//        Console.WriteLine("Area of Circle (using Areaof3_Circle): " + circleArea2);
//    }
//}


class program
{
    public static void Main(string[] args)
    {
        BankAcc account = new BankAcc("John Doe", 1000.00m);
        account.Deposit(500.00m);
        account.Withdraw(200.00m);
        account.Withdraw(1500.00m); 
      \
    }
}
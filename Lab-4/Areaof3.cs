//Write a programs to Find Area of Square, Rectangle and Circle using
//Method Overloading. 
class Areaof3
{
    public virtual double Area(double r)
    {
        return 3.14 * r * r; 
    }

}

class Areaof3_Square : Areaof3
{
    public override double Area(double side)
    {
        return side * side; 
    }
}

class Areaof3_Rectangle : Areaof3
{
    public double Area(double length, double breadth)
    {
        return length * breadth; 
    }
}
class Areaof3_Circle : Areaof3
{
    public override double Area(double radius)
    {
        return 3.14 * radius * radius; 
    }
}
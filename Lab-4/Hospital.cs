//Create a class Hospital with HospitalDetails() method.Create another     
//classes Apollo, Wockhardt, Gokul_Superspeciality which overrides     
//HospitalDetails() method. 
class Hospital
{
    public virtual void HospitalDetails()
    {
        Console.WriteLine("Hospital Details: General Hospital");
    }
}

class Apollo : Hospital
{
    public override void HospitalDetails()
    {
        Console.WriteLine("Hospital Details: Apollo Hospital, Specializes in Cardiology");
    }
}
class Wockhardt : Hospital
{
    public override void HospitalDetails()
    {
        Console.WriteLine("Hospital Details: Wockhardt Hospital, Specializes in Neurology");
    }
}
class Gokul_Superspeciality : Hospital
{
    public override void HospitalDetails()
    {
        Console.WriteLine("Hospital Details: Gokul Superspeciality Hospital, Specializes in Orthopedics");
    }
}
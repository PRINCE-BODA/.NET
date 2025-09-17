using HMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
public class HomeController : Controller
{
    private readonly IConfiguration _configuration;

    public HomeController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        string connectionStr = _configuration.GetConnectionString("HMSConnectionStr");

        ViewBag.TotalUsers = GetCountFromProcedure(connectionStr, "PR_User_SelectAll");
        ViewBag.TotalDepartments = GetCountFromProcedure(connectionStr, "PR_Department_SelectAll");
        ViewBag.TotalDoctors = GetCountFromProcedure(connectionStr, "PR_Doctor_SelectAll");
        ViewBag.TotalDoctorDepartments = GetCountFromProcedure(connectionStr, "PR_DoctorDepartment_SelectAll");
        ViewBag.TotalPatients = GetCountFromProcedure(connectionStr, "PR_Patient_SelectAll");
        ViewBag.TotalAppointments = GetCountFromProcedure(connectionStr, "PR_Appointment_SelectAll");

        return View();
    }

    private int GetCountFromProcedure(string connectionStr, string procedureName)
    {
        using (SqlConnection connection = new SqlConnection(connectionStr))
        {
            SqlCommand cmd = new SqlCommand(procedureName, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows.Count;
        }
    }
}

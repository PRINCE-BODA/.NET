using ClosedXML.Excel;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HMS.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IConfiguration myconfiguration;

        public DoctorController(IConfiguration configuration)
        {
            myconfiguration = configuration;
        }

        public IActionResult DoctorList()
        {
            string connectionString = myconfiguration.GetConnectionString("HMSConnectionStr");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PR_Doctor_SelectAll";

                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                return View("DoctorList", dt);
            }
        }

        public IActionResult DoctorDelete(int doctorID)
        {
            string connectionStr = myconfiguration.GetConnectionString("HMSConnectionStr");

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PR_Doctor_DeleteByPK";
                command.Parameters.AddWithValue("@DoctorID", doctorID);
                command.ExecuteNonQuery();
            }

            return RedirectToAction("DoctorList");
        }

        [HttpGet]
        public IActionResult DoctorAddEdit(int? doctorID)
        {
            DoctorModel doctorModel = new DoctorModel();

            if (doctorID > 0)
            {
                string connectionStr = myconfiguration.GetConnectionString("HMSConnectionStr");

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PR_Doctor_SelectByPK";
                    command.Parameters.AddWithValue("@DoctorID", doctorID);

                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    foreach (DataRow row in dt.Rows)
                    {
                        doctorModel.DoctorID = Convert.ToInt32(row["DoctorID"]);
                        doctorModel.Name = row["Name"].ToString();
                        doctorModel.Phone = row["Phone"].ToString();
                        doctorModel.Email = row["Email"]?.ToString();
                        doctorModel.Qualification = row["Qualification"]?.ToString();
                        doctorModel.Specialization = row["Specialization"]?.ToString();
                        doctorModel.IsActive = Convert.ToBoolean(row["IsActive"]);
                        doctorModel.UserID = Convert.ToInt32(row["UserID"]);
                    }
                }
            }
            UserDropDown();
            return View("DoctorAddEdit", doctorModel);
        }

        [HttpPost]
        public IActionResult DoctorSave(DoctorModel doctor)
        {
            if (ModelState.IsValid)
            {
                string connectionStr = myconfiguration.GetConnectionString("HMSConnectionStr");

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;

                    if (doctor.DoctorID == 0)
                    {
                        command.CommandText = "PR_Doctor_Insert";
                    }
                    else
                    {
                        command.CommandText = "PR_Doctor_UpdateByPK";
                        command.Parameters.AddWithValue("@DoctorID", doctor.DoctorID);
                    }

                    command.Parameters.AddWithValue("@Name", doctor.Name ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Phone", doctor.Phone ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Email", doctor.Email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Qualification", doctor.Qualification ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Specialization", doctor.Specialization ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", doctor.IsActive);
                    command.Parameters.AddWithValue("@UserID", doctor.UserID);

                    command.ExecuteNonQuery();
                }

                TempData["SuccessMessage"] = "Doctor saved successfully.";
                return RedirectToAction("DoctorList");
            }
            UserDropDown();
            return View("DoctorAddEdit", doctor);
        }
        [Route("ExportToExcelDoctors")]
        public IActionResult ExportToExcelDoctors()
        {
            string connectionStr = myconfiguration.GetConnectionString("HMSConnectionStr");
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();

            SqlCommand cmd = new SqlCommand("PR_Doctor_SelectAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            using (var workbook = new XLWorkbook())
            {
                workbook.Worksheets.Add(dt, "Users");

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Doctors.xlsx"
                    );
                }
            }
        }


        public void UserDropDown()
        {
            string connectionString = myconfiguration.GetConnectionString("HMSConnectionStr");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PR_User_DropDown";

                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader); 

                List<UserModel> userList = new List<UserModel>();
                foreach (DataRow data in dataTable.Rows)
                {
                    UserModel model = new UserModel();
                    model.UserID = Convert.ToInt32(data["UserID"]);
                    model.UserName = data["UserName"].ToString();
                    userList.Add(model);
                }
                ViewBag.UserList = userList;
            }
        }
    }
}

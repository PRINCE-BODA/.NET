using ClosedXML.Excel;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HMS.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IConfiguration myconfiguration;

        public PatientsController(IConfiguration configuration)
        {
            myconfiguration = configuration;
        }

        // ✅ GET: All Patients
        public IActionResult PatientsList()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(myconfiguration.GetConnectionString("HMSConnectionStr")))
            {
                SqlCommand command = new SqlCommand("PR_Patient_SelectAll", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            return View(dt); // View should accept DataTable
        }

        // ✅ GET: Add or Edit Page
        [HttpGet]
        public IActionResult PatientsAddEdit(int? PatientID)
        {
            PatientModel patientModel = new PatientModel();

            if (PatientID > 0)
            {
                using (SqlConnection connection = new SqlConnection(myconfiguration.GetConnectionString("HMSConnectionStr")))
                {
                    SqlCommand command = new SqlCommand("PR_Patient_SelectByPK", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PatientID", PatientID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    foreach (DataRow dr in dt.Rows)
                    {
                        patientModel.PatientID = Convert.ToInt32(dr["PatientID"]);
                        patientModel.Name = dr["Name"].ToString();
                        patientModel.DateOfBirth = dr["DateOfBirth"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["DateOfBirth"]);
                        patientModel.Gender = dr["Gender"].ToString();
                        patientModel.Email = dr["Email"].ToString();
                        patientModel.Phone = dr["Phone"].ToString();
                        patientModel.Address = dr["Address"].ToString();
                        patientModel.City = dr["City"].ToString();
                        patientModel.State = dr["State"].ToString();
                        patientModel.IsActive = Convert.ToBoolean(dr["IsActive"]);
                        patientModel.Created = dr["Created"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["Created"]);
                        patientModel.Modified = dr["Modified"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["Modified"]);
                        patientModel.UserID = Convert.ToInt32(dr["UserID"]);
                    }
                }
            }
            UserDropDown();
            return View("PatientsAddEdit", patientModel);
        }

        // ✅ POST: Save (Insert or Update)
        [HttpPost]
        public IActionResult PatientsSave(PatientModel patientModel)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection connection = new SqlConnection(myconfiguration.GetConnectionString("HMSConnectionStr")))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;

                    if (patientModel.PatientID == 0)
                    {
                        command.CommandText = "PR_Patient_Insert";
                    }
                    else
                    {
                        command.CommandText = "PR_Patient_UpdateByPK";
                        command.Parameters.AddWithValue("@PatientID", patientModel.PatientID);
                        command.Parameters.AddWithValue("@IsActive", patientModel.IsActive);
                    }

                    command.Parameters.AddWithValue("@Name", patientModel.Name ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DateOfBirth", patientModel.DateOfBirth == DateTime.MinValue ? (object)DBNull.Value : patientModel.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", patientModel.Gender ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Email", patientModel.Email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Phone", patientModel.Phone ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Address", patientModel.Address ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@City", patientModel.City ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@State", patientModel.State ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@UserID", patientModel.UserID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                TempData["SuccessMessage"] = "Patient saved successfully.";
                UserDropDown();
                return RedirectToAction("PatientsList");
            }

            return View("PatientsAddEdit", patientModel);
        }

        // ✅ GET: Delete Patient
        public IActionResult PatientsDelete(int PatientID)
        {
            using (SqlConnection connection = new SqlConnection(myconfiguration.GetConnectionString("HMSConnectionStr")))
            {
                SqlCommand command = new SqlCommand("PR_Patient_DeleteByPK", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PatientID", PatientID);

                connection.Open();
                command.ExecuteNonQuery();
            }

            TempData["SuccessMessage"] = "Patient deleted successfully.";
            return RedirectToAction("PatientsList");
        }

        // download
        [Route("ExportToExcelPatients")]
        public IActionResult ExportToExcelPatients()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(myconfiguration.GetConnectionString("HMSConnectionStr")))
            {
                SqlCommand command = new SqlCommand("PR_Patient_SelectAll", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }

            using (var workbook = new XLWorkbook())
            {
                // Add the DataTable to a worksheet
                workbook.Worksheets.Add(dt, "States");

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Patients.xlsx"
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

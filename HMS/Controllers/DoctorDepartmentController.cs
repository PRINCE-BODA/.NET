using ClosedXML.Excel;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HMS.Controllers
{
    public class DoctorDepartmentController : Controller
    {
        private readonly IConfiguration myconfiguration;

        public DoctorDepartmentController(IConfiguration configuration)
        {
            myconfiguration = configuration;
        }

        public IActionResult DoctorDepartmentList()
        {
            string connStr = myconfiguration.GetConnectionString("HMSConnectionStr");

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PR_DoctorDepartment_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                return View(dt);
            }
        }

        public IActionResult DoctorDepartmentAddEdit(int? DoctorDepartmentID)
        {
            string connStr = myconfiguration.GetConnectionString("HMSConnectionStr");
            DoctorDepartmentModel model = new DoctorDepartmentModel();

            if (DoctorDepartmentID > 0)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("PR_DoctorDepartment_SelectByPK", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@DoctorDepartmentID", DoctorDepartmentID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        model.DoctorDepartmentID = Convert.ToInt32(dr["DoctorDepartmentID"]);
                        model.DoctorID = Convert.ToInt32(dr["DoctorID"]);
                        model.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                        model.UserID = Convert.ToInt32(dr["UserID"]);
                    }
                }
            }
            UserDropDown();
            DoctorDropDown();
            DepartmentDropDown();
            return View("DoctorDepartmentAddEdit", model);
        }

        [HttpPost]
        public IActionResult DoctorDepartmentSave(DoctorDepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                string connStr = myconfiguration.GetConnectionString("HMSConnectionStr");

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = model.DoctorDepartmentID > 0
                            ? "PR_DoctorDepartment_UpdateByPK"
                            : "PR_DoctorDepartment_Insert"
                    };

                    if (model.DoctorDepartmentID > 0)
                    {
                        cmd.Parameters.AddWithValue("@DoctorDepartmentID", model.DoctorDepartmentID);
                    }

                    cmd.Parameters.AddWithValue("@DoctorID", model.DoctorID);
                    cmd.Parameters.AddWithValue("@DepartmentID", model.DepartmentID);
                    cmd.Parameters.AddWithValue("@UserID", model.UserID);

                    cmd.ExecuteNonQuery();
                }

                TempData["SuccessMessage"] = "Doctor-Department saved successfully.";
                UserDropDown();
                DoctorDropDown();
                DepartmentDropDown();
                return RedirectToAction("DoctorDepartmentList");
            }

            return View("DoctorDepartmentAddEdit", model);
        }

        public IActionResult DoctorDepartmentDelete(int DoctorDepartmentID)
        {
            string connStr = myconfiguration.GetConnectionString("HMSConnectionStr");

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PR_DoctorDepartment_DeleteByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@DoctorDepartmentID", DoctorDepartmentID);
                cmd.ExecuteNonQuery();
            }

            TempData["SuccessMessage"] = "Doctor-Department deleted successfully.";
            return RedirectToAction("DoctorDepartmentList");
        }
        [Route("ExportToExcelDoctorDepartment")]
        public IActionResult ExportToExcelDoctorDepartment()
        {
            string connectionStr = myconfiguration.GetConnectionString("HMSConnectionStr");
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();

            SqlCommand cmd = new SqlCommand("PR_DoctorDepartment_SelectAll", connection);
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
                        "DoctorDepartments.xlsx"
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

        public void DoctorDropDown()
        {
            string connectionString = myconfiguration.GetConnectionString("HMSConnectionStr");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PR_Doctor_SelectForDropDown";

                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                List<DoctorModel> doctorList = new List<DoctorModel>();
                foreach (DataRow data in dataTable.Rows)
                {
                    DoctorModel model = new DoctorModel();
                    model.DoctorID = Convert.ToInt32(data["DoctorID"]);
                    model.Name = data["Name"].ToString();
                    doctorList.Add(model);
                }
                ViewBag.DoctorList = doctorList;
            }
        }

        public void DepartmentDropDown()
        {
            string connectionString = myconfiguration.GetConnectionString("HMSConnectionStr");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PR_Department_SelectForDropDown";

                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                List<DepartmentModel> departmentList = new List<DepartmentModel>();
                foreach (DataRow data in dataTable.Rows)
                {
                    DepartmentModel model = new DepartmentModel();
                    model.DepartmentID = Convert.ToInt32(data["DepartmentID"]);
                    model.DepartmentName = data["DepartmentName"].ToString();
                    departmentList.Add(model);
                }
                ViewBag.DepartmentList = departmentList;
            }
        }
    }
}

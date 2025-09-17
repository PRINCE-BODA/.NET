using ClosedXML.Excel;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HMS.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IConfiguration myconfiguration;

        public DepartmentController(IConfiguration configuration)
        {
            myconfiguration = configuration;
        }

        #region Department List
        public IActionResult DepartmentList()
        {
            string connectionStr = myconfiguration.GetConnectionString("HMSConnectionStr");

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("PR_Department_SelectAll", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                return View("DepartmentList", dt);
            }
        }
        #endregion

        #region Add/Edit Department (GET)
        [HttpGet]
        public IActionResult DepartmentAddEdit(int? DepartmentID)
        {
            DepartmentModel model = new DepartmentModel();

            if (DepartmentID > 0)
            {
                string connStr = myconfiguration.GetConnectionString("HMSConnectionStr");
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("PR_Department_SelectByPK", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        model.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                        model.DepartmentName = reader["DepartmentName"].ToString();
                        model.Description = reader["Description"]?.ToString();
                        model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        model.UserID = Convert.ToInt32(reader["UserID"]);
                    }
                }
            }
            UserDropDown();
            return View("DepartmentAddEdit", model);
        }
        #endregion

        #region Save Department (POST)
        [HttpPost]
        public IActionResult DepartmentSave(DepartmentModel model)
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
                        CommandType = CommandType.StoredProcedure
                    };

                    if (model.DepartmentID == 0)
                        cmd.CommandText = "PR_Department_Insert";
                    else
                    {
                        cmd.CommandText = "PR_Department_UpdateByPK";
                        cmd.Parameters.AddWithValue("@DepartmentID", model.DepartmentID);
                    }

                    cmd.Parameters.AddWithValue("@DepartmentName", model.DepartmentName);
                    cmd.Parameters.AddWithValue("@Description", model.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", model.IsActive);
                    cmd.Parameters.AddWithValue("@UserID", model.UserID);

                    cmd.ExecuteNonQuery();
                }

                TempData["SuccessMessage"] = "Department saved successfully.";
                return RedirectToAction("DepartmentList");
            }
            UserDropDown();
            return View("DepartmentAddEdit", model);
        }
        #endregion

        #region Delete Department
        public IActionResult DepartmentDelete(int DepartmentID)
        {
            string connStr = myconfiguration.GetConnectionString("HMSConnectionStr");

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PR_Department_DeleteByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("DepartmentList");
        }
        #endregion
        [Route("ExportToExcelDepartment")]
        public IActionResult ExportToExcelDepartment()
        {
            string connectionStr = myconfiguration.GetConnectionString("HMSConnectionStr");
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();

            SqlCommand cmd = new SqlCommand("PR_Department_SelectAll", connection);
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
                        "Departments.xlsx"
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

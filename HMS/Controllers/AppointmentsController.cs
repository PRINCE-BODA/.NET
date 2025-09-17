using ClosedXML.Excel;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HMS.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IConfiguration myconfiguration;

        public AppointmentsController(IConfiguration configuration)
        {
            myconfiguration = configuration;
        }

        public IActionResult AppointmentsList()
        {
            string connStr = this.myconfiguration.GetConnectionString("HMSConnectionStr");
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PR_Appointment_SelectAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }

            return View(dt);
        }

        public IActionResult AppointmentDelete(int AppointmentID)
        {
            string connStr = this.myconfiguration.GetConnectionString("HMSConnectionStr");

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PR_Appointment_DeleteByPK", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("AppointmentsList");
        }

        [HttpGet]
        public IActionResult AppointmentAddEdit(int? AppointmentID)
        {
            string connStr = this.myconfiguration.GetConnectionString("HMSConnectionStr");
            AppointmentModel model = new AppointmentModel();

            if (AppointmentID > 0)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("PR_Appointment_SelectByPK", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        model.AppointmentID = Convert.ToInt32(reader["AppointmentID"]);
                        model.PatientID = Convert.ToInt32(reader["PatientID"]);
                        model.DoctorID = Convert.ToInt32(reader["DoctorID"]);
                        model.AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                        model.AppointmentStatus = reader["AppointmentStatus"].ToString();
                        model.Description = reader["Description"].ToString();
                        model.SpecialRemarks = reader["SpecialRemarks"].ToString();
                        model.TotalConsultedAmount = reader["TotalConsultedAmount"] != DBNull.Value ? Convert.ToDecimal(reader["TotalConsultedAmount"]) : null;
                        model.UserID = Convert.ToInt32(reader["UserID"]);
                    }
                }
            }
            UserDropDown();
            DoctorDropDown();
            PatientDropDown();
            return View("AppointmentAddEdit", model);
        }

        [HttpPost]
        public IActionResult AppointmentSave(AppointmentModel appointmentModel)
        {
            if (ModelState.IsValid)
            {
                string connStr = this.myconfiguration.GetConnectionString("HMSConnectionStr");

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (appointmentModel.AppointmentID == 0)
                    {
                        cmd.CommandText = "PR_Appointment_Insert";
                    }
                    else
                    {
                        cmd.CommandText = "PR_Appointment_UpdateByPK";
                        cmd.Parameters.AddWithValue("@AppointmentID", appointmentModel.AppointmentID);
                    }

                    cmd.Parameters.AddWithValue("@PatientID", appointmentModel.PatientID);
                    cmd.Parameters.AddWithValue("@DoctorID", appointmentModel.DoctorID);
                    cmd.Parameters.AddWithValue("@AppointmentDate", appointmentModel.AppointmentDate);
                    cmd.Parameters.AddWithValue("@AppointmentStatus", appointmentModel.AppointmentStatus ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", appointmentModel.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SpecialRemarks", appointmentModel.SpecialRemarks ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalConsultedAmount", appointmentModel.TotalConsultedAmount ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserID", appointmentModel.UserID);

                    cmd.ExecuteNonQuery();
                }

                TempData["SuccessMessage"] = "Appointment saved successfully.";
                UserDropDown();
                DoctorDropDown();
                PatientDropDown();
                return RedirectToAction("AppointmentsList");
            }

            return View("AppointmentAddEdit", appointmentModel);
        }
        [Route("ExportToExcelAppointment")]
        public IActionResult ExportToExcelAppointment()
        {
            string connectionStr = myconfiguration.GetConnectionString("HMSConnectionStr");
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();

            SqlCommand cmd = new SqlCommand("PR_Appointment_SelectAll", connection);
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
                        "Appointments.xlsx"
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

        public void PatientDropDown()
        {
            string connectionString = myconfiguration.GetConnectionString("HMSConnectionStr");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PR_Patient_SelectForDropDown";  // Need SP for Patient

                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                List<PatientModel> patientList = new List<PatientModel>();
                foreach (DataRow data in dataTable.Rows)
                {
                    PatientModel model = new PatientModel();
                    model.PatientID = Convert.ToInt32(data["PatientID"]);
                    model.Name = data["Name"].ToString();
                    patientList.Add(model);
                }
                ViewBag.PatientList = patientList;
            }
        }
    }
}

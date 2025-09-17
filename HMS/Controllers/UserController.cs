using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ClosedXML.Excel;

namespace HMS.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration myconfiguration;

        public UserController(IConfiguration configuration)
        {
            myconfiguration = configuration;
        }

        public IActionResult UsersList()
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionStr = myconfiguration.GetConnectionString("HMSConnectionStr");
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("PR_User_SelectAll", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            ViewBag.UserName = "";
            ViewBag.Email = "";
            return View(dt);
        }

        [HttpPost]
        public IActionResult UsersListSearch(string UserName = "", string Email = "")
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionStr = myconfiguration.GetConnectionString("HMSConnectionStr");
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("PR_User_SelectAll", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                if (!string.IsNullOrWhiteSpace(UserName) || !string.IsNullOrWhiteSpace(Email))
                {
                    var filters = new List<string>();
                    if (!string.IsNullOrWhiteSpace(UserName))
                    {
                        var escapedUser = UserName.Replace("'", "''");
                        filters.Add($"UserName LIKE '%{escapedUser}%'");
                    }
                    if (!string.IsNullOrWhiteSpace(Email))
                    {
                        var escapedEmail = Email.Replace("'", "''");
                        filters.Add($"Email LIKE '%{escapedEmail}%'");
                    }
                    string rowFilter = string.Join(" AND ", filters);
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = rowFilter;
                    dt = dv.ToTable();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            ViewBag.UserName = UserName;
            ViewBag.Email = Email;
            return View("UsersList", dt);
        }

        public IActionResult UserDelete(int UserID)
        {
            try
            {
                string connectionStr = myconfiguration.GetConnectionString("HMSConnectionStr");
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("PR_User_DeleteByPK", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.ExecuteNonQuery();
                }
                TempData["SuccessMessage"] = "User deleted successfully.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return RedirectToAction("UsersList");
        }

        public IActionResult UserAddEdit(int? UserID)
        {
            UserModel userModel = new UserModel();
            if (UserID > 0)
            {
                string connStr = myconfiguration.GetConnectionString("HMSConnectionStr");
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("PR_User_SelectByPK", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    foreach (DataRow row in dt.Rows)
                    {
                        userModel.UserID = Convert.ToInt32(row["UserID"]);
                        userModel.UserName = row["UserName"].ToString();
                        userModel.Password = row["Password"].ToString();
                        userModel.Email = row["Email"].ToString();
                        userModel.MobileNo = row["MobileNo"].ToString();
                        userModel.IsActive = Convert.ToBoolean(row["IsActive"]);
                    }
                }
            }
            return View("UserAddEdit", userModel);
        }

        [HttpPost]
        public IActionResult UserSave(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                string connStr = myconfiguration.GetConnectionString("HMSConnectionStr");
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (userModel.UserID == 0)
                    {
                        cmd.CommandText = "PR_User_Insert";
                    }
                    else
                    {
                        cmd.CommandText = "PR_User_UpdateByPK";
                        cmd.Parameters.AddWithValue("@UserID", userModel.UserID);
                    }
                    cmd.Parameters.AddWithValue("@UserName", userModel.UserName);
                    cmd.Parameters.AddWithValue("@Password", userModel.Password);
                    cmd.Parameters.AddWithValue("@Email", userModel.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MobileNo", userModel.MobileNo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", userModel.IsActive);
                    cmd.ExecuteNonQuery();
                }
                TempData["SuccessMessage"] = "User saved successfully.";
                return RedirectToAction("UsersList");
            }
            return View("UserAddEdit", userModel);
        }

        [Route("ExportToExcel")]
        public IActionResult ExportToExcel()
        {
            string connectionStr = myconfiguration.GetConnectionString("HMSConnectionStr");
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("PR_User_SelectAll", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            using (var workbook = new XLWorkbook())
            {
                workbook.Worksheets.Add(dt, "Users");
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Users.xlsx");
                }
            }
        }
    }
}

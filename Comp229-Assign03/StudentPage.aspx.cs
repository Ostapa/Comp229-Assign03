using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Comp229_Assign03
{
    public partial class StudentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Student";
            SqlDataReader reader;
            string studentSql = "SELECT FirstMidName, LastName, StudentID, EnrollmentDate FROM Students WHERE StudentId = @StudentID";
            string courseSql = "SELECT Title, Courses.CourseID FROM Courses LEFT OUTER JOIN Enrollments ON Courses.CourseID = Enrollments.CourseID WHERE StudentID = @StudentID";
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6LRG8C7\\SQLEXPRESS;Initial Catalog=Comp229Assign03;Integrated Security=True");
            SqlCommand command = new SqlCommand(studentSql, connection);
            command.Parameters.Add(new SqlParameter("@StudentID", System.Data.SqlDbType.NChar, 6));
            command.Parameters["@StudentID"].Value = Request.QueryString["StudentID"];

            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                studentInfo.DataSource = reader;
                studentInfo.DataBind();
                reader.Close();
                command = new SqlCommand(courseSql, connection);
                command.Parameters.Add(new SqlParameter("@StudentID", System.Data.SqlDbType.NChar, 6));
                command.Parameters["@StudentID"].Value = Request.QueryString["StudentID"];
                reader = command.ExecuteReader();
                courses.DataSource = reader;
                courses.DataBind();
                connection.Close();
            }
            catch (Exception err)
            {
                Response.Write("Sorry, something went wrong while searching students...");
                Response.Write(err.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdatePage.aspx?StudentID=@StudentID");
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {

            var studentId = Convert.ToInt32(Request.QueryString["StudentId"]);
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6LRG8C7\\SQLEXPRESS;Initial Catalog=Comp229Assign03;Integrated Security=True");
            SqlCommand enrollmentCommand = new SqlCommand("DELETE FROM Enrollments WHERE StudentID=@StudentID", connection);
            SqlCommand studentsCommand = new SqlCommand("DELETE FROM Students WHERE StudentID=@StudentID", connection);

            enrollmentCommand.Parameters.Add(new SqlParameter("@StudentID", System.Data.SqlDbType.Int, 6));
            studentsCommand.Parameters.Add(new SqlParameter("@StudentID", System.Data.SqlDbType.Int, 6));
            enrollmentCommand.Parameters["@StudentId"].Value = studentId;
            studentsCommand.Parameters["@StudentId"].Value = studentId;

            try
            {
                connection.Open();
                enrollmentCommand.ExecuteNonQuery();
                studentsCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
                Response.Redirect("HomePage.aspx");
            }
        }

    }
}
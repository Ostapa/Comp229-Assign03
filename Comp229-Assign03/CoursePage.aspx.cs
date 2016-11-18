using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Comp229_Assign03
{
    public partial class CoursePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Course";
            if (!Page.IsPostBack)
            {
                Page.Title = "Course";
                string command = "SELECT Courses.CourseID, Title, COUNT(StudentID) as Total " +
                                                    "FROM Enrollments " +
                                                    "FULL OUTER JOIN Courses " +
                                                    "ON Courses.CourseID = Enrollments.CourseID " +
                                                    "GROUP BY Courses.CourseID, Title";
                bindData(command, courses);
            }
        }

        protected void listStudentsBtn_Click(object sender, EventArgs e)
        {
            string command = "SELECT Students.StudentID, FirstMidName, LastName " +
                                                "FROM Students " +
                                                "LEFT OUTER JOIN Enrollments " +
                                                "ON Students.StudentID = Enrollments.StudentID " +
                                                "WHERE CourseID = @CourseID ";
            bindData(command, enrolledStudents);
        }

        // when the delete button clicked on a specific student he will be removed from current course
        protected void enrolledStudents_ItemCommand(object source, RepeaterCommandEventArgs e)
        { 
            Label studentId = e.Item.FindControl("studentId") as Label; // change to capital if doesn't work

            string command = "DELETE FROM Enrollments WHERE CourseID = @CourseID AND StudentID = @StudentID";
            updateOrDelete(command, studentId.Text, courseId.Text);
            Response.Redirect(Request.RawUrl);

        }

        protected void courses_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label courseId = e.Item.FindControl("courseIdAdd") as Label;
            TextBox studentId = e.Item.FindControl("studentIdAdd") as TextBox;

            string command = "INSERT INTO Enrollments (CourseID, StudentID, Grade) VALUES (@CourseID, @StudentID, 0)";
            updateOrDelete(command, studentId.Text, courseId.Text);
            Response.Redirect(Request.RawUrl);

        }

        protected void updateOrDelete(string comm, string studentId, string courseId)
        {
            
            int student = 0;
            int course = 0;
            Int32.TryParse(studentId, out student);
            Int32.TryParse(courseId, out course);
            // int course = Int32.Parse(courseId.Text); don't understand why this or Convert.ToInt32 didn't work
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand command = new SqlCommand(comm, connection);
            command.Parameters.Add(new SqlParameter("@CourseID", System.Data.SqlDbType.Int, 4));
            command.Parameters.Add(new SqlParameter("@StudentID", System.Data.SqlDbType.Int, 6));
            command.Parameters["@CourseID"].Value = course;
            command.Parameters["@StudentID"].Value = student;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Response.Write("ERROR: " + err.Message + "====" + error.Text);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void bindData(string comm, Repeater repeater)
        {
            SqlDataReader reader;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            int course = 0;
            Int32.TryParse(courseId.Text, out course);
            SqlCommand command = new SqlCommand(comm, connection);
            command.Parameters.Add(new SqlParameter("@CourseID", System.Data.SqlDbType.Int, 4));
            command.Parameters["@CourseID"].Value = course;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                repeater.DataSource = reader;
                repeater.DataBind();
                connection.Close();
            }
            catch (Exception err)
            {
                Response.Write("Sorry, something went wrong...<br>ERROR: " + err.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

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
                SqlDataReader reader;
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6LRG8C7\\SQLEXPRESS;Initial Catalog=Comp229Assign03;Integrated Security=True");
                SqlCommand command = new SqlCommand("SELECT Courses.CourseID, Title, COUNT(StudentID) as Total " +
                                                    "FROM Enrollments " +
                                                    "LEFT OUTER JOIN Courses " +
                                                    "ON Courses.CourseID = Enrollments.CourseID " +
                                                    "GROUP BY Courses.CourseID, Title", connection);

                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();
                    courses.DataSource = reader;
                    courses.DataBind();
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

        protected void listStudentsBtn_Click(object sender, EventArgs e)
        {
            SqlDataReader reader;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6LRG8C7\\SQLEXPRESS;Initial Catalog=Comp229Assign03;Integrated Security=True");
            SqlCommand command = new SqlCommand("SELECT Students.StudentID, FirstMidName, LastName " +
                                                "FROM Students " +
                                                "LEFT OUTER JOIN Enrollments " +
                                                "ON Students.StudentID = Enrollments.StudentID " +
                                                "WHERE CourseID = @CourseID ", connection);
            command.Parameters.Add(new SqlParameter("@CourseID", System.Data.SqlDbType.Int, 4));
            command.Parameters["@CourseID"].Value = courseId.Text;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                enrolledStudents.DataSource = reader;
                enrolledStudents.DataBind();
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

        // when the delete button clicked on a specific student he will be rempved from current course
        protected void enrolledStudents_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            Label studentId = e.Item.FindControl("StudentId") as Label;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6LRG8C7\\SQLEXPRESS;Initial Catalog=Comp229Assign03;Integrated Security=True");
            SqlCommand command = new SqlCommand("DELETE FROM Enrollments WHERE CourseID = @CourseID AND StudentID = @StudentID", connection);
            command.Parameters.Add(new SqlParameter("@CourseID", System.Data.SqlDbType.Int, 4));
            command.Parameters.Add(new SqlParameter("@StudentID", System.Data.SqlDbType.Int, 6));
            command.Parameters["@CourseID"].Value = courseId.Text;
            command.Parameters["@StudentID"].Value = studentId.Text;


            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Response.Write("ERROR: " + err.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void courses_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label courseId = e.Item.FindControl("courseIdAdd") as Label;
            TextBox studentId = e.Item.FindControl("studentIdAdd") as TextBox;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6LRG8C7\\SQLEXPRESS;Initial Catalog=Comp229Assign03;Integrated Security=True");
            SqlCommand command = new SqlCommand("INSERT INTO Enrollments (CourseID, StudentID, Grade) VALUES(@CourseID, @StudentID, 0)", connection);
            command.Parameters.Add(new SqlParameter("@CourseID", System.Data.SqlDbType.Int, 4));
            command.Parameters.Add(new SqlParameter("@StudentID", System.Data.SqlDbType.Int, 6));
            command.Parameters["@CourseID"].Value = courseId.Text;
            command.Parameters["@StudentID"].Value = Convert.ToInt32(studentId.Text);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception err)
            {
                Response.Write("ERROR: " + err.Message);
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
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
    public partial class StudentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Student";
            /* couldn't figure out how to print the student credentials once except for courseID, title and grade
               need to do it with two separate commands
            string comm = "SELECT Students.StudentID, FirstMidName, LastName, SUBSTRING(CAST(EnrollmentDate AS CHAR),1,10) AS EnDate, Enrollments.CourseID, Title, Grade" +
                                 " FROM Students " +
                                 " LEFT OUTER JOIN Enrollments " +
                                 " ON Enrollments.StudentID = Students.StudentID " +
                                 " LEFT OUTER JOIN Courses " +
                                 " ON Enrollments.CourseID = Courses.CourseID " +
                                 " WHERE Enrollments.StudentId = @StudentID "; */

            if (!Page.IsPostBack)
            {
                // if the user hit the Student tab or goes directly through url, this will provide a form to enter studentID
                if (string.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    studentPanel.Visible = false;
                    requestPanel.Visible = true;
                }
                else
                {
                    try { 
                        requestPanel.Visible = false;
                        studentPanel.Visible = true;
                        string command = "SELECT FirstMidName, LastName, StudentID, SUBSTRING(CAST(EnrollmentDate AS CHAR),1,10) AS EnDate FROM Students WHERE StudentID  = @StudentID ";
                        selectOrDelete(command, studentInfo);
                        command = "SELECT c.CourseID, Title, Grade " +
                                  " FROM Courses AS c " +
                                  " LEFT OUTER JOIN Enrollments AS e " +
                                  " ON e.CourseID = c.CourseID " +
                                  " WHERE e.StudentID = @StudentID";
                        selectOrDelete(command, courseInfo);
                        // throws error here
                        // fix it later
                        Label fName = studentInfo.Items[0].FindControl("fName") as Label;
                        Label lName = studentInfo.Items[0].FindControl("lName") as Label;
                        studentName.Text = fName.Text + " " + lName.Text;
                    }
                    catch (Exception)
                    {
                        error.Text = "Sorry, the student with specified ID doen not exist. Try again.";
                    }
                }
            }
            

        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            Label fName = studentInfo.Items[0].FindControl("fName") as Label;
            Label lName = studentInfo.Items[0].FindControl("lName") as Label;
            Label studentId = studentInfo.Items[0].FindControl("studentId") as Label;
            Label enDate = studentInfo.Items[0].FindControl("enDate") as Label;
            Application["fName"] = fName.Text;
            Application["lName"] = lName.Text;
            Application["studentId"] = studentId.Text;
            Application["enDate"] = enDate.Text;

            Response.Redirect("UpdatePage.aspx");
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        { 
            string enrollmentCommand = "DELETE FROM Enrollments WHERE StudentID=@StudentID";
            string studentsCommand = "DELETE FROM Students WHERE StudentID=@StudentID";

            selectOrDelete(enrollmentCommand, null); // I guess it wasn't the best thing to do with current method
            selectOrDelete(studentsCommand, null);
            Response.Redirect("HomePage.aspx");
        }

        protected void selectOrDelete(string comm, Repeater repeater)
        {
            var studentId = Convert.ToInt32(Request.QueryString["StudentID"]);
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand command = new SqlCommand(comm, connection);
            command.Parameters.Add(new SqlParameter("@StudentID", System.Data.SqlDbType.Int, 6));
            command.Parameters["@StudentID"].Value = studentId;

            try
            {
                connection.Open();
                if (comm.Substring(0, 6) == "SELECT")
                {
                    SqlDataReader reader;
                    reader = command.ExecuteReader();
                    repeater.DataSource = reader;
                    repeater.DataBind();
                    reader.Close();
                }
                else
                {
                    command.ExecuteNonQuery();
                }
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

        protected void provideStudentInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPage.aspx?StudentID=" + requestedId.Text);
        }
    }
}
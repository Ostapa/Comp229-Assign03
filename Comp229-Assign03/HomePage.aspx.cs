using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Comp229_Assign03.Scripts
{
    public partial class HomePage : System.Web.UI.Page
    {   

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Page.Title = "Home Page";
                string comm = "SELECT FirstMidName, LastName, StudentID FROM Students";
                bindOrInsert(comm);
                
            }
        }
        
        // finish later if there is time
       
        protected void studentNames_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label studentId = e.Item.FindControl("studentId") as Label;

            Response.Redirect("StudentPage.aspx?StudentID=" + studentId.Text);
        }

        protected void addStudent_Click(object sender, EventArgs e)
        {
            string command = "INSERT INTO Students (FirstMidName, LastName, EnrollmentDate) VALUES (@FirstName, @LastName, @EnrollmentDate)";
            bindOrInsert(command);
        }

        protected void bindOrInsert(string comm)
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand command = new SqlCommand(comm, connection);
            try
            {
                connection.Open();
                if (comm.Substring(0,6) == "SELECT")
                {
                    SqlDataReader reader;
                    reader = command.ExecuteReader();
                    studentNames.DataSource = reader;
                    studentNames.DataBind();
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@FirstName", System.Data.SqlDbType.VarChar, 50));
                    command.Parameters.Add(new SqlParameter("@LastName", System.Data.SqlDbType.VarChar, 50));
                    command.Parameters.Add(new SqlParameter("@EnrollmentDate", System.Data.SqlDbType.Date));
                    command.Parameters["@FirstName"].Value = txtFirstName.Text;
                    command.Parameters["@LastName"].Value = txtLastName.Text;
                    command.Parameters["@EnrollmentDate"].Value = enrollmentDate.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();

            }
            catch (Exception err)
            {
                // Create an error div under the table or sth like that
                Response.Write("Sorry, something went wrong...<br>ERROR: " + err.Message + "=====" + command.Parameters["@LastName"].Value);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
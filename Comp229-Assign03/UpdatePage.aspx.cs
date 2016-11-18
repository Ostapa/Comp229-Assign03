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
    public partial class UpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Update";
            

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {

            txtFirstName.Text = (string.IsNullOrEmpty(txtFirstName.Text)) ? Application["fName"].ToString() : txtFirstName.Text;
            txtLastName.Text = (string.IsNullOrEmpty(txtLastName.Text)) ? Application["lName"].ToString() : txtLastName.Text;
           // enrollmentDate.Text += (string.IsNullOrEmpty(enrollmentDate.Text)) ? Application["enDate"].ToString() : enrollmentDate.Text;

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand command = new SqlCommand("UPDATE Students SET FirstMidName=@FirstName, LastName=@LastName, EnrollmentDate=@EnrollmentDate WHERE StudentID=@StudentID", connection);
            command.Parameters.Add(new SqlParameter("@FirstName", System.Data.SqlDbType.VarChar));
            command.Parameters.Add(new SqlParameter("@LastName", System.Data.SqlDbType.VarChar));
            command.Parameters.Add(new SqlParameter("@EnrollmentDate", System.Data.SqlDbType.Date));
            command.Parameters.Add(new SqlParameter("@StudentID", System.Data.SqlDbType.Int));
            command.Parameters["@StudentID"].Value = Convert.ToInt32(Application["studentId"].ToString());
            command.Parameters["@FirstName"].Value = txtFirstName.Text;
            command.Parameters["@LastName"].Value = txtLastName.Text;
            command.Parameters["@EnrollmentDate"].Value = enrollmentDate.Text;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("StudentPage.aspx?StudentID=" + Application["studentId"].ToString());
            }
            catch (Exception err)
            {
                // Create an error div under the table or sth like that
                Response.Write("ERROR: " + err.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPage.aspx?StudentID=" + Application["studentId"].ToString());
        }
    }
}
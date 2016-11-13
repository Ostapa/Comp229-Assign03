using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

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
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6LRG8C7\\SQLEXPRESS;Initial Catalog=Comp229Assign03;Integrated Security=True");
            SqlCommand command = new SqlCommand("INSERT INTO Students (FirstMidName, LastName, EnrollmentDate) VALUES (@FirstName, @LastName, @EnrollmentDate)", connection);
            command.Parameters.Add(new SqlParameter("@FirstName", System.Data.SqlDbType.VarChar));
            command.Parameters.Add(new SqlParameter("@LastName", System.Data.SqlDbType.VarChar));
            command.Parameters.Add(new SqlParameter("@EnrollmentDate", System.Data.SqlDbType.Date));
            command.Parameters["@FirstName"].Value = txtFirstName.Text;
            command.Parameters["@LastName"].Value = txtLastName.Text;
            command.Parameters["@EnrollmentDate"].Value = enrollmentDate.Text;


            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception)
            {
                // Create an error div under the table or sth like that
                Response.Write("Sorry, something went wrong...");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
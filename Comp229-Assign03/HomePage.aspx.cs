using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Comp229_Assign03.Scripts
{
    public partial class HomePage : System.Web.UI.Page
    {   

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Page.Title = "Home Page";
                SqlDataReader reader;

                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6LRG8C7\\SQLEXPRESS;Initial Catalog=Comp229Assign03;Integrated Security=True");
                SqlCommand command = new SqlCommand("SELECT FirstMidName, LastName, StudentID FROM Students", connection);

                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();
                    studentNames.DataSource = reader;
                    studentNames.DataBind();
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
        
        // finish later if there is time
       
        protected void studentNames_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label studentId = e.Item.FindControl("studentId") as Label;

            Response.Redirect("StudentPage.aspx?StudentID=" + studentId.Text);
        }

    }
}
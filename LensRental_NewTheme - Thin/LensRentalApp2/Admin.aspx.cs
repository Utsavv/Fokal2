using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Visible = false;
    }
    protected void btnExecuteQuery_Click(object sender, EventArgs e)
    {
        try
        {
            using (var cnn = new SqlConnection("Data Source=" + txtIP.Text + ";Initial Catalog=" + txtDatabase.Text + ";User ID=" + txtUserName.Text + ";Password=" + txtPassword.Text))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = txtSqlQuery.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error in Executing SQL Query :- " + ex.Message;
            lblMessage.Visible = true;
        }
    }
}
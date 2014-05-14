using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int InquiryResult = InquiryManager.GetInstance.InsertInquiry(txtName.Text, txtEmail.Text, txtSubject.Text, txtMessage.Text);
        if (InquiryResult == 1)
        {
            Response.Redirect("Home.aspx");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "alert('Error in Saving Enquiry!!!')", true);
        }
    }
}
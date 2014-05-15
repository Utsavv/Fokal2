using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class PublishEvents_EventPageGenerator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        FolksploreDAL FD = new FolksploreDAL(SD.ConnectionString);
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow selectedRow = GridView1.Rows[index];
        Response.Write(selectedRow.Cells[0].Text + Server.MapPath("/"));

        string destinationPath = "", webPath = "", FolderName = "Pages";

        
        destinationPath = Server.MapPath("/") + "PSP\\" + FolderName + "\\";
        webPath = (HttpContext.Current.Request.Url.AbsoluteUri.Replace("PSPPageGenerator.aspx","") + FolderName + @"/");


        Response.Redirect( FD.GenerateVendorPage(
            Convert.ToInt32(selectedRow.Cells[0].Text),
            Server.MapPath("/") + "PSP/PSPTemplate.aspx",
            destinationPath,
            webPath));

    }
}
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
        
        string destinationPath = "";
        destinationPath = Server.MapPath("/") + "PublishEvents/"+(DateTime.Now.Year * 100 + DateTime.Now.Month).ToString()+"/";
        if (!System.IO.Directory.Exists(destinationPath)) System.IO.Directory.CreateDirectory(destinationPath);

        FD.GenerateEventPage(
            Convert.ToInt32(selectedRow.Cells[0].Text),
            Server.MapPath("/")+"PublishEvents/EventTemplate.aspx",
            destinationPath);

    }
}
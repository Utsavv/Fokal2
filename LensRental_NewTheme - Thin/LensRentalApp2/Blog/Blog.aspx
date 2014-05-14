<%@ Page Title="Blog  | Fokal.in" Language="C#" MasterPageFile="~/m_Other.master" AutoEventWireup="true" CodeFile="Blog.aspx.cs" Inherits="Blog" %>


<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
    <div id="blog_title">
        <h3>Lates Blog Posts</h3>
        
        
    </div>
    <br />
    <div id="blog-content">
          <div class="blogs">
              <p>
            <ul>
                <li>
                    <a href="Getting off auto mode - 5 Things beginners need to know.aspx">Getting off auto mode? - 5 Things beginners need to know</a>
                    <br />
                    
                </li>
                <li>
                    <a href="PhotoWalks.aspx">Photo Walks – What do you stand to gain from one?</a>
                </li>
            </ul>

              </p>
          </div>

      </div>


</asp:Content>
<asp:Content ID="shareContent" ContentPlaceHolderID="shareBar" runat="server">
   <%-- <div style="float:left; position:relative; width:25%;">
        <div class="fb-share-button" data-type="button_count"></div>
    </div>
    <div style="float:left; position:relative ; width:25%;">
        <div class="g-plusone" data-size="medium"></div>
    </div>--%>
</asp:Content>
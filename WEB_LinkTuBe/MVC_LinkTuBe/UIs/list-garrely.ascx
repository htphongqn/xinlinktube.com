<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="list-garrely.ascx.cs"
    Inherits="MVC_LinkTuBe.UIs.list_garrely" %>
<!--List Gallery-->
<h1 class="page_title">
    <asp:HyperLink ID="Hypertitle" runat="server"></asp:HyperLink>
</h1>
<div class="box box_Main">
    <div class="box_ct" id="list_albumn">
        <ul>
            <asp:Repeater ID="Rplistnews" runat="server">
                <ItemTemplate>
                    <li><a href="<%# GetLink(Eval("NEWS_URL"),Eval("NEWS_SEO_URL")) %>"
                        class="img_albumn">
                        <img src="<%# GetImageT(Eval("NEWS_ID"),Eval("NEWS_IMAGE3")) %>" /></a>
                        <h2 class="text_album">
                            <%# Eval("NEWS_TITLE") %></h2>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="pagination">
            <asp:Literal ID="ltrPage" runat="server"></asp:Literal>
        </div>
    </div>
</div>
<!--End List Gallery-->

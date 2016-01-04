<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="footer.ascx.cs" Inherits="MVC_Kutun.UIs.footer" %>
<footer class="footer" role="contentinfo">
    <div class="container">
        <asp:Repeater ID="Re_MenuF" runat="server">
            <ItemTemplate>
              <div class="col-ft">
                <h3 class="tt-ft"><%#Eval("CAT_NAME")%></h3>
                  <asp:Repeater ID="Repeater3" runat="server" DataSource='<%# Load_Menu2(Eval("CAT_ID"))%>'>
                      <ItemTemplate>
                          <h4><a href="<%#GetLink(Eval("cat_url"),Eval("cat_seo_url"),1)%>"><%#Eval("CAT_NAME")%></a></h4>
                      </ItemTemplate>
                  </asp:Repeater>
              </div>
            </ItemTemplate>
        </asp:Repeater>
      <div class="col-ft">
        <address>
       <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </address>
      </div>
    </div>
  </footer>

<!--ho tro-->
<div class="httt-fix"> <span class="icon-httt"></span>
  <div class="content-httt">
    <p class="tt">Liên hệ với United</p>
    <div class="wmn inner-ht">
      <p class="hotline-httt">Hotline 1: <b>0979 677 111</b></p>
      <p class="hotline-httt">Hotline 2: <b>0979 677 111</b></p>
      <p class="hotline-httt">Hotline 1: <b>0979 677 111</b></p>
      <p class="hotline-httt">Hotline 1: <b>0979 677 111</b></p>
    </div>
    <p><i><b>Thời gian làm việc:</b></i><br />
      &nbsp;&nbsp;&nbsp;<i>8h - 17h30 từ thứ 2 đến thứ 6</i><br />
      &nbsp;&nbsp;&nbsp;<i>8h - 12h ngày thứ 7</i><br />
    </p>
    <p class="email-httt"><i class="fa fa-envelope"></i> <i>email</i></p>
  </div>
</div>

<!--ho tro--> 

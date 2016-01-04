<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menu.ascx.cs" Inherits="MVC_LinkTuBe.UIs.menu" %>
<script type="text/javascript">
    function clickButton(e, buttonid) {
        var evt = e ? e : window.event;
        var bt = document.getElementById(buttonid);

        if (bt) {
            if (evt.keyCode == 13) {
                bt.click();
                return false;
            }
        }
    }
</script>
<div class="w3-container menu-top">
 <div class="w3-content"> <span class="w3-opennav" onclick="w3_open()"><i class="fa fa-align-justify fa-2x"></i></span>
  <nav class="navx"> <a href="javascript:void(0)" onclick="w3_close()" class="w3-closenav w3-right"><i class="fa fa-remove"></i></a>
   <ul>
    <li>
     <h3> <a href="/trang-chu.html"><i class="fa fa-home"></i></a></h3>
    </li>
    <asp:Repeater ID="Rpmenu" runat="server">
        <ItemTemplate>
          <li class="<%#GetStyleActive(Eval("Cat_Seo_Url"),Eval("Cat_Url")) %>">
            <h3><a href="<%#GetLink(Eval("cat_url"),Eval("cat_seo_url"))%>"><span><%#Eval("cat_name")%></span></a></h3>
          <asp:Repeater ID="Re_menu1" runat="server" DataSource='<%# Menu_phu(Eval("Cat_ID")) %>'>
            <HeaderTemplate>
              <ul>
            </HeaderTemplate>
            <ItemTemplate>
              <li>
                <h4><a href="<%#GetLink(Eval("cat_url"),Eval("cat_seo_url"))%>"> <%#Eval("cat_name")%></a></h4>
              <asp:Repeater ID="Re_menu2" runat="server" DataSource='<%# Menu_phu(Eval("Cat_ID")) %>'>
                <HeaderTemplate>
                  <ul>
                </HeaderTemplate>
                <ItemTemplate>
                  <li>
                    <h5><a href="<%#GetLink(Eval("cat_url"),Eval("cat_seo_url"))%>"> <%#Eval("cat_name")%> </a></h5>
                  </li>
                </ItemTemplate>
                <FooterTemplate>
                  </ul>
                </FooterTemplate>
              </asp:Repeater>
              </li>
            </ItemTemplate>
            <FooterTemplate>
              </ul>
            </FooterTemplate>
          </asp:Repeater>
          </li>
        </ItemTemplate>
      </asp:Repeater>
      <li class="<%=GetStyleActive("lien-he","lien-he") %>">
            <h3><a rel="nofollow" href="/lien-he.html"><span>Liên hệ</span></a></h3>
    </li>
   </ul>
  </nav>
 </div>
</div>

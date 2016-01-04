<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="MVC_Kutun.UIs.header" %>
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
 <header class="header" role="banner">
    <div class="clearfix banner-hd">
      <div class="container">
        <figure class="brand">
             <asp:Repeater ID="Re_logo" runat="server">
              <ItemTemplate>
                    <%# Getbanner(Eval("BANNER_TYPE"),Eval("BANNER_FIELD1"), Eval("BANNER_ID"), Eval("BANNER_FILE"),Eval("BANNER_DESC"))%>
              </ItemTemplate>
          </asp:Repeater>
        </figure>
        <figure class="brand-name">
           <asp:Repeater ID="Re_banner" runat="server">
              <ItemTemplate>
                    <%# Getbanner(Eval("BANNER_TYPE"),Eval("BANNER_FIELD1"), Eval("BANNER_ID"), Eval("BANNER_FILE"),Eval("BANNER_DESC"))%>
              </ItemTemplate>
          </asp:Repeater>
        </figure>
        <div class="right-hd-2">
          <div class="cskh">
              <asp:Literal ID="ltl_hotline" runat="server"></asp:Literal>
          </div>
          <p class="search">
            <input class="txt-search" name="txtsearch" id="txtsearch" runat="server" type="text" placeholder="Từ khóa tìm kiếm…"/>
              <asp:LinkButton ID="btnSearch" runat="server" class="btn-search" OnClick="btnSearch_Click"><i class="fa fa-search"></i></asp:LinkButton>
          </p>
        </div>
      </div>
    </div>
    <nav class="menu" role="navigation">
      <div class="navx">
        <ul>
          <asp:Repeater ID="Rpmenu" runat="server">
            <ItemTemplate>
                <li class="<%#GetStyleActive(Eval("Cat_Seo_Url"),Eval("Cat_Url")) %>">
                    <h3><a href="<%#GetLink(Eval("cat_url"),Eval("cat_seo_url"),1)%>"><span><%#Eval("cat_name")%></span></a></h3>
                        <asp:Repeater ID="Re_menu1" runat="server" DataSource='<%# Load_Menu2(Eval("Cat_ID")) %>'>
                            <HeaderTemplate>
                            <ul>
                            </HeaderTemplate>
                        <ItemTemplate>
                            <li><h4><a href="<%#GetLink(Eval("cat_url"),Eval("cat_seo_url"),1)%>">
                                <%#Eval("cat_name")%></a></h4>
                                <asp:Repeater ID="Re_menu2" runat="server" DataSource='<%# Load_Menu2(Eval("Cat_ID")) %>'>
                                    <HeaderTemplate>
                                        <ul>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                            <li><h5><a href="<%#GetLink(Eval("cat_url"),Eval("cat_seo_url"),1)%>">
                                                <%#Eval("cat_name")%>
                                            </a></h5></li>
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
        </ul>
      </div>
    </nav>
  </header>
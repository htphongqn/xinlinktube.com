<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexRight.ascx.cs" Inherits="MVC_Kutun.UIs.IndexRight" %>
<%@ Register Src="~/UIs/support.ascx" TagPrefix="uc1" TagName="support" %>

<aside class="aside side-right"> <!-- InstanceBeginEditable name="leftmenu" --> <!-- InstanceEndEditable -->
        <div class="bl">
          <h3 class="tt-side"> <span>Danh mục sản phẩm</span> </h3>
          <div class="inner-side">
            <nav class="navy">
              <ul>
               <asp:Repeater ID="Re_menu" runat="server">
                <ItemTemplate>
                        <li class="cat-header <%#GetStyleActive(Eval("Cat_Seo_Url"),Eval("Cat_Url")) %>">
                        <h4><a href="<%#GetLink(Eval("cat_url"),Eval("cat_seo_url"),1)%>"><%#Eval("cat_name")%></a></h4>
                            <asp:Repeater ID="Re_menu1" runat="server" DataSource='<%# Load_Menu2(Eval("Cat_ID")) %>'>
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li class="<%#GetStyleActive(Eval("Cat_Seo_Url"),Eval("Cat_Url")) %>">
                                    <h5><a href="<%#GetLink(Eval("cat_url"),Eval("cat_seo_url"),1)%>"><%#Eval("cat_name")%></a></h5>
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
            </nav>
          </div>
        </div>
        <!--end block-->
    <uc1:support runat="server" ID="support1" />
        <div class="bl">
          <h3 class="tt-side"> <span>Quảng cáo</span> </h3>
          <div class="inner-side">
            <div class="ads" >
                <asp:Repeater ID="Rpslider" runat="server">
                    <ItemTemplate>
                        <%# GetImageAd_ads(Eval("AD_ITEM_ID"), Eval("AD_ITEM_FILENAME"), Eval("AD_ITEM_TARGET"), Eval("AD_ITEM_URL"),Eval("AD_ITEM_DESC"))%>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
          </div>
        </div>
        <!--end block-->
        <div class="bl get-email">
          <h3 class="tt-side"> <span>Đăng ký nhận tin</span> </h3>
          <div class="inner-side">
            <input type="text" class="txt-search-left" id="txt_nhantin" runat="server"/>
            <asp:Button ID="btn_nhantin" runat="server" Text="Gửi"  class="btn-b btn-b-sm" OnClick="btn_nhantin_Click"/>
            <p><i>Xin vui lòng nhập địa chỉ mail để 
              nhận thông tin khuyến mãi</i> </p>
          </div>
        </div>
        <!--end block-->
        <div class="bl social-left">
          <h3 class="tt-side"> <span>Chia sẻ với chúng tôi</span> </h3>
          <div class="inner-side">
            <div class="social_network">
                <asp:Literal ID="ltl_social_network" runat="server"></asp:Literal>  
            </div>
          </div>
        </div>
        <!--end block-->
        <div class="bl vss">
          <h3 class="tt-side"> <span>Thống kê truy cập</span> </h3>
          <div class="inner-side">
            <table class="tbl">
              <tr>
                <td width="13%"><i class="icon_visit icon_v_1"></i></td>
                <td>Đang truy cập:<b><asp:Literal ID="lbl_online" runat="server"></asp:Literal></b></td>
              </tr>
              <tr>
                <td width="13%"><i class="icon_visit icon_v_2"></i></td>
                <td>Tổng truy cập:<b><asp:Literal ID="lbl_tngotruycap" runat="server"></asp:Literal></b></td>
              </tr>
              <tr>
                <td></td>
                <td></td>
              </tr>
            </table>
          </div>
        </div>
        <!--end block--> 
        
      </aside>
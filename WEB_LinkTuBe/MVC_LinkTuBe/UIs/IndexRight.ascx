<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexRight.ascx.cs" Inherits="MVC_LinkTuBe.UIs.IndexRight" %>
  <div class="w3-col m2 side">
       <div class="iblock vs-box">
        <div class="tt-side"><span> Thống kê truy cập</span> </div>
            <div class="inner-box">
                <p><i class="fa fa-group"></i>Online:
                <b>
                 <asp:Literal ID="lbl_online" runat="server"></asp:Literal>
                </b>
                </p>
                <p><i class="fa fa-star-o"></i> Ngày: <b>
                    <asp:Literal ID="ltl_day" runat="server"></asp:Literal>
                </b></p>
                <p><i class="fa fa-moon-o"></i> Tuần: <b>
                  <asp:Literal ID="ltl_week" runat="server"></asp:Literal>
                 </b></p>
                <p><i class="fa fa-sun-o"></i> Tháng: <b>
                  <asp:Literal ID="ltl_month" runat="server"></asp:Literal>
                </b></p>
                <p><i class="fa fa-globe"></i> Tổng : <b>
              <asp:Literal ID="lbl_tngotruycap" runat="server"></asp:Literal>
             </b></p>
        </div>
</div>
   <div class="iblock">
    <div class="tt-side"><span> Quảng cáo</span> </div>
    <div class="ads"><asp:Repeater ID="Re_ads" runat="server">
            <ItemTemplate>
               <a target="_blank" rel="nofollow" href="/chuyen-huong-quang-cao.html?aditem_id=<%#Eval("AD_ITEM_ID")%>"><img src="<%#GetImageT_Ad(Eval("AD_ITEM_ID"),Eval("AD_ITEM_FILENAME"))%>" alt="<%# Eval("AD_ITEM_DESC")%>" title="<%# Eval("AD_ITEM_DESC")%>"/></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
   </div>
  </div>
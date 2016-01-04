<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoDem_TruyCap.ascx.cs" Inherits="MVC_LinkTuBe.UIs.BoDem_TruyCap" %>
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
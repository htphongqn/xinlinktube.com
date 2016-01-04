<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="support.ascx.cs" Inherits="MVC_LinkTuBe.UIs.support" %>

<div class="httt-fix"> <span class="icon-httt"></span>
  <div class="content-httt">
    <p class="tt">Hỗ trợ trực tuyến</p>
    <div class="wmn inner-ht">
        <asp:Literal ID="ltl_hotline" runat="server"></asp:Literal>
    </div>
<%--    <p><i><b>Thời gian làm việc:</b></i><br />
      &nbsp;&nbsp;&nbsp;<i>8h - 17h30 từ thứ 2 đến thứ 6</i><br />
      &nbsp;&nbsp;&nbsp;<i>8h - 12h ngày thứ 7</i><br />
    </p>--%>
    <p class="email-httt"><i class="fa fa-envelope"></i>
        <asp:Literal ID="ltl_email" runat="server"></asp:Literal>
    </p>
  </div>
</div>

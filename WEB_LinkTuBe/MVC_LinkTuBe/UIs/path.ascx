<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="path.ascx.cs" Inherits="MVC_LinkTuBe.UIs.path" %>
<section class="w3-container">
<div class="w3-content">
<div class="w3-col m6">
 <ul class="breadcrumb">
    <li><a href="/trang-chu.html">Trang chủ</a></li>
    <asp:Literal ID="liPath" runat="server"></asp:Literal>
  </ul>
  </div>
  <div class="w3-col m6">
  <marquee class="mq slg-ft"><asp:Literal ID="ltl_sologan" runat="server"></asp:Literal></marquee>
  </div>
</div>
</section>
<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="thongbaoloi.aspx.cs" Inherits="MVC_LinkTuBe.vi_vn.thongbaoloi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <asp:Literal ID="ltrFavicon" runat="server" EnableViewState="false"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="w3-col m12" style="align-content:center;">
    <img src="/vi-vn/images/eror404.jpg" alt="http://xinlinktube.com/" title="Thông báo lỗi" />
    <h2 class="tt-main">Rất tiếc trang web bạn cần tìm không tồn tại hoặc có thể đã được chuyển sang địa chỉ khác. <br />
    <asp:Label ID="lbl_thongbao" runat="server" Text=""></asp:Label></h2>
 </div>
</asp:Content>



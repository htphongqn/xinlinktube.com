<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="contact.aspx.cs" Inherits="MVC_LinkTuBe.vi_vn.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Literal ID="ltrFavicon" runat="server" EnableViewState="false"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-col m12">
  <h2 class="tt-main"><span><i class="fa fa-map-marker"></i> Bản đồ</span></h2>
  
  <map class="map">
  <asp:Literal ID="Literal2" runat="server"></asp:Literal>
  </map>
 </div>
  <div class="w3-col m6">
   <div class="iblock ctbl" >
    <h2 class="tt-main"><span><i class="fa fa-envelope"></i> Liên hệ</span></h2>
    <div class="w3-form " style=" color:#ddd  ; font-size:1.2em">
     <div class=" w3-col m12">
      <div class="w3-col m2">
       <label class=" label">Tên </label>
      </div>
      <div class="w3-col m9">
        <input type="text" id="Txtname" name="Txtname" runat="server" class="w3-input"/><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn vui lòng nhập họ tên" Display="None" ControlToValidate="Txtname" ValidationGroup="G10"></asp:RequiredFieldValidator>
      </div>
     </div>
     <div class=" w3-col m12">
      <div class="w3-col m2">
       <label class=" label">Email </label>
      </div>
      <div class="w3-col m9">
        <input type="text" id="txtEmail" name="txtEmail" runat="server" class="w3-input"/><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Bạn vui lòng nhập Email" Display="None" ControlToValidate="txtEmail" ValidationGroup="G10"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Email không đúng định dạng" Display="None" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="G10"></asp:RegularExpressionValidator>
      </div>
     </div>
     <div class=" w3-col m12">
      <div class="w3-col m2">
       <label class=" label">Tel </label>
      </div>
      <div class="w3-col m9">
        <input type="text" id="Txtphone" name="Txtphone" runat="server" class="w3-input"/><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bạn vui lòng nhập số điện thoại" Display="None" ControlToValidate="Txtphone" ValidationGroup="G10"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Số điện thoại không đúng định dạng" Display="None" ControlToValidate="Txtphone" ValidationExpression="^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$" ValidationGroup="G10"></asp:RegularExpressionValidator>
      </div>
     </div>
    <div class=" w3-col m12">
      <div class="w3-col m2">
       <label class=" label">Tiêu đề </label>
      </div>
      <div class="w3-col m9">
        <input type="text" id="Txttitle" name="Txttitle" runat="server" class="w3-input"/><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Bạn vui lòng nhập tiêu đề liên hệ" Display="None" ControlToValidate="Txttitle" ValidationGroup="G10"></asp:RequiredFieldValidator>
      </div>
     </div>
     <div class=" w3-col m12">
      <div class="w3-col m2">
       <label class=" label">Nội dung </label>
      </div>
      <div class="w3-col m9">
         <textarea id="txtContent" name="txtContent" runat="server" class="w3-input"></textarea><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Bạn vui lòng nhập nội dung liên hệ" Display="None" ControlToValidate="txtContent" ValidationGroup="G10"></asp:RequiredFieldValidator>
      </div>
     </div>
     <div class=" w3-col m12">
      <div class="w3-col m2"> Mã xác thực</div>
      <div class="w3-col m3">
        <input type="text" class="w3-input" id="txtCapcha" name="txtCapcha" runat="server"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="None"  ErrorMessage="Bạn vui lòng nhập mã xác thực" ControlToValidate="txtCapcha" ValidationGroup="G10"></asp:RequiredFieldValidator>
      </div>
      <div class="w3-col m5 captcha"><asp:Image ID="Image1" runat="server" ImageUrl="../vi-vn/CImage.aspx" /></div>
     </div>
     <div class=" w3-col m12">
      <div class="w3-col m2"> &nbsp;</div>
      <div class="w3-col m9">
          <asp:Button ID="lbt_send" class="w3-btn w3-red" runat="server" Text="Gửi liên hệ" OnClick="Lbthanhtoan_Click" ValidationGroup="G10" />
          <asp:ValidationSummary ID="ValidationSummary1" runat="server" Display="None" ForeColor="Red" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="G10" />
      </div>
     </div>
     <br>
    </div>
   </div>
  </div>
  <div class="w3-col m6">
   <div class="iblock ctbl" >
    <h2 class="tt-main"><span><i class="fa fa-phone"></i>  Thông tin liên hệ</span></h2>
    <div class="inner" style="padding:15px; color:#ddd; font-size:1.2em">
     <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
   </div>
  </div>
</asp:Content>







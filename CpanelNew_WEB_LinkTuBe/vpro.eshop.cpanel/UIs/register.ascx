<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="register.ascx.cs" Inherits="MVC_Kutun.UIs.register" %>
<section class="main-content">
         <div class="iblock">
        <p class="tt-main"><span>Đăng ký</span></p>
        <div class="inner-iblock">
           <div class="ibl signup">
            <fieldset class="fld">
                <legend class="lgd"><b>Thông tin đăng ký </b></legend>
           <div class="form-ct frm-lg">
           <div class="rowmn">
            <div class="col3">Địa chỉ email
              <red>*</red>
            </div>
            <div class="col9">
              <input class="txt-md" type="text" id="SignUpEmail" name="SignUpEmail" runat="server" placeholder="Email"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn chưa nhập Email" ControlToValidate="SignUpEmail" Display="None" ValidationGroup="G10"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email không đúng định dạng" ControlToValidate="SignUpEmail" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="G10"></asp:RegularExpressionValidator>
            </div>
          </div>
          <div class="rowmn">
            <div class="col3">Mật khẩu
              <red>*</red>
            </div>
            <div class="col9">
              <input class="txt-md"  type="password" id="SignUpPassword" name="SignUpPassword" runat="server"  placeholder="Mật khẩu"/>
              <i style="font-size: 11px">(Mật khẩu phải chứa ít nhất 6 ký tự bao gồm cả chữ và số)</i>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Mật khẩu không đúng định dạng" ControlToValidate="SignUpPassword" Display="None" ValidationExpression="^(?=.*\d)(?=.*[a-zA-Z]).{6,}" ValidationGroup="G10"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="SignUpPassword" Display="None" ErrorMessage="Bạn chưa nhập mật khẩu" ValidationGroup="G10"></asp:RequiredFieldValidator>
              </div>
          </div>
          <div class="rowmn">
            <div class="col3">Gõ lại mật khẩu
              <red>*</red>
            </div>
            <div class="col9">
              <input class="txt-md"  type="password" id="SignUpRepassword" name="SignUpRepassword" runat="server"  placeholder="Nhập lại mật khẩu"/>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Mật khẩu xác nhận không chính xác" ControlToCompare="SignUpPassword" ControlToValidate="SignUpRepassword" Display="None" ValidationGroup="G10"></asp:CompareValidator>
            </div>
          </div>
          <div class="rowmn">
            <div class="col3">Họ và tên
              <red>*</red>
            </div>
            <div class="col9">
              <input  class="txt-md" type="text" id="fullname" name="fullname" runat="server" placeholder="Họ và tên"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bạn chưa nhập họ tên" ControlToValidate="fullname" Display="None" ValidationGroup="G10"></asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="rowmn">
            <div class="col3">Giới tính
              <red>*</red>
            </div>
            <div class="col9">
                <asp:RadioButtonList ID="rblsex" runat="server" RepeatColumns="5">
                    <asp:ListItem Text="Nam" Value="0" class="rdo" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Nữ" Value="1"  class="rdo" style="margin-left:5px;"></asp:ListItem>
              </asp:RadioButtonList>
            </div>
          </div>
          <div class="rowmn">
            <div class="col3">Ngày sinh
            <red>*</red>
            </div>
            <div class="col3 wmn3">
            <asp:DropDownList ID="Drday" runat="server" class="select">
            </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Vui lòng chọn ngày sinh" Display="None" ValidationGroup="G10" ControlToValidate="Drday" InitialValue="0"></asp:RequiredFieldValidator>
            </div>
            <div class="col3 wmn3">
            <asp:DropDownList ID="Drmonth" runat="server" class="select">
            </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Vui lòng chọn tháng sinh" Display="None" ValidationGroup="G10" ControlToValidate="Drmonth" InitialValue="0"></asp:RequiredFieldValidator>
            </div>
            <div class="col3 wmn3">
            <asp:DropDownList ID="Dryear" runat="server" class="select">
            </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Vui lòng chọn năm sinh" Display="None" ValidationGroup="G10" ControlToValidate="Dryear" InitialValue="0"></asp:RequiredFieldValidator>
            </div>
            </div>
          <div class="rowmn">
            <div class="col3">Điện thoại
              <red>*</red>
            </div>
            <div class="col9">
              <input  class="txt-md"  type="text" id="mobile" name="mobile" runat="server" placeholder="Điện thoại"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Bạn chưa nhập số điện thoại" ControlToValidate="mobile" Display="None" ValidationGroup="G10"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Số điện thoại không đúng định dạng" ControlToValidate="mobile" Display="None" ValidationExpression="^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$" ValidationGroup="G10"></asp:RegularExpressionValidator>
            </div>
          </div>
          <div class="rowmn">
            <div class="col3">Địa chỉ
              <red>*</red>
            </div>
            <div class="col9">
              <input  class="txt-md"  type="text" id="address" name="address" runat="server" placeholder="Địa chỉ"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Bạn chưa nhập địa chỉ" ControlToValidate="address" Display="None" ValidationGroup="G10"></asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="rowmn">
            <div class="col3">Tỉnh/thành phố
              <red>*</red>
            </div>
            <div class="col9">
                     <asp:DropDownList ID="Drcity" runat="server" class="select" AutoPostBack="True"
                            OnSelectedIndexChanged="Drcity_SelectedIndexChanged">
                     </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Bạn chưa chọn tỉnh/ thành phố" ControlToValidate="Drcity" Display="None" InitialValue="0" ValidationGroup="G10"></asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="rowmn">
            <div class="col3">Quận/huyện
              <red>*</red>
            </div>
            <div class="col9">
               <asp:DropDownList ID="Drdistric" runat="server" class="select">
               </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Bạn chưa chọn quận/ huyện" ControlToValidate="Drdistric" Display="None" InitialValue="0" ValidationGroup="G10"></asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="rowmn">
            <div class="col3">Mã bảo vệ
              <red>*</red>
            </div>
            <div class="col9">
              <p class="send">
                <input type="text" class="txt-md captcha " id="txtCapcha" name="txtCapcha" runat="server"  placeholder="Nhập mã an toàn"/>
                    <asp:Image ID="Image1" runat="server" ImageUrl="../vi-vn/CImage.aspx" />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Bạn chưa nhập mã bảo vệ" ControlToValidate="txtCapcha" Display="None" ValidationGroup="G10"></asp:RequiredFieldValidator>
                </p>
            </div>
          </div>
          <div class="rowmn">
            <div class="col3"> </div>
            <div class="col9">
              <p>
                <red>* Thông tin bắt buộc</red>
              </p>
              <p>
                  <asp:LinkButton ID="lbt_dangky" class="btn-b btn-l" runat="server" OnClick="IbtnFinish_Click" ValidationGroup="G10">Đăng ký</asp:LinkButton>
              </p>
              <p>
                  <asp:CheckBox ID="chk_nhantin" runat="server" class="chk"/>
                Đăng ký nhận tin khuyến mãi qua email</p>
                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" dislay="none" ShowMessageBox="True" ShowSummary="False" ValidationGroup="G10" />
                 <p><asp:Label ID="lbl_result" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></p>
            </div>
          </div>
        </div>
        </fieldset>
        </div>
        </div>
      </div>
</section>















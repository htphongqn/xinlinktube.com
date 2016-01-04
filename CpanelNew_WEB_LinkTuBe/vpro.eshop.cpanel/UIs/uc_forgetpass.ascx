<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_forgetpass.ascx.cs"
    Inherits="MVC_Kutun.UIs.uc_forgetpass" %>
 <section class="main-content"> <!-- InstanceBeginEditable name="maincontent" -->
         <div class="iblock">
        <p class="tt-main"><span>Quên mật khẩu</span></p>
        <div class="inner-iblock">
          <div class="contact">
            <fieldset class="fld">
              <legend class="lgd"><b>Thông tin</b></legend>
              <div class="form-ct frm-lg">
                <div class="rowmn">
                <div class="col4">Email:
                  <red>*</red>
                </div>
                <div class="col8">
                 <input class="txt-md" type="text" id="SignUpEmail" name="SignUpEmail" runat="server" placeholder="Email"/>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn chưa nhập Email" ControlToValidate="SignUpEmail" Display="None" ValidationGroup="G10"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email không đúng định dạng" ControlToValidate="SignUpEmail" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="G10"></asp:RegularExpressionValidator>
                </div>
              </div>
                <div class="rowmn">
                <div class="col4">Mã bảo vệ
                  <red>*</red>
                </div>
                <div class="col8">
                  <p class="send">
                    <input type="text" class="txt-md captcha " id="txtCapcha" name="txtCapcha" runat="server"  placeholder="Nhập mã an toàn"/>
                        <asp:Image ID="Image1" runat="server" ImageUrl="../vi-vn/CImage.aspx" />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Bạn chưa nhập mã bảo vệ" ControlToValidate="txtCapcha" Display="None" ValidationGroup="G10"></asp:RequiredFieldValidator>
                    </p>
                </div>
              </div>
              <div class="rowmn">
                <div class="col4"> </div>
                <div class="col8">
                  <p>
                    <red>* Thông tin bắt buộc</red>
                  </p>
                <p><asp:Label ID="lbl_result" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></p>
                      <asp:ValidationSummary ID="ValidationSummary2" runat="server" dislay="none" ShowMessageBox="True" ShowSummary="False" ValidationGroup="G10" />
                    <asp:Button ID="lbt_cappass" runat="server" Text="Cấp lại" class="btn-b" OnClick="lbt_cappass_Click" ValidationGroup="G10" />
                </div>
              </div>
              </div>
            </fieldset>
          </div>
        </div>
      </div>
     </section>
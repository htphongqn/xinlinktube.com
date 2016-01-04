<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_DoiMatKhau.ascx.cs" Inherits="MVC_Kutun.UIs.uc_DoiMatKhau" %>
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
<fieldset class="fld">
              <legend class="lgd"><b>Đổi mật khẩu</b></legend>
              <div class="form-ct frm-lg">
                   <div class="rowmn">
                <div class="col4">Mật khẩu cũ:
                  <red>*</red>
                </div>
                <div class="col8">
                  <input type="password" class="txt-md" id="Password" name="Password" runat="server" placeholder="Mật khẩu cũ" /><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="G14" ControlToValidate="Password" Display="None" ErrorMessage="Bạn chưa nhập mật khẩu cũ"></asp:RequiredFieldValidator>
                </div>
              </div>
              <div class="rowmn">
                <div class="col4">Mật khẩu mới:
                  <red>*</red>
                </div>
                <div class="col8">
                  <input type="password" class="txt-md" id="Password1" name="Password1" runat="server" placeholder="Mật khẩu mới" /><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Password1" ValidationGroup="G14" Display="None" ErrorMessage="Bạn chưa nhập mật khẩu mới"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="G14" ControlToValidate="Password1" ValidationExpression="^(?=.*\d)(?=.*[a-zA-Z]).{6,}" Display="None" ErrorMessage="Mật khẩu không đúng định dạng"></asp:RegularExpressionValidator>
                </div>
              </div>
              <div class="rowmn">
                <div class="col4">Nhập lại mật khẩu:
                  <red>*</red>
                </div>
                <div class="col8">
                  <input type="password" class="txt-md" id="Password2" name="Password2" runat="server" placeholder="Nhập lại mật khẩu mới" /><asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Mật khẩu xác nhận không chính xác" ValidationGroup="G14" Display="None" ControlToValidate="Password2" ControlToCompare="Password1"></asp:CompareValidator>
                </div>
              </div>
              <div class="rowmn">
                <div class="col4"> </div>
                <div class="col8">
                  <p>
                    <red>* Thông tin bắt buộc</red>
                  </p>
                  <asp:Button ID="btn_luu" runat="server" Text="Lưu" class="btn-b" OnClick="btn_luu_Click" ValidationGroup="G14" />
                  <p>
                      <asp:ValidationSummary ID="ValidationSummary1" runat="server" dislay="none" ShowMessageBox="True" ShowSummary="False" ValidationGroup="G14" />
                      <asp:Label ID="lbl_result" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                  </p>
                </div>
              </div>
              </div>
            </fieldset>


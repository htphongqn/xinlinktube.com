<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_diachigiaohang.ascx.cs" Inherits="MVC_Kutun.UIs.uc_diachigiaohang" %>
            <fieldset class="fld">
              <legend class="lgd"><b>Địa chỉ giao hàng</b></legend>
              <div class="form-ct frm-lg">
                       <div class="rowmn">
                <div class="col4">Địa chỉ:
                  <red>*</red>
                </div>
                <div class="col8">
                  <input type="text" class="txt-md" id="txtAddress" name="txtAddress" runat="server" placeholder="" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn chưa nhập địa chỉ" ValidationGroup="G24" ControlToValidate="txtAddress" Display="None"></asp:RequiredFieldValidator>
                </div>
              </div>
              <div class="rowmn">
                <div class="col4">Khu vực:
                  <red>*</red>
                </div>
                <div class="col4">
                 <asp:DropDownList ID="Drcity" runat="server" class="select" AutoPostBack="True"
                            OnSelectedIndexChanged="Drcity_SelectedIndexChanged">
                     </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Drcity" ErrorMessage="Bạn chưa chọn thành phố" ValidationGroup="G24" Display="None" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
                <div class="col4">
                 <asp:DropDownList ID="Drdistric" runat="server" class="select">
               </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Drdistric" ErrorMessage="Bạn chưa chọn quận/ huyện" ValidationGroup="G24" Display="None" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
              </div>
              <div class="rowmn">
                <div class="col4"> </div>
                <div class="col8">
                  <p>
                    <red>* Thông tin bắt buộc</red>
                  </p>
                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" dislay="none" ShowMessageBox="True" ShowSummary="False" ValidationGroup="G24" />
                         <asp:Label ID="lbl_result" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    <asp:Button ID="btn_diachigiaohang" runat="server" class="btn-b" Text="Lưu"  OnClick="btn_diachigiaohang_Click" ValidationGroup="G24" />
                </div>
              </div>
              </div>
            </fieldset>
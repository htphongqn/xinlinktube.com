<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_login.ascx.cs" Inherits="MVC_Kutun.UIs.uc_login" %>
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
<div id="id01" class="w3-modal">
  <div class="w3-modal-dialog">
    <div class="w3-modal-content">
      <div class="frm-signin"> <a class="w3-closebtn">&times;</a>
        <h2 class="tt-main"><span>Đăng nhập</span></h2>
        <div class="rowmn">
          <div class="col3">Địa chỉ email
            <red>*</red>
          </div>
          <div class="col9">
            <input class="txt-md" type="text" id="SignUpEmail" runat="server" placeholder="Email"/>
          </div>
        </div>
        <div class="rowmn">
          <div class="col3">Mật khẩu
            <red>*</red>
          </div>
          <div class="col9">
            <input class="txt-md" type="password" id="ignUpPassword" runat="server" placeholder="Mật khẩu"/>
          </div>
        </div>
        <div class="rowmn">
          <div class="col3"></div>
          <div class="col9">
            <p style="text-decoration:underline"><a href="/quyenmatkhau.html">Quên mật khẩu</a></p>
            <p>
                <asp:Button ID="btn_dangnhap" runat="server" Text="Đăng nhập" class="btn-b btn-l" OnClick="lbt_dangnhap_Click" />
            </p>
            <p>Bạn chưa là thành viên? <a href="/dangky.html">Đăng ký ngay</a></p>
          </div>
        </div>
  <%--      <div class="rowmn">
          <div class="col3"></div>
          <div class="col9">
            <p class="red">

            </p>
          </div>
        </div>--%>
      </div>
    </div>
  </div>
</div>
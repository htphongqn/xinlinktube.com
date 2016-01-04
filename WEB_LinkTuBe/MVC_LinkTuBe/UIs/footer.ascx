<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="footer.ascx.cs" Inherits="MVC_LinkTuBe.UIs.footer" %>
<footer class="w3-container footer">
 <div class="w3-content">
  <div class="w3-col m3">
   <div class="fbs" style="width:auto;">
       <asp:Literal ID="ltl_fanpage" runat="server"></asp:Literal>
   </div>
  </div>
  <div class="w3-col m9">
   <div class="ft-content">
       <asp:Repeater ID="Re_menuF" runat="server">
           <ItemTemplate>
               <div class="w3-quarter col-ft">
                 <h3 class="h3"><%#Eval("CAT_NAME")%></h3>
                    <asp:Repeater ID="Re_child" runat="server" DataSource='<%#Load_Menu2_Footer(Eval("CAT_ID"))%>'>
                        <ItemTemplate>
                            <p><a target="_blank" rel="nofollow" href="<%#GetLink(Eval("cat_url"),Eval("cat_seo_url"))%>" title="<%#Eval("CAT_NAME")%>"><%#Eval("CAT_NAME")%></a></p>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
           </ItemTemplate>
       </asp:Repeater>
    <!--end col ft-->
   </div>
   <div class="w3-col m12 follow">
    <div class="w3-half">
     <p>Đăng ký nhận thông tin </p>
     <input type="text" class="txt-getemail" id="txt_Email" runat="server">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"  ValidationGroup="GG" ControlToValidate="txt_Email" ErrorMessage="Vui lòng nhập video muốn đăng ký nhận tin!"></asp:RequiredFieldValidator>
        <asp:Button ID="btn_nhantin" class="btn btn-primary btn-sm" runat="server" Text="Gửi" ValidationGroup="GG" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Display="None" ForeColor="Red" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="GG" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Email không đúng định dạng !?" Display="None" ControlToValidate="txt_Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="GG"></asp:RegularExpressionValidator>
    </div>
    <div class="w3-half">
     <div class="social"> <span class="tt-ft">Follow Us </span>
     <asp:Literal ID="ltl_social_network" runat="server"></asp:Literal> 
     </div>
    </div>
   </div>
  </div>
 </div>
</footer>
<section class="w3-container copyright">
 <div class="w3-content">
  <p>Copyright ©  2015 by xinlinktube.com. All Rights Reserved.</p>
 </div>
</section>
<asp:Literal ID="ltl_cauhinhhaiben" runat="server"></asp:Literal>
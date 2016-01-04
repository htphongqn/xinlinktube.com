<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="slider.ascx.cs" Inherits="MVC_LinkTuBe.UIs.slider" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<section class="w3-container slider">
 <div class="w3-content">
  <div class="w3-col m10 col-slide">
   <div class="slide-main">
    <div class="camera_wrap camera_red_skin" id="camera_wrap_1">
    <asp:Repeater ID="Rpslider" runat="server">
    <ItemTemplate>
        <div data-thumb="<%#GetImageT_Ad(Eval("AD_ITEM_ID"),Eval("AD_ITEM_FILENAME"))%>" data-src="<%#GetImageT_Ad(Eval("AD_ITEM_ID"),Eval("AD_ITEM_FILENAME"))%>">
          <div class="camera_caption fadeFromRight">
           <p class="h3"><a rel="nofollow" target="_blank" href="/chuyen-huong-quang-cao.html?aditem_id=<%#Eval("AD_ITEM_ID")%>"><%#Eval("AD_ITEM_FIELD1")%></a></p>
           <p><a rel="nofollow" target="_blank" href="/chuyen-huong-quang-cao.html?aditem_id=<%#Eval("AD_ITEM_ID")%>"><%#Eval("AD_ITEM_DESC")%></a></p>
          </div>
        </div>
     </ItemTemplate>
    </asp:Repeater>
    </div>
   </div>
  </div>
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
  <div class="w3-col m2 side">
   <div class="wmn w3-form search-right">
    <div class="tt-side"><span> Tìm kiếm </span> </div>      
    <div class="w3-c333 inner">
     <p>
         <asp:DropDownList ID="ddl_cat1" class="w3-select txtvmn" runat="server" OnSelectedIndexChanged="ddl_cat1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
     </p>
     <p>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddl_cat1" />
           </Triggers>
           <ContentTemplate>
     	    <asp:DropDownList ID="ddl_cat2" class="w3-select txtvmn" runat="server"></asp:DropDownList>
           </ContentTemplate>
       </asp:UpdatePanel>
     </p>
     <p>
      <input class="w3-input txtvmn" id="txtsearch" name="txtsearch" runat="server" type="text" placeholder="Bạn cần tìm video gì...?">
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="G94" ControlToValidate="txtsearch" Display="None"  ErrorMessage="Vui lòng nhập từ khóa muốn tìm kiếm...!"></asp:RequiredFieldValidator>
      <asp:ValidationSummary ID="ValidationSummary55" runat="server" Display="None" ForeColor="Red" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="G94" />
     <p>
         <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btn_search_Click" ValidationGroup="G94" class="w3-btn w3-red wmn" />
     </p>
     <div class="w3-c333 text-center">
         <asp:Literal ID="ltl_yutube" runat="server"></asp:Literal></div>
    </div>
   </div>
  </div>
 </div>
</section>
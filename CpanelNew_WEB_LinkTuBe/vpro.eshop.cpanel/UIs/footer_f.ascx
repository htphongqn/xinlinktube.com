<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="footer_f.ascx.cs" Inherits="MVC_Kutun.UIs.footer_f" %>
  <div class="clearfix bottom-page">
    <div class=" ads ads-bt">
        <asp:Repeater ID="Rpslider" runat="server">
            <ItemTemplate>
                <%# GetImageAd_ads(Eval("AD_ITEM_ID"), Eval("AD_ITEM_FILENAME"), Eval("AD_ITEM_TARGET"), Eval("AD_ITEM_URL"),Eval("AD_ITEM_DESC"))%>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="keyword-bt"><asp:Literal ID="ltl_tukhoa" runat="server"></asp:Literal>
    </div>
  </div>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="slider_F.ascx.cs" Inherits="MVC_Kutun.UIs.slider_F" %>
<div class="left_pmt adsfix" id="divAdLeft">
    <asp:Repeater ID="re_trai" runat="server">
        <ItemTemplate>
            <%# GetImageAd_ads_1(Eval("AD_ITEM_ID"), Eval("AD_ITEM_FILENAME"), Eval("AD_ITEM_TARGET"), Eval("AD_ITEM_URL"), Eval("AD_ITEM_DESC"))%>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="right_pmt adsfix" id="divAdRight"> 
    <asp:Repeater ID="re_phai" runat="server">
        <ItemTemplate>
             <%# GetImageAd_ads_1(Eval("AD_ITEM_ID"), Eval("AD_ITEM_FILENAME"), Eval("AD_ITEM_TARGET"), Eval("AD_ITEM_URL"), Eval("AD_ITEM_DESC"))%>
        </ItemTemplate>
    </asp:Repeater>
</div>
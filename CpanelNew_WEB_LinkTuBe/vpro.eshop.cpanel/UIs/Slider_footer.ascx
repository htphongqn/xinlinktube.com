<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Slider_footer.ascx.cs" Inherits="MVC_Kutun.UIs.Slider_footer" %>
<div class="box">
<div class="box_ct padd20 ads_bottom">
    <div id="slide_ads" class="owl-carousel">
        <asp:Repeater ID="Re_Spham" runat="server">
            <ItemTemplate>
                <div class="item"><%# GetImageAd(Eval("AD_ITEM_ID"), Eval("AD_ITEM_FILENAME"), Eval("AD_ITEM_TARGET"), Eval("AD_ITEM_URL"))%></div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
</div>
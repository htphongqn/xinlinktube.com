<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="slider.ascx.cs" Inherits="MVC_Kutun.UIs.slider" %>
<figure class="wmn slider" role="slider">
<div class="camera_wrap camera_coffee_skin" id="camera_wrap_1"> 
    <asp:Repeater ID="Rpslider" runat="server">
        <ItemTemplate>
        <div data-thumb="<%#GetImageT_Ad(Eval("AD_ITEM_ID"),Eval("AD_ITEM_FILENAME"))%>" data-src="<%#GetImageT_Ad(Eval("AD_ITEM_ID"),Eval("AD_ITEM_FILENAME"))%>">
        <div class="camera_caption">
            <p class="tt-slide"><%#Eval("AD_ITEM_FIELD1")%></p>
            <p class="des-slide"><%#Eval("AD_ITEM_DESC")%></p>
        </div>
        </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
</figure>
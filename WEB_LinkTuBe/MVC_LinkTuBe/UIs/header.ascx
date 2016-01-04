<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="MVC_LinkTuBe.UIs.header" %>
<asp:Literal ID="ltl_script" runat="server"></asp:Literal>
<header class="w3-container w3-c333 header">
 <div class="w3-content">
  <div class="inner-hd">
   <figure class="brand">
       <asp:Repeater ID="Re_logo" runat="server">
           <ItemTemplate> <%# Getbanner(Eval("BANNER_TYPE"),Eval("BANNER_FIELD1"), Eval("BANNER_ID"), Eval("BANNER_FILE"),Eval("BANNER_DESC"))%> </ItemTemplate>
       </asp:Repeater>
   </figure>
  </div>
 </div>
</header>

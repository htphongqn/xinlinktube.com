<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="news-details.ascx.cs"
    Inherits="MVC_LinkTuBe.UIs.news_details" %>
<div class="w3-col m10 main-col-2">
   <article class="iblock detail-news">
        <h1 class="tt-detail-news"><asp:Label ID="lbNewsTitle" runat="server" Text=""></asp:Label></h1>
        <p class="postDatetime"><asp:Label ID="lbNewsUpdate" runat="server" Text=""></asp:Label></p>
        <!-- begin-->
         <asp:Literal ID="liHtml" runat="server"></asp:Literal>
        <div class="attachment">
        <div class="download_item">
        <asp:Repeater ID="Re_download" runat="server">
        <ItemTemplate>
                <%# BindAttItems(Eval("NEWS_ID"),Eval("EXT_ID"),Eval("NEWS_ATT_NAME"),Eval("NEWS_ATT_URL"),Eval("NEWS_ATT_FILE"),Eval("EXT_FILE_IMAGE"))%>
        </ItemTemplate>
        </asp:Repeater>
        </div>
        </div>
        <!-- end--> 
       <div id="fb-comments" class="fb-comments" data-numposts="5" data-colorscheme="light" data-height="545" data-width="467"></div>
        <div id="fb-root"></div>
        <script>(function (d, s, id) { var currentUrl = window.location.href; document.getElementById("fb-comments").setAttribute("data-href", currentUrl); var js, fjs = d.getElementsByTagName(s)[0]; if (d.getElementById(id)) return; js = d.createElement(s); js.id = id; js.src = "//connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v2.4"; fjs.parentNode.insertBefore(js, fjs); }(document, 'script', 'facebook-jssdk'));</script>
       </article>
  </div>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Link_Hot.ascx.cs" Inherits="MVC_LinkTuBe.UIs.Link_Hot" %>
<script type="text/javascript">
    $(document).ready(function () {
        $('.slider-ht3').bxSlider({
            slideHeight: 250,
            mode: 'vertical',
            minSlides: 5,
            moveSlides: 1,
            maxSlides: 5,
            slideMargin: 0,
            auto: false,
            speed: 1000,
            controls: true,
            pause: 4000,
        });
    });
</script>
<div class="w3-col m2 side">
   <div class="iblock link-hot">
    <div class="tt-side"><span> Link Hot</span> </div>
    <div class="slider-ht3">
     <asp:Repeater ID="re_link_hot" OnItemCommand="re_link_hot_ItemCommand" runat="server">
        <ItemTemplate>
              <div class="slide">
                <article class="video-it">
                <div class="inner-video">
                <div class="video-thumbnail"><%#GetLinkYoutube(Eval("NEWS_VIDEO_URL"),Eval("NEWS_TITLE"))%></div>
                <h2 class="video-title"> <a href="<%#GetLinkNews(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>" title="<%#Eval("NEWS_TITLE") %>"><%#Eval("NEWS_TITLE") %></a> </h2>
                <p class="video-by-line">by <span><a rel="nofollow" href="<%# Get_linkkenh(Eval("NEWS_FIELD4"))%>" target="_blank"><%# Get_tenKenh(Eval("NEWS_FIELD4"))%></a></span></p>
                <div class="video-meta">
                    <p><%# FormatView(Eval("NEWS_COUNT"))%> lượt xem</p>
                    <p><%# HAM_QUI_DOI(Eval("NEWS_PUBLISHDATE"))%></p>
                </div>
                <div class="wmn share-box">
                    <asp:LinkButton ID="Link_like" rel="nofollow" class="thumbs-up" runat="server" CommandName="like" CommandArgument='<%# Eval("NEWS_SEO_URL") %>'><i class="fa fa-thumbs-o-up"></i> Like </asp:LinkButton>
                    Share 
                    <a class="fb-share-button facebook" data-href="<%#Getlink_Share(Eval("NEWS_SEO_URL"))%>" data-layout="icon"><i class="fa fa-facebook"></i></a>
                    <a class="google-plus" rel="nofollow" href="https://plus.google.com/share?url=<%#Getlink_Share(Eval("NEWS_SEO_URL"))%>" onclick="javascript:window.open(this.href,'', 'menubar=no,toolbar=no,resizable=yes,scrollbars=yes,height=600,width=600');return false;"><i class="fa fa-google-plus"></i></a>
                    <a class="twitter twitter-share-button"  rel="nofollow" href="https://twitter.com/intent/tweet?text=<%# Get_ShareTweet(Eval("NEWS_SEO_URL"),Eval("NEWS_TITLE"))%>"><i class="fa fa-twitter"></i></a>
                </div>
                </div>
                </article>
                <!--end video item--> 
               </div>
            </ItemTemplate>
        </asp:Repeater>
       </div>
   </div>
   <div class="iblock">
    <div class="tt-side"><span> Quảng cáo</span> </div>
    <div class="ads">
        <asp:Repeater ID="Re_ads" runat="server">
            <ItemTemplate>
                <a target="_blank" rel="nofollow" href="/chuyen-huong-quang-cao.html?aditem_id=<%#Eval("AD_ITEM_ID")%>"><img src="<%#GetImageT_Ad(Eval("AD_ITEM_ID"),Eval("AD_ITEM_FILENAME"))%>" alt="<%# Eval("AD_ITEM_DESC")%>" title="<%# Eval("AD_ITEM_DESC")%>"/></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
   </div>
</div>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="product-details.ascx.cs" Inherits="MVC_LinkTuBe.UIs.product_details" %>
<div id="id01" class="w3-modal error-link">
    <div class="w3-modal-dialog">
    <div class="w3-modal-content">
    <header class="w3-container w3-red"> <a href="#" class="w3-closebtn">&times;</a>
    <h2>Báo link hỏng</h2>
    </header>
    <div class="w3-container">
    <div class="content-error-link"> <i class="fa fa-unlink i-error-link"></i>
        <input type="text" readonly="readonly" class="txt-df" placeholder="Xác nhận: Link này đã thật sự bị hỏng ?" value="Xác nhận: Link này đã thật sự bị hỏng ?">
                 <asp:LinkButton ID="link_die" class="w3-btn btn-send-error-link" OnClick="Lbadddie_Click" runat="server">Phải</asp:LinkButton>
        <p style="float:left; margin-top:15px; width:100%;">Cảm ơn bạn đã quan tâm ...</p>
    </div>
    </div>
    </div>
    </div>
</div>
     <div class=" w3-col m7 col-dt">
   <div class="block adss video-lg">
       <asp:Literal ID="ltl_video" runat="server"></asp:Literal>
   </div>
   <div class="iblock info-video" style="position:relative">
     <h1 class="tt-h1-video"><asp:Literal ID="ltl_newtitle" runat="server"></asp:Literal></h1>
    <div class="share-box share-box-dt">
    <a class="fb-like thumbs-up" data-href="<%=Getlink_Share()%>" data-layout="button_count" data-action="like" data-show-faces="true" data-share="false"></a>
    Share 
    <a id="fb-share" class="facebook" style='text-decoration:none;' type="icon_link" onClick="window.open('http://www.facebook.com/sharer.php?s=100&amp;p[title]=<%=_newtitle%>&amp;p[summary]=<%=_newsdesc%>&amp;p[url]=<%=Getlink_Share()%>&amp;p[images][0]=<%=GetImageT()%>','sharer','toolbar=0,status=0,width=580,height=325');" href="javascript: void(0)"><i class="fa fa-facebook"></i></a>
    <a class="google-plus" rel="nofollow" href="https://plus.google.com/share?url=<%=Getlink_Share()%>" onclick="javascript:window.open(this.href,'', 'menubar=no,toolbar=no,resizable=yes,scrollbars=yes,height=600,width=600');return false;"><i class="fa fa-google-plus"></i></a>
    <a class="twitter twitter-share-button"  onclick="window.open('https://twitter.com/intent/tweet?text=<%=Get_ShareTweet()%>','sharer','toolbar=0,status=0,width=580,height=325');"><i class="fa fa-twitter"></i></a>
    </div>
    <p class="time-video"><i class="fa fa-hourglass-end"></i> Ngày đăng: <b class="tdt">
    <asp:Literal ID="ltl_ngaydang" runat="server"></asp:Literal></b></p>
    <p class="link-video"><a title="Báo link hỏng"  href="#id01" class="fa fa-warning"></a> 
    Link: <i class="fa fa-link tg-source"></i>
        <a class="tdt">
        <asp:Literal ID="ltl_link" runat="server"></asp:Literal></a></p>
    <p class="source-video"><i class="fa fa-youtube-play"></i> Lượt xem: <b class="tdt">
        <asp:Literal ID="ltl_cout" runat="server"></asp:Literal></b></p>
    <p class="user-upload"><i class="fa fa-user-plus"></i> Người đăng: <asp:Literal ID="ltl_kenh" runat="server"></asp:Literal></p>
    <a class="trigger-des" id="a_hrefmota" runat="server" style=" position:absolute; bottom:-8px; width:100%; left:0; text-align:center"><i class="tg-des fa fa-angle-double-down" style="color:#fff; padding:1px 15px; border-radius: 0px 0px 8px 8px; background:#181818; display:inline-block; font-size:20px"></i></a> </div>
   <script type="text/javascript" src="/vi-vn/Scripts/jquery.slimscroll.js"></script> 
   <script type="text/javascript">
       $(function () {
           $('.testDiv').slimScroll({
               disableFadeOut: false,
               alwaysVisible: true,
           });

       });
        </script>
   <script type="text/javascript">
       $(document).ready(function () {
           $('.slider-cl').bxSlider({
               slideWidth: 230,
               minSlides: 1,
               moveSlides: 1,
               maxSlides: 5,
               slideMargin: 5,
               auto: false,
               speed: 500,
               controls: true,
               pause: 4000,
           });
       });
</script>
<%--<script type="text/javascript">
    $(document).ready(function () {
        $('.slider-h3').bxSlider({
            slideWidth: 230,
            minSlides: 1,
            moveSlides: 1,
            maxSlides: 5,
            slideMargin: 5,
            auto: false,
            speed: 500,
            controls: false,
            pause: 4000,
        });
    });
</script>--%>
  </div>
  <div class=" w3-col m5 col-dt">
   <div class="iblock adss commenbox">
    <div class="tt-main"><span><i class="fa fa-comment"></i>  Bình luận</span> </div>
    <div class="inner-cm-box">
        <div id="fb-comments" class="fb-comments" data-numposts="5" data-colorscheme="light" data-height="545" data-width="467"></div>
        <div id="fb-root"></div>
        <script>(function (d, s, id) { var currentUrl = window.location.href; document.getElementById("fb-comments").setAttribute("data-href", currentUrl); var js, fjs = d.getElementsByTagName(s)[0]; if (d.getElementById(id)) return; js = d.createElement(s); js.id = id; js.src = "//connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v2.4"; fjs.parentNode.insertBefore(js, fjs); }(document, 'script', 'facebook-jssdk'));</script>
    </div>
   </div>
  </div>
  <div class="w3-col m12">
  <div class="iblock des-video">
    <div class="inner-des-video">
     <div class="testDiv">
      <div class="txt-video"><asp:Literal ID="liHtml_info" runat="server"></asp:Literal>
      </div>
     </div>
    </div>
   </div>
   </div>
  <div class="w3-col m12" id="div_MoiHon" runat="server">
   <div class="iblock list-video w3-c333 other-video">
    <h2 class="tt-main"><span>Các video tiếp theo</span> </h2>
    <div class="inner-list">
     <div class="slider-h3">
         <asp:Repeater ID="Re_MoiHon" runat="server">
             <ItemTemplate>
                <div class="slide">
                <article class="video-it-detail">
                <div class="inner-video">
                    <div class="video-thumbnail"><%#GetLinkYoutube(Eval("NEWS_VIDEO_URL"),Eval("NEWS_TITLE"))%></div>
                    <h2 class="video-title"> <a href="<%#GetLinkNews(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>" title="<%#GetLinkNews(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>"><%#Eval("NEWS_TITLE")%></a> </h2>
                    <p class="video-by-line">by <span><a rel="nofollow" href="<%# Get_linkkenh(Eval("NEWS_FIELD4"))%>" target="_blank"><%# Get_tenKenh(Eval("NEWS_FIELD4"))%></a></span></p>
                    <div class="video-meta">
                    <p><%# FormatView(Eval("NEWS_COUNT"))%> lượt xem</p>
                    <p><%# HAM_QUI_DOI(Eval("NEWS_PUBLISHDATE"))%></p>
                    </div>
                <div class="wmn share-box">
                    <!--<i class="fa fa-thumbs-o-up"></i> Like -->
                    <a class="fb-like thumbs-up" data-href="<%#Getlink_Share(Eval("NEWS_SEO_URL"))%>" data-layout="button_count" data-action="like" data-show-faces="true" data-share="false"></a>
                    Share 
                    <a id="fb-share" class="facebook" style='text-decoration:none;' type="icon_link" onClick="window.open('http://www.facebook.com/sharer.php?s=100&amp;p[title]=<%#Eval("NEWS_TITLE")%>&amp;p[summary]=<%#Eval("NEWS_DESC")%>&amp;p[url]=<%#Getlink_Share(Eval("NEWS_SEO_URL"))%>&amp;p[images][0]=<%#GetImageT(Eval("NEWS_ID"),Eval("NEWS_IMAGE3"))%>','sharer','toolbar=0,status=0,width=580,height=325');" href="javascript: void(0)"><i class="fa fa-facebook"></i></a>
                    <a class="google-plus" rel="nofollow" href="https://plus.google.com/share?url=<%#Getlink_Share(Eval("NEWS_SEO_URL"))%>" onclick="javascript:window.open(this.href,'', 'menubar=no,toolbar=no,resizable=yes,scrollbars=yes,height=600,width=600');return false;"><i class="fa fa-google-plus"></i></a>
                    <a class="twitter twitter-share-button"  onclick="window.open('https://twitter.com/intent/tweet?text=<%# Get_ShareTweet(Eval("NEWS_SEO_URL"),Eval("NEWS_TITLE"))%>','sharer','toolbar=0,status=0,width=580,height=325');"><i class="fa fa-twitter"></i></a>
                </div>
                </div>
                </article>
                </div>
             </ItemTemplate>
         </asp:Repeater>
     </div>
    </div>
   </div>
  </div>
  <div class="w3-col m12" id="div_CuHon" runat="server">
   <div class="iblock list-video w3-c333 other-video">
    <h2 class="tt-main"><span>Các video cũ hơn</span> </h2>
    <div class="inner-list">
     <div class="slider-h3">
     <asp:Repeater ID="Re_CuHon" runat="server">
             <ItemTemplate>
                <div class="slide">
                <article class="video-it-detail">
                <div class="inner-video">
                    <div class="video-thumbnail"><%#GetLinkYoutube(Eval("NEWS_VIDEO_URL"),Eval("NEWS_TITLE"))%></div>
                    <h2 class="video-title"> <a href="<%#GetLinkNews(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>" title="<%#GetLinkNews(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>"><%#Eval("NEWS_TITLE")%></a> </h2>
                    <p class="video-by-line">by <span><a rel="nofollow" href="<%# Get_linkkenh(Eval("NEWS_FIELD4"))%>" target="_blank"><%# Get_tenKenh(Eval("NEWS_FIELD4"))%></a></span></p>
                    <div class="video-meta">
                    <p><%# FormatView(Eval("NEWS_COUNT"))%> lượt xem</p>
                    <p><%# HAM_QUI_DOI(Eval("NEWS_PUBLISHDATE"))%></p>
                    </div>
                <div class="wmn share-box">
                    <!--<i class="fa fa-thumbs-o-up"></i> Like -->
                    <a class="fb-like thumbs-up" data-href="<%#Getlink_Share(Eval("NEWS_SEO_URL"))%>" data-layout="button_count" data-action="like" data-show-faces="true" data-share="false"></a>
                    Share 
                    <a id="fb-share" class="facebook" style='text-decoration:none;' type="icon_link" onClick="window.open('http://www.facebook.com/sharer.php?s=100&amp;p[title]=<%#Eval("NEWS_TITLE")%>&amp;p[summary]=<%#Eval("NEWS_DESC")%>&amp;p[url]=<%#Getlink_Share(Eval("NEWS_SEO_URL"))%>&amp;p[images][0]=<%#GetImageT(Eval("NEWS_ID"),Eval("NEWS_IMAGE3"))%>','sharer','toolbar=0,status=0,width=580,height=325');" href="javascript: void(0)"><i class="fa fa-facebook"></i></a>
                    <a class="google-plus" rel="nofollow" href="https://plus.google.com/share?url=<%#Getlink_Share(Eval("NEWS_SEO_URL"))%>" onclick="javascript:window.open(this.href,'', 'menubar=no,toolbar=no,resizable=yes,scrollbars=yes,height=600,width=600');return false;"><i class="fa fa-google-plus"></i></a>
                    <a class="twitter twitter-share-button"  onclick="window.open('https://twitter.com/intent/tweet?text=<%# Get_ShareTweet(Eval("NEWS_SEO_URL"),Eval("NEWS_TITLE"))%>','sharer','toolbar=0,status=0,width=580,height=325');"><i class="fa fa-twitter"></i></a>
                </div>
                </div>
                </article>
                </div>
             </ItemTemplate>
         </asp:Repeater>
     </div>
    </div>
   </div>
  </div>
  <div class="w3-col m12" id="div_dexuat" runat="server">
   <div class="iblock list-video w3-c333 other-video">
    <h2 class="tt-main"><span>Các video đề xuất</span> </h2>
    <div class="inner-list">
     <div class="slider-cl">
      <asp:Repeater ID="Re_dexuat" runat="server">
    <ItemTemplate>
                <div class="slide">
                <article class="video-it-detail">
                <div class="inner-video">
                    <div class="video-thumbnail"><%#GetLinkYoutube(Eval("NEWS_VIDEO_URL"),Eval("NEWS_TITLE"))%></div>
                    <h2 class="video-title"> <a href="<%#GetLinkNews(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>" title="<%#GetLinkNews(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>"><%#Eval("NEWS_TITLE")%></a> </h2>
                    <p class="video-by-line">by <span><a rel="nofollow" href="<%# Get_linkkenh(Eval("NEWS_FIELD4"))%>" target="_blank"><%# Get_tenKenh(Eval("NEWS_FIELD4"))%></a></span></p>
                    <div class="video-meta">
                    <p><%# FormatView(Eval("NEWS_COUNT"))%> lượt xem</p>
                    <p><%# HAM_QUI_DOI(Eval("NEWS_PUBLISHDATE"))%></p>
                    </div>
                <div class="wmn share-box">
                    <!--<i class="fa fa-thumbs-o-up"></i> Like -->
                    <a class="fb-like thumbs-up" data-href="<%#Getlink_Share(Eval("NEWS_SEO_URL"))%>" data-layout="button_count" data-action="like" data-show-faces="true" data-share="false"></a>
                    Share 
                    <a id="fb-share" class="facebook" style='text-decoration:none;' type="icon_link" onClick="window.open('http://www.facebook.com/sharer.php?s=100&amp;p[title]=<%#Eval("NEWS_TITLE")%>&amp;p[summary]=<%#Eval("NEWS_DESC")%>&amp;p[url]=<%#Getlink_Share(Eval("NEWS_SEO_URL"))%>&amp;p[images][0]=<%#GetImageT(Eval("NEWS_ID"),Eval("NEWS_IMAGE3"))%>','sharer','toolbar=0,status=0,width=580,height=325');" href="javascript: void(0)"><i class="fa fa-facebook"></i></a>
                    <a class="google-plus" rel="nofollow" href="https://plus.google.com/share?url=<%#Getlink_Share(Eval("NEWS_SEO_URL"))%>" onclick="javascript:window.open(this.href,'', 'menubar=no,toolbar=no,resizable=yes,scrollbars=yes,height=600,width=600');return false;"><i class="fa fa-google-plus"></i></a>
                    <a class="twitter twitter-share-button"  onclick="window.open('https://twitter.com/intent/tweet?text=<%# Get_ShareTweet(Eval("NEWS_SEO_URL"),Eval("NEWS_TITLE"))%>','sharer','toolbar=0,status=0,width=580,height=325');"><i class="fa fa-twitter"></i></a>
                </div>
                </div>
                </article>
                </div>
             </ItemTemplate>
         </asp:Repeater>
     </div>
    </div>
   </div>
  </div>
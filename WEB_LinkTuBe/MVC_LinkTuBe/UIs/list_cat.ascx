<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="list_cat.ascx.cs" Inherits="MVC_LinkTuBe.UIs.list_cat" %>
  <div class="w3-col m10 main-col-2">
    <asp:Repeater ID="Re_Cat_Index" runat="server">
    <ItemTemplate>
        <div class="iblock list-video w3-c333">
        <h2 class="tt-main"><span><a style="color:white;" href="<%#GetLinkNews(Eval("cat_url"),Eval("cat_seo_url"))%>"><%#Eval("CAT_NAME") %></a></span>
         <div class="share-box share-box-tt">
             <a id="fb-share" class="facebook" style='text-decoration:none;' type="icon_link" onClick="window.open('http://www.facebook.com/sharer.php?s=100&amp;p[title]=<%#Eval("CAT_NAME")%>&amp;p[summary]=<%#Eval("CAT_DESC")%>&amp;p[url]=<%#Getlink_Share(Eval("cat_seo_url"))%>&amp;p[images][0]=<%#GetImageT_Cat(Eval("CAT_ID"),Eval("CAT_IMAGE1"))%>','sharer','toolbar=0,status=0,width=580,height=325');" href="javascript: void(0)"><i class="fa fa-facebook"></i></a> 
             <a rel="nofollow" class="google-plus" href="https://plus.google.com/share?url=<%#Getlink_Share(Eval("cat_seo_url"))%>" onclick="javascript:window.open(this.href,'', 'menubar=no,toolbar=no,resizable=yes,scrollbars=yes,height=600,width=600');return false;"><i class="fa fa-google-plus"></i></a>
             <a class="twitter twitter-share-button"  onclick="window.open('https://twitter.com/intent/tweet?text=<%# Get_ShareTweet(Eval("cat_seo_url"),Eval("CAT_NAME"))%>','sharer','toolbar=0,status=0,width=580,height=325');"><i class="fa fa-twitter"></i></a>
         </div>
        </h2>
    <div class="inner-list">
     <div class="slider-cl">
           <asp:Repeater ID="Repeater1" runat="server" DataSource='<%#loadnews(Eval("CAT_ID"))%>'>
             <ItemTemplate>
                 <div class="slide">
                   <article class="video-it">
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
    </ItemTemplate>
    </asp:Repeater>
   <!--end block-->
    <section class="text-center"  id="Page" runat="server">
    <ul class="w3-pagination" >
        <asp:Literal ID="ltrPage" runat="server"></asp:Literal>
    </ul>
    </section>
  </div>
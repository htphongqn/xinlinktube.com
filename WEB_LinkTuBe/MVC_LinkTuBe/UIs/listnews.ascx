<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listnews.ascx.cs" Inherits="MVC_LinkTuBe.UIs.listnews" %>
<div class="w3-col m10 main-col-2">
   <div class="iblock list-media  ">
    <h2 class="tt-main"><span><asp:Literal ID="ltl_newtitle" runat="server"></asp:Literal></span> </h2>
    <div class="inner-list">
    <asp:Repeater ID="Re_New" runat="server">
         <ItemTemplate>
             <article class="media">
              <div class="wmn inner-media">
               <div class="bg-hover-left"></div>
               <figure class="photo-media"><a href="<%#GetLink(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>"><img src="<%#GetImageT(Eval("NEWS_ID"),Eval("NEWS_IMAGE3"))%>" /></a></figure>
               <div class="text-media">
                <h2 class="tt-media"> <a href="<%#GetLink(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>"><%#Eval("NEWS_TITLE")%></a></h2>
                <p class="post-datetime"><%#FomatDate(Eval("NEWS_PUBLISHDATE"))%></p>
                <p class="des-media"><%#setBr(Eval("NEWS_DESC"))%></p>
               </div>
               <p><a href="<%#GetLink(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>" class="learnmore btn-news-detail">Chi tiết</a></p>
              </div>
             </article>
             <!--End article-->
        </ItemTemplate>
    </asp:Repeater>
    </div>
    <section class="text-center"  id="page" runat="server">
    <ul class="w3-pagination" >
        <asp:Literal ID="ltrPage" runat="server"></asp:Literal>
    </ul>
    </section>
   </div>
   <!--end block-->
  </div>
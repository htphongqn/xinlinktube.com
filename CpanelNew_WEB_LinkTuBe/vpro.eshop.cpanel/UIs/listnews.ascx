<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listnews.ascx.cs" Inherits="MVC_Kutun.UIs.listnews" %>
<section class="main-content"> <!-- InstanceBeginEditable name="maincontent" -->
         <div class="iblock">
        <p class="tt-main"><span><asp:Literal ID="ltl_newtitle" runat="server"></asp:Literal></span></p>
        <div class="inner-iblock">
          <div class="list-media">
              <asp:Repeater ID="Re_New" runat="server">
                  <ItemTemplate>
                      <article class="media">
                          <figure class="photo-media"><a href="<%#GetLink(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>"><img src="<%#GetImageT(Eval("NEWS_ID"),Eval("NEWS_IMAGE3"))%>" /></a></figure>
                          <div class="text-media">
                            <h2 class="tt-media"><a href="<%#GetLink(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>"><%#Eval("NEWS_TITLE")%></a></h2>
                                <p class="post-datetime"><%#FomatDate(Eval("NEWS_PUBLISHDATE"))%></p>
                            <p class="des-media"><%#setBr(Eval("NEWS_DESC"))%></p>
                          </div>
                </article>
                  </ItemTemplate>
              </asp:Repeater>
            <!--End article-->
              <p class="pagination clearfix" id="page" runat="server"><asp:Literal ID="ltrPage" runat="server"></asp:Literal></p>
          </div>
        </div>
      </div>
</section>
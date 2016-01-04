<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="search-result.ascx.cs"
    Inherits="MVC_Kutun.UIs.search_result" %>
<section class="main-content">
         <div class="iblock">
          <p class="tt-main"><span><asp:Literal ID="ltl_newtitle" runat="server"></asp:Literal></span></p>
          <div class="inner-iblock">
            <div class="list-products">
                <asp:Repeater ID="Rpproduct" runat="server">
                    <ItemTemplate>
                      <article class="product">
                        <div class="inner-product">
                          <figure class="img-product"><a href="<%#GetLink(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>"><img src="<%#GetImageT(Eval("NEWS_ID"),Eval("NEWS_IMAGE3"))%>" /></a></figure>
                          <h2 class="tt-product"><a href="<%#GetLink(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>"><%#Eval("NEWS_TITLE")%></a></h2>
                          <p class="price-product"><%#GetMoney(Eval("NEWS_PRICE1"))%></p>
                        </div>
                      </article>
                    </ItemTemplate>
                </asp:Repeater>
              <!--End article-->
              <p class="pagination clearfix" id="Page" runat="server"><asp:Literal ID="ltrPage" runat="server"></asp:Literal></p>
            </div>
          </div>
        </div>
</section>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="main.ascx.cs" Inherits="MVC_Kutun.UIs.main" %>
<section class="main-content">
        <div class="iblock">
          <p class="tt-main"><span>Sản phẩm nổi bật</span></p>
          <div class="inner-iblock">
            <div class="list-products">
                <asp:Repeater ID="Re_NoiBat" runat="server">
                    <ItemTemplate>
                        <article class="product">
                        <div class="inner-product">
						<div class="tooltip-pro"><div class="inner-tool"><img src="<%#GetImageT(Eval("NEWS_ID"),Eval("NEWS_IMAGE3"))%>" /></div></div>
                            <figure class="img-product"><a href="<%#GetLinkNews(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"),1)%>"><img src="<%#GetImageT(Eval("NEWS_ID"),Eval("NEWS_IMAGE3"))%>" /></a></figure>
                            <h2 class="tt-product"><a href="<%#GetLinkNews(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"),1)%>"><%#Eval("NEWS_TITLE")%></a></h2>
                            <p class="price-product"><%#GetMoney(Eval("NEWS_PRICE1"))%></p>
                        </div>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
          </div>
        </div>
        <!--end block-->
        <div class="iblock">
          <p class="tt-main"><span>Sản phẩm mới</span></p>
          <div class="inner-iblock">
            <div class="list-products">
              <asp:Repeater ID="Re_Moi" runat="server">
                    <ItemTemplate>
                        <article class="product">
                        <div class="inner-product">
                            <figure class="img-product"><a href="<%#GetLinkNews(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"),1)%>"><img src="<%#GetImageT(Eval("NEWS_ID"),Eval("NEWS_IMAGE3"))%>" /></a></figure>
                            <h2 class="tt-product"><a href="<%#GetLinkNews(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"),1)%>"><%#Eval("NEWS_TITLE")%></a></h2>
                            <p class="price-product"><%#GetMoney(Eval("NEWS_PRICE1"))%></p>
                        </div>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
          </div>
        </div>
    </section>
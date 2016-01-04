<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="product-details.ascx.cs"
    Inherits="MVC_Kutun.UIs.product_details" %>
<section class="main-content"> <!-- InstanceBeginEditable name="maincontent" -->
        <div class="iblock">
          <p class="tt-main"><span>Sản phẩm</span></p>
          <div class="inner-iblock">
            <div class="ibl detail-pro"> 
              <!--detail-product-->
              <link rel="stylesheet" type="text/css" href="/vi-vn/styles/cloud-zoom.css">
              <script type="text/javascript" src="/vi-vn/scripts/cloud-zoom.js"></script>
              <link rel="stylesheet" type="text/css" href="/vi-vn/styles/fancybox.css">
              <script type="text/javascript" src="/vi-vn/scripts/fancybox.js"></script> 
              <script type="text/javascript">
                  $(document).ready(function () {
                      $('.slider-pro-detail').bxSlider({
                          slideWidth: 100,
                          minSlides: 4,
                          maxSlides: 4,
                          moveSlides: 1,
                          slideMargin: 5,
                          speed: 500,
                          auto: false,
                      });
                  });
   		</script> 
              <script>
                  var imgsrc;
                  $(document).ready(function () {
                      $('.clsA').click(function () {
                          imgsrc = $(this).attr("href");
                          $('.imgLarge a').attr("href", imgsrc);
                          $('.zoomimg a').attr("href", imgsrc);
                          $('.imgLarge img').attr("src", imgsrc);
                          $('#zoom1').CloudZoom();
                          $(this).removeClass("fancybox");
                          $(this).removeAttr("rel");
                          return false;
                      });
                  });
                  //fancybox
                  $(document).ready(function () {
                      $('.fancybox').fancybox();
                  });
	  </script>

               <figure class="list-photo-detail">
               <asp:Repeater ID="re_hinh1" runat="server">
                  <ItemTemplate>
                    <div class="imgLarge">
                    <a class="cloud-zoom"  id="zoom1" href="<%# GetImageT(Eval("NEWS_ID"),Eval("NEWS_IMG_IMAGE1")) %>"><img src="<%# GetImageT(Eval("NEWS_ID"),Eval("NEWS_IMG_IMAGE1")) %>"></a> 
                    </div>
                    <p class="zoomimg"><i class="fa fa-plus-circle"></i>
                    <a class="fancybox" rel="group" href="<%# GetImageT(Eval("NEWS_ID"),Eval("NEWS_IMG_IMAGE1")) %>"> Click vào đây hình để xem hình lớn</a>
                    </p>
                  </ItemTemplate>
              </asp:Repeater>
                <div class="slide-detail">
              <div class="slider-pro-detail ">
                  <asp:Repeater ID="re_hinh2" runat="server">
                      <ItemTemplate>
                            <div class="slide"> <a href="<%# GetImageT(Eval("NEWS_ID"),Eval("NEWS_IMG_IMAGE1")) %>" class="clsA fancybox" rel="group"><img src="<%# GetImageT(Eval("NEWS_ID"),Eval("NEWS_IMG_IMAGE1")) %>"></a></div>
                      </ItemTemplate>
                  </asp:Repeater>
              </div>
            </div>
            </figure>
              
              <article class="short-detail-pro">
                <h1><asp:Literal ID="ltl_newtitle" runat="server"></asp:Literal></h1>
                <p class="msp">
                    <asp:Literal ID="ltl_msp_hangsx" runat="server"></asp:Literal></p>
                <p> </p>
                <div class="short-info">
                    <asp:Literal ID="ltl_desc" runat="server"></asp:Literal>
                </div>
                <!--<p class="price"> <span>Giá gốc</span>: <del>165.000 VNĐ</del> </p>-->
                <p class="price price-detail"> <span>Giá bán</span> <b>
                    <asp:Literal ID="ltl_price" runat="server"></asp:Literal></b> </p>
                <p class="number-prodetail"><span style="display:none;">Số lượng :</span>
                <asp:DropDownList class="txt-qlt" ID="ddl_soluong" runat="server" Visible="false">
                <asp:ListItem Value="1" Text="1" Selected="True"></asp:ListItem>
                <asp:ListItem Value="2" Text="2"></asp:ListItem>
                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                <asp:ListItem Value="4" Text="4"></asp:ListItem>
                <asp:ListItem Value="5" Text="5"></asp:ListItem>
                <asp:ListItem Value="6" Text="6"></asp:ListItem>
                <asp:ListItem Value="7" Text="7"></asp:ListItem>
                <asp:ListItem Value="8" Text="8"></asp:ListItem>
                <asp:ListItem Value="9" Text="9"></asp:ListItem>
                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                </asp:DropDownList>
                 <asp:LinkButton ID="lbt_muangay" class="btn-b btn-l btn-buy" runat="server" OnClick="LinkButton1_Click">Mua ngay</asp:LinkButton>
                </p>
                <p class="pro-btn"></p>
              </article>
              <!--detail-product-->
              <article class="detail-product clearfix"> 
                <!--<p class="tt-detail"><span>Thông tin chi tiết</span></p>--> 
                <!--begin--> 
                <script src="/vi-vn/scripts/tabcontent.js" type="text/javascript"></script>
                <link href="/vi-vn/styles/tabcontent.css" rel="stylesheet" type="text/css" />
                <ul class="tabs" data-persist="true">
                  <li><a href="#view1">Thông tin sản phẩm</a></li>
                  <li><a href="#view2">Bình luận</a></li>
                </ul>
                <div class="tabcontents">
                  <div id="view1">
                    <div class="inner-view"> 
                      <!--begin--> 
                    <asp:Literal ID="liHtml_info" runat="server"></asp:Literal>
                      <!--end--> 
                    </div>
                  </div>
                  <div id="view2">
                    <div class="inner-view"> 
                      <!--begin--> 
                      <div id="fb-comments" class="fb-comments" data-numposts="5" data-colorscheme="light" data-width="520"></div>
                        <div id="fb-root"></div>
                        <script>(function (d, s, id) { var currentUrl = window.location.href; document.getElementById("fb-comments").setAttribute("data-href", currentUrl); var js, fjs = d.getElementsByTagName(s)[0]; if (d.getElementById(id)) return; js = d.createElement(s); js.id = id; js.src = "//connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v2.4"; fjs.parentNode.insertBefore(js, fjs); }(document, 'script', 'facebook-jssdk'));</script>
                      <!--end--> 
                    </div>
                  </div>
                </div>
              </article>
            </div>
          </div>
        </div>
        <!--end block-->
        <div class=" iblock" id="dvOtherNews" runat="server">
          <p class="tt-main"><span>Sản phẩm tương tự</span></p>
          <div class="inner-iblock"> 
            <!--other product-->
            <article class="wmn other-product"> 
              <script type="text/javascript">
                  $(document).ready(function () {
                      $('.sl-other-product').bxSlider({
                          slideWidth: 200,
                          minSlides: 1,
                          maxSlides: 4,
                          moveSlides: 1,
                          slideMargin: 5,
                          speed: 500,
                          pause: 4000,
                          auto: true,
                      });
                  });
   		</script>
              <div class="sl-product">
                <div class="sl-other-product">
                    <asp:Repeater ID="Re_other" runat="server">
                        <ItemTemplate>
                           <div class="slide">
                            <div class="inner-product">
                              <figure class="img-product"><a href="<%#GetLink(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>"><img src="<%#GetImageT(Eval("NEWS_ID"),Eval("NEWS_IMAGE3"))%>" /></a></figure>
                              <h2 class="tt-product"><a href="<%#GetLink(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>"><%#Eval("NEWS_TITLE")%></a></h2>
                              <p class="price-product"><%#GetMoney(Eval("NEWS_PRICE1"))%></p>
                            </div>
                          </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
              </div>
            </article>
            <!--End other product--> 
          </div>
        </div>
       </section>
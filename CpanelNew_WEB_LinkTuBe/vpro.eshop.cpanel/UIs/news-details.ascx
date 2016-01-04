<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="news-details.ascx.cs"
    Inherits="MVC_Kutun.UIs.news_details" %>
<%@ Register Src="~/UIs/toolbar.ascx" TagPrefix="uc1" TagName="toolbar" %>
<uc1:toolbar runat="server" ID="toolbar" />
      <section class="main-content">
         <div class="iblock">
        <p class="tt-main"><span><asp:Literal ID="lbCatname" runat="server"></asp:Literal></span></p>
        <div class="inner-iblock">
          <article class="detail-news">
            <h1 class="tt-detail-news"><span><asp:Label ID="lbNewsTitle" runat="server" Text=""></asp:Label></span></h1>
            <p class="post-datetime"><asp:Label ID="lbNewsUpdate" runat="server" Text=""></asp:Label></p>
            <!-- begin-->
           <asp:Literal ID="liHtml" runat="server"></asp:Literal>
            <!-- end--> 
          </article>
          <div class="attachment">
            <div class="download_item">
            <asp:Repeater ID="Re_download" runat="server">
            <ItemTemplate>
                    <%# BindAttItems(Eval("NEWS_ID"),Eval("EXT_ID"),Eval("NEWS_ATT_NAME"),Eval("NEWS_ATT_URL"),Eval("NEWS_ATT_FILE"),Eval("EXT_FILE_IMAGE"))%>
            </ItemTemplate>
            </asp:Repeater>
            </div>
          </div>
          <div class="clearfix function">
            <div class="shareBox">
                <div class="addthis_toolbox addthis_default_style like_face shareBox">
                    <a class="addthis_button_preferred_1"></a><a class="addthis_button_preferred_2">
                    </a><a class="addthis_button_preferred_3"></a><a class="addthis_button_preferred_4">
                    </a><a class="addthis_button_compact"></a><a class="addthis_counter addthis_bubble_style">
                    </a>
                    <script type="text/javascript">
                        var addthis_config = { "data_track_addressbar": true };
                        addthis_config = addthis_config || {};
                        addthis_config.data_track_addressbar = false;
                    </script>
                    <script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-50d418ab2d45f0aa"></script>
                 </div>
            </div>
            <div class="toolbarBox">
                <a href="#" id="hplFeedback" runat="server"><i class="fa fa-edit"></i>Phản hồi</a>
            </div>
          </div>
          <!--function--> 
          <!--Other News-->
          <div class="clearfix otherNews" id="dvOtherNews" runat="server">
            <h3><span>Tin bài khác</span></h3>
            <ul>
                <asp:Repeater ID="Rptinkhac" runat="server">
                    <ItemTemplate>
                           <li><a href="<%#GetLink(Eval("NEWS_URL"),Eval("NEWS_SEO_URL"))%>"><%#Eval("NEWS_TITLE")%><small class="date">(Ngày đăng <%# FomatDate(Eval("NEWS_PUBLISHDATE"))%>)</small></a> </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
          </div>
      <!--Other News--> 
        </div>
      </div>
</section>
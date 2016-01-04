<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Video_DanhMuc.ascx.cs" Inherits="MVC_Kutun.UIs.Video_DanhMuc" %>
<div class="box">
          <h3 class="box_Tab">Video</h3>
          <div class="box_ct"> <span id="ytvideo2"></span>
            <ul class="demo2">
              <asp:Repeater ID="Re_video" runat="server">
                <ItemTemplate>
                <li><a href="<%#Eval("NEWS_VIDEO_URL")%>" class="link_video"><%#Eval("NEWS_TITLE")%></a></li>
                </ItemTemplate>
              </asp:Repeater>
            </ul>
          </div>
        </div>
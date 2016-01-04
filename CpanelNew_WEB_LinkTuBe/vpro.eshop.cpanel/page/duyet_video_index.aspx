<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="duyet_video_index.aspx.cs" Inherits="vpro.eshop.cpanel.page.duyet_video_index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">
				<!--
    function ToggleAll(e, action) {
        if (e.checked) {
            CheckAll();
        }
        else {
            ClearAll();
        }
    }
    function CheckAll() {
        var ml = document.forms[0];
        var len = ml.elements.length;
        for (var i = 1; i < len; i++) {
            var e = ml.elements[i];

            if (e.name.toString().indexOf("chkSelect") > 0)
                e.checked = true;
        }
        ml.MainContent_GridItemList_toggleSelect.checked = true;
    }

    function ClearAll() {
        var ml = document.forms[0];
        var len = ml.elements.length;
        for (var i = 1; i < len; i++) {
            var e = ml.elements[i];
            if (e.name.toString().indexOf("chkSelect") > 0)
                e.checked = false;
        }
        ml.MainContent_GridItemList_toggleSelect.checked = false;
    }

    function selectChange() {
        var radioButtons = document.getElementsByName("rblType");
        for (var x = 0; x < radioButtons.length; x++) {
            if (radioButtons[x].checked) {
                if (radioButtons[x].value == 1)
                { CheckAll(); }
            }
        }

    }

    // -->
    </script>
    <div class="row page-header">
 
        <asp:LinkButton ID="Lbsave" runat="server" class="btn btn-default btn-sm" OnClick="lbtSave_Click"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>&nbsp;Lưu</asp:LinkButton>
        <a href="#" onclick="javascript:document.location.reload(true);" class="btn btn-default btn-sm">
            <span class="glyphicon glyphicon-random" aria-hidden="true"></span>&nbsp;Refresh</a>
    </div>
    <div class="row page-header">
        <div class="form-inline">
            <div class="form-group">
                <input type="text" class="form-control col-sm-6" id="txtKeyword" placeholder="Từ khóa"
                    runat="server">
            </div>
            <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" class="btn btn-default"
                OnClick="btnSearch_Click" />
        </div>
    </div>
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">
                    Danh mục</h3>
            </div>
            <div class="panel-body table-responsive">
                <table class="table table-striped">
                    <tr>
                        <td>
                            #
                        </td>
                        <td>
                            <input type="checkbox" id="toggleSelect" runat="server" onclick="javascript: ToggleAll(this, 0);"
                                name="toggleSign">
                        </td>
                        <td>
                            Tiêu đề
                        </td>
                        <td>
                            Trạng thái
                        </td>
                         <td>
                            Lượt xem
                        </td>
                         <td>
                            Ngày đăng
                        </td>
                        <td>
                            Thứ tự
                        </td>
                        <td>
                            Thứ tự trang chủ
                        </td>
                    </tr>
                    <asp:Repeater ID="Rplist_news" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# getOrder() %>
                                    <asp:HiddenField ID="Hdnewsid" runat="server" Value='<%#Eval("NEWS_ID") %>' />
                                </td>
                                <td>
                                    <input id="chkSelect" type="checkbox" name="chkSelect" runat="server">
                                </td>
                                <td>  
                                        <%# Eval("NEWS_TITLE")%>
                                </td>
                                <td>
                                    <%# get_trangthai(Eval("NEWS_PERIOD"))%>
                                </td>
                                <td class="text-center">
                                    <%# FormatView(Eval("NEWS_COUNT")) %>
                                </td>
                                <td>
                                    <%# getDate(Eval("NEWS_PUBLISHDATE"))%>
                                </td>
                                <td>
                                    <input type="text" id="txtOrder" runat="server" maxlength="4" size="6" value='<%# Eval("NEWS_ORDER") %>'
                                        onkeyup="this.value=formatNumeric(this.value);" onblur="this.value=formatNumeric(this.value);"
                                        name="txtOrder" class="form-control" />
                                </td>
                                <td>
                                    <input type="text" id="txtOrderPeriod" runat="server" maxlength="4" size="6" value='<%# Eval("NEWS_ORDER_PERIOD") %>'
                                        onkeyup="this.value=formatNumeric(this.value);" onblur="this.value=formatNumeric(this.value);"
                                        name="txtOrderPeriod" class="form-control" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
            <td colspan="10">
            <ul class="pagination">
                <asp:Literal ID="LitPage" runat="server"></asp:Literal>
            </ul>
            </td>
            </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

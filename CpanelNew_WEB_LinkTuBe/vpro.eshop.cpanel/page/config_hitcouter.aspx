<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="config_hitcouter.aspx.cs" Inherits="vpro.eshop.cpanel.page.config_hitcouter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        <title>Lượt truy cập | Vpro.Eshop</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div class="row page-header">
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbtSave_Click" class="btn btn-success btn-sm" ValidationGroup="G1"><span class="glyphicon glyphicon-floppy-save" aria-hidden="true"></span>&nbsp;Lưu</asp:LinkButton>
        <asp:HyperLink ID="Hyperback" runat="server" class="btn btn-default btn-sm"> 
                <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>&nbsp;Đóng</asp:HyperLink>
 </div>
 <div class="row">
        <div class="form-horizontal">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title" id="H1">
                        Thông tin cấu hình</h3>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">
                            Lượt truy cập</label>
                        <div class="col-sm-10">
                            <input type="text" name="txtHitcouter" id="txtHitcouter" runat="server" onblur="this.value=formatNumeric(this.value);"
                            class="form-control" value="1" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Vui lòng nhập Lượt truy cập chung"
                        Text="Vui lòng nhập Lượt truy cập chung" ControlToValidate="txtHitcouter" CssClass="errormes"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
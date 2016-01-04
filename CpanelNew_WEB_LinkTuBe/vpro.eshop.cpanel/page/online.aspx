﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="online.aspx.cs" Inherits="vpro.eshop.cpanel.page.online" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row page-header col-md-12">
        <asp:LinkButton ID="lbtSave" runat="server" OnClick="lbtSave_Click" class="btn btn-success btn-sm"
            ValidationGroup="G1"><span class="glyphicon glyphicon-floppy-save" aria-hidden="true"></span>&nbsp;Lưu</asp:LinkButton>
        <asp:LinkButton ID="lbtSaveNew" runat="server" OnClick="lbtSaveNew_Click" class="btn btn-default btn-sm"
            ValidationGroup="G1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span>&nbsp;Lưu &
            Thêm mới
        </asp:LinkButton>
        <asp:LinkButton ID="LbsaveClose" runat="server" class="btn btn-default btn-sm" OnClick="LbsaveClose_Click"
            ValidationGroup="G1">
				<span class="glyphicon glyphicon-remove" aria-hidden="true"></span>&nbsp;Lưu & Đóng
        </asp:LinkButton>
        <asp:HyperLink ID="Hyperback" runat="server" class="btn btn-default btn-sm"> 
                <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>&nbsp;Đóng</asp:HyperLink>
        <span id="dvDelete" runat="server">
            <asp:LinkButton ID="Lbdelete" runat="server" class="btn btn-default btn-sm" OnClick="lbtDelete_Click"
                OnClientClick="return confirm('Bạn có chắc chắn xóa không?');" CausesValidation="false"> <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>&nbsp;Xóa</asp:LinkButton>
        </span>
    </div>
    <div class="row">
        <div class="col-md-8 form-horizontal">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title" id="H1">
                        Thông tin hỗ trợ</h3>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="rblType" />
                    </Triggers>
                    <ContentTemplate>
                         <div class="panel-body">
                    <div class="form-group" id="div_url" runat="server">
                        <label class="col-sm-2 control-label">
                            <asp:Label ID="lbl_url" runat="server" Text="Tên người hỗ trợ"></asp:Label></label>
                        <div class="col-sm-10">
                            <input type="text" name="txtName" id="txtName" runat="server" class="form-control" />
                          <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Vui lòng nhập tên"
                                Text="Vui lòng nhập tên" ControlToValidate="txtName" CssClass="label label-danger"
                                ValidationGroup="G1"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">
                            <asp:Label ID="ltl_desc" runat="server" Text="Mô tả"></asp:Label></label>
                        <div class="col-sm-10">
                            <textarea id="txtDesc" runat="server" class="form-control"></textarea>
                         <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Vui lòng nhập mô tả"
                                Text="Vui lòng nhập mô tả" ControlToValidate="txtDesc" CssClass="label label-danger"
                                ValidationGroup="G1"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div id="div_skype" runat="server">
                         <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Yahoo</label>
                            <div class="col-sm-10">
                                <input type="text" name="txt_Email" id="txt_Email" runat="server" class="form-control" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Skype</label>
                            <div class="col-sm-10">
                                <input type="text" name="txtnicksky" id="txtnicksky" runat="server" class="form-control" />
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Email</label>
                            <div class="col-sm-10">
                                <input type="text" name="txtroomname" id="txtroomname" runat="server" class="form-control" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Phone</label>
                            <div class="col-sm-10">
                                <input type="text" name="txtphone" id="txtphone" runat="server" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">
                            Thứ tự</label>
                        <div class="col-sm-10">
                            <input type="text" name="txtOrder" id="txtOrder" runat="server" onkeyup="this.value=formatNumeric(this.value);"
                                onblur="this.value=formatNumeric(this.value);" maxlength="4" class="form-control"
                                value="1" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">
                            Ngôn ngữ</label>
                        <div class="col-sm-10">
                            <asp:RadioButtonList ID="rblLanguage" runat="server" RepeatColumns="5">
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="col-md-4">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title" id="H2">
                        Loại hỗ trợ</h3>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label>
                            Loại</label>
                        <asp:RadioButtonList ID="rblType" runat="server" RepeatColumns="2" AutoPostBack="True"
                            OnSelectedIndexChanged="rblType_SelectedIndexChanged">
                            <asp:ListItem Value="2" Text="Hotline"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Fanpage"></asp:ListItem>
                            <asp:ListItem Value="4" Text="Google+"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Facebook"></asp:ListItem>
                            <asp:ListItem Value="5" Text="Twitter"></asp:ListItem>
                            <asp:ListItem Value="6" Text="Youtube"></asp:ListItem>
                           <%-- <asp:ListItem Value="7" Text="Zing"></asp:ListItem>
                            <asp:ListItem Value="8" Text="Pinterest"></asp:ListItem>--%>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

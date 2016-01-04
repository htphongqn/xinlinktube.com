﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="contact_config.aspx.cs" Inherits="vpro.eshop.cpanel.page.contact_config"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../tinymce/js/tinymce/tinymce.min.js"></script>
    <script src="../Scripts/TinymiceEditor.js" type="text/javascript"></script>
    <div class="row page-header col-md-12">
        <asp:LinkButton ID="lbtSave" runat="server" OnClick="lbtSave_Click" class="btn btn-success btn-sm"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>&nbsp;Lưu</asp:LinkButton>
    </div>
    <div class="row">
        <div class="col-md-9">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title" id="H1">
                        Cấu hình liên hệ</h3>
                </div>
                <div class="panel-body">
                    <textarea id="mrk" cols="20" rows="15" class="form-control" runat="server"></textarea>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title" id="H8">
                        Liên hệ tiếng anh</h3>
                </div>
                <div class="panel-body">
                    <textarea id="mrk6" cols="20" rows="15" class="form-control" runat="server"></textarea>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title" id="H3">
                        Cấu hình bản đồ</h3>
                </div>
                <div class="panel-body">
                    <textarea id="mrk1" cols="20" rows="15" class="form-control" runat="server"></textarea>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title" id="H4">
                        Cấu hình vận chuyển hà nội</h3>
                </div>
                <div class="panel-body">
                    <textarea id="mrk2" cols="20" rows="15" class="form-control" runat="server"></textarea>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title" id="H9">
                        Cấu hình vận chuyển hà nội tiếng anh</h3>
                </div>
                <div class="panel-body">
                    <textarea id="mrk2_en" cols="20" rows="15" class="form-control" runat="server"></textarea>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title" id="H5">
                        Cấu hình vận chuyển đà nẵng</h3>
                </div>
                <div class="panel-body">
                    <textarea id="mrk3" cols="20" rows="15" class="form-control" runat="server"></textarea>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title" id="H10">
                        Cấu hình vận chuyển đà nẵng tiếng anh</h3>
                </div>
                <div class="panel-body">
                    <textarea id="mrk3_en" cols="20" rows="15" class="form-control" runat="server"></textarea>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title" id="H6">
                        Cấu hình vận chuyển HCM</h3>
                </div>
                <div class="panel-body">
                    <textarea id="mrk4" cols="20" rows="15" class="form-control" runat="server"></textarea>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title" id="H11">
                        Cấu hình vận chuyển HCM tiếng anh</h3>
                </div>
                <div class="panel-body">
                    <textarea id="mrk4_en" cols="20" rows="15" class="form-control" runat="server"></textarea>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title" id="H7">
                        Cấu hình vận chuyển bình dương</h3>
                </div>
                <div class="panel-body">
                    <textarea id="mrk5" cols="20" rows="15" class="form-control" runat="server"></textarea>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title" id="H12">
                        Cấu hình vận chuyển bình dương tiếng anh</h3>
                </div>
                <div class="panel-body">
                    <textarea id="mrk5_en" cols="20" rows="15" class="form-control" runat="server"></textarea>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title" id="H2">
                        Select images</h3>
                </div>
                <div class="panel-body">
                    <span class="btn btn-default btn-file"><span class="glyphicon glyphicon-file" aria-hidden="true">
                    </span>&nbsp;Chọn file<asp:FileUpload ID="FileUpload1" runat="server" multiple="true" /></span>
                    <asp:Button ID="Btupmulti" runat="server" Text="Upload" OnClick="Btupmulti_Click"
                        class="btn btn-success btn-sm" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MVC_LinkTuBe.Components;
using System.IO;
using vpro.functions;
using System.Web.UI.HtmlControls;
using Controller;

namespace MVC_LinkTuBe.vi_vn
{
    public partial class contact : System.Web.UI.Page
    {
        #region Declare
        Config cf = new Config();
        SendMail sm = new SendMail();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show_File_HTML("contact-vi.htm", 0);
                Show_File_HTML("map-vi.htm", 1);
            }
            var _configs = cf.Config_meta();

            if (_configs.ToList().Count > 0)
            {
                if (!string.IsNullOrEmpty(_configs.ToList()[0].CONFIG_FAVICON))
                    ltrFavicon.Text = "<link rel='shortcut icon' href='" + PathFiles.GetPathConfigs() + _configs.ToList()[0].CONFIG_FAVICON + "' />";
            }

            HtmlHead header = base.Header;
            HtmlMeta headerDes = new HtmlMeta();
            HtmlMeta headerKey = new HtmlMeta();
            headerDes.Name = "Description";
            headerKey.Name = "Keywords";

            header.Title = "Liên hệ";
        }
        private void Show_File_HTML(string HtmlFile, int type)
        {
            string pathFile;
            string strHTMLContent;
            pathFile = Server.MapPath("../Data/contact/" + HtmlFile);

            if ((File.Exists(pathFile)))
            {
                StreamReader objNewsReader;
                objNewsReader = new StreamReader(pathFile);
                strHTMLContent = objNewsReader.ReadToEnd();
                objNewsReader.Close();
                if (type == 0)
                    Literal1.Text = strHTMLContent;
                else Literal2.Text = strHTMLContent;
            }


        }


        protected void Lbthanhtoan_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtCapcha.Value != this.Session["CaptchaImageText"].ToString())
                {
                    string strScript = "<script>";
                    strScript += "alert(' Mã xác thực không đúng!');";
                    strScript += "</script>";
                    Page.RegisterClientScriptBlock("strScript", strScript);
                }
                else
                {

                    string _sEmailCC = string.Empty;
                    string _sEmailCC1 = string.Empty;
                    string _sEmailBCC = string.Empty;
                    string _sEmail = txtEmail.Value;
                    string _sName = Txtname.Value;
                    string _add = "";
                    string _phone = Txtphone.Value;
                    string _content = txtContent.Value;
                    string _title = Txttitle.Value;
                    cf.Insert_contact(_sName, _sEmail, _title, _content, _add, _phone);
                    string _mailBody = string.Empty;
                    _mailBody += "<br/><br/><strong>Tên người liên hệ</strong>: " + _sName;
                    _mailBody += "<br/><br/><strong>Email</strong>: " + _sEmail;
                    _mailBody += "<br/><br/><strong>Số điện thoại</strong>: " + _phone;
                    if (_add != string.Empty)
                    {
                        _mailBody += "<br/><br/><strong>Địa chỉ</strong>: " + _add;
                    }
                    _mailBody += "<br/><br/><strong>Tiêu đề</strong>: " + _title;
                    _mailBody += "<br/><br/><strong>Nội dung</strong>: " + _content + "<br/><br/>";
                    string _sMailBody = string.Empty;
                    _sMailBody += "Cám ơn bạn: " + _sName + " đã đặt liên hệ với chúng tôi. Đây là email được gửi từ website của " + System.Configuration.ConfigurationManager.AppSettings["EmailDisplayName"] + " <br>" + _mailBody;
                    _sEmailCC = cf.Getemail(2).Count > 0 ? cf.Getemail(2)[0].EMAIL_TO : "";
                    _sEmailCC1 = cf.Getemail(2).Count > 0 ? cf.Getemail(2)[0].EMAIL_CC : "";
                    _sEmailBCC = cf.Getemail(2).Count > 0 ? cf.Getemail(2)[0].EMAIL_BCC : "";
                    sm.SendEmailSMTP("Thông báo: Bạn đã liên hệ thành công", _sEmail, _sEmailCC, _sEmailCC1, _sEmailBCC, _sMailBody, true, false);
                    string strScript = "<script>";
                    strScript += "alert(' Đã gửi liên hệ thành công!');";
                    strScript += "window.location='/trang-chu.html';";
                    strScript += "</script>";
                    Page.RegisterClientScriptBlock("strScript", strScript);
                }
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vpro.functions;
using Controller;
using MVC_LinkTuBe.Components;

namespace MVC_LinkTuBe.UIs
{
    public partial class footer : System.Web.UI.UserControl
    {
        #region Declare
        Config cf = new Config();
        Propertity per = new Propertity();
        Function fun = new Function();
        Userinfo User = new Userinfo();
        Home index = new Home();
        SendMail send = new SendMail();
        setCookieDevice setckdv = new setCookieDevice();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_Email.Attributes.Add("onkeypress", "return clickButton(event,'" + btn_nhantin.ClientID + "')");
                Load_Fanpage();
                Load_Social();
                Load_MenuF();
                Show_File_HTML();
            }
        }
        #region Function
        private void Load_MenuF()
        {
            Re_menuF.DataSource = per.Kenh_Footer(5);
            Re_menuF.DataBind();
        }
        protected IQueryable Load_Menu2(object cat_parent_id)
        {
            try
            {
                return per.Menu_phu(cat_parent_id);
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }

        }
        protected IQueryable Load_Menu2_Footer(object cat_parent_id)
        {
            try
            {
                return per.Menu_phu(cat_parent_id, 1,5);
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }

        }
        //<div class="fb-page" data-href="https://www.facebook.com/denuongda/?ref=hl" data-small-header="false" data-width="320" data-adapt-container-width="true" data-hide-cover="false" data-show-facepile="true"><div class="fb-xfbml-parse-ignore"><blockquote cite="https://www.facebook.com/denuongda/?ref=hl"><a href="https://www.facebook.com/denuongda/?ref=hl">Dê nướng đá</a></blockquote></div></div>
        private void Load_Fanpage()
        {
            var list = per.LoadHTTT(1);
            if (list.Count() > 0)
            {
                ltl_fanpage.Text = "<div class='fb-page' data-href='" + list.FirstOrDefault().ONLINE_NICKNAME + "' data-tabs='timeline' data-width='231' data-height='244' data-small-header='false' data-adapt-container-width='false' data-hide-cover='false' data-show-facepile='true'><div class='fb-xfbml-parse-ignore'><blockquote cite='" + list.FirstOrDefault().ONLINE_NICKNAME + "'><a href='" + list.FirstOrDefault().ONLINE_NICKNAME + "'>" + list.FirstOrDefault().ONLINE_DESC + "</a></blockquote></div></div>";
            }
        }
         //<a class="facebook"><i class="fa fa-facebook"></i></a>
         //<a class="google-plus"><i class="fa fa-google-plus"></i></a>
         //<a class="twitter"><i class="fa fa-twitter"></i></a>
         //<a class="youtube"><i class="fa fa-youtube"></i></a>
        private void Load_Social()
        {
            var list = per.LoadHTTT();
            string str = "<a href='{0}' class='{1}' target='_blank'><i class='{2}'></i></a>";
            foreach (var item in list)
            {
                switch (item.ONLINE_TYPE)
                {
                    //google
                    case 4: ltl_social_network.Text += String.Format(str, item.ONLINE_NICKNAME, "google-plus", "fa fa-google-plus"); break;
                    //facebook
                    case 3: ltl_social_network.Text += String.Format(str, item.ONLINE_NICKNAME, "facebook", "fa fa-facebook"); break;
                    //twitter
                    case 5: ltl_social_network.Text += String.Format(str, item.ONLINE_NICKNAME, "twitter", "fa fa-twitter"); break;
                    //youtube
                    case 6: ltl_social_network.Text += String.Format(str, item.ONLINE_NICKNAME, "youtube", "fa fa-youtube"); break;
                }
            }
        }
        public string GetLink(object Cat_Url, object Cat_Seo_Url)
        {
            try
            {
                return fun.Getlink_Cat(Cat_Url, Cat_Seo_Url);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region event
        protected void btn_nhantin_Click(object sender, EventArgs e)
        {
            try
            {
                if (User.checkemail(txt_Email.Value))
                {
                    User.DangKyNhanTin(txt_Email.Value);
                    string Mbody = "Cám ơn : " + txt_Email.Value + " đã đăng ký nhận tin của chúng tôi. Đây là email được gửi từ website của " + System.Configuration.ConfigurationManager.AppSettings["EmailDisplayName"];
                    send.SendEmailSMTP("Thông báo: Bạn đã đăng ký nhận tin thành công", txt_Email.Value, "", "", "", Mbody, true, false);
                    string strScript = "<script>";
                    strScript += "alert('Đăng ký nhận tin thành công!');";
                    strScript += "</script>";
                    Page.RegisterClientScriptBlock("strScript", strScript);
                    return;
                }
                else
                {
                    string strScript = "<script>";
                    strScript += "alert('Email này đã đăng ký nhận tin rồi!');";
                    strScript += "</script>";
                    Page.RegisterClientScriptBlock("strScript", strScript);
                    return;
                }
            }
            catch
            {
                string strScript = "<script>";
                strScript += "alert('Đăng ký thất bại!');";
                strScript += "</script>";
                Page.RegisterClientScriptBlock("strScript", strScript);
                return;
            }
        }
        private void Show_File_HTML()
        {
            ltl_cauhinhhaiben.Text = cf.Show_File_HTML("thanhtruot-vi.htm", "/Data/footer/");
        }
        #endregion
    }
}
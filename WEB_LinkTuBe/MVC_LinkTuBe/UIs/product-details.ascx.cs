using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vpro.functions;
using System.IO;
using Controller;
using System.Data;
using MVC_LinkTuBe.Components;

namespace MVC_LinkTuBe.UIs
{
    public partial class product_details : System.Web.UI.UserControl
    {
        #region Declare
        News_details ndetail = new News_details();
        Home index = new Home();
        Product_Details pro_detail = new Product_Details();
        Function fun = new Function();
        Attfile att = new Attfile();
        Comment cm = new Comment();
        List_product list_pro = new List_product();
        Getcookie ck = new Getcookie();
        Checkcookie checkck = new Checkcookie();
        setCookieLike setck = new setCookieLike();
        public clsFormat fm = new clsFormat();
        int _newsID = 0;
        public string _img3,_sNewsSeoUrl, _newtitle, _newsdesc = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            _newsID = Utils.CIntDef(Session["News_id"]);
            _img3 = Utils.CStrDef(Session["News_image3"]);
            _newsdesc = Utils.CStrDef(Session["News_desc"]);
            _sNewsSeoUrl = Utils.CStrDef(Session["News_seo_url"]);
            if (!IsPostBack)
            {
                Addsee();
                TinMoiHon();
                TinCuHon();
                Load_DeXuat();
                Loaddetails();
            }
        }
        #region Addsee
        protected void Lbadddie_Click(object sender, EventArgs e)
        {
             string url = Request.RawUrl;
             if (!String.IsNullOrEmpty(url))
             {
                 string[] a = url.Split('?');
                 if (!checkck.Listcookie_like().Contains(_sNewsSeoUrl))
                 {
                     setck.Addcookie(_sNewsSeoUrl);
                     pro_detail.Adddie(_sNewsSeoUrl);
                     string strScript = "<script>";
                     strScript += "alert('Cảm ơn bạn đã thông báo');";
                     strScript += "window.location='" + a[0] + "';";
                     strScript += "</script>";
                     Page.RegisterClientScriptBlock("strScript", strScript);
                 }
                 else
                 {
                     string strScript = "<script>";
                     strScript += "alert('Bạn đã thông báo rồi');";
                     strScript += "window.location='" + a[0] + "';";
                     strScript += "</script>";
                     Page.RegisterClientScriptBlock("strScript", strScript);
                 }
             }
        }
        private void Addsee()
        {
            pro_detail.Addsee(_sNewsSeoUrl);
        }
        #endregion
        #region Loaddata
        public void Loaddetails()
        {
            try
            {
                Show_File_HTML();
                var list = pro_detail.Load_Product_Detail(_sNewsSeoUrl);
                if (list.Count > 0)
                {
                    _newtitle = list[0].NEWS_TITLE;
                    string newvideourl = list[0].NEWS_VIDEO_URL;
                    ltl_newtitle.Text = _newtitle;
                    ltl_ngaydang.Text=FomatDate(list[0].NEWS_PUBLISHDATE);
                    ltl_link.Text = "<a class='tdt' target='blank' rel='nofollow' href='" + newvideourl + "'>" + newvideourl + "</a>";
                    ltl_cout.Text = FormatView(list[0].NEWS_COUNT);
                    ltl_video.Text = GetLinkYoutube_detail(newvideourl, _newtitle);
                    ltl_kenh.Text = "<a class='tdt' target='blank' rel='nofollow' href='"+Get_linkkenh(Utils.CStrDef(list[0].NEWS_FIELD4))+"'>"+Get_tenKenh(Utils.CStrDef(list[0].NEWS_FIELD4))+"</a>";
                }

            }
            catch (Exception ex)
            {

                clsVproErrorHandler.HandlerError(ex);
            }
        }
        private void Show_File_HTML()
        {
            try
            {
                liHtml_info.Text = pro_detail.Show_File_HTML(_newsID,1);
                if (liHtml_info.Text.Length <= 0)
                    a_hrefmota.Visible = false;
                else
                    a_hrefmota.Visible = true;
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }
        public void TinMoiHon()
        {
            try
            {
                var _tinTucKhac = ndetail.Load_othernews_moihon(_newsID);
                if (_tinTucKhac.ToList().Count > 0)
                {
                    Re_MoiHon.DataSource = _tinTucKhac;
                    Re_MoiHon.DataBind();
                    div_MoiHon.Visible = true;
                }
                else
                    div_MoiHon.Visible = false;
            }
            catch (Exception ex)
            {

                clsVproErrorHandler.HandlerError(ex);
            }
        }
        public void TinCuHon()
        {
            try
            {
                var _tinTucKhac = ndetail.Load_othernews_cuhon(_newsID);
                if (_tinTucKhac.ToList().Count > 0)
                {
                    Re_CuHon.DataSource = _tinTucKhac;
                    Re_CuHon.DataBind();
                    div_CuHon.Visible = true;
                }
                else
                    div_CuHon.Visible = false;
            }
            catch (Exception ex)
            {

                clsVproErrorHandler.HandlerError(ex);
            }
        }
        private void Load_DeXuat()
        {
            var list = index.Loadindex(1, 2, 10);
            if (list.Count() > 0)
            {
                Re_dexuat.DataSource = list;
                Re_dexuat.DataBind();
                div_dexuat.Visible = true;
            }
            else
                div_dexuat.Visible = false;
        }
        #endregion
        #region function
        public string FomatDate(object News_publishdate)
        {
            return string.Format("{0:dd/MM/yyyy hh:mm tt}", News_publishdate);
        }
        public string GetLinkYoutube(object News_linkyoutube, object News_title)
        {
            try
            {
                return fun.GetLinkYoutube(News_linkyoutube, News_title);
            }
            catch
            {
                return string.Empty;
            }
        }
        public string GetLinkYoutube_detail(object News_linkyoutube, object News_title)
        {
            try
            {
                return fun.GetLinkYoutube_detail(News_linkyoutube, News_title);
            }
            catch
            {
                return string.Empty;
            }
        }
        public string HAM_QUI_DOI(object news_publish_day)
        {

            return fun.HAM_QUI_DOI(Utils.CDateDef(news_publish_day, DateTime.Now));
        }
        public string FormatView(object _cat_count)
        {
            return fun.FormatView(_cat_count);
        }
        public string Get_linkkenh(object _cat_id)
        {
            int cat_id = Utils.CIntDef(_cat_id);
            return fun.Get_linkkenh(cat_id);
        }
        public string Get_tenKenh(object _cat_id)
        {
            int cat_id = Utils.CIntDef(_cat_id);
            return fun.Get_tenKenh(cat_id);
        }
        //+ System.Configuration.ConfigurationManager.AppSettings["URLWebsite"] +
        public string Getlink_Share()
        {
            try
            {
                string _URLWebsite = System.Configuration.ConfigurationManager.AppSettings["URLWebsite"];
                return fun.Getlink_Share(_sNewsSeoUrl, _URLWebsite);
            }
            catch (Exception ex)
            {
                vpro.functions.clsVproErrorHandler.HandlerError(ex);
                return string.Empty;
            }
        }
        public string Get_ShareTweet()
        {
            try
            {
                string _EmailDisplayName = System.Configuration.ConfigurationManager.AppSettings[" EmailDisplayName"];
                string _URLWebsite = System.Configuration.ConfigurationManager.AppSettings["URLWebsite"];
                return fun.Get_ShareTweet(Utils.CStrDef(_sNewsSeoUrl), Utils.CStrDef(_newtitle), _URLWebsite, _EmailDisplayName);
            }
            catch (Exception ex)
            {
                vpro.functions.clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        public string GetLinkNews(object News_Url, object News_Seo_Url)
        {
            try
            {
                return fun.Getlink_News(News_Url, News_Seo_Url);
            }
            catch (Exception ex)
            {
                vpro.functions.clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        public string GetImageT()
        {

            try
            {
                return fun.GetImageT_News(_newsID, _img3);
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        public string GetImageT(object News_Id, object News_Image1)
        {

            try
            {
                return fun.GetImageT_News(News_Id, News_Image1);
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        public string Getlink_Share(object News_Seo_Url)
        {
            try
            {
                string _URLWebsite = System.Configuration.ConfigurationManager.AppSettings["URLWebsite"];
                return fun.Getlink_Share(News_Seo_Url, _URLWebsite);
            }
            catch (Exception ex)
            {
                vpro.functions.clsVproErrorHandler.HandlerError(ex);
                return string.Empty;
            }
        }
        public string Get_ShareTweet(object News_Seo_Url, object News_Title)
        {
            try
            {
                string _EmailDisplayName = System.Configuration.ConfigurationManager.AppSettings[" EmailDisplayName"];
                string _URLWebsite = System.Configuration.ConfigurationManager.AppSettings["URLWebsite"];
                return fun.Get_ShareTweet(Utils.CStrDef(News_Seo_Url), Utils.CStrDef(News_Title), _URLWebsite, _EmailDisplayName);
            }
            catch (Exception ex)
            {
                vpro.functions.clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        #endregion
        protected void Lbaddtocart_Click(object sender, EventArgs e)
        {
            try
            {
                var list = pro_detail.Load_Product_Detail(_sNewsSeoUrl);
                if (list.Count > 0)
                {
                    if (Utils.CDecDef(list[0].NEWS_PRICE1) != 0)
                        Response.Redirect("../vi-vn/Addtocart.aspx?id=" + list[0].NEWS_ID,true);
                    else
                    {
                        string strScript = "<script>";
                        strScript += "alert(' Bạn hãy liên hệ chúng tôi để mua sản phẩm này!');";
                        strScript += "</script>";
                        Page.RegisterClientScriptBlock("strScript", strScript);
                    }
                }
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                
            }
        }

        protected void Lbaddlike_Click(object sender, EventArgs e)
        {
            string url = Request.RawUrl;
            if (!String.IsNullOrEmpty(url))
            {
                string[] a = url.Split('?');
                if (!checkck.Listcookie_like().Contains(_sNewsSeoUrl))
                {
                    setck.Addcookie(_sNewsSeoUrl);
                    string strScript = "<script>";
                    strScript += "alert('Đã thêm vào yêu thích!');";
                    strScript += "window.location='"+a[0]+"';";
                    strScript += "</script>";
                    Page.RegisterClientScriptBlock("strScript", strScript);
                }
                else
                {
                    string strScript = "<script>";
                    strScript += "alert(' Bạn đã thích sản phẩm này!');";
                    strScript += "window.location='" + a[0] + "';";
                    strScript += "</script>";
                    Page.RegisterClientScriptBlock("strScript", strScript);
                }
            }
            
        }
    }
}
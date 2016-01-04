using Controller;
using MVC_LinkTuBe.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vpro.functions;

namespace MVC_LinkTuBe.UIs
{
    public partial class Link_Hot : System.Web.UI.UserControl
    {
        #region Decclare
        Home index = new Home();
        Propertity per = new Propertity();
        Function fun = new Function();
        Getcookie ck = new Getcookie();
        Checkcookie checkck = new Checkcookie();
        setCookieLike setck = new setCookieLike();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_TinMoi();
                Load_ads();
            }
        }

        #region Function
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
        public string GetLink(object Cat_Url, object Cat_Seo_Url, object Cat_Type)
        {
            try
            {
                string temp = fun.Getlink_Cat(Cat_Url, Cat_Seo_Url);
                return temp;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string GetImageT_Ad(object Ad_Id, object Ad_Image1)
        {
            try
            {
                return fun.GetImageT_Ad(Ad_Id, Ad_Image1);
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }

        }
        #endregion
        #region Load data
        private void Load_ads()
        {
            Re_ads.DataSource = per.Load_slider(1, 5);
            Re_ads.DataBind();
        }
        private void Load_TinMoi()
        {
            re_link_hot.DataSource = index.Loadindex(1, 3, 10);
            re_link_hot.DataBind();
        }
        protected void re_link_hot_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "like")
            {
                string _sNewsSeoUrl = e.CommandArgument.ToString();
                string url = Request.RawUrl;
                string _sNewsTitle = fun.Get_news_title(_sNewsSeoUrl);
                if (!String.IsNullOrEmpty(url))
                {
                    string[] a = url.Split('?');
                    if (!checkck.Listcookie_like().Contains(_sNewsSeoUrl))
                    {
                        setck.Addcookie(_sNewsSeoUrl);
                        string strScript = "<script>";
                        strScript += "alert('Bạn đã thích video " + _sNewsTitle + "');";
                        strScript += "</script>";
                        Page.RegisterClientScriptBlock("strScript", strScript);
                    }
                    else
                    {
                        string strScript = "<script>";
                        strScript += "alert('Bạn đã thích video " + _sNewsTitle + " rồi');";
                        strScript += "</script>";
                        Page.RegisterClientScriptBlock("strScript", strScript);
                    }
                }
                fun.add_like(_sNewsSeoUrl);
            }
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vpro.functions;
using MVC_LinkTuBe.Components;
using Controller;

namespace MVC_LinkTuBe.UIs
{
    public partial class list_product : System.Web.UI.UserControl
    {
        #region Declare
        List_product list_pro = new List_product();
        Function fun = new Function();
        clsFormat fm = new clsFormat();
        Product_Details pro_detail = new Product_Details();
        Pageindex_chage change = new Pageindex_chage();
        Home index = new Home();
        Checkcookie cki = new Checkcookie();
        int _Catid = 0,_idhangsx=0;
        public string _title, _desc = string.Empty;
        string _cat_seo_url, _img1 = string.Empty;
        int _page = 0;
        string _price;
        int _pricetype,_sortvl=0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            _img1 = Utils.CStrDef(Session["Cat_img1"]);
            _Catid = Utils.CIntDef(Session["Cat_id"]);
            _cat_seo_url = Request.QueryString["purl"];
            _page = Utils.CIntDef(Request.QueryString["page"]);
            _idhangsx = Utils.CIntDef(Request.QueryString["idhangsx"]);
            _pricetype = Utils.CIntDef(Request.QueryString["typepri"]);
            _price = Utils.CStrDef(Request.QueryString["price"]);
            _sortvl = Utils.CIntDef(Request.QueryString["sort"]);
            _desc = Utils.CStrDef(Session["Cat_desc"]);
            _title = Utils.CStrDef(Session["Cat_name"]);
            if (!IsPostBack)
            {
               
                //hiddenLeft();
                Loadtitle();
                Loadlist();
            }
        }
        public void Loadtitle()
        {
            try
            {
                Lbtitle.Text = _title;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Loadlist()
        {
            try
            {
                int sotin = list_pro.Getsotin(_Catid);
                if (sotin == 0)
                {
                    sotin = 20;
                }
                var list = list_pro.Load_listpro(_Catid,_idhangsx,_pricetype,_price,_sortvl);
                if (list.Count > 0)
                {
                    if (_page != 0)
                    {
                        Rplistpro.DataSource = list.Skip(sotin * _page - sotin).Take(sotin);
                        Rplistpro.DataBind();
                    }
                    else
                    {
                        Rplistpro.DataSource = list.Take(sotin);
                        Rplistpro.DataBind();
                    }

                    ltrPage.Text = change.result(list.Count, sotin, _cat_seo_url, _page, 1, 10);

                }

            }
            catch (Exception)
            {

                throw;
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
        public string Getlink_Share()
        {
            try
            {
                string _URLWebsite = System.Configuration.ConfigurationManager.AppSettings["URLWebsite"];
                return fun.Getlink_Share(_cat_seo_url, _URLWebsite);
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
                return fun.Get_ShareTweet(Utils.CStrDef(_cat_seo_url), Utils.CStrDef(_title), _URLWebsite, _EmailDisplayName);
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
        public string GetImageT_Cat()
        {

            try
            {
                return fun.GetImageT_News_Cat(_Catid, _img1);
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
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
        #endregion
    }
}
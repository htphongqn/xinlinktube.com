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
    public partial class list_cat : System.Web.UI.UserControl
    {
        #region Decclare
        int _Catid = 0;
        int _page = 0;
        string _cat_seo_url = string.Empty;
        List_product list_pro = new List_product();
        Getcookie ck = new Getcookie();
        Checkcookie checkck = new Checkcookie();
        setCookieLike setck = new setCookieLike();
        Propertity per = new Propertity();
        Pageindex_chage change = new Pageindex_chage();
        Home index = new Home();
        Function fun = new Function();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            _Catid = Utils.CIntDef(Session["Cat_id"]);
            _cat_seo_url = Request.QueryString["purl"];
            _page = Utils.CIntDef(Request.QueryString["page"]);
            if (!IsPostBack)
            {
                Loadlist();
            }
        }
        #region Load cat index
        public void Loadlist()
        {
            try
            {
                int sotin = list_pro.Getsotin(_Catid);
                if (sotin == 0)
                {
                    sotin = 20;
                }
                var list = list_pro.loadCatepro(_Catid);
                if (list.Count > 0)
                {
                    if (_page != 0)
                    {
                        Re_Cat_Index.DataSource = list.Skip(sotin * _page - sotin).Take(sotin);
                        Re_Cat_Index.DataBind();
                    }
                    else
                    {
                        Re_Cat_Index.DataSource = list.Take(sotin);
                        Re_Cat_Index.DataBind();
                    }
                    Page.Visible = true;
                    ltrPage.Text = change.result(list.Count, sotin, _cat_seo_url, _page, 1, 10);
                }
                else
                    Page.Visible = false;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public IQueryable loadnews(object cat_id)
        {
            return index.Load_pro_index_cate(cat_id, 4, 0, 4);
        }
        #endregion
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
        public string GetImageT_Cat(object News_Id, object News_Image1)
        {

            try
            {
                return fun.GetImageT_News_Cat(News_Id, News_Image1);
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
          //<li class="active"><a href="#">1</a></li>
          //<li><a href="#">2</a></li>
          //<li><a href="#">3</a></li>
          //<li><a href="#">4</a></li>
          //<li><a href="#">5</a></li>
        #endregion
    }
}
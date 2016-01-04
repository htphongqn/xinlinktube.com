using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vpro.functions;
using MVC_LinkTuBe.Components;
using Controller;
using System.Data;

namespace MVC_LinkTuBe.UIs
{
    public partial class search_result : System.Web.UI.UserControl
    {
        #region Declare
        Search_result search = new Search_result();
        Function fun = new Function();
        Pageindex_chage change = new Pageindex_chage();
        string _txt = string.Empty;
        int _page = 0;
        int _catid, _catid_child = 0;
        clsFormat fm = new clsFormat();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            _page = Utils.CIntDef(Request.QueryString["page"]);
            _txt = Utils.CStrDef(Request.QueryString["key"]);
            _catid = Utils.CIntDef(Request.QueryString["cat_id"]);
            _catid_child = Utils.CIntDef(Request.QueryString["cat_id_child"]);
            if (!IsPostBack)
            {

                ltl_newtitle.Text = "Tìm kiếm";
                Load_list();
            }
        }
        //public void Load_listBill()
        //{
        //    try
        //    {

        //        if (_code == "")
        //        {
        //            _code = "";
        //        }
        //        else
        //        {
        //            //if (!_txt.Contains("%"))
        //            //    _code = "%" + _code + "%";
        //        }

        //        DataTable dt = _CheckBill.LoadTrackAndTrace("001", "tnt", "24hexpress", _code, "");

        //        GridView1.DataSource = dt;
        //        GridView1.DataBind();

        //    }
        //    catch (Exception ex)
        //    {

        //        clsVproErrorHandler.HandlerError(ex);
        //    }
        //}
        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    Load_listBill();
        //}
        #region Loadsearch
        public void Load_list()
        {
            try
            {
                int _sotin = 12;
                if (!_txt.Contains("%"))
                    _txt = "%" + _txt + "%";
                int _cat_sreach=0;
                if (_catid != 0)
                    _cat_sreach = _catid;
                if (_catid_child != 0)
                    _cat_sreach = _catid_child;
                var _vNews = search.Load_search_result(_txt, 1, _cat_sreach);
                if (_vNews.ToList().Count > 0)
                {
                    if (_page != 0)
                    {
                        Rpproduct.DataSource = _vNews.Skip(_sotin * _page - _sotin).Take(_sotin);
                        Rpproduct.DataBind();
                    }
                    else
                    {
                        Rpproduct.DataSource = _vNews.Take(_sotin);
                        Rpproduct.DataBind();
                    }
                    ltrPage.Text = change.result(_vNews.ToList().Count, _sotin, _txt, _page, 2, 10);
                }


            }
            catch (Exception ex)
            {

                clsVproErrorHandler.HandlerError(ex);
            }
        }
        #endregion
        #region function
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
        #endregion
    }
}
﻿using System;
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
    public partial class list_garrely : System.Web.UI.UserControl
    {
        #region Declare
        List_news lnews = new List_news();
        Function fun = new Function();
        clsFormat fm = new clsFormat();
        Pageindex_chage change = new Pageindex_chage();
        int _Catid = 0;
        string _cat_seo_url = string.Empty;
        int _page = 0;
        int _typecat = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            _Catid = Utils.CIntDef(Session["Cat_id"]);
            _page = Utils.CIntDef(Request.QueryString["page"]);
            _typecat = Utils.CIntDef(Request.QueryString["typecat"]);
            if (!IsPostBack)
            {
                Loadtitle();
                Loadlist();
            }
        }
        public void Loadtitle()
        {
            try
            {
                Lbtitle.Text = lnews.Loadtitle(_Catid);
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
                int sotin = (_typecat == 0 ? lnews.Getsotin(_Catid) : 100);
                var list = lnews.Load_listnews(_Catid);
                if (list.Count > 0)
                {
                    if (_page != 0)
                    {
                        Rplistnews.DataSource = list.Skip(sotin * _page - sotin).Take(sotin);
                        Rplistnews.DataBind();
                    }
                    else
                    {
                        Rplistnews.DataSource = list.Take(sotin);
                        Rplistnews.DataBind();
                    }

                    //ltrPage.Text = change.result(list.Count, sotin, _cat_seo_url, 0, "", _page, 1,2);

                }
                else
                    page.Visible = false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        #region function
        public string GetLink(object News_Url, object News_Seo_Url)
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
        public string getdate(object date)
        {
            return fun.getDate(date);
        }
        #endregion
    }
}
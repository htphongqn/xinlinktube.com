using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vpro.functions;
using MVC_LinkTuBe.Components;
using System.IO;
using Controller;

namespace MVC_LinkTuBe.UIs
{
    public partial class news_details : System.Web.UI.UserControl
    {
        #region Declare

        public clsFormat _clsFormat = new clsFormat();
        News_details ndetail = new News_details();
        Function fun = new Function();
        clsFormat fm = new clsFormat();
        string _sNews_Seo_Url = string.Empty;
        SendMail send = new SendMail();
        Attfile att = new Attfile();
        int _newsID = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string[] cut_sNews_Seo_Url = Utils.CStrDef(Request.QueryString["purl"]).Split('/');
            if (cut_sNews_Seo_Url.Length > 1)
            {
                _sNews_Seo_Url=cut_sNews_Seo_Url[1];
            }
            else
            {
                _sNews_Seo_Url = cut_sNews_Seo_Url[0];
            }
            _newsID = ndetail.getID(_sNews_Seo_Url);
            //hplPrint.HRef = "/in/" + _sNews_Seo_Url + ".html";
            if (!IsPostBack)
            {
                Show_File_HTML();
                Loadattfile();
                gettitle();
                Addsee();
            }
        }
        #region Addsee
        private void Addsee()
        {
            ndetail.Addsee(_sNews_Seo_Url);
        }
        #endregion
        #region Attfile
        public void Loadattfile()
        {
            Re_download.DataSource = att.Load_dsatt_file(_newsID);
            Re_download.DataBind();
        }
        public string BindAttItems(object News_Id, object Ext_Id, object Att_Name, object Att_Url, object Att_File, object Ext_Image)
        {
            return att.BindAttItems(News_Id, Ext_Id, Att_Name, Att_Url, Att_File, Ext_Image);
        }
        #endregion
        #region My Function
        public string FomatDate(object News_publishdate)
        {
            return string.Format("{0:dd/MM/yyyy hh:mm tt}", News_publishdate);
        }
        public void gettitle()
        {
            try
            {
                lbNewsUpdate.Text = ndetail.gettitle(_sNews_Seo_Url).Count > 0 ? FomatDate(ndetail.gettitle(_sNews_Seo_Url)[0].New_update) : "";
                lbNewsTitle.Text = ndetail.gettitle(_sNews_Seo_Url).Count > 0 ? ndetail.gettitle(_sNews_Seo_Url)[0].News_title : "";
            }
            catch (Exception)
            {

                throw;
            }
        }



        //private void Get_ViewMore()
        //{
        //    try
        //    {

        //        hplViewmore.HRef = ndetail.Get_ViewMore(_newsID);
        //    }
        //    catch (Exception ex)
        //    {
        //        clsVproErrorHandler.HandlerError(ex);
        //    }
        //}

        private void Show_File_HTML()
        {
            try
            {

                liHtml.Text = ndetail.Showfilehtm(_newsID);
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }
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
        public string getDate(object News_PublishDate)
        {
            return fun.getDate(News_PublishDate);
        }
        #endregion
    }
}
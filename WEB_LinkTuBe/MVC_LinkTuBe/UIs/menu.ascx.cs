using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vpro.functions;
using Controller;

namespace MVC_LinkTuBe.UIs
{
    public partial class menu : System.Web.UI.UserControl
    {
        #region Declare
        Propertity per = new Propertity();
        Function fun = new Function();
        Config cf = new Config();
        Cart_result cart = new Cart_result();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Menu();
            }
        }
       
        #region Load menu
        protected void Load_Menu()
        {
            try
            {
                Rpmenu.DataSource = per.Loadmenu(1, 100, 1);
                Rpmenu.DataBind();
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }

        }
        protected IQueryable Menu_phu(object cat_parent_id)
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
        #endregion

        #region Function
        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    if (txtsearch.Value.Trim() == string.Empty)
        //        return;
        //    string s = txtsearch.Value;
        //    Response.Redirect("/tim-kiem.html?page=0&key=" + s + "");
        //}
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
      
        public string GetStyleActive(object Cat_Seo_Url, object Cat_Url)
        {
            try
            {
                string _curl = Utils.CStrDef(Request.QueryString["purl"]);
                string _seoUrl = Utils.CStrDef(Request.QueryString["purl"]);
                return per.GetStyleActive(Cat_Seo_Url, Cat_Url);
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vpro.functions;
using Controller;
using System.Data;

namespace MVC_LinkTuBe.UIs
{
    public partial class slider : System.Web.UI.UserControl
    {
        #region Declare
        Propertity per = new Propertity();
        Function fun = new Function();
        int sott = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtsearch.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "')");
                Load_slider();
                Load_youtube();
                Load_Cat_Cap1();
                Load_Cat_Cap2(-1);
            }
        }
        #region Load Cat
        private void Load_Cat_Cap1()
        {
            ddl_cat1.DataValueField = "CAT_ID";
            ddl_cat1.DataTextField = "CAT_NAME";
            ddl_cat1.DataSource = per.Loadmenu_video();
            ddl_cat1.DataBind();
            ListItem l = new ListItem("--- Tất cả ---", "0");
            l.Selected = true;
            ddl_cat1.Items.Insert(0, l);
        }
        private void Load_Cat_Cap2(int id)
        {
            var list = per.Loadmenu_video_2(id);
            if (list.Count > 0)
            {
                ddl_cat2.DataValueField = "CAT_ID";
                ddl_cat2.DataTextField = "CAT_NAME";
                ddl_cat2.DataSource = list;
                ddl_cat2.DataBind();
                ListItem l = new ListItem("--- Tất cả ---", "0");
                l.Selected = true;
                ddl_cat2.Items.Insert(0, l);
            }
            else
            {
                DataTable dt = new DataTable("Newtable");

                dt.Columns.Add(new DataColumn("CAT_ID"));
                dt.Columns.Add(new DataColumn("CAT_NAME"));

                DataRow row = dt.NewRow();
                row["CAT_ID"] = 0;
                row["CAT_NAME"] = "--- Tất cả ---";
                dt.Rows.Add(row);

                ddl_cat2.DataTextField = "CAT_NAME";
                ddl_cat2.DataValueField = "CAT_ID";
                ddl_cat2.DataSource = dt;
                ddl_cat2.DataBind();

            }
        }
        #endregion
        #region Youtube
        private void Load_youtube()
        {
            var list = per.LoadHTTT(6);
            if (list.Count() > 0)
            {
                ltl_yutube.Text = "<a rel='nofollow' href='" + list[0].ONLINE_NICKNAME + "'><img src='/vi-vn/data/dangky.gif' alt='" + list[0].ONLINE_DESC + "' title='" + list[0].ONLINE_DESC + "'></a>";
            }
        }
        #endregion
        #region Slider
        public void Load_slider()
        {
            try
            {
                Rpslider.DataSource = per.Load_slider(0, 100);
                Rpslider.DataBind();
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }
        #endregion
        #region Function
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
        public string GetImageAd(object Ad_Id, object Ad_Image1, object Ad_Target, object Ad_Url)
        {
            try
            {
                return fun.GetImageAd(Ad_Id, Ad_Image1, Ad_Target, Ad_Url);
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }

        }
        #endregion
        #region Event
        protected void ddl_cat1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Utils.CIntDef(ddl_cat1.SelectedValue);
            Load_Cat_Cap2(id);
        }
        protected void btn_search_Click(object sender, EventArgs e)
        {
            string _cat_id = ddl_cat1.SelectedValue;
            string _cat_id_child = ddl_cat2.SelectedValue;
            Response.Redirect("/tim-kiem.html?page=0&key=" + txtsearch.Value + "&cat_id=" + _cat_id + "&cat_id_child=" + _cat_id_child);
        }
        #endregion       
    }
}
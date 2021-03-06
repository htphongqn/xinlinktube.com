﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vpro.functions;

using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;

namespace vpro.eshop.cpanel.page
{
    public partial class aditem : System.Web.UI.Page
    {
        #region Declare

        private int m_ad_id = 0;
        int _count = 0;
        eshopdbDataContext DB = new eshopdbDataContext();

        #endregion

        #region form event

        protected void Page_Load(object sender, EventArgs e)
        {
            m_ad_id = Utils.CIntDef(Request["ad_id"]);
            Hyperback.NavigateUrl = "aditem_list.aspx";
            if (m_ad_id == 0)
            {
                //dvDelete.Visible = false;
                trFile.Visible = false;
            }

            if (!IsPostBack)
            {
               
                getInfo();
                LoadCat();
            }

        }

        #endregion

        #region Button Events

        protected void lbtSave_Click(object sender, EventArgs e)
        {
            SaveInfo();
        }

        protected void lbtSaveNew_Click(object sender, EventArgs e)
        {
            SaveInfo("aditem.aspx");
        }
        protected void LbsaveClose_Click(object sender, EventArgs e)
        {
            SaveInfo("aditem_list.aspx");
        }
        protected void lbtDelete_Click(object sender, EventArgs e)
        {
            DeleteInfo(m_ad_id);
        }

        protected void btnDelete1_Click(object sender, ImageClickEventArgs e)
        {
            string strLink = "";
            try
            {
                var n_info = DB.GetTable<ESHOP_AD_ITEM>().Where(n => n.AD_ITEM_ID == m_ad_id).ToList();

                if (n_info.Count > 0)
                {
                    if (!string.IsNullOrEmpty(n_info[0].AD_ITEM_FILENAME))
                    {
                        string imagePath = Server.MapPath(PathFiles.GetPathAdItems(m_ad_id) + n_info[0].AD_ITEM_FILENAME);
                        n_info[0].AD_ITEM_FILENAME = "";
                        DB.SubmitChanges();

                        if (File.Exists(imagePath))
                            File.Delete(imagePath);

                        strLink = "aditem.aspx?ad_id=" + m_ad_id;
                    }
                }
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
            finally
            {
                if (!string.IsNullOrEmpty(strLink))
                    Response.Redirect(strLink);
            }
        }

        #endregion

        #region My Functions

        public string getOrder()
        {
            _count = _count + 1;
            return _count.ToString();
        }

        private void getInfo()
        {
            try
            {
                Components.CpanelUtils.createItemLanguage(ref rblLanguage);
                Components.CpanelUtils.createItemAdPos(ref rblAdPos);
                Components.CpanelUtils.createItemTarget(ref ddlTarget);

                var G_info = (from g in DB.ESHOP_AD_ITEMs
                              where g.AD_ITEM_ID == m_ad_id
                              select g
                            ).ToList();

                if (G_info.Count > 0)
                {
                    txtCode.Value = G_info[0].AD_ITEM_CODE;
                    txtDesc.Value = G_info[0].AD_ITEM_DESC;
                    txtDesc1.Value = G_info[0].AD_ITEM_FIELD1;
                    txtUrl.Value = G_info[0].AD_ITEM_URL;
                    ddlTarget.SelectedValue = G_info[0].AD_ITEM_TARGET;
                    rblBannerType.SelectedValue = Utils.CStrDef(G_info[0].AD_ITEM_TYPE);
                    rblAdPos.SelectedValue = Utils.CStrDef(G_info[0].AD_ITEM_POSITION);
                    txtWidth.Value = Utils.CStrDef(G_info[0].AD_ITEM_WIDTH);
                    txtHeight.Value = Utils.CStrDef(G_info[0].AD_ITEM_HEIGHT);
                    txtOrder.Value = Utils.CStrDef(G_info[0].AD_ITEM_ORDER);
                    ucFromDate.returnDate = Utils.CDateDef(G_info[0].AD_ITEM_DATEFROM, DateTime.Now);
                    ucToDate.returnDate = Utils.CDateDef(G_info[0].AD_ITEM_DATETO, DateTime.Now.Add(new TimeSpan(365, 0, 0, 0)));
                    rblLanguage.SelectedValue = Utils.CStrDef(G_info[0].AD_ITEM_LANGUAGE);
                    lblCount.Text = Utils.CStrDef(G_info[0].AD_ITEM_CLICKCOUNT);

                    //image
                    if (!string.IsNullOrEmpty(G_info[0].AD_ITEM_FILENAME))
                    {
                        trUpload.Visible = false;
                        trFile.Visible = true;
                        hplFile.NavigateUrl = PathFiles.GetPathAdItems(m_ad_id) + G_info[0].AD_ITEM_FILENAME;
                        hplFile.Text = G_info[0].AD_ITEM_FILENAME;

                        if (G_info[0].AD_ITEM_TYPE == 0)
                        {
                            ltrImage.Text = "<img src='" + PathFiles.GetPathAdItems(m_ad_id) + G_info[0].AD_ITEM_FILENAME + "'  border='0'>";
                        }
                        else
                        {
                            ltrImage.Text += "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0' width='" + Utils.CStrDef(G_info[0].AD_ITEM_WIDTH) + "' height='" + Utils.CStrDef(G_info[0].AD_ITEM_HEIGHT) + "' id='ShockwaveFlash1' >";
                            ltrImage.Text += "<param name='movie' value='" + PathFiles.GetPathAdItems(m_ad_id) + G_info[0].AD_ITEM_FILENAME + "'>";
                            ltrImage.Text += "<param name='Menu' value='0'>";
                            ltrImage.Text += "<param name='quality' value='high'>";
                            ltrImage.Text += "<param name='wmode' value='transparent'>";
                            ltrImage.Text += "<embed width='" + Utils.CStrDef(G_info[0].AD_ITEM_WIDTH) + "' height='" + Utils.CStrDef(G_info[0].AD_ITEM_HEIGHT) + "' src='" + PathFiles.GetPathAdItems(m_ad_id) + G_info[0].AD_ITEM_FILENAME + "' wmode='transparent' ></object>";
                        }
                    }
                    else
                    {
                        trUpload.Visible = true;
                        trFile.Visible = false;
                    }
                }
                else
                {
                    trUpload.Visible = true;
                    trFile.Visible = false;

                    ucFromDate.returnDate = DateTime.Now;
                    ucToDate.returnDate = DateTime.Now.Add(new TimeSpan(365, 0, 0, 0));
                }
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }

        private void SaveInfo(string strLink = "")
        {
            try
            {

                //get image
                string Banner_File;

                if (trUpload.Visible == true)
                {
                    if (fileImage1.PostedFile != null)
                    {
                        Banner_File = Path.GetFileName(fileImage1.PostedFile.FileName);
                    }
                    else
                    {
                        Banner_File = "";
                    }
                }
                else
                {
                    Banner_File = hplFile.Text;
                }

                if (m_ad_id == 0)
                {
                    //insert
                    ESHOP_AD_ITEM g_insert = new ESHOP_AD_ITEM();

                    g_insert.AD_ITEM_CODE = txtCode.Value;
                    g_insert.AD_ITEM_DESC = txtDesc.Value;
                    g_insert.AD_ITEM_URL = txtUrl.Value;
                    g_insert.AD_ITEM_TARGET = ddlTarget.SelectedValue;
                    g_insert.AD_ITEM_TYPE = Utils.CIntDef(rblBannerType.SelectedValue);
                    g_insert.AD_ITEM_POSITION = Utils.CIntDef(rblAdPos.SelectedValue);
                    g_insert.AD_ITEM_WIDTH = Utils.CIntDef(txtWidth.Value);
                    g_insert.AD_ITEM_HEIGHT = Utils.CIntDef(txtHeight.Value);
                    g_insert.AD_ITEM_ORDER = Utils.CIntDef(txtOrder.Value);
                    g_insert.AD_ITEM_DATEFROM = ucFromDate.returnDate;
                    g_insert.AD_ITEM_DATETO = ucToDate.returnDate;
                    g_insert.AD_ITEM_LANGUAGE = Utils.CIntDef(rblLanguage.SelectedValue);
                    g_insert.AD_ITEM_FILENAME = Banner_File;
                    g_insert.AD_ITEM_FIELD1 = txtDesc1.Value;
                    //g_insert.AD_ITEM_FIELD1 = Utils.CStrDef(txtClip.Value);
                    DB.ESHOP_AD_ITEMs.InsertOnSubmit(g_insert);

                    DB.SubmitChanges();

                    //get new id
                    var _new = DB.GetTable<ESHOP_AD_ITEM>().OrderByDescending(g => g.AD_ITEM_ID).Take(1);

                    m_ad_id = _new.Single().AD_ITEM_ID;

                    SaveAdItemsCat(m_ad_id);

                    DB.SubmitChanges();

                    strLink = string.IsNullOrEmpty(strLink) ? "aditem.aspx?ad_id="+m_ad_id+"" : strLink;
                }
                else
                {
                    //update
                    var g_update = DB.GetTable<ESHOP_AD_ITEM>().Where(g => g.AD_ITEM_ID == m_ad_id).ToList();

                    if (g_update.Count > 0)
                    {
                        g_update.Single().AD_ITEM_CODE = txtCode.Value;
                        g_update.Single().AD_ITEM_DESC = txtDesc.Value;
                        g_update.Single().AD_ITEM_URL = txtUrl.Value;
                        g_update.Single().AD_ITEM_TARGET = ddlTarget.SelectedValue;
                        g_update.Single().AD_ITEM_TYPE = Utils.CIntDef(rblBannerType.SelectedValue);
                        g_update.Single().AD_ITEM_POSITION = Utils.CIntDef(rblAdPos.SelectedValue);
                        g_update.Single().AD_ITEM_WIDTH = Utils.CIntDef(txtWidth.Value);
                        g_update.Single().AD_ITEM_HEIGHT = Utils.CIntDef(txtHeight.Value);
                        g_update.Single().AD_ITEM_ORDER = Utils.CIntDef(txtOrder.Value);
                        g_update.Single().AD_ITEM_DATEFROM = ucFromDate.returnDate;
                        g_update.Single().AD_ITEM_DATETO = ucToDate.returnDate;
                        g_update.Single().AD_ITEM_LANGUAGE = Utils.CIntDef(rblLanguage.SelectedValue);
                        g_update.Single().AD_ITEM_FILENAME = Banner_File;
                        g_update.Single().AD_ITEM_FIELD1 = txtDesc1.Value;
                        SaveAdItemsCat(g_update.Single().AD_ITEM_ID);
                        DB.SubmitChanges();
                        strLink = string.IsNullOrEmpty(strLink) ? "aditem.aspx?ad_id=" + m_ad_id + "" : strLink;
                    }
                }

                //update images
                if (trUpload.Visible)
                {
                    if (!string.IsNullOrEmpty(fileImage1.PostedFile.FileName))
                    {
                        string pathfile = Server.MapPath("/data/aditems/" + m_ad_id);
                        string fullpathfile = pathfile + "/" + Banner_File;

                        if (!Directory.Exists(pathfile))
                        {
                            Directory.CreateDirectory(pathfile);
                        }

                        fileImage1.PostedFile.SaveAs(fullpathfile);
                    }
                }
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
            finally
            {
                if (!string.IsNullOrEmpty(strLink))
                { Response.Redirect(strLink); }
            }
        }

        private void DeleteInfo(int ad_id)
        {
            string strLink = "";
            try
            {
                string Banner_File = "";

                var G_info = DB.GetTable<ESHOP_AD_ITEM>().Where(g => g.AD_ITEM_ID == ad_id).ToList();

                if (G_info.Count > 0)
                    Banner_File = Utils.CStrDef(G_info[0].AD_ITEM_FILENAME);

                DB.ESHOP_AD_ITEMs.DeleteAllOnSubmit(G_info);
                DB.SubmitChanges();

                //delete file
                if (!string.IsNullOrEmpty(Banner_File))
                {
                    string fullpath = Server.MapPath(PathFiles.GetPathAdItems(ad_id) + Banner_File);

                    if (File.Exists(fullpath))
                    {
                        File.Delete(fullpath);
                    }
                }

                strLink = "aditem_list.aspx";

            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
            finally
            {
                if (!string.IsNullOrEmpty(strLink))
                    Response.Redirect(strLink);
            }

        }

        private void LoadCat()
        {
            try
            {
                var AllList = (from g in DB.ESHOP_CATEGORies
                               where g.CAT_RANK > 0
                               select g).ToList();

                if (AllList.Count > 0)
                {
                    DataRelation relCat;
                    //Session["CatList"] = DataUtil.LINQToDataTable(AllList);
                    //DataTable tbl = Session["CatList"] as DataTable;
                    DataTable tbl = DataUtil.LINQToDataTable(AllList);

                    DataSet ds = new DataSet();
                    ds.Tables.Add(tbl);

                    tbl.PrimaryKey = new DataColumn[] { tbl.Columns["CAT_ID"] };
                    relCat = new DataRelation("Category_parent", ds.Tables[0].Columns["CAT_ID"], ds.Tables[0].Columns["CAT_PARENT_ID"], false);

                    ds.Relations.Add(relCat);
                    DataSet dsCat = ds.Clone();
                    DataTable CatTable = ds.Tables[0];

                    DataUtil.TransformTableWithSpace(ref CatTable, dsCat.Tables[0], relCat, null);
                    Rplistcate.DataSource = dsCat.Tables[0];
                    Rplistcate.DataBind();
                }


                //var allCat=DB.GetTable<ESHOP_CATEGORy>();

                //GridItemList.DataSource = allCat;
                //GridItemList.DataBind();

                //Session["CatGroupList"] = allCat;
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }

        public bool CheckCat(object CatId)
        {
            try
            {
                int Per_Id = Utils.CIntDef(CatId);

                var per = DB.GetTable<ESHOP_AD_ITEM_CAT>().Where(gp => gp.AD_ITEM_ID == m_ad_id && gp.CAT_ID == Per_Id).ToList();
                if (per.Count > 0)
                    return true;
                else
                    if (m_ad_id == 0)
                        return true;

                return false;
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return false;
            }
        }

        private void SaveAdItemsCat(int AdItem_Id)
        {
            try
            {
                
                
                var gcdel = (from gp in DB.ESHOP_AD_ITEM_CATs
                             where gp.AD_ITEM_ID == AdItem_Id
                             select gp);

                DB.ESHOP_AD_ITEM_CATs.DeleteAllOnSubmit(gcdel);
                for (int i = 0; i < Rplistcate.Items.Count; i++)
                {
                    HtmlInputCheckBox check = new HtmlInputCheckBox();
                    check = (HtmlInputCheckBox)Rplistcate.Items[i].FindControl("chkSelect");
                    HiddenField Hdid = Rplistcate.Items[i].FindControl("Hdcatid") as HiddenField;
                    int _catid = Utils.CIntDef(Hdid.Value);
                    if (check.Checked)
                    {
                        ESHOP_AD_ITEM_CAT grinsert = new ESHOP_AD_ITEM_CAT();
                        grinsert.CAT_ID = _catid;
                        grinsert.AD_ITEM_ID = AdItem_Id;
                        DB.ESHOP_AD_ITEM_CATs.InsertOnSubmit(grinsert);
                    }
                }

               

            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }

        #endregion

        
    }
}
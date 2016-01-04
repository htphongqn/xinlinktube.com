using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vpro.functions;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

namespace vpro.eshop.cpanel.page
{
    public partial class news : System.Web.UI.Page
    {
        #region Declare

        private int m_news_id = 0;
        int _type = 0;
        eshopdbDataContext DB = new eshopdbDataContext();
        int _gtype, _gid;
        #endregion

        #region form event

        protected void Page_Load(object sender, EventArgs e)
        {
            _gid = Utils.CIntDef(Session["GROUP_ID"]);
            _gtype = Utils.CIntDef(Session["GROUP_TYPE"]);
            m_news_id = Utils.CIntDef(Request["news_id"]);
            _type = Utils.CIntDef(Request["type"]);
            Hyperback.NavigateUrl = "news_list.aspx?type=" + _type;
            if (_type != 1)
            {
                div_productinfo.Visible = false;
            }
            else
            {
                div_productinfo.Visible = true;
            }
            if (m_news_id == 0)
            {
                trNewsFunction.Visible = false;
                trImage3.Visible = false;
            }
            else
            {
                hplCatNews.HRef = "news_category.aspx?type=" + _type + "&news_id=" + m_news_id;
                hplEditorHTMl.HRef = "news_editor.aspx?type=" + _type + "&news_id=" + m_news_id;
                hplNewsAtt.HRef = "news_attachment.aspx?type=" + _type + "&news_id=" + m_news_id;
                hplAlbum.HRef = "news_images.aspx?type=" + _type + "&news_id=" + m_news_id;         
                hplComment.HRef = "news_comment.aspx?type=" + _type + "&news_id=" + m_news_id;
            }

            if (!IsPostBack)
            {
                Load_kenh();
                getInfo();
                LoadCategoryParent();
            }
        }

        #endregion
        #region Button Events

        protected void lbtSave_Click(object sender, EventArgs e)
        {
            string news_seo_url = txtSeoUrl.Value.Trim();
            if (CheckExitsLink(news_seo_url) || CheckExitsLink_Cats(news_seo_url))
            {
                txtSeoUrl.Value = txtSeoUrl.Value + "-" + "N" + loadmaxnewsid();
                SaveInfo();
            }
            else
                SaveInfo();
        }

        protected void lbtSaveNew_Click(object sender, EventArgs e)
        {
            string news_seo_url = txtSeoUrl.Value.Trim();
            if (CheckExitsLink(news_seo_url) || CheckExitsLink_Cats(news_seo_url))
            {
                txtSeoUrl.Value = txtSeoUrl.Value + "-" + "N" + loadmaxnewsid();
                SaveInfo("news.aspx?type=" + _type);
            }
            else
                SaveInfo("news.aspx?type=" + _type);
        }
        protected void LbsaveClose_Click(object sender, EventArgs e)
        {
            string news_seo_url = txtSeoUrl.Value.Trim();
            if (CheckExitsLink(news_seo_url) || CheckExitsLink_Cats(news_seo_url))
            {
                txtSeoUrl.Value = txtSeoUrl.Value + "-" + "N" + loadmaxnewsid();
                SaveInfo("news_list.aspx?type=" + _type);
            }
            else
                SaveInfo("news_list.aspx?type=" + _type);
        }
        protected void lbtDelete_Click(object sender, EventArgs e)
        {
            DeleteInfo();
        }

        protected void btnDelete1_Click(object sender, ImageClickEventArgs e)
        {
            string strLink = "";
            try
            {
                var n_info = DB.GetTable<ESHOP_NEW>().Where(n => n.NEWS_ID == m_news_id);

                if (n_info.ToList().Count > 0)
                {
                    if (!string.IsNullOrEmpty(n_info.ToList()[0].NEWS_IMAGE1))
                    {
                        string imagePath = Server.MapPath(PathFiles.GetPathNews(m_news_id) + n_info.ToList()[0].NEWS_IMAGE1);
                        n_info.ToList()[0].NEWS_IMAGE1 = "";
                        DB.SubmitChanges();

                        if (File.Exists(imagePath))
                            File.Delete(imagePath);

                        strLink = "news.aspx?type=" + _type + "&news_id=" + m_news_id;
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

        #region My functions


        private List<string> getCatid()
        {
            List<string> l = new List<string>();
            var list = DB.ESHOP_GROUP_CATs.Where(n => n.GROUP_ID == _gid).ToList();
            foreach (var i in list)
            {
                l.Add(Utils.CStrDef(i.CAT_ID));
            }
            return l;
        }
        private void Load_kenh()
        {
            var list = DB.ESHOP_CATEGORies.Where(n => n.CAT_RANK == 2 && n.CAT_TYPE == 2).OrderByDescending(n => n.CAT_ORDER).ToList();
            ddl_kenh.DataValueField = "CAT_ID";
            ddl_kenh.DataTextField = "CAT_NAME";
            ddl_kenh.DataSource = list;
            ddl_kenh.DataBind();
            ListItem l = new ListItem("--- Chọn kênh ---", "0");
            l.Selected = true;
            ddl_kenh.Items.Insert(0, l);
        }
        private void LoadCategoryParent()
        {
            try
            {
                var CatList = (from t2 in DB.ESHOP_CATEGORies
                               where t2.CAT_RANK > 0 && (t2.CAT_TYPE == _type)

                                 && (_gtype != 1 ? (getCatid().Contains(t2.CAT_ID.ToString()) || getCatid().Contains(t2.CAT_PARENT_ID.ToString())) : true)
                               select new
                               {
                                   CAT_ID = t2.CAT_NAME == "------- Root -------" ? 0 : t2.CAT_ID,
                                   CAT_NAME = (string.IsNullOrEmpty(t2.CAT_CODE) ? t2.CAT_NAME : t2.CAT_NAME + "(" + t2.CAT_CODE + ")"),
                                   CAT_NAME_EN = (string.IsNullOrEmpty(t2.CAT_CODE_EN) ? t2.CAT_NAME_EN : t2.CAT_NAME_EN + "(" + t2.CAT_CODE_EN + ")"),
                                   CAT_PARENT_ID = t2.CAT_PARENT_ID,
                                   CAT_RANK = t2.CAT_RANK
                               }
                            );
                if (CatList.ToList().Count > 0)
                {
                    DataRelation relCat;
                    DataTable tbl = DataUtil.LINQToDataTable(CatList);
                    DataSet ds = new DataSet();
                    ds.Tables.Add(tbl);

                    tbl.PrimaryKey = new DataColumn[] { tbl.Columns["CAT_ID"] };
                    relCat = new DataRelation("Category_parent", ds.Tables[0].Columns["CAT_ID"], ds.Tables[0].Columns["CAT_PARENT_ID"], false);

                    ds.Relations.Add(relCat);
                    DataSet dsCat = ds.Clone();
                    DataTable CatTable = ds.Tables[0];

                    DataUtil.TransformTableWithSpace(ref CatTable, dsCat.Tables[0], relCat, null);
                 
                    ddlCategory.DataSource = dsCat.Tables[0];
                    ddlCategory.DataTextField = "CAT_NAME";
                    ddlCategory.DataValueField = "CAT_ID";
                    ddlCategory.DataBind();

                }
                else
                {
                    DataTable dt = new DataTable("Newtable");

                    dt.Columns.Add(new DataColumn("CAT_ID"));
                    dt.Columns.Add(new DataColumn("CAT_NAME"));
                    dt.Columns.Add(new DataColumn("CAT_NAME_EN"));

                    DataRow row = dt.NewRow();
                    row["CAT_ID"] = 0;
                    row["CAT_NAME"] = "--------Root--------";
                    row["CAT_NAME_EN"] = "--------Root--------";
                    dt.Rows.Add(row);

                    ddlCategory.DataTextField = "CAT_NAME";
                    ddlCategory.DataValueField = "CAT_ID";
                    ddlCategory.DataSource = dt;
                    ddlCategory.DataBind();
                }

            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }
        //private void Loadhangsx()
        //{
        //    var list = DB.ESHOP_CATEGORies.Where(n => n.CAT_TYPE == 2 && n.CAT_RANK == 2);
        //    Drhangsx.DataValueField = "CAT_ID";
        //    Drhangsx.DataTextField = "CAT_NAME";
        //    Drhangsx.DataSource = list;
        //    Drhangsx.DataBind();
        //    ListItem l = new ListItem("--- Chọn hãng sản xuất ---", "0");
        //    l.Selected = true;
        //    Drhangsx.Items.Insert(0, l);
        //}
        //private void LoadUnits()
        //{
        //    try
        //    {
        //        var units = DB.GetTable<ESHOP_UNIT>();

        //        ddlUnit1.DataSource = units;
        //        ddlUnit1.DataTextField = "UNIT_NAME";
        //        ddlUnit1.DataValueField = "UNIT_ID";
        //        ddlUnit1.DataBind();

        //        ddlUnit2.DataSource = units;
        //        ddlUnit2.DataTextField = "UNIT_NAME";
        //        ddlUnit2.DataValueField = "UNIT_ID";
        //        ddlUnit2.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        clsVproErrorHandler.HandlerError(ex);
        //    }
        //}
        private bool Kiemtra_catindex(int _cat_id)
        {
            try
            {
                var list = (from a in DB.ESHOP_CATEGORies
                            where a.CAT_ID == _cat_id && a.CAT_PERIOD == 1
                            select a).ToList();
                if (list.Count() > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        private void getInfo()
        {
            try
            {
                //LoadUnits();
                Components.CpanelUtils.createItemTarget(ref ddlTarget);

                var G_info = (from n in DB.ESHOP_NEWs
                              join c in DB.ESHOP_NEWS_CATs on n.NEWS_ID equals c.NEWS_ID into t2_join
                              from c in t2_join.DefaultIfEmpty()
                              where n.NEWS_ID == m_news_id
                              select new
                              {
                                  n,
                                  c.CAT_ID
                              }
                            ).ToList();

                if (G_info.Count > 0)
                {
                    trCat.Visible = false;
                    if (Kiemtra_catindex(Utils.CIntDef(G_info[0].CAT_ID)) == true)
                    {
                        div_noibat.Visible = true;
                    }
                    else
                        div_noibat.Visible = false;
                    txtTitle.Value = G_info[0].n.NEWS_TITLE;
                    rblNoiBat.SelectedValue = G_info[0].n.NEWS_FIELD1;
                    txtVideo.Value = G_info[0].n.NEWS_VIDEO_URL;
                    ddl_kenh.SelectedValue = G_info[0].n.NEWS_FIELD4;
                    txtDesc.Value = G_info[0].n.NEWS_DESC;
                    txtUrl.Value = G_info[0].n.NEWS_URL;
                    ddlTarget.SelectedValue = G_info[0].n.NEWS_TARGET;
                    rblStatus.SelectedValue = Utils.CStrDef(G_info[0].n.NEWS_SHOWTYPE);            
                    rblFeefback.SelectedValue = Utils.CStrDef(G_info[0].n.NEWS_FEEDBACKTYPE);
                    txtOrder.Value = Utils.CStrDef(G_info[0].n.NEWS_ORDER, "1");
                    txtOrderPeriod.Value = Utils.CStrDef(G_info[0].n.NEWS_ORDER_PERIOD, "1");
                    txtSeoTitle.Value = Utils.CStrDef(G_info[0].n.NEWS_SEO_TITLE);
                    txtSeoKeyword.Value = Utils.CStrDef(G_info[0].n.NEWS_SEO_KEYWORD);
                    txtSeoDescription.Value = Utils.CStrDef(G_info[0].n.NEWS_SEO_DESC);
                    txtSeoUrl.Value = Utils.CStrDef(G_info[0].n.NEWS_SEO_URL);
                    if (!string.IsNullOrEmpty(G_info[0].n.NEWS_IMAGE3))
                    {
                        trUploadImage3.Visible = false;
                        trImage3.Visible = true;
                        Image3.Src = PathFiles.GetPathNews(m_news_id) + G_info[0].n.NEWS_IMAGE3;
                        hplImage3.NavigateUrl = PathFiles.GetPathNews(m_news_id) + G_info[0].n.NEWS_IMAGE3;
                        hplImage3.Text = G_info[0].n.NEWS_IMAGE3;
                    }
                    else
                    {
                        trUploadImage3.Visible = true;
                        trImage3.Visible = false;
                    }

                }
                else
                {
                    if (Kiemtra_catindex(Utils.CIntDef(ddlCategory.SelectedValue)) == true)
                    {
                        div_noibat.Visible = true;
                    }
                    else
                        div_noibat.Visible = false;
                    trUploadImage3.Visible = true;
                    trImage3.Visible = false;
                    LoadCategoryParent();
                    trCat.Visible = true;
                }

            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }
        private int getlangbycatid(int cat_id)
        {
            try
            {
                var list = DB.ESHOP_CATEGORies.Where(n => n.CAT_ID == cat_id).ToList();
                if (list.Count() > 0)
                {
                    return Utils.CIntDef(list[0].CAT_LANGUAGE);
                }
                return 1;
            }
            catch
            {
                return 1;
            }
        }
        private int Get_New_Lang(int CAT_ID)
        {
            try
            {
                var list = DB.ESHOP_CATEGORies.Where(n => n.CAT_ID == CAT_ID).ToList();
                if (list.Count() > 0)
                    return Utils.CIntDef(list[0].CAT_LANGUAGE);
                return 1;
            }
            catch
            {
                return 1;
            }
        }
        private void SaveInfo(string strLink = "")
        {
            try
            {
                int _CATID = Utils.CIntDef(ddlCategory.SelectedValue);
                string News_Image3;

                if (trUploadImage3.Visible == true)
                {
                    if (fileImage3.PostedFile != null)
                    {
                        News_Image3 = Path.GetFileName(fileImage3.PostedFile.FileName);
                    }
                    else
                    {
                        News_Image3 = "";
                    }
                }
                else
                {
                    News_Image3 = hplImage3.Text;
                }
                if (CheckError())
                {
                    if (m_news_id == 0)
                    {

                        //insert
                        ESHOP_NEW news_insert = new ESHOP_NEW();
                        news_insert.NEWS_TITLE = txtTitle.Value;
                        news_insert.NEWS_VIDEO_URL = txtVideo.Value;
                        news_insert.NEWS_COUNT = 1;
                        news_insert.NEWS_FIELD1 = rblNoiBat.SelectedValue;
                        news_insert.UNIT_ID1 = 0;
                        news_insert.NEWS_LANGUAGE = getlangbycatid(_CATID);
                        news_insert.NEWS_DESC = txtDesc.Value;
                        news_insert.NEWS_URL = txtUrl.Value;
                        news_insert.NEWS_TARGET = ddlTarget.SelectedValue;
                        news_insert.NEWS_SEO_URL = txtSeoUrl.Value;
                        news_insert.NEWS_SEO_TITLE = txtSeoTitle.Value;
                        news_insert.NEWS_SEO_KEYWORD = txtSeoKeyword.Value;
                        news_insert.NEWS_SEO_DESC = txtSeoDescription.Value;
                        news_insert.NEWS_TYPE = _type;
                        news_insert.NEWS_SHOWTYPE = Utils.CIntDef(rblStatus.SelectedValue);
                        //news_insert.NEWS_SHOWINDETAIL = Utils.CIntDef(rblShowDetail.SelectedValue);
                        news_insert.NEWS_FEEDBACKTYPE = Utils.CIntDef(rblFeefback.SelectedValue);
                        //news_insert.NEWS_COUNT = Utils.CIntDef(txtCount.Value);
                        news_insert.NEWS_ORDER = Utils.CIntDef(txtOrder.Value);
                        news_insert.NEWS_ORDER_PERIOD = Utils.CIntDef(txtOrderPeriod.Value);
                        news_insert.NEWS_IMAGE3 = News_Image3;
                        news_insert.USER_ID = Utils.CIntDef(Session["USER_ID"]);
                        news_insert.NEWS_PUBLISHDATE = DateTime.Now;
                        news_insert.NEWS_FIELD4 = ddl_kenh.SelectedValue;
                        DB.ESHOP_NEWs.InsertOnSubmit(news_insert);
                        DB.SubmitChanges();
                        //update cat news
                        var _new = DB.GetTable<ESHOP_NEW>().OrderByDescending(g => g.NEWS_ID).Take(1);
                        m_news_id = _new.Single().NEWS_ID;
                        SaveNewsCategory(_new.Single().NEWS_ID);
                        strLink = string.IsNullOrEmpty(strLink) ? "news.aspx?type=" + _type + "&news_id=" + m_news_id : strLink;
                    }
                    else
                    {
                        //update
                        var c_update = DB.GetTable<ESHOP_NEW>().Where(g => g.NEWS_ID == m_news_id).ToList();
                        if (c_update.ToList().Count > 0)
                        {
                            c_update[0].NEWS_UPDATE = DateTime.Now;
                            c_update[0].NEWS_TITLE = txtTitle.Value;
                            c_update[0].NEWS_VIDEO_URL = txtVideo.Value;
                            c_update[0].NEWS_FIELD1 = rblNoiBat.SelectedValue;
                            c_update[0].NEWS_LANGUAGE = getlangbycatid(_CATID);
                            c_update[0].NEWS_DESC = txtDesc.Value;
                            c_update[0].NEWS_URL = txtUrl.Value;
                            c_update[0].NEWS_TARGET = ddlTarget.SelectedValue;
                            c_update[0].NEWS_SEO_URL = txtSeoUrl.Value;
                            c_update[0].NEWS_SEO_TITLE = txtSeoTitle.Value;
                            c_update[0].NEWS_SEO_KEYWORD = txtSeoKeyword.Value;
                            c_update[0].NEWS_SEO_DESC = txtSeoDescription.Value;
                            c_update[0].NEWS_TYPE = _type;
                            c_update[0].NEWS_SHOWTYPE = Utils.CIntDef(rblStatus.SelectedValue);
                            //c_update.ToList()[0].NEWS_SHOWINDETAIL = Utils.CIntDef(rblShowDetail.SelectedValue);
                            c_update[0].NEWS_FEEDBACKTYPE = Utils.CIntDef(rblFeefback.SelectedValue);
                            //c_update.ToList()[0].NEWS_COUNT = Utils.CIntDef(txtCount.Value);
                            c_update[0].NEWS_ORDER = Utils.CIntDef(txtOrder.Value);
                            c_update[0].NEWS_ORDER_PERIOD = Utils.CIntDef(txtOrderPeriod.Value);
                            c_update[0].NEWS_IMAGE3 = News_Image3;
                            DB.SubmitChanges();
                            strLink = string.IsNullOrEmpty(strLink) ? "news_list.aspx?type=" + _type + "" : strLink;
                        }
                    }
                    if (trUploadImage3.Visible)
                    {
                        if (!string.IsNullOrEmpty(fileImage3.PostedFile.FileName))
                        {
                            string pathfile = Server.MapPath("/data/news/" + m_news_id);
                            string fullpathfile = pathfile + "/" + News_Image3;

                            if (!Directory.Exists(pathfile))
                            {
                                Directory.CreateDirectory(pathfile);
                            }

                            fileImage3.PostedFile.SaveAs(fullpathfile);
                        }

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

        private void DeleteInfo()
        {
            string strLink = "";
            try
            {
                var G_info = DB.GetTable<ESHOP_NEW>().Where(g => g.NEWS_ID == m_news_id);

                DB.ESHOP_NEWs.DeleteAllOnSubmit(G_info);
                DB.SubmitChanges();

                //delete folder
                string fullpath = Server.MapPath(PathFiles.GetPathNews(m_news_id));
                if (Directory.Exists(fullpath))
                {
                    DeleteAllFilesInFolder(fullpath);
                    Directory.Delete(fullpath);
                }

                strLink = "news_list.aspx?type=" + _type;

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

        private void DeleteAllFilesInFolder(string folderpath)
        {
            foreach (var f in System.IO.Directory.GetFiles(folderpath))
                System.IO.File.Delete(f);
        }

        public string getLink(object GroupId)
        {
            return "news.aspx?type=" + _type + "&news_id=" + Utils.CStrDef(GroupId);
        }
        private bool CheckExitsLink_Cats(string strLink)
        {
            try
            {
                var exits = (from c in DB.ESHOP_CATEGORies where c.CAT_SEO_URL == strLink select c);

                if (exits.ToList().Count > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return false;

            }

        }
        private int loadmaxnewsid()
        {
            try
            {
                var exits = (from c in DB.ESHOP_NEWs select c).OrderByDescending(n=>n.NEWS_ID).ToList();

                if (exits.Count() > 0)
                    return Utils.CIntDef(exits[0].NEWS_ID) + 1;

                return 0;
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return 0;

            }
        }
        private bool CheckExitsLink(string strLink)
        {
            try
            {
                var exits = (from c in DB.ESHOP_NEWs where c.NEWS_SEO_URL == strLink && c.NEWS_ID != m_news_id select c);

                if (exits.ToList().Count > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return false;

            }

        }

        private bool CheckError()
        {
            //if (string.IsNullOrEmpty(txtStatus.Value))
            //{
            //    lblError.Text = "Tình trạng sản phẩm không được rỗng!";
            //    return false;
            //}
            //else if (string.IsNullOrEmpty(txtOrigin.Value))
            //{
            //    lblError.Text = "Nhà nhập khẩu sản phẩm không được rỗng!";
            //    return false;
            //}
            //else if (string.IsNullOrEmpty(txtManufacture.Value))
            //{
            //    lblError.Text = "Nhà sản xuất không được rỗng!";
            //    return false;
            //}
            //else if (string.IsNullOrEmpty(txtWeight.Value))
            //{
            //    lblError.Text = "Trọng lượng sản phẩm không được rỗng!";
            //    return false;
            //}
            return true;
        }

        private void SaveNewsCategory(int NewsId)
        {
            try
            {
                ESHOP_NEWS_CAT nc = new ESHOP_NEWS_CAT();
                nc.CAT_ID = Utils.CIntDef(ddlCategory.SelectedValue);
                nc.NEWS_ID = NewsId;

                DB.ESHOP_NEWS_CATs.InsertOnSubmit(nc);
                DB.SubmitChanges();
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }

        #endregion

        protected void btnDelete2_Click(object sender, ImageClickEventArgs e)
        {
            string strLink = "";
            try
            {
                var n_info = DB.GetTable<ESHOP_NEW>().Where(n => n.NEWS_ID == m_news_id);

                if (n_info.ToList().Count > 0)
                {
                    if (!string.IsNullOrEmpty(n_info.ToList()[0].NEWS_IMAGE2))
                    {
                        string imagePath = Server.MapPath(PathFiles.GetPathNews(m_news_id) + n_info.ToList()[0].NEWS_IMAGE2);
                        n_info.ToList()[0].NEWS_IMAGE2 = "";
                        DB.SubmitChanges();

                        if (File.Exists(imagePath))
                            File.Delete(imagePath);

                        strLink = "news.aspx?type=" + _type + "&news_id=" + m_news_id;
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



        protected void btnDelete3_Click(object sender, ImageClickEventArgs e)
        {
            string strLink = "";
            try
            {
                var n_info = DB.GetTable<ESHOP_NEW>().Where(n => n.NEWS_ID == m_news_id);

                if (n_info.ToList().Count > 0)
                {
                    if (!string.IsNullOrEmpty(n_info.ToList()[0].NEWS_IMAGE3))
                    {
                        string imagePath = Server.MapPath(PathFiles.GetPathNews(m_news_id) + n_info.ToList()[0].NEWS_IMAGE3);
                        n_info.ToList()[0].NEWS_IMAGE3 = "";
                        DB.SubmitChanges();

                        if (File.Exists(imagePath))
                            File.Delete(imagePath);

                        strLink = "news.aspx?type=" + _type + "&news_id=" + m_news_id;
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

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Kiemtra_catindex(Utils.CIntDef(Utils.CIntDef(ddlCategory.SelectedValue))) == true)
            {
                div_noibat.Visible = true;
            }
            else
                div_noibat.Visible = false;
        }

       
       
    }
}
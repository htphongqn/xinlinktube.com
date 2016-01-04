using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vpro.functions;
using System.Web.UI.HtmlControls;
using Controller;

namespace MVC_LinkTuBe.vi_vn
{
    public partial class page_default : System.Web.UI.Page
    {
        #region Declare
        Get_session getsession = new Get_session();
        Config cf = new Config();
        int _type = 0, lang = 1, _langsearch = 0;
        string _catSeoUrl = string.Empty;
        string _newsSeoUrl = string.Empty;
        checkProperties _checkprt = new checkProperties();
        #endregion
        #region Page Event
        protected void Page_PreInit(object sender, EventArgs e)
        {
            _type = Utils.CIntDef(Request["type"]);
            string[] cut_catSeoUrl = Utils.CStrDef(Request.QueryString["purl"]).ToString().Split('/');
            if (cut_catSeoUrl.Length > 1)
            {
                _newsSeoUrl = cut_catSeoUrl[1];
                _catSeoUrl = cut_catSeoUrl[0];
            }
            else
            {
                _newsSeoUrl = cut_catSeoUrl[0];
                _catSeoUrl = cut_catSeoUrl[0];
            }
            Page.MasterPageFile = "/Master/Default.Master";
            if (getsession.check_CatorNews(_newsSeoUrl))
            {
                int _cattype = getsession.Getcat_type(_newsSeoUrl);
                if (_cattype == 1)
                    Page.MasterPageFile = "/Master/Site.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Bind_icon();
                //string _catSeoUrl = Utils.CStrDef(Request.QueryString["purl"]);
                //string _newsSeoUrl = Utils.CStrDef(Request.QueryString["purl"]);
                //string device = Request.UserAgent.ToLower();
                //if (Request.Browser.IsMobileDevice || device.Contains("mobile") || device.Contains("ipad"))
                //{
                //    if (!String.IsNullOrEmpty(_catSeoUrl))
                //        Response.Redirect("/" + _catSeoUrl + ".html");
                //}
                UserControl list_news = null;
                UserControl list_cat = null;
                UserControl details_news = null;
                UserControl search = null;
                UserControl list_product = null;
                UserControl product_detail = null;
                if (lang == 1)
                {
                    list_cat = Page.LoadControl("../UIs/list_cat.ascx") as UserControl;
                    product_detail = Page.LoadControl("../UIs/product-details.ascx") as UserControl;
                    list_product = Page.LoadControl("../UIs/list-product.ascx") as UserControl;
                    list_news = Page.LoadControl("../UIs/listnews.ascx") as UserControl;
                    details_news = Page.LoadControl("../UIs/news-details.ascx") as UserControl;
                    search = Page.LoadControl("../UIs/search-result.ascx") as UserControl;
                }
                else
                {
                    //list_news = Page.LoadControl("../UIs-en/listnews.ascx") as UserControl;
                    //details_news = Page.LoadControl("../UIs-en/news-details.ascx") as UserControl;
                    //search = Page.LoadControl("../UIs-en/search-result.ascx") as UserControl;
                }

                switch (_type)
                {

                    case 3:
                        if (!_checkprt.check_CatorNews(_newsSeoUrl) && !_checkprt.check_ExitsCategories(_catSeoUrl))
                        {
                            Response.Redirect("/thong-bao-loi.html");
                            break;
                        }
                        if (getsession.check_CatorNews(_newsSeoUrl))
                        {
                            getsession.LoadNewsInfo(_newsSeoUrl);
                            Bind_meta_tags_news();
                            int _cattype = getsession.Getcat_type(_newsSeoUrl);
                            if (_cattype == 0)
                                phdMain.Controls.Add(details_news);
                            else
                            {
                                if (_cattype == 1)
                                {
                                    phdMain.Controls.Add(product_detail);
                                }
                                else
                                    phdMain.Controls.Add(details_news);
                            }
                        }
                        else
                        {
                            getsession.LoadCatInfo(_catSeoUrl);
                            Bind_meta_tags_cat();
                            if (Utils.CIntDef(Session["Cat_showitem"]) == 1)
                            {
                                if (Utils.CIntDef(Session["Cat_type"]) == 0)
                                    phdMain.Controls.Add(details_news);
                                else
                                {
                                    if (Utils.CIntDef(Session["Cat_type"]) == 1)
                                    {
                                        phdMain.Controls.Add(product_detail);
                                    }
                                    else
                                        phdMain.Controls.Add(details_news);
                                }
                            }
                            else
                            {
                                if (Utils.CIntDef(Session["Cat_type"]) == 0)
                                    phdMain.Controls.Add(list_news);
                                else
                                {
                                    if (Utils.CIntDef(Session["Cat_type"]) == 1)
                                    {
                                        if (getsession.check_parent(Utils.CIntDef(Session["Cat_id"]))==true)
                                            phdMain.Controls.Add(list_cat);
                                        else
                                            phdMain.Controls.Add(list_product);
                                    }
                                    else
                                    {
                                        phdMain.Controls.Add(list_news);
                                    }
                                }
                            }
                        }
                        break;
                    case 5:
                        Bind_meta_tags_index();
                        phdMain.Controls.Add(search);
                        break;


                    default:
                        Response.Redirect("/");
                        break;
                }
            }
            catch (Exception ex)
            {
                //clsVproErrorHandler.HandlerError(ex);
            }
        }
        #endregion
        public void Bind_meta_tags_cat()
        {
            #region Bind Meta Tags
            HtmlHead header = base.Header;
            HtmlMeta headerDes = new HtmlMeta();
            HtmlMeta headerKey = new HtmlMeta();

            HtmlLink linkcanonical = new HtmlLink();
            HtmlMeta propety = new HtmlMeta();
            HtmlMeta propetyTitle = new HtmlMeta();
            HtmlMeta propetyDesc = new HtmlMeta();

            headerDes.Name = "Description";
            headerKey.Name = "Keywords";

            header.Title = Utils.CStrDef(Session["Cat_seo_title"]);
            headerDes.Content = Utils.CStrDef(Session["Cat_seo_desc"]);
            headerKey.Content = Utils.CStrDef(Session["Cat_seo_keyword"]);


            if (string.IsNullOrEmpty(headerDes.Content))
            {
                headerDes.Content = "";
            }
            header.Controls.Add(headerDes);

            if (string.IsNullOrEmpty(headerKey.Content))
            {
                headerKey.Content = "";
            }

            header.Controls.Add(headerKey);

            //Facebook meta
            //Link
            linkcanonical.Attributes.Add("rel", "canonical");
            linkcanonical.Href = System.Configuration.ConfigurationManager.AppSettings["URLWebsite"] + "/" + Utils.CStrDef(Session["Cat_seo_url"]) + ".html";
            header.Controls.Add(linkcanonical);
            //Img
            propety.Attributes.Add("property", "og:image");
            propety.Attributes.Add("name", "xlarge");
            propety.Content = System.Configuration.ConfigurationManager.AppSettings["URLWebsite"] + "" + PathFiles.GetPathCategory(Utils.CIntDef(Session["Cat_id"])) + Utils.CStrDef(Session["Cat_img1"]);
            header.Controls.Add(propety);
            //Title         
            propetyTitle.Attributes.Add("property", "og:title");
            propetyTitle.Content = Utils.CStrDef(Session["Cat_name"]);
            header.Controls.Add(propetyTitle);
            //Desc
            propetyDesc.Attributes.Add("property", "og:description");
            propetyDesc.Content = Utils.CStrDef(Session["Cat_seo_desc"]);
            header.Controls.Add(propetyDesc);
            #endregion
        }
        public void Bind_meta_tags_news()
        {
            #region Bind Meta Tags
            HtmlHead header = base.Header;
            HtmlMeta headerDes = new HtmlMeta();
            HtmlMeta headerKey = new HtmlMeta();
            //Face tags
            HtmlLink linkcanonical = new HtmlLink();
            HtmlMeta propety = new HtmlMeta();
            HtmlMeta propetyTitle = new HtmlMeta();
            HtmlMeta propetyDesc = new HtmlMeta();
            //Twitter tags
            //HtmlMeta propetyTw = new HtmlMeta();
            //HtmlMeta propetyTitleTw = new HtmlMeta();
            //HtmlMeta propetyDescTw = new HtmlMeta();
            headerDes.Name = "Description";
            headerKey.Name = "Keywords";
            header.Title = Utils.CStrDef(Session["News_seo_title"]);
            headerDes.Content = Utils.CStrDef(Session["News_seo_desc"]);
            headerKey.Content = Utils.CStrDef(Session["News_seo_keyword"]);
            if (string.IsNullOrEmpty(headerDes.Content))
            {
                headerDes.Content = "";
            }
            header.Controls.Add(headerDes);

            if (string.IsNullOrEmpty(headerKey.Content))
            {
                headerKey.Content = "";
            }

            header.Controls.Add(headerKey);
            //<meta rel=”canonical” href="http://example.com/content-news.html"/>
            //Facebook meta
            //Link
            linkcanonical.Attributes.Add("rel", "canonical");
            linkcanonical.Href = System.Configuration.ConfigurationManager.AppSettings["URLWebsite"] +"/"+ Utils.CStrDef(Session["News_seo_url"]) + ".html";
            header.Controls.Add(linkcanonical);
            //Img
            propety.Attributes.Add("property", "og:image");
            propety.Attributes.Add("name", "xlarge");
            propety.Content = System.Configuration.ConfigurationManager.AppSettings["URLWebsite"] + "" + PathFiles.GetPathNews(Utils.CIntDef(Session["News_id"])) + Utils.CStrDef(Session["News_image3"]);
            header.Controls.Add(propety);
            //Title         
            propetyTitle.Attributes.Add("property", "og:title");
            propetyTitle.Content = Utils.CStrDef(Session["News_seo_title"]);
            header.Controls.Add(propetyTitle);
            //Desc
            propetyDesc.Attributes.Add("property", "og:description");
            propetyDesc.Content = Utils.CStrDef(Session["News_seo_desc"]);
            header.Controls.Add(propetyDesc);
            ////Twitter meta
            //propetyTw.Attributes.Add("property", "twitter:image");
            //propetyTw.Content = "" + System.Configuration.ConfigurationManager.AppSettings["URLWebsite"] + "" + PathFiles.GetPathNews(Utils.CIntDef(Session["News_id"])) + Utils.CStrDef(Session["News_image3"]);
            //header.Controls.Add(propetyTw);
            ////Title         
            //propetyTitleTw.Attributes.Add("property", "twitter:title");
            //propetyTitleTw.Content = Utils.CStrDef(Session["News_seo_title"]);
            //header.Controls.Add(propetyTitleTw);
            ////Desc
            //propetyDescTw.Attributes.Add("property", "twitter:description");
            //propetyDescTw.Content = Utils.CStrDef(Session["News_seo_desc"]);
            //header.Controls.Add(propetyDescTw);


            #endregion
        }
        private void Bind_icon()
        {
            var _configs = cf.Config_meta();

            if (_configs.ToList().Count > 0)
            {
                if (!string.IsNullOrEmpty(_configs.ToList()[0].CONFIG_FAVICON))
                    ltrFavicon.Text = "<link rel='shortcut icon' href='" + PathFiles.GetPathConfigs() + _configs.ToList()[0].CONFIG_FAVICON + "' />";
            }
        }
        public void Bind_meta_tags_index()
        {
            HtmlHead header = base.Header;
            HtmlMeta headerDes = new HtmlMeta();
            HtmlMeta headerKey = new HtmlMeta();
            headerDes.Name = "Description";
            headerKey.Name = "Keywords";

            var _configs = cf.Config_meta();

            if (_configs.ToList().Count > 0)
            {
                if (!string.IsNullOrEmpty(_configs.ToList()[0].CONFIG_FAVICON))
                    ltrFavicon.Text = "<link rel='shortcut icon' href='" + PathFiles.GetPathConfigs() + _configs.ToList()[0].CONFIG_FAVICON + "' />";

                header.Title = _configs.ToList()[0].CONFIG_TITLE;

                headerDes.Content = _configs.ToList()[0].CONFIG_DESCRIPTION;
                header.Controls.Add(headerDes);

                headerKey.Content = _configs.ToList()[0].CONFIG_KEYWORD;
                header.Controls.Add(headerKey);
            }
            else
            {
                header.Title = "Enews Standard V1.0";

                headerDes.Content = "Enews Standard V1.0";
                header.Controls.Add(headerDes);

                headerKey.Content = "Enews Standard V1.0";
                header.Controls.Add(headerKey);
            }
        }

    }
}
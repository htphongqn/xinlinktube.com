using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using vpro.functions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Controller
{
    public class Get_session
    {
        #region Decclare
        dbVuonRauVietDataContext db = new dbVuonRauVietDataContext();
        #endregion
        public void LoadCatInfo(string _catSeoUrl)
        {
            try
            {

                var cats = db.GetTable<ESHOP_CATEGORy>().Where(c => c.CAT_SEO_URL == _catSeoUrl).ToList();

                if (cats.Count > 0)
                {

                    #region Bind Cat Info
                    HttpContext.Current.Session["Cat_id"] = cats[0].CAT_ID;
                    HttpContext.Current.Session["Cat_seo_url"] = cats[0].CAT_SEO_URL;
                    HttpContext.Current.Session["Cat_img1"] = cats[0].CAT_IMAGE1;
                    HttpContext.Current.Session["Cat_showitem"] = cats[0].CAT_SHOWITEM;
                    HttpContext.Current.Session["Cat_type"] = cats[0].CAT_TYPE;
                    HttpContext.Current.Session["Cat_desc"] = cats[0].CAT_DESC;
                    HttpContext.Current.Session["Cat_name"] = cats[0].CAT_NAME;
                    HttpContext.Current.Session["Cat_seo_title"] = cats[0].CAT_SEO_TITLE;
                    HttpContext.Current.Session["Cat_seo_desc"] = cats[0].CAT_SEO_DESC;
                    HttpContext.Current.Session["Cat_seo_keyword"] = cats[0].CAT_SEO_KEYWORD;
                    HttpContext.Current.Session["News_type"] = null;
                    #endregion

                }
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }
        public void LoadNewsInfo(string News_Seo_Url)
        {
            try
            {

                var news = db.GetTable<ESHOP_NEW>().Where(c => c.NEWS_SEO_URL == News_Seo_Url).ToList();

                if (news.ToList().Count > 0)
                {

                    #region Bind News Info
                    HttpContext.Current.Session["News_id"] = news[0].NEWS_ID;
                    HttpContext.Current.Session["News_title"] = news[0].NEWS_TITLE;
                    HttpContext.Current.Session["News_desc"] = news[0].NEWS_DESC;
                    HttpContext.Current.Session["News_seo_url"] = news[0].NEWS_SEO_URL;
                    HttpContext.Current.Session["News_filehtml"] = news[0].NEWS_FILEHTML;
                    HttpContext.Current.Session["Cat_type"] = null;
                    HttpContext.Current.Session["News_publishdate"] = news[0].NEWS_PUBLISHDATE;
                    HttpContext.Current.Session["News_showtype"] = news[0].NEWS_SHOWTYPE;
                    HttpContext.Current.Session["News_type"] = news[0].NEWS_TYPE;
                    HttpContext.Current.Session["News_count"] = news[0].NEWS_COUNT;
                    HttpContext.Current.Session["News_image1"] = news[0].NEWS_IMAGE1;
                    HttpContext.Current.Session["News_image3"] = news[0].NEWS_IMAGE3;
                    HttpContext.Current.Session["News_seo_title"] = news[0].NEWS_SEO_TITLE;
                    HttpContext.Current.Session["News_seo_desc"] = news[0].NEWS_SEO_DESC;
                    HttpContext.Current.Session["News_seo_keyword"] = news[0].NEWS_SEO_KEYWORD;
                    #endregion


                }
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }
        public int Getcat_type(string News_Seo_Url)
        {
            int _type=0;
            var list = (from a in db.ESHOP_NEWS_CATs
                        join b in db.ESHOP_NEWs on a.NEWS_ID equals b.NEWS_ID
                        where b.NEWS_SEO_URL == News_Seo_Url
                        select new { a.ESHOP_CATEGORy.CAT_TYPE }).ToList();
            if (list.Count > 0)
            {
                _type =Utils.CIntDef(list[0].CAT_TYPE);
            }
            return _type;
        }
        public bool check_CatorNews(string url)
        {
            var list = db.ESHOP_NEWs.Where(n => n.NEWS_SEO_URL == url).ToList();
            if (list.Count > 0)
                return true;
            return false;
        }
        public bool check_parent(int _cat_id)
        {
            try
            {
                var list = db.ESHOP_CATEGORies.Where(n => n.CAT_PARENT_ID == _cat_id).ToList();
                if (list.Count() > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        public int getLang(string _news_seo, string _catseo)
        {
            int lang = 1;
            if (!String.IsNullOrEmpty(_news_seo))
            {
                var list = (from a in db.ESHOP_NEWS_CATs
                            join b in db.ESHOP_NEWs on a.NEWS_ID equals b.NEWS_ID
                            where b.NEWS_SEO_URL == _news_seo
                            select new { a.ESHOP_CATEGORy.CAT_LANGUAGE }).ToList();
                if (list.Count > 0)
                {
                    lang = Utils.CIntDef(list[0].CAT_LANGUAGE);
                }
            }
            else
            {
                var list = db.ESHOP_CATEGORies.Where(n => n.CAT_SEO_URL == _catseo).Select(n => new { n.CAT_LANGUAGE }).ToList();
                if (list.Count > 0)
                {
                    lang = Utils.CIntDef(list[0].CAT_LANGUAGE);
                }
            }
            return lang;
        }
    }
}

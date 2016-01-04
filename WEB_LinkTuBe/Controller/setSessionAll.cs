using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Web;
using vpro.functions;

namespace Controller
{
    public class setSessionAll
    {
        dbVuonRauVietDataContext db = new dbVuonRauVietDataContext();
        public void Load_All_Cuss(string email)
        {
            try
            {
                var _cus = db.GetTable<ESHOP_CUSTOMER>().Where(a => a.CUSTOMER_EMAIL == email);
                if (_cus.ToList().Count > 0)
                {
                    HttpContext.Current.Session["USER_NAME"] = _cus.ToList()[0].CUSTOMER_FULLNAME;
                    HttpContext.Current.Session["USER_ID"] = _cus.ToList()[0].CUSTOMER_ID;
                }
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }
        public void Load_All_Cuss(int cusid)
        {
            try
            {
                var _cus = db.GetTable<ESHOP_CUSTOMER>().Where(a => a.CUSTOMER_ID == cusid);
                if (_cus.ToList().Count > 0)
                {
                    HttpContext.Current.Session["USER_NAME"] = _cus.ToList()[0].CUSTOMER_FULLNAME;
                    HttpContext.Current.Session["USER_ID"] = _cus.ToList()[0].CUSTOMER_ID;
                }
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }
        public void LoadCatInfo(string _catSeoUrl)
        {
            try
            {

                var cats = db.GetTable<ESHOP_CATEGORy>().Where(c => c.CAT_SEO_URL == _catSeoUrl);

                if (cats.ToList().Count > 0)
                {

                    #region Bind Cat Info
                    HttpContext.Current.Session["Cat_id"] = cats.ToList()[0].CAT_ID;
                    HttpContext.Current.Session["Cat_image1"] = cats.ToList()[0].CAT_IMAGE1;
                    HttpContext.Current.Session["Cat_seo_desc"] = cats.ToList()[0].CAT_SEO_DESC;
                    HttpContext.Current.Session["Cat_seo_keyword"] = cats.ToList()[0].CAT_SEO_KEYWORD;
                    HttpContext.Current.Session["Cat_seo_title"] = cats.ToList()[0].CAT_SEO_TITLE;
                    HttpContext.Current.Session["Cat_showitem"] = cats.ToList()[0].CAT_SHOWITEM;
                    HttpContext.Current.Session["Cat_type"] = cats.ToList()[0].CAT_TYPE;
                    HttpContext.Current.Session["Cat_url"] = cats.ToList()[0].CAT_URL;

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

                var news = db.GetTable<ESHOP_NEW>().Where(c => c.NEWS_SEO_URL == News_Seo_Url);

                if (news.ToList().Count > 0)
                {

                    #region Bind News Info
                    HttpContext.Current.Session["News_id"] = news.ToList()[0].NEWS_ID;
                    HttpContext.Current.Session["News_seo_keyword"] = news.ToList()[0].NEWS_SEO_KEYWORD;
                    HttpContext.Current.Session["News_seo_desc"] = news.ToList()[0].NEWS_SEO_DESC;
                    HttpContext.Current.Session["News_seo_title"] = news.ToList()[0].NEWS_SEO_TITLE;
                    HttpContext.Current.Session["News_image3"] = news.ToList()[0].NEWS_IMAGE3;
                    #endregion


                }
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }
    }
}

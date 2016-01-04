using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using vpro.functions;
using System.Web;
using System.Web.UI;

namespace Controller
{
    public class Propertity
    {
        #region Decclare
        dbVuonRauVietDataContext db = new dbVuonRauVietDataContext();
        #endregion
        #region Load menu
        public List<ESHOP_CATEGORy> Loadmenu_video()
        {
            return db.ESHOP_CATEGORies.Where(n => n.CAT_TYPE == 1 && n.CAT_RANK==1).OrderBy(n => n.CAT_NAME).OrderByDescending(n => n.CAT_ORDER).OrderByDescending(n => n.CAT_PERIOD_ORDER).ToList();
        }
        public List<ESHOP_CATEGORy> Loadmenu_video_2(int cat_id)
        {
            return db.ESHOP_CATEGORies.Where(n => n.CAT_TYPE == 1 && n.CAT_PARENT_ID == cat_id &&n.CAT_RANK==2).OrderBy(n => n.CAT_NAME).OrderByDescending(n => n.CAT_ORDER).OrderByDescending(n => n.CAT_PERIOD_ORDER).ToList();
        }
        public List<ESHOP_CATEGORy> Loadmenu(int position,int limit,int rank)
        {
            try
            {
                var list = db.ESHOP_CATEGORies.Where(n => n.CAT_STATUS == 1 && (n.CAT_POSITION == position||n.CAT_POSITION==3)&&n.CAT_RANK==rank ).OrderBy(n=>n.CAT_ID).OrderByDescending(n=>n.CAT_ORDER).Take(limit).ToList();
                return list;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public List<ESHOP_CATEGORy> Kenh_Footer(int limit)
        {
            var list = db.ESHOP_CATEGORies.Where(n => n.CAT_TYPE == 2 && n.CAT_SHOWFOOTER == 1 && n.CAT_RANK==1).OrderByDescending(n => n.CAT_PERIOD_ORDER).Take(limit).ToList();
            return list;
        }
        public IQueryable<ESHOP_CATEGORy> Menu_phu(object catid)
        {
            int id=Utils.CIntDef(catid);
            var list = db.ESHOP_CATEGORies.Where(n => n.CAT_PARENT_ID == id).OrderByDescending(n => n.CAT_ORDER);
            return list.ToList().Count>0 ? list:null;
        }
        public IQueryable<ESHOP_CATEGORy> Menu_phu(object catid, int stt, int limit)
        {
            int id = Utils.CIntDef(catid);
            var list = db.ESHOP_CATEGORies.Where(n => n.CAT_PARENT_ID == id && n.CAT_SHOWFOOTER == stt).OrderByDescending(n => n.CAT_ORDER).Take(limit);
            return list.ToList().Count > 0 ? list : null;
        }
        #endregion
        //Active menu
        #region Active menu
        public string Get_Cat_Seo_Url(string _seoUrl)
        {
            var rausach = from p in db.ESHOP_CATEGORies
                          where p.CAT_SEO_URL == _seoUrl && p.CAT_STATUS == 1
                          select p;
            int _catID = -1;

            if (rausach.ToList().Count > 0)
            {
                string cat_parent_path = rausach.ToList()[0].CAT_PARENT_PATH;

                string[] str = cat_parent_path.Split(',');

                if (str.Count() > 1)
                {
                    _catID = Utils.CIntDef(str[1]);
                }
                else
                {
                    _catID = Utils.CIntDef(rausach.ToList()[0].CAT_ID);
                }
            }

            else
            {
                var rausach1 = (from nc in db.ESHOP_NEWS_CATs
                                join c in db.ESHOP_CATEGORies on nc.CAT_ID equals c.CAT_ID
                                join n in db.ESHOP_NEWs on nc.NEWS_ID equals n.NEWS_ID
                                where n.NEWS_SEO_URL == _seoUrl && c.CAT_STATUS == 1
                                orderby c.CAT_RANK descending
                                select new
                                {
                                    c.CAT_PARENT_PATH,
                                    c.CAT_NAME,
                                    c.CAT_DESC,
                                    c.CAT_ID
                                }).Take(1);

                if (rausach1.ToList().Count > 0)
                {
                    string cat_parent_path_Max = rausach1.ToList()[0].CAT_PARENT_PATH;

                    string[] str = cat_parent_path_Max.Split(',');
                    if (str.Count() > 1)
                    {
                        _catID = Utils.CIntDef(str[1]);
                    }
                    else
                    {
                        _catID = Utils.CIntDef(rausach1.ToList()[0].CAT_ID);
                    }
                }
            }
            var _cat_Seo_Url = db.GetTable<ESHOP_CATEGORy>().Where(a => a.CAT_ID == _catID && a.CAT_STATUS == 1);
            if (_cat_Seo_Url.ToList().Count > 0)
            {
                string _catSeoUrl = _cat_Seo_Url.ToList()[0].CAT_SEO_URL;
                return _catSeoUrl;
            }
            else
            {
                return null;
            }
        }
        public string GetStyleActive(object Cat_Seo_Url, object Cat_Url)
        {
            try
            {
                if (!string.IsNullOrEmpty(Utils.CStrDef(HttpContext.Current.Request.QueryString["purl"])))
                {
                    string _curl = Utils.CStrDef(HttpContext.Current.Request.QueryString["purl"]);

                    var _cat = db.GetTable<ESHOP_CATEGORy>().Where(a => a.CAT_SEO_URL == _curl && a.CAT_STATUS == 1);
                    if (_cat.ToList().Count > 0)
                    {
                        if (_cat.ToList()[0].CAT_RANK >= 1)
                        {
                            if (Utils.CStrDef(HttpContext.Current.Request.QueryString["purl"]) == Utils.CStrDef(Cat_Seo_Url))
                            {
                                return "active";
                            }
                            else
                            {
                                return null;
                            }
                        }
                        else
                        {
                            int _catID = -1;
                            string[] str = Utils.CStrDef(_cat.ToList()[0].CAT_PARENT_PATH).Split(',');

                            if (str.Count() > 1)
                            {
                                _catID = Utils.CIntDef(str[1]);

                                var _cat_Seo_Url = db.GetTable<ESHOP_CATEGORy>().Where(a => a.CAT_ID == _catID && a.CAT_STATUS == 1);
                                if (_cat_Seo_Url.ToList().Count > 0)
                                {
                                    string _catSeoUrl = _cat_Seo_Url.ToList()[0].CAT_SEO_URL;

                                    if (_catSeoUrl == Utils.CStrDef(Cat_Seo_Url))
                                    {
                                        return "active";
                                    }
                                    else
                                    {
                                        return null;
                                    }
                                }
                                else
                                {
                                    return null;
                                }
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    //string _seoUrl = fm.CatChuoiURL(Utils.CStrDef(Request.RawUrl));
                    string _seoUrl = Utils.CStrDef(HttpContext.Current.Request.QueryString["purl"]);
                    if (!string.IsNullOrEmpty(_seoUrl))
                    {
                        string _catSeoUrl = Get_Cat_Seo_Url(_seoUrl);
                        if (_catSeoUrl == Utils.CStrDef(Cat_Seo_Url))
                        {
                            return "active";
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        if (Utils.CStrDef(HttpContext.Current.Request.RawUrl) == Utils.CStrDef(Cat_Url))
                        {
                            return "active";
                        }
                        else
                        {
                            return null;
                        }
                    }
                }

                //}
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        #endregion
        #region Load HTTT
        public List<ESHOP_ONLINE> LoadHTTT(int type)
        {
            var list = db.ESHOP_ONLINEs.Where(n => n.ONLINE_TYPE == type).OrderByDescending(n => n.ONLINE_ORDER).ToList();
            return list;
        }
        public List<ESHOP_ONLINE> LoadHTTT()
        {
            var list = db.ESHOP_ONLINEs.OrderByDescending(n=>n.ONLINE_ORDER).ToList();
            return list;
        }
        #endregion
        #region Path

        /// <summary>
        /// Lấy đường dẫn và ghi chú về sản phẩm
        /// </summary>
        public string Getpath()
        {
            try
            {
                string _result = string.Empty;
                string requesturl = Utils.CStrDef(HttpContext.Current.Request.RawUrl);

                string cat_seo_url = CatChuoiURL(requesturl);

                if (cat_seo_url.Contains("html?p"))
                {
                    string[] a = cat_seo_url.Split('?');
                    cat_seo_url = a[0].Substring(0, a[0].Length - 5);
                }
                var rausach = from p in db.ESHOP_CATEGORies
                              where p.CAT_SEO_URL == cat_seo_url && p.CAT_STATUS == 1
                              select p;

                if (rausach.ToList().Count > 0)
                {

                    string cat_parent_path = rausach.ToList()[0].CAT_PARENT_PATH;

                    string[] str = cat_parent_path.Split(',');

                    if (str.Count() > 1)
                    {
                        _result = Convert_Name(str) + "<li><a href='/" + rausach.ToList()[0].CAT_SEO_URL + ".html'>" + rausach.ToList()[0].CAT_NAME + "</a></li>";
                    }
                    else
                    {
                        if (rausach.ToList()[0].CAT_SHOWITEM > 0)
                        {
                            _result = "<li><a href='/" + rausach.ToList()[0].CAT_SEO_URL + ".html'>" + rausach.ToList()[0].CAT_NAME + "</a></li>";
                        }
                        else
                        {
                            _result = "<li><a href='/" + rausach.ToList()[0].CAT_SEO_URL + ".html'>" + rausach.ToList()[0].CAT_NAME + "</a></li>";
                        }
                    }
                }

                else
                {
                    var rausach1 = (from nc in db.ESHOP_NEWS_CATs
                                    join c in db.ESHOP_CATEGORies on nc.CAT_ID equals c.CAT_ID
                                    join n in db.ESHOP_NEWs on nc.NEWS_ID equals n.NEWS_ID
                                    where n.NEWS_SEO_URL == cat_seo_url && c.CAT_STATUS == 1
                                    orderby c.CAT_RANK descending
                                    select c).Take(1);
                    if (rausach1.ToList().Count > 0)
                    {
                        string cat_parent_path_Max = rausach1.ToList()[0].CAT_PARENT_PATH;

                        string[] str = cat_parent_path_Max.Split(',');
                        if (str.Count() > 1)
                        {
                            _result = Convert_Name(str) + "<li><a href='/" + rausach1.ToList()[0].CAT_SEO_URL + ".html'>" + rausach1.ToList()[0].CAT_NAME + "</a></li>";
                        }
                        else
                        {
                            if (rausach1.ToList()[0].CAT_SHOWITEM > 0)
                            {
                                _result = "<li><a href='/" + rausach1.ToList()[0].CAT_SEO_URL + ".html'>" + rausach1.ToList()[0].CAT_NAME + "</a></li>";
                            }
                            else
                            {
                                _result = "<li><a href='/" + rausach1.ToList()[0].CAT_SEO_URL + ".html'>" + rausach1.ToList()[0].CAT_NAME + "</a></li>";
                            }
                        }

                    }
                }
                return _result;
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return "";
            }
        }

        /// <summary>
        /// Chuyển chuỗi kiểu số thành chuỗi kiểu chữ
        /// </summary>
        /// <param name="str">mảng chứa đường dẫn kiểu số</param>
        /// <returns>đường dẫn kiểu chữ</returns>
        public string Convert_Name(string[] str)
        {
            string s = "";

            try
            {
                int _value = 0;

                for (int i = 1; i < str.Count(); i++)
                {

                    _value = Utils.CIntDef(str[i]);

                    var rausach = (from r in db.ESHOP_CATEGORies
                                   where r.CAT_ID == _value && r.CAT_STATUS == 1
                                   select r).ToList();
                    //s += rausach.ToList()[0] + " > ";
                    if (rausach.Count > 0)
                        s += "<li><a href='/" + rausach.ToList()[0].CAT_SEO_URL + ".html'>" + rausach.ToList()[0].CAT_NAME + "</a></li>";
                }
                return s;
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return "";
            }
        }
        private string CatChuoiURL(string s)
        {
            string[] sep = { "/" };
            string[] sep1 = { " " };
            string[] t1 = s.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            string res = "";
            for (int i = (t1.Length > 1 ? 1 : 0); i < t1.Length; i++)
            {
                string[] t2 = t1[i].Split(sep1, StringSplitOptions.RemoveEmptyEntries);
                if (t2.Length > 0)
                {
                    if (res.Length > 0)
                    {
                        res += "//";
                    }
                    res += t2[0];
                }
            }
            return res.Substring(0, res.Length - 5);
        }
        #endregion
        #region Load logo
        public List<ESHOP_BANNER> LoadLogoBanner(string field, int limit)
        {
            try
            {
                var list = db.ESHOP_BANNERs.Where(n => n.BANNER_FIELD1 == field).Take(limit).ToList();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region Load slider
        public List<ESHOP_AD_ITEM> Load_slider(int pos, int limit)
        {
            var list = db.ESHOP_AD_ITEMs.Where(n => n.AD_ITEM_POSITION == pos && n.AD_ITEM_DATETO >= DateTime.Now).OrderByDescending(n => n.AD_ITEM_ORDER).Take(limit).ToList();
            return list;
        }
        #endregion
    }
}

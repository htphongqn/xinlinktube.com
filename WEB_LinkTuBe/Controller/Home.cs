using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using vpro.functions;
using System.Web;
using System.Web.UI;
using System.IO;

namespace Controller
{
    public class Home
    {
        #region Decclare
        dbVuonRauVietDataContext db = new dbVuonRauVietDataContext();
        #endregion
        //Pro or news hien thi trang chu
        public List<ESHOP_NEWS_IMAGE> listimg(int id)
        {
            var list = (from a in db.ESHOP_NEWs
                        join b in db.ESHOP_NEWS_IMAGEs on a.NEWS_ID equals b.NEWS_ID
                        where a.NEWS_ID == id
                        select b).ToList();
            return list;
        }
        public List<ESHOP_NEWS_IMAGE> id_album_index()
        {
            int _id = 0;
            var list = db.ESHOP_NEWs.Where(n => n.NEWS_TYPE == 2).OrderByDescending(n => n.NEWS_ORDER).OrderByDescending(n => n.NEWS_ORDER_PERIOD).ToList();
            if (list.Count() > 0)
                _id = Utils.CIntDef(list[0].NEWS_ID);
            return listimg(_id);
        }
        public string GetIMG(object CAT_ID, object CAT_IMG)
        {
            try
            {
                if (CAT_IMG != null && CAT_IMG.ToString() != string.Empty)
                {
                    return "/data/categories/" + CAT_ID.ToString() + "/" + CAT_IMG.ToString();
                }
                return "";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ESHOP_CATEGORy> Loadmenutype(int cat_type, int limit)
        {
            try
            {
                List<ESHOP_CATEGORy> list = db.ESHOP_CATEGORies.Where(n => n.CAT_TYPE == cat_type).Take(limit).ToList();
                return list;
            }
            catch
            {
                throw;
            }
        }
        public string Get_Cat_Seo(object News_Url, object News_Seo_Url)
        {
            try
            {
                if (News_Url != string.Empty && News_Url != null)
                {
                    var list = (from a in db.ESHOP_NEWs
                                join b in db.ESHOP_NEWS_CATs on a.NEWS_ID equals b.NEWS_ID
                                join c in db.ESHOP_CATEGORies on b.CAT_ID equals c.CAT_ID
                                where (a.NEWS_URL == News_Url)
                                select (c)).ToList();
                    if (list.Count > 0)
                    {
                        return list[0].CAT_SEO_URL;
                    }
                    return "1";
                }
                else
                {
                    var list = (from a in db.ESHOP_NEWs
                                join b in db.ESHOP_NEWS_CATs on a.NEWS_ID equals b.NEWS_ID
                                join c in db.ESHOP_CATEGORies on b.CAT_ID equals c.CAT_ID
                                where (a.NEWS_SEO_URL == News_Seo_Url)
                                select (c)).ToList();
                    if (list.Count > 0)
                    {
                        return list[0].CAT_SEO_URL;
                    }
                    return "1";
                }
            }
            catch
            {
                throw;
            }
        }
        public List<ESHOP_NEW> Loadindex(int type, int period,int skip,int limit)
        {
            try
            {
                var list = db.ESHOP_NEWs.Where(n => n.NEWS_PERIOD == period && n.NEWS_TYPE == type).OrderByDescending(n => n.NEWS_ID).OrderByDescending(n => n.NEWS_ORDER_PERIOD).Take(limit).Skip(skip).ToList();
                return list;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ESHOP_NEW> LoadDvu(int period, int limit)
        {
            try
            {
                var list = db.ESHOP_NEWs.Where(n => n.NEWS_PERIOD == period).OrderByDescending(n => n.NEWS_ID).OrderByDescending(n => n.NEWS_ORDER_PERIOD).Take(limit).ToList();
                return list;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ESHOP_NEW> Loadindex(int type, int period, int limit)
        {
            try
            {
                var list = db.ESHOP_NEWs.Where(n => n.NEWS_PERIOD == period && n.NEWS_TYPE == type).OrderByDescending(n => n.NEWS_ORDER_PERIOD).Take(limit).ToList();
                return list;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Pro_details_entity> Loadpro_cookie(int type, List<string> listnews_url)
        {
            try
            {
                List<Pro_details_entity> l = new List<Pro_details_entity>();
                var list = (from a in db.ESHOP_NEWS_CATs
                            join b in db.ESHOP_NEWs on a.NEWS_ID equals b.NEWS_ID
                            join c in db.ESHOP_CATEGORies on a.CAT_ID equals c.CAT_ID
                            where b.NEWS_TYPE == type && listnews_url.Contains(b.NEWS_SEO_URL)
                            select new { b.NEWS_ID, b.NEWS_TITLE, b.NEWS_IMAGE1, b.NEWS_IMAGE3, b.NEWS_PRICE1, b.NEWS_PRICE2, b.NEWS_DESC, b.NEWS_SEO_URL, b.NEWS_URL, b.NEWS_ORDER_PERIOD, b.NEWS_PUBLISHDATE}).Distinct().OrderByDescending(n => n.NEWS_PUBLISHDATE).OrderByDescending(n => n.NEWS_ORDER_PERIOD).ToList();
                foreach (var i in list)
                {
                    Pro_details_entity pro = new Pro_details_entity();
                    pro.NEWS_ID = i.NEWS_ID;
                    pro.NEWS_TITLE = i.NEWS_TITLE;
                    pro.NEWS_IMAGE1 = i.NEWS_IMAGE1;
                    pro.NEWS_IMAGE3 = i.NEWS_IMAGE3;
                    pro.NEWS_DESC = i.NEWS_DESC;
                    pro.NEWS_SEO_URL = i.NEWS_SEO_URL;
                    pro.NEWS_URL = i.NEWS_URL;
                    pro.NEWS_PRICE1 = Utils.CDecDef(i.NEWS_PRICE1);
                    pro.NEWS_PRICE2 = Utils.CDecDef(i.NEWS_PRICE2);
                    pro.NEWS_ORDER_PERIOD = Utils.CIntDef(i.NEWS_ORDER_PERIOD);
                    pro.NEWS_PUBLISHDATE = Utils.CDateDef(i.NEWS_PUBLISHDATE, DateTime.Now);
                   
                    l.Add(pro);
                }
                return l;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Pro_details_entity> Loadpro_new(int type)
        {
            try
            {
                List<Pro_details_entity> l = new List<Pro_details_entity>();
                var list = (from a in db.ESHOP_NEWS_CATs
                            join b in db.ESHOP_NEWs on a.NEWS_ID equals b.NEWS_ID
                            join c in db.ESHOP_CATEGORies on a.CAT_ID equals c.CAT_ID
                            where b.NEWS_TYPE == type
                            select new { b.NEWS_ID, b.NEWS_TITLE, b.NEWS_IMAGE1, b.NEWS_IMAGE3, b.NEWS_PRICE1, b.NEWS_PRICE2, b.NEWS_DESC, b.NEWS_SEO_URL, b.NEWS_URL, b.NEWS_ORDER_PERIOD, b.NEWS_PUBLISHDATE }).Distinct().OrderByDescending(n => n.NEWS_PUBLISHDATE).OrderByDescending(n => n.NEWS_ORDER_PERIOD).ToList();
                foreach (var i in list)
                {
                    Pro_details_entity pro = new Pro_details_entity();
                    pro.NEWS_ID = i.NEWS_ID;
                    pro.NEWS_TITLE = i.NEWS_TITLE;
                    pro.NEWS_IMAGE1 = i.NEWS_IMAGE1;
                    pro.NEWS_IMAGE3 = i.NEWS_IMAGE3;
                    pro.NEWS_DESC = i.NEWS_DESC;
                    pro.NEWS_SEO_URL = i.NEWS_SEO_URL;
                    pro.NEWS_URL = i.NEWS_URL;
                    pro.NEWS_PRICE1 = Utils.CDecDef(i.NEWS_PRICE1);
                    pro.NEWS_PRICE2 = Utils.CDecDef(i.NEWS_PRICE2);
                    pro.NEWS_ORDER_PERIOD = Utils.CIntDef(i.NEWS_ORDER_PERIOD);
                    pro.NEWS_PUBLISHDATE = Utils.CDateDef(i.NEWS_PUBLISHDATE, DateTime.Now);
                    l.Add(pro);
                }
                return l;

            }
            catch (Exception)
            {

                throw;
            }
        }
        //Categories hien tri trang chu
        public List<ESHOP_CATEGORy>Load_cate_index(int limit, int type,int skip)
        {
            try
            {
                var list = db.ESHOP_CATEGORies.Where(n => n.CAT_STATUS == 1 && n.CAT_PERIOD == 1 && n.CAT_TYPE == type).OrderByDescending(n => n.CAT_PERIOD_ORDER).Skip(skip).Take(limit).ToList();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ESHOP_CATEGORy> Load_cate_index(int limit, int skip)
        {
            try
            {
                var list = db.ESHOP_CATEGORies.Where(n => n.CAT_STATUS == 1 && n.CAT_PERIOD == 1).OrderByDescending(n => n.CAT_PERIOD_ORDER).Skip(skip).Take(limit).ToList();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Load ajax cate news
        public List<ESHOP_CATEGORy> Load_cate_ajaxnews(int id)
        {
            try
            {
                var list = db.ESHOP_CATEGORies.Where(n => n.CAT_STATUS == 1 && n.CAT_ID == id).OrderByDescending(n => n.CAT_PERIOD_ORDER).ToList();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string GetTarget_Weblink(object link_url)
        {
            try
            {
                var list = db.ESHOP_WEBLINKs.Where(n => n.WEBSITE_LINKS_URL == link_url.ToString()).ToList();
                if (list.Count > 0)
                {
                    return list[0].WEBSITE_LINKS_TARGET;
                }
                return "";
            }
            catch
            {
                throw;
            }
        }
        public List<ESHOP_WEBLINK> loadwebsitelink()
        {
            try
            {
                var list = db.ESHOP_WEBLINKs.ToList();
                return list;
            }
            catch
            {
                throw;
            }
        }
        public IQueryable<ESHOP_CATEGORy> Load_cate_index_rank2(object cat_id, int limit)
        {
            int id = Utils.CIntDef(cat_id);
            var list = db.ESHOP_CATEGORies.Where(n => n.CAT_PARENT_ID == id).OrderByDescending(n => n.CAT_PERIOD_ORDER).Take(limit);
            return list.ToList().Count > 0 ? list : null;
        }
        public IQueryable<Pro_details_entity> Load_pro_index_cate(object catid, int per, int skip, int limit)
        {
            try
            {
                int id = Utils.CIntDef(catid);
                List<Pro_details_entity> l = new List<Pro_details_entity>();
                var list = (from a in db.ESHOP_NEWS_CATs
                            join b in db.ESHOP_NEWs on a.NEWS_ID equals b.NEWS_ID
                            join c in db.ESHOP_CATEGORies on a.CAT_ID equals c.CAT_ID
                            where (c.CAT_ID == id || c.CAT_PARENT_PATH.Contains(id.ToString())) & b.NEWS_FIELD1 == per.ToString()
                            select new { b.NEWS_COUNT, b.NEWS_VIDEO_URL, b.NEWS_FIELD3, b.NEWS_FIELD1, b.NEWS_FIELD2, b.NEWS_ID, b.NEWS_TITLE, b.NEWS_IMAGE3, b.NEWS_DESC, b.NEWS_SEO_URL, b.NEWS_PRICE2, b.NEWS_PRICE1, b.NEWS_URL, b.NEWS_ORDER, b.NEWS_PUBLISHDATE }).Distinct().OrderByDescending(n => n.NEWS_PUBLISHDATE).OrderByDescending(n => n.NEWS_ORDER).Skip(skip).Take(limit).ToList();
                foreach (var i in list)
                {
                    Pro_details_entity pro = new Pro_details_entity();
                    pro.NEWS_VIDEO_URL = i.NEWS_VIDEO_URL;
                    pro.NEWS_ID = i.NEWS_ID;
                    pro.NEWS_COUNT = Utils.CIntDef(i.NEWS_COUNT);
                    pro.NEWS_TITLE = i.NEWS_TITLE;
                    pro.NEWS_IMAGE3 = i.NEWS_IMAGE3;
                    pro.NEWS_DESC = i.NEWS_DESC;
                    pro.NEWS_SEO_URL = i.NEWS_SEO_URL;
                    pro.NEWS_URL = i.NEWS_URL;
                    pro.NEWS_ORDER = Utils.CIntDef(i.NEWS_ORDER);
                    pro.NEWS_PRICE1 = Utils.CDecDef(i.NEWS_PRICE1);
                    pro.NEWS_PRICE2 = Utils.CDecDef(i.NEWS_PRICE2);
                    pro.NEWS_PUBLISHDATE = Utils.CDateDef(i.NEWS_PUBLISHDATE, DateTime.Now);
                    pro.NEWS_FIELD1 = i.NEWS_FIELD1;
                    pro.NEWS_FIELD2 = i.NEWS_FIELD2;
                    pro.NEWS_FIELD3 = i.NEWS_FIELD3;
                    l.Add(pro);
                }
                return l.AsQueryable();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IQueryable<ESHOP_AD_ITEM> load_ads_cate(object cat_id, int pos)
        {
            int id = Utils.CIntDef(cat_id);
            var list = (from a in db.ESHOP_AD_ITEMs
                        join b in db.ESHOP_AD_ITEM_CATs on a.AD_ITEM_ID equals b.AD_ITEM_ID
                        where b.CAT_ID == id && a.AD_ITEM_POSITION == pos
                        select a).OrderByDescending(n => n.AD_ITEM_ID);
            return list.ToList().Count > 0 ? list : null;
        }
        public List<ESHOP_CATEGORy> loadListCateID(int cat_id)
        {
            var list = db.ESHOP_CATEGORies.Where(n => n.CAT_ID == cat_id).ToList();
            return list;
        }
        public List<ESHOP_CATEGORy> loadtopCate(int pos)
        {
            var list = db.ESHOP_CATEGORies.Where(n=>n.CAT_POSITION==pos).ToList();
            return list;
        }
        private string Get_Embed(string s)
        {
            try
            {
                return s.Substring(s.Length - 11, 11);
            }
            catch (Exception ex)
            {
                //clsVproErrorHandler.HandlerError(ex);
                return "";
            }
        }
        public string Load_video(int period)
        {
            string _sResult = "";
            var _vGetVideo = db.GetTable<ESHOP_NEW>().Where(n => n.NEWS_PERIOD == period).Select(n => new { n.NEWS_VIDEO_URL,n.NEWS_ID}).Take(1).OrderByDescending(a => a.NEWS_ID);

            if (_vGetVideo.ToList().Count > 0)
            {
                _sResult += "<iframe style='display: block; margin-left: auto; margin-right: auto; width:100%;height:220px' allowfullscreen='true'";
                _sResult += " src='http://www.youtube.com/embed/" + Get_Embed(_vGetVideo.ToList()[0].NEWS_VIDEO_URL) + "?rel=0' frameborder='0' height='260px' width='100%'></iframe>";
            }
            return _sResult;
        }
    }
}

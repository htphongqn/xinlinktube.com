﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using vpro.functions;

namespace Controller
{
    public class Order_now
    {
        #region Decclare
        dbVuonRauVietDataContext db = new dbVuonRauVietDataContext();
        #endregion
        public List<Order_entity> load_ordenow(int limit)
        {
            List<Order_entity> l = new List<Order_entity>();
            var list = (from a in db.ESHOP_ORDERs
                        join b in db.ESHOP_ORDER_ITEMs on a.ORDER_ID equals b.ORDER_ID
                        join c in db.ESHOP_NEWs on b.NEWS_ID equals c.NEWS_ID
                        join d in db.ESHOP_NEWS_CATs on c.NEWS_ID equals d.NEWS_ID
                        select new
                        {
                            c.NEWS_TITLE,
                            a.ORDER_NAME,
                            a.ORDER_ID,
                            c.NEWS_SEO_URL,
                            c.NEWS_URL,
                            d.ESHOP_CATEGORy.CAT_SEO_URL
                        }).OrderByDescending(n => n.ORDER_ID).Take(limit);
            foreach (var i in list)
            {
                Order_entity order = new Order_entity();
                order.CAT_SEO_URL = i.CAT_SEO_URL;
                order.NEWS_SEO_URL = i.NEWS_SEO_URL;
                order.NEWS_URL = i.NEWS_URL;
                order.ORDER_NAME = i.ORDER_NAME;
                order.NEWS_TITLE = i.NEWS_TITLE;
                l.Add(order);
            }
            return l;
        }
        public List<Order_entity> load_ordePaymentFinal(int id)
        {
            List<Order_entity> l = new List<Order_entity>();
            var list = (from a in db.ESHOP_ORDERs
                        join b in db.ESHOP_ORDER_ITEMs on a.ORDER_ID equals b.ORDER_ID
                        join c in db.ESHOP_NEWs on b.NEWS_ID equals c.NEWS_ID
                        join d in db.ESHOP_NEWS_CATs on c.NEWS_ID equals d.NEWS_ID
                        where a.ORDER_ID==id
                        select new
                        {
                            c.NEWS_TITLE,
                            a.ORDER_NAME,
                            a.ORDER_ID,
                            c.NEWS_SEO_URL,
                            c.NEWS_URL,
                            d.ESHOP_CATEGORy.CAT_SEO_URL,
                            c.NEWS_IMAGE3,
                            a.ORDER_ADDRESS,
                            c.NEWS_ID,
                            c.NEWS_PRICE1,
                            c.NEWS_PRICE2,
                            a.ORDER_CODE
                        }).OrderByDescending(n => n.ORDER_ID).Take(1);
            foreach (var i in list)
            {
                Order_entity order = new Order_entity();
                order.CAT_SEO_URL = i.CAT_SEO_URL;
                order.NEWS_SEO_URL = i.NEWS_SEO_URL;
                order.NEWS_URL = i.NEWS_URL;
                order.ORDER_NAME = i.ORDER_NAME;
                order.NEWS_TITLE = i.NEWS_TITLE;
                order.NEWS_IMAGE3 = i.NEWS_IMAGE3;
                order.NEWS_ID = Utils.CIntDef(i.NEWS_ID);
                order.ORDER_ADDRESS = i.ORDER_ADDRESS;
                order.NEWS_PRICE1 = Utils.CDecDef(i.NEWS_PRICE1);
                order.NEWS_PRICE2 = Utils.CDecDef(i.NEWS_PRICE2);
                order.ORDER_CODE = i.ORDER_CODE;
                l.Add(order);
            }
            return l;
        }
        public List<ESHOP_ORDER> checkOrder(string code, string email)
        {
            var list = db.ESHOP_ORDERs.Where(n => n.ORDER_CODE == code && n.ORDER_EMAIL == email).ToList();
            return list;
        }
    }
}

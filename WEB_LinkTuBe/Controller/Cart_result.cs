﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using vpro.functions;

namespace Controller
{
    public class Cart_result
    {
        #region Decclare
        dbVuonRauVietDataContext db = new dbVuonRauVietDataContext();
        #endregion
        //Load cart
        public List<Cart_result_entity> Load_cart(Guid _guid)
        {
            try
            {
                List<Cart_result_entity> l=new List<Cart_result_entity>();
                var list = from a in db.ESHOP_BASKETs
                           join b in db.ESHOP_NEWs on a.NEWS_ID equals b.NEWS_ID
                           where a.CUSTOMER_OID == _guid
                           select new
                           {
                               a.BASKET_QUANTITY,
                               a.BASKET_PRICE,
                               b.NEWS_ID,
                               b.NEWS_TITLE,
                               b.NEWS_SEO_URL,
                               b.NEWS_URL,
                               b.NEWS_IMAGE3,
                               a.BASKET_FIELD2,
                               a.BASKET_FIELD3
                           };
                foreach (var i in list)
                {
                    Cart_result_entity cart = new Cart_result_entity();
                    //cart.CAT_SEO_URL = i.CAT_SEO_URL;
                    cart.Basket_quantity =Utils.CIntDef(i.BASKET_QUANTITY);
                    cart.Basket_Price =Utils.CDecDef(i.BASKET_PRICE);
                    cart.NEWS_ID = i.NEWS_ID;
                    cart.NEWS_TITLE = i.NEWS_TITLE;
                    cart.NEWS_SEO_URL = i.NEWS_SEO_URL;
                    cart.NEWS_IMAGE3 = i.NEWS_IMAGE3;
                    cart.BASKET_FIELD2 = i.BASKET_FIELD2;
                    cart.BASKET_FIELD3 = i.BASKET_FIELD3;
                    l.Add(cart);
                }
                return l;
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }

        public int Total_quantity(Guid _guid)
        {
            int _quantity = 0;
            var _basket = (from a in db.ESHOP_BASKETs
                           where a.CUSTOMER_OID == _guid
                           select new
                           {
                               a.NEWS_ID,
                               a.BASKET_PRICE,
                               a.BASKET_QUANTITY
                           });
            _quantity = _basket.ToList().Count;

            return _quantity;
        }
        public decimal Total_Amount(Guid _guid)
        {
            decimal _totalAmount = 0;
            var _basket = (from a in db.ESHOP_BASKETs
                           where a.CUSTOMER_OID == _guid
                           select new
                           {
                               a.NEWS_ID,
                               a.BASKET_PRICE,
                               a.BASKET_QUANTITY
                           });
            foreach (var item in _basket)
            {
                double _rowTotal = double.Parse(item.BASKET_PRICE.ToString()) * double.Parse(item.BASKET_QUANTITY.ToString());
                _totalAmount += (decimal)_rowTotal;
            }
            
            return _totalAmount;
        }
        public bool Update_cart(Guid _guid, int NEWS_ID,int quantity)
        {
            try
            {
                if (quantity < 0 || quantity > 100)
                {
                    return false;
                }
                else
                {
                    var g = db.GetTable<ESHOP_BASKET>().Where(gid => gid.NEWS_ID == NEWS_ID && gid.CUSTOMER_OID == _guid);
                    if (g.ToList().Count > 0)
                    {
                        if (quantity == 0)
                        {
                            db.ESHOP_BASKETs.DeleteAllOnSubmit(g);
                            db.SubmitChanges();
                        }
                        else
                        {
                            g.ToList()[0].BASKET_QUANTITY = quantity;
                            db.SubmitChanges();
                        }
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public bool Delete_cart(Guid _guid, int NEWS_ID)
        {
            try
            {
                var g = db.GetTable<ESHOP_BASKET>().Where(gid => gid.NEWS_ID == NEWS_ID && gid.CUSTOMER_OID == _guid);
                db.ESHOP_BASKETs.DeleteAllOnSubmit(g);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public string Getnamecolor_size(object cat_id)
        {
            int id = Utils.CIntDef(cat_id);
            var list = db.ESHOP_CATEGORies.Where(n => n.CAT_ID == id).ToList();
            if (list.Count > 0) return list[0].CAT_NAME;
            return "";
        }
        public bool updateCartShip(Guid _guid, decimal price)
        {
            var list = db.ESHOP_BASKETs.Where(n => n.CUSTOMER_OID == _guid).ToList();
            if (list.Count > 0)
            {
                if (price != 0)
                {
                    list[0].BASKET_FIELD4 = price.ToString();
                    db.SubmitChanges();
                }
                
                return true;
            }
            return false;
        }
    }
}

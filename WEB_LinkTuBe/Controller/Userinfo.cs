using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using vpro.functions;

namespace Controller
{
    public class Userinfo
    {
        #region Decclare
        dbVuonRauVietDataContext db = new dbVuonRauVietDataContext();
        #endregion
        public string MaHoaMatKhau(string Password)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedDataBytes = md5Hasher.ComputeHash(System.Text.UTF8Encoding.UTF8.GetBytes(Password));
            string EncryptPass = Convert.ToBase64String(hashedDataBytes);
            return EncryptPass;
        }
        public bool checkmatkhau(string user_id, string pass)
        {
            try
            {
                var list = db.ESHOP_CUSTOMERs.Where(a => a.CUSTOMER_PW == pass && a.CUSTOMER_ID.ToString() == user_id).ToList();
                if (list.Count() > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
        public List<ESHOP_PROPERTy> Loadcity()
        {
            try
            {
                var list = db.ESHOP_PROPERTies.Where(n => n.PROP_RANK == 2).ToList();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ESHOP_PROPERTy> Loaddistric(int idpro)
        {
            try
            {
                var list = db.ESHOP_PROPERTies.Where(n => n.PROP_RANK == 3 && n.PROP_PARENT_ID == idpro).ToList();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public decimal getShip(int id)
        {
            var list = db.ESHOP_PROPERTies.Where(n => n.PROP_ID == id).ToList();
            if (list.Count > 0)
                return Utils.CIntDef(list[0].PROP_SHIPPING_FEE);
            return 0;
        }
        public string getnamePro(int id)
        {
            var list = db.ESHOP_PROPERTies.Where(n => n.PROP_ID == id).ToList();
            if (list.Count > 0)
                return list[0].PROP_NAME;
            return "";
        }
        protected void Lbthanhtoan_Click(object sender, EventArgs e)
        {
            try
            {

                //string _sEmailCC = string.Empty;
                //string _sEmail = txtEmail.Value;
                //string _sName = Txtname.Value;
                //string _add = "";
                //string _phone = Txtphone.Value;
                //string _content = txtContent.Value;
                //string _title = txttitle.Value;
                //cf.Insert_contact(_sName, _sEmail, _title, _content, _add, _phone);
                //    string _mailBody = string.Empty;
                //    _mailBody += "<br/><br/><strong>Tên khách hàng</strong>: " + _sName;
                //    _mailBody += "<br/><br/><strong>Email</strong>: " + _sEmail;
                //    _mailBody += "<br/><br/><strong>Số điện thoại</strong>: " + _phone;
                //    _mailBody += "<br/><br/><strong>Địa chỉ</strong>: " + _add;
                //    _mailBody += "<br/><br/><strong>Tiêu đề</strong>: " + _title;
                //    _mailBody += "<br/><br/><strong>Nội dung</strong>: " + _content + "<br/><br/>";
                //    string _sMailBody = string.Empty;
                //    _sMailBody += "Cám ơn quý khách: " + _sName + " đã đặt liên hệ với chúng tôi. Đây là email được gửi từ website của " + System.Configuration.ConfigurationManager.AppSettings["EmailDisplayName"] + " <br>" + _mailBody;
                //    _sEmailCC = cf.Getemail(2).Count > 0 ? cf.Getemail(2)[0].EMAIL_TO : "";
                //    sm.SendEmailSMTP("Thông báo: Bạn đã liên hệ thành công", _sEmail, _sEmailCC, "", _sMailBody, true, false);
                //    string strScript = "<script>";
                //    strScript += "alert(' Đã gửi thành công!');";
                //    strScript += "window.location='/';";
                //    strScript += "</script>";
                //    Page.RegisterClientScriptBlock("strScript", strScript);
                //}
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }
        public int DoiPass(string user_id, string passnew, string salt)
        {
            try
            {
                var _vUser = db.GetTable<ESHOP_CUSTOMER>().Where(a => a.CUSTOMER_ID.ToString() == user_id);
                _vUser.Single().CUSTOMER_PW = passnew;
                _vUser.Single().CUSTOMER_FIELD5 = salt;
                db.SubmitChanges();
                return 1;
            }
            catch
            {
                return -1;
            }
        }
        public string GetSALT(string email)
        {
            try
            {
                var user = db.ESHOP_CUSTOMERs.Where(n => n.CUSTOMER_EMAIL == email).ToList();
                if (user.Count() > 0)
                    return user[0].CUSTOMER_FIELD5;
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
        public string GetSALTbyID(string user_id)
        {
            try
            {
                var user = db.ESHOP_CUSTOMERs.Where(n => n.CUSTOMER_ID.ToString() == user_id).ToList();
                if (user.Count() > 0)
                    return user[0].CUSTOMER_FIELD5;
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
        public int updateuserpass(string email, string pass)
        {
            try
            {
                string SALT = string.Empty;
                SALT = Common.CreateSalt();
                string USER_PW = string.Empty;
                USER_PW = Common.Encrypt(pass, SALT);
                var user = db.ESHOP_CUSTOMERs.Where(n => n.CUSTOMER_EMAIL == email);
                foreach (var i in user)
                {
                    i.CUSTOMER_PW = USER_PW;
                    i.CUSTOMER_FIELD5 = SALT;
                    db.SubmitChanges();
                    return 1;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }
        public string laytennguoidung(string email)
        {
            try
            {
                var user = db.ESHOP_CUSTOMERs.Where(n => n.CUSTOMER_EMAIL == email).ToList();
                if (user.Count() > 0)
                    return user[0].CUSTOMER_FULLNAME;
                return "";
            }
            catch
            {
                return "";
            }
        }
        public bool checkmatkhau(string pass)
        {
            try
            {
                var list = db.ESHOP_CUSTOMERs.Where(a =>a.CUSTOMER_PW == pass).ToList();
                if (list.Count() > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
        public bool Login(string email, string pass)
        {
            try
            {
                var list = db.ESHOP_CUSTOMERs.Where(a => a.CUSTOMER_EMAIL == email && a.CUSTOMER_PW == pass).ToList();
                if (list.Count() > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
        public bool checkemail(object Email)
        {
            try
            {
                var list = db.ESHOP_MAIL_RECIVEs.Where(n => n.MAIL_NAME == Email).ToList();
                if (list.Count > 0)
                    return false;
                return true;
            }
            catch
            {
                throw;
            }
        }
        public void DangKyNhanTin(string Email)
        {
            try
            {
                ESHOP_MAIL_RECIVE mail = new ESHOP_MAIL_RECIVE();
                mail.MAIL_NAME = Email;
                mail.MAIL_ACTIVE = 1;
                db.ESHOP_MAIL_RECIVEs.InsertOnSubmit(mail);
                db.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }
        public List<ESHOP_CUSTOMER> Loaduserinfo(string userid)
        {
            var _vUser = db.GetTable<ESHOP_CUSTOMER>().Where(a => a.CUSTOMER_ID.ToString() == userid).ToList();
            return _vUser;
        }
        public List<ESHOP_CUSTOMER> Loaduserinfo(int userid)
        {
            var _vUser = db.GetTable<ESHOP_CUSTOMER>().Where(a => a.CUSTOMER_ID == userid).ToList();
            return _vUser;
        }
        public bool Updateuser(string email, string name, string phone, DateTime ngaysinh, string sex)
        {
            try
            {
                var _vUser = db.GetTable<ESHOP_CUSTOMER>().Where(a => a.CUSTOMER_EMAIL == email);
                foreach (var i in _vUser)
                {
                    i.CUSTOMER_FULLNAME = name;
                    i.CUSTOMER_PHONE1 = phone;
                    i.CUSTOMER_FIELD3 = sex;
                    i.CUSTOMER_PUBLISHDATE = ngaysinh;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
        public bool Updateuser(string userid, string address)
        {
            var _vUser = db.GetTable<ESHOP_CUSTOMER>().Where(a => a.CUSTOMER_ID.ToString() == userid);
            foreach (var i in _vUser)
            {
                i.CUSTOMER_ADDRESS = address;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool Updateuser(int userid, string name, string phone, string address, string city, string district, string sex, DateTime time, string pass1, string pass2, string passfm)
        {
            var _vUser = db.GetTable<ESHOP_CUSTOMER>().Where(a => a.CUSTOMER_ID == userid);
            foreach (var i in _vUser)
            {
                if (!string.IsNullOrEmpty(pass2))
                {
                    if (pass1.Trim() != pass2.Trim())
                    {
                        return false;
                    }
                    i.CUSTOMER_PW = passfm;
                }
                i.CUSTOMER_FULLNAME = name;
                i.CUSTOMER_PHONE1 = phone;
                i.CUSTOMER_ADDRESS = address;
                i.CUSTOMER_FIELD1 = city;
                i.CUSTOMER_FIELD2 = district;
                i.CUSTOMER_FIELD3 = sex;
                i.CUSTOMER_UPDATE = time;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}

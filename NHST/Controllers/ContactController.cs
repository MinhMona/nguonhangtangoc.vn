using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHST.Models;
using NHST.Bussiness;
using System.Data;
using WebUI.Business;
using MB.Extensions;

namespace NHST.Controllers
{
    public class ContactController
    {
        #region CRUD
        public static string Insert(string Fullname, string Email, string Phone,string ContactContent, bool IsRead, DateTime CreatedDate, string CreatedBy)
        {
            using (var dbe = new NHSTEntities())
            {
                tbl_Contact p = new tbl_Contact();
                p.Fullname = Fullname;
                p.Email = Email;
                p.Phone = Phone;
                p.ContactContent = ContactContent;
                p.IsRead = IsRead;
                p.CreatedDate = CreatedDate;
                p.CreatedBy = CreatedBy;
                dbe.tbl_Contact.Add(p);
                dbe.Configuration.ValidateOnSaveEnabled = false;
                int kq = dbe.SaveChanges();
                string k = p.ID.ToString();
                return k;
            }
        }
        public static string Update(int ID, bool IsRead, DateTime ModifiedDate, string ModifiedBy)
        {
            using (var dbe = new NHSTEntities())
            {
                var p = dbe.tbl_Contact.Where(pa => pa.ID == ID).FirstOrDefault();
                if (p != null)
                {
                    p.IsRead = IsRead;
                    p.ModifiedBy = ModifiedBy;
                    p.ModifiedDate = ModifiedDate;
                    dbe.Configuration.ValidateOnSaveEnabled = false;
                    string kq = dbe.SaveChanges().ToString();
                    return kq;
                }
                else
                    return null;
            }
        }

        public static string Delete(int ID)
        {
            using (var dbe = new NHSTEntities())
            {
                var p = dbe.tbl_Menu.Where(pa => pa.ID == ID).FirstOrDefault();
                if (p != null)
                {
                    dbe.tbl_Menu.Remove(p);
                    dbe.SaveChanges();
                    return "ok";
                }
                else
                    return null;
            }
        }
        #endregion
        #region Select
        public static List<tbl_Contact> GetAll(string s)
        {
            using (var dbe = new NHSTEntities())
            {
                List<tbl_Contact> pages = new List<tbl_Contact>();
                pages = dbe.tbl_Contact.Where(p => p.Fullname.Contains(s)).OrderByDescending(a => a.CreatedDate).ToList();
                return pages;
            }
        }

        public static tbl_Contact GetByID(int ID)
        {
            using (var dbe = new NHSTEntities())
            {
                tbl_Contact page = dbe.tbl_Contact.Where(p => p.ID == ID).FirstOrDefault();
                if (page != null)
                    return page;
                else
                    return null;
            }
        }
        #endregion

        public static string InsertNew(string Fullname, string Email, string Phone, string ContactContent, int Status, DateTime CreatedDate, string CreatedBy)
        {
            using (var dbe = new NHSTEntities())
            {
                tbl_Contact p = new tbl_Contact();
                p.Fullname = Fullname;
                p.Email = Email;
                p.Phone = Phone;
                p.ContactContent = ContactContent;
                p.Status = Status;
                p.CreatedDate = CreatedDate;
                p.CreatedBy = CreatedBy;
                dbe.tbl_Contact.Add(p);
                dbe.Configuration.ValidateOnSaveEnabled = false;
                int kq = dbe.SaveChanges();
                string k = p.ID.ToString();
                return k;
            }
        }
        public static string UpdateNew(int ID, int Status, DateTime ModifiedDate, string ModifiedBy)
        {
            using (var dbe = new NHSTEntities())
            {
                var p = dbe.tbl_Contact.Where(pa => pa.ID == ID).FirstOrDefault();
                if (p != null)
                {
                    p.Status = Status;
                    p.ModifiedBy = ModifiedBy;
                    p.ModifiedDate = ModifiedDate;
                    dbe.Configuration.ValidateOnSaveEnabled = false;
                    string kq = dbe.SaveChanges().ToString();
                    return kq;
                }
                else
                    return null;
            }
        }

        public static int GetTotal(string s, string phone, int Status)
        {
            var sql = @"select Total=Count(*) ";
            sql += "from tbl_Contact ";
            sql += "Where  FullName like N'%" + s + "%' and Phone like N'%" + phone + "%'";
            if (Status > 0)
            {
                sql += " and Status=" + Status + " ";
            }
            var reader = (IDataReader)SqlHelper.ExecuteDataReader(sql);
            int a = 0;
            while (reader.Read())
            {
                if (reader["Total"] != DBNull.Value)
                    a = reader["Total"].ToString().ToInt(0);

            }
            reader.Close();
            return a;
        }
        public static List<tbl_Contact> GetAllBySQL(string s, string phone, int pageIndex, int pageSize, int Status)
        {
            var sql = @"select * ";
            sql += "from tbl_Contact ";
            sql += "Where FullName Like N'%" + s + "%' and Phone Like N'%" + phone + "%'";
            if (Status > 0)
            {
                sql += " and Status=" + Status + " ";
            }
            sql += "order by id DESC OFFSET " + pageIndex + "*" + pageSize + " ROWS FETCH NEXT " + pageSize + " ROWS ONLY";
            var reader = (IDataReader)SqlHelper.ExecuteDataReader(sql);
            List<tbl_Contact> a = new List<tbl_Contact>();
            while (reader.Read())
            {
                var entity = new tbl_Contact();
                if (reader["ID"] != DBNull.Value)
                    entity.ID = reader["ID"].ToString().ToInt(0);

                if (reader["Fullname"] != DBNull.Value)
                    entity.Fullname = reader["Fullname"].ToString();

                if (reader["Phone"] != DBNull.Value)
                    entity.Phone = reader["Phone"].ToString();

                if (reader["ContactContent"] != DBNull.Value)
                    entity.ContactContent = reader["ContactContent"].ToString();

                if (reader["CreatedDate"] != DBNull.Value)
                    entity.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());

                if (reader["Status"] != DBNull.Value)
                    entity.Status = Convert.ToInt32(reader["Status"].ToString());

                a.Add(entity);
            }
            reader.Close();
            return a;
        }

    }
}
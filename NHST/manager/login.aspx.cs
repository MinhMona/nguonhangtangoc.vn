using NHST.Models;
using NHST.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Net;
using Supremes;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using NHST.Bussiness;
using NHST.Hubs;

namespace NHST.manager
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userLoginSystem"] == null)
                {

                }
                else
                {
                    string username_current = Session["userLoginSystem"].ToString();
                    var obj_user = AccountController.GetByUsername(username_current);
                    if (obj_user != null)
                    {
                        int role = Convert.ToInt32(obj_user.RoleID);

                        if (obj_user.RoleID == 1)                       
                            Response.Redirect("/");                        
                        else if (role == 3 || role == 9)
                            Response.Redirect("/manager/OrderList.aspx");
                        else if (role == 4)
                            Response.Redirect("/manager/TQWareHouse-DHH.aspx");
                        else if (role == 5)
                            Response.Redirect("/manager/VNWarehouse-DHH.aspx");
                        else if (role == 6)
                            Response.Redirect("/manager/Sale-Home.aspx");
                        else
                            Response.Redirect("/manager/home.aspx");
                    }
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = rUser.Text;
            string password = rPass.Text;
            var ac = AccountController.Login(username.Trim().ToLower(), password.Trim());
            ChatHub ch = new ChatHub();
            if (ac != null)
            {
                if (ac.RoleID != 1)
                {
                    Session["userLoginSystem"] = username;
                    Session["StateLogin"] = TokenSession.CreateAndStoreSessionToken(rUser.Text);
                    ac = AccountController.GetByID(ac.ID);
                    ch.Login(ac.ID.ToString(), ac.LoginStatus);
                    Response.Redirect("/manager/Home.aspx");
                }
                else
                {
                    Response.Redirect("/trang-chu");
                }
            }
            else
            {
                lblError.Text = "Sai Username hoặc Password, vui lòng kiểm tra lại.";
                lblError.Visible = true;
            }
        }
    }
}
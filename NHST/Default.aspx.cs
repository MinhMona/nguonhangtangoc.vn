using NHST.Bussiness;
using NHST.Controllers;
using Supremes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NHST
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            var ck = CustomerBenefitsController.GetAllByItemType(2);
            if (ck.Count > 0)
            {
                double time1 = 0.3;               
                foreach (var item in ck)
                {                   
                    ltrCamKet.Text += "<article class=\"feat-box wow animate__bounceInUp\" data-wow-delay=\"" + time1 + "s\" data-wow-duration=\"1s\">";
                    ltrCamKet.Text += " <div class=\"img\"><img src=\"" + item.Icon + "\" alt=\"\"></div>";
                    ltrCamKet.Text += "     <h3 class=\"title\">" + item.CustomerBenefitName + "</h3>";
                    ltrCamKet.Text += "     <p class=\"smr\">" + item.CustomerBenefitDescription + "</p>";
                    ltrCamKet.Text += "</article>";
                    time1 = time1 + 0.2;                    
                }
            }

            var steps = StepController.GetAll("");
            if (steps.Count > 0)
            {
                double time = 0.3;
                for (int i = 0; i < steps.Count(); i++)
                {
                    int t = i + 1;
                    var item = steps[i];
                    string bg = "step-" + t;
                    if (i == 0)
                    {
                        ltrStepName.Text += "<li class=\"step-item active current wow animate__jackInTheBox\" data-wow-delay=\"" + time + "s\" data-toggle=\"register-steps\">";
                        ltrStepName.Text += "  <div class=\"img\"><span class=\"img-step " + bg + "\"></span></div>";
                        ltrStepName.Text += "   <h3 class=\"lb\">" + item.StepName + "</h3>";
                        ltrStepName.Text += "  </li>";
                    }
                    else
                    {
                        ltrStepName.Text += "<li class=\"step-item active wow animate__jackInTheBox\" data-wow-delay=\"" + time + "s\" data-toggle=\"register-steps\">";
                        ltrStepName.Text += "  <div class=\"img\"><span class=\"img-step " + bg + "\" alt=\"" + item.StepName + "\"></span></div>";
                        ltrStepName.Text += "   <h3 class=\"lb\">" + item.StepName + "</h3>";
                        ltrStepName.Text += "  </li>";
                    }

                    ltrStepContent.Text += " <div class=\"slider-item\">";
                    ltrStepContent.Text += " <div class=\"img wow animate__bounceInLeft\">";
                    ltrStepContent.Text += "  <img src=\"" + item.StepIMG + "\" >";
                    ltrStepContent.Text += "  </div>";

                    ltrStepContent.Text += "<div class=\"info wow animate__backInRight\">";
                    ltrStepContent.Text += "<a href=\"" + item.StepLink + "\" class=\"title link-custom\">" + item.StepName + "</a>";
                    ltrStepContent.Text += " <p class=\"summary\">" + item.StepContent + "</p>";
                    if (!string.IsNullOrEmpty(item.StepLink))
                    {
                        ltrStepContent.Text += " <a href=\"" + item.StepLink + "\" class=\"btn wow animate__flipInX\">Chi tiết</a>";
                    }
                    ltrStepContent.Text += " </div>";
                    ltrStepContent.Text += " </div>";

                    time = time + 0.2;
                }
            }

            var confi = ConfigurationController.GetByTop1();
            try
            {
                ltrTimework.Text = "<p>" + confi.TimeWork + "</p>";
                ltrHotline.Text += "<p><a href=\"tel:" + confi.Hotline + "\">" + confi.Hotline + "</a></p>";
                ltrEmail.Text += "<p><a href=\"mailto:" + confi.EmailContact + "\">" + confi.EmailContact + "</a></p>";

                ltrAddressCt.Text = "<a>" + confi.Address + "</a>";
                ltrAddressKhoMN.Text = "<a>" + confi.Address2 + "</a>";
                ltrAddressKhoMN2.Text = "<a>" + confi.Address2 + "</a>";
                ltrHotlineCt.Text += "<a href=\"tel:" + confi.Hotline + "\">" + confi.Hotline + "</a>";
                ltrHotlineCt2.Text += "<a href=\"tel:" + confi.HotlineSupport + "\">" + confi.HotlineSupport + "</a>";
                ltrHotlineKhoHN.Text += "<a href=\"tel:" + confi.HotlineFeedback + "\">" + confi.HotlineFeedback + "</a>";
                ltrHotlineKhoMN.Text += "<a href=\"tel:" + confi.HotlineMN + "\">" + confi.HotlineMN + "</a>";             


                string weblink = "https://nguonhangtangoc.vn/";
                string url = HttpContext.Current.Request.Url.AbsoluteUri;

                HtmlHead objHeader = (HtmlHead)Page.Header;

                //we add meta description
                HtmlMeta objMetaFacebook = new HtmlMeta();

                objMetaFacebook = new HtmlMeta();
                objMetaFacebook.Attributes.Add("property", "fb:app_id");
                objMetaFacebook.Content = "676758839172144";
                objHeader.Controls.Add(objMetaFacebook);

                objMetaFacebook = new HtmlMeta();
                objMetaFacebook.Attributes.Add("property", "og:url");
                objMetaFacebook.Content = url;
                objHeader.Controls.Add(objMetaFacebook);

                objMetaFacebook = new HtmlMeta();
                objMetaFacebook.Attributes.Add("property", "og:type");
                objMetaFacebook.Content = "website";
                objHeader.Controls.Add(objMetaFacebook);

                objMetaFacebook = new HtmlMeta();
                objMetaFacebook.Attributes.Add("property", "og:title");
                objMetaFacebook.Content = confi.OGTitle;
                objHeader.Controls.Add(objMetaFacebook);

                objMetaFacebook = new HtmlMeta();
                objMetaFacebook.Attributes.Add("property", "og:description");
                objMetaFacebook.Content = confi.OGDescription;
                objHeader.Controls.Add(objMetaFacebook);

                objMetaFacebook = new HtmlMeta();
                objMetaFacebook.Attributes.Add("property", "og:image");
                objMetaFacebook.Content = weblink + "/App_Themes/CSSNHTG/images/logo.png";
                objHeader.Controls.Add(objMetaFacebook);

                objMetaFacebook = new HtmlMeta();
                objMetaFacebook.Attributes.Add("property", "og:image:width");
                objMetaFacebook.Content = "200";
                objHeader.Controls.Add(objMetaFacebook);

                objMetaFacebook = new HtmlMeta();
                objMetaFacebook.Attributes.Add("property", "og:image:height");
                objMetaFacebook.Content = "500";
                objHeader.Controls.Add(objMetaFacebook);

                HtmlMeta meta = new HtmlMeta();
                meta = new HtmlMeta();
                meta.Attributes.Add("name", "description");
                meta.Content = confi.MetaDescription;

                objHeader.Controls.Add(meta);
                this.Title = confi.MetaTitle;

                objMetaFacebook = new HtmlMeta();
                objMetaFacebook.Attributes.Add("property", "og:title");
                objMetaFacebook.Content = confi.OGTitle;
                objHeader.Controls.Add(objMetaFacebook);

                objMetaFacebook = new HtmlMeta();
                objMetaFacebook.Attributes.Add("property", "twitter:title");
                objMetaFacebook.Content = confi.OGTwitterTitle;
                objHeader.Controls.Add(objMetaFacebook);

                objMetaFacebook = new HtmlMeta();
                objMetaFacebook.Attributes.Add("property", "twitter:description");
                objMetaFacebook.Content = confi.OGTwitterDescription;
                objHeader.Controls.Add(objMetaFacebook);

                objMetaFacebook = new HtmlMeta();
                objMetaFacebook.Attributes.Add("property", "twitter:image");
                objMetaFacebook.Content = weblink + confi.OGTwitterImage;
                objHeader.Controls.Add(objMetaFacebook);

                objMetaFacebook = new HtmlMeta();
                objMetaFacebook.Attributes.Add("property", "twitter:image:width");
                objMetaFacebook.Content = "200";
                objHeader.Controls.Add(objMetaFacebook);

                objMetaFacebook = new HtmlMeta();
                objMetaFacebook.Attributes.Add("property", "twitter:image:height");
                objMetaFacebook.Content = "500";
                objHeader.Controls.Add(objMetaFacebook);

                HtmlLink canonicalTag = new HtmlLink();
                canonicalTag.Attributes["rel"] = "canonical";
                canonicalTag.Href = weblink;
                Page.Header.Controls.Add(canonicalTag);
            }
            catch
            {

            }
        }

        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();  //or use SHA1.Create();
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(inputString);
            return bytes;
        }
        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append("%" + b.ToString("X2"));

            return sb.ToString();
        }
        public void SearchPage(string page, string text)
        {
            string linkgo = "";
            if (page == "tmall")
            {
                string a = text;
                string textsearch_tmall = GetHashString(a);
                //string fullLinkSearch_tmall = "https://list.tmall.com/search_product.htm?q=" + textsearch_tmall + "&type=p&vmarket=&spm=875.7931836%2FB.a2227oh.d100&from=mallfp..pc_1_searchbutton";
                linkgo = "https://list.tmall.com/search_product.htm?q=" + textsearch_tmall + "&type=p&vmarket=&spm=875.7931836%2FB.a2227oh.d100&from=mallfp..pc_1_searchbutton";
            }
            else if (page == "taobao")
            {
                string a = text;
                string textsearch_taobao = GetHashString(a);
                //string fullLinkSearch_taobao = "https://world.taobao.com/search/search.htm?q=" + textsearch_taobao + "&navigator=all&_input_charset=&spm=a21bp.7806943.20151106.1";
                linkgo = "https://world.taobao.com/search/search.htm?q=" + textsearch_taobao + "&navigator=all&_input_charset=&spm=a21bp.7806943.20151106.1";
                //https://world.taobao.com/search/search.htm?q=%B9%AB%BC%A6&navigator=all&_input_charset=&spm=a21bp.7806943.20151106.1
            }
            else if (page == "1688")
            {
                string a = text;
                string textsearch_1688 = GetHashString(a);
                //string fullLinkSearch_1688 = "https://s.1688.com/selloffer/offer_search.htm?keywords=" + textsearch_1688 + "&button_click=top&earseDirect=false&n=y";
                linkgo = "https://s.1688.com/selloffer/offer_search.htm?keywords=" + textsearch_1688 + "&button_click=top&earseDirect=false&n=y";
            }
            Response.Redirect(linkgo);
        }

        [WebMethod]
        public static string getPopup()
        {
            if (HttpContext.Current.Session["notshowpopup"] == null)
            {
                var conf = ConfigurationController.GetByTop1();
                string popup = conf.NotiPopupTitle;
                if (!string.IsNullOrEmpty(popup))
                {
                    NotiInfo n = new NotiInfo();
                    n.NotiTitle = conf.NotiPopupTitle;
                    n.NotiEmail = conf.NotiPopupEmail;
                    n.NotiContent = conf.NotiPopup;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    return serializer.Serialize(n);
                }
                else
                    return "null";
            }
            else
                return null;
        }
        [WebMethod]
        public static void setNotshow()
        {
            HttpContext.Current.Session["notshowpopup"] = "1";
        }
        [WebMethod]
        public static string closewebinfo()
        {
            HttpContext.Current.Session["infoclose"] = "ok";
            return "ok";
        }
        public class NotiInfo
        {
            public string NotiTitle { get; set; }
            public string NotiContent { get; set; }
            public string NotiEmail { get; set; }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            DateTime currentDate = DateTime.Now;

            string FullName = txtFullName.Text.Trim();
            string Email = txtEmail.Text.Trim();
            string Phone = txtPhone.Text.Trim();
            string Note = txtNoteContact.Text.Trim();

            var rs = ContactController.InsertNew(FullName, Email, Phone, Note, 1, currentDate, FullName);
            if (rs != null)
            {
                PJUtils.ShowMessageBoxSwAlert("Gửi yêu cầu thành công.", "s", true, Page);

                var setNoti = SendNotiEmailController.GetByID(1);
                if (setNoti != null)
                {
                    if (setNoti.IsSentNotiAdmin == true)
                    {
                        var admins = AccountController.GetAllByRoleID(0);
                        if (admins.Count > 0)
                        {
                            foreach (var admin in admins)
                            {
                                NotificationsController.Inser(admin.ID, admin.Username, 0, "Có khách hàng vừa yêu cầu Nguồn hàng Tận Gốc liên hệ là: " + FullName, 6, DateTime.UtcNow.AddHours(7), FullName, false);
                            }
                        }
                        //var cskhs = AccountController.GetAllByRoleID(18);
                        //if (cskhs.Count > 0)
                        //{
                        //    foreach (var cskh in cskhs)
                        //    {
                        //        NotificationsController.Inser(cskh.ID, cskh.Username, 0, "Có khách hàng vừa yêu cầu Nguồn hàng Tận Gốc liên hệ là: " + FullName, 6, DateTime.UtcNow.AddHours(7), FullName, false);
                        //    }
                        //}
                    }
                }
            }
            else
            {
                PJUtils.ShowMessageBoxSwAlert("Có lỗi trong quá trình gửi. Vui lòng thử lại.", "e", true, Page);
            }

        }
    }
}
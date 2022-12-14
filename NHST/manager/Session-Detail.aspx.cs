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
using MB.Extensions;
using Telerik.Web.UI;
using System.Web.Script.Serialization;

namespace NHST.manager
{
    public partial class Session_Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userLoginSystem"] == null)
                {
                    Response.Redirect("/trang-chu");
                }
                else
                {
                    string username_current = Session["userLoginSystem"].ToString();
                    tbl_Account ac = AccountController.GetByUsername(username_current);
                    if (ac != null)
                    {
                        LoadData();
                    }
                }
            }
        }

        public void LoadData()
        {
            string username_current = Session["userLoginSystem"].ToString();
            var ac = AccountController.GetByUsername(username_current);
            if (ac != null)
            {
                if (ac.RoleID == 0)
                {
                    pnAdmin.Visible = true;
                }

                string search = "";
                if (!string.IsNullOrEmpty(Request.QueryString["s"]))
                {
                    search = Request.QueryString["s"].ToString().Trim();
                    tSearchName.Text = search;
                }
                int page = 0;
                Int32 Page = GetIntFromQueryString("Page");
                if (Page > 0)
                {
                    page = Page - 1;
                }
                int i = Request.QueryString["ID"].ToInt(0);
                if (i > 0)
                {
                    ViewState["ID"] = i;

                    string NameSession = "";
                    double Weight = 0;
                    int TotalPackage = 0;

                    var session = WorkingSessionController.GetByID(i);
                    NameSession = session.NameSession;
                    txtPackageCode.Text = NameSession;
                    txtPackageNote.Text = session.NoteSession;
                    ltrPackageName.Text = "Phiên làm việc: " + NameSession;

                    var sm = SmallPackageController.GetBySessionID(i);
                    if (sm != null)
                    {
                        if (sm.Count > 0)
                        {
                            TotalPackage = sm.Count;
                            double totalweight = 0;
                            foreach (var item in sm)
                            {
                                double compareSize = 0;
                                double weight = Convert.ToDouble(item.Weight);
                                double pDai = Convert.ToDouble(item.Length);
                                double pRong = Convert.ToDouble(item.Width);
                                double pCao = Convert.ToDouble(item.Height);
                                if (pDai > 0 && pRong > 0 && pCao > 0)
                                {
                                    compareSize = (pDai * pRong * pCao) / 6000;
                                }
                                if (weight >= compareSize)
                                {
                                    totalweight += weight;
                                }
                                else
                                {
                                    totalweight += compareSize;
                                }
                            }
                            Weight = totalweight;
                        }
                    }

                    pWeight.Value = Weight;
                    pTotalPackage.Value = TotalPackage;
                    ddlStatus.SelectedValue = session.Status.ToString();

                    var total = SmallPackageController.GetTotalByWorkingSessionID(i, search);
                    var la = SmallPackageController.GetAllBySQLWorkingSessionID(i, search, page, 20);
                    pagingall(la, total);
                }
            }
        }

        #region Pagging
        public void pagingall(List<SmallPackageController.ShowWorkingSession> acs, int total)
        {
            int PageSize = 20;
            if (total > 0)
            {
                int TotalItems = total;
                if (TotalItems % PageSize == 0)
                    PageCount = TotalItems / PageSize;
                else
                    PageCount = TotalItems / PageSize + 1;
                Int32 Page = GetIntFromQueryString("Page");

                if (Page == -1) Page = 1;
                int FromRow = (Page - 1) * PageSize;
                int ToRow = Page * PageSize - 1;
                if (ToRow >= TotalItems)
                    ToRow = TotalItems - 1;

                int page = 0;
                if (Page > 0)
                    page = Page - 1;

                int stt = (page * PageSize);
                StringBuilder hcm = new StringBuilder();
                for (int i = 0; i < acs.Count; i++)
                {
                    stt++;
                    var item = acs[i];
                    hcm.Append("<tr>");
                    hcm.Append("<td>" + stt + "</td>");
                    hcm.Append("<td>" + item.Username + "</td>");
                    hcm.Append("<td>" + item.MainOrderID + "</td>");
                    hcm.Append("<td>" + item.OrderTransactionCode + "</td>");
                    hcm.Append("<td>" + item.Weight + "</td>");
                    hcm.Append("<td>" + item.Length + "</td>");
                    hcm.Append("<td>" + item.Width + "</td>");
                    hcm.Append("<td>" + item.Height + "</td>");
                    hcm.Append("<td>" + item.UserNote + "</td>");
                    hcm.Append("<td>" + item.Description + "</td>");
                    hcm.Append("<td>" + item.StatusString + "</td>");
                    hcm.Append("<td>" + item.CreatedDateString + "</td>");
                    //hcm.Append("<td>");
                    //hcm.Append("<div class=\"action-table\">");
                    //hcm.Append("<a ID=" + item.ID + " onclick=\"CallBtn(" + item.ID + ")\" href = \"mavandon-chitiet.php\" class=\"tooltipped edit-mode\" data-position=\"top\" data-tooltip=\"Cập nhật\"><i class=\"material-icons\">edit</i></a>");
                    //hcm.Append("</div>");
                    //hcm.Append("</td>");
                    hcm.Append("</tr>");
                }
                ltr.Text = hcm.ToString();
            }
        }
        [WebMethod]
        public static string loadinfo(string ID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var p = SmallPackageController.GetByID(Convert.ToInt32(ID));
            if (p != null)
            {

                tbl_SmallPackage l = new tbl_SmallPackage();
                l.ID = p.ID;
                l.MainOrderID = p.MainOrderID;
                l.OrderTransactionCode = p.OrderTransactionCode;
                l.ProductType = p.ProductType;
                l.FeeShip = p.FeeShip;
                l.Weight = p.Weight;
                l.Volume = p.Volume;
                l.IMGPackage = p.IMGPackage;
                l.Description = p.Description;
                l.Status = p.Status;
                l.BigPackageID = p.BigPackageID;
                return serializer.Serialize(l);
            }
            return serializer.Serialize(null);
        }
        public static Int32 GetIntFromQueryString(String key)
        {
            Int32 returnValue = -1;
            String queryStringValue = HttpContext.Current.Request.QueryString[key];
            try
            {
                if (queryStringValue == null)
                    return returnValue;
                if (queryStringValue.IndexOf("#") > 0)
                    queryStringValue = queryStringValue.Substring(0, queryStringValue.IndexOf("#"));
                returnValue = Convert.ToInt32(queryStringValue);
            }
            catch
            { }
            return returnValue;
        }
        private int PageCount;
        protected void DisplayHtmlStringPaging1()
        {
            Int32 CurrentPage = Convert.ToInt32(Request.QueryString["Page"]);
            if (CurrentPage == -1) CurrentPage = 1;
            string[] strText = new string[4] { "Trang đầu", "Trang cuối", "Trang sau", "Trang trước" };
            if (PageCount > 1)
                Response.Write(GetHtmlPagingAdvanced(6, CurrentPage, PageCount, Context.Request.RawUrl, strText));
        }
        private static string GetPageUrl(int currentPage, string pageUrl)
        {
            pageUrl = Regex.Replace(pageUrl, "(\\?|\\&)*" + "Page=" + currentPage, "");
            if (pageUrl.IndexOf("?") > 0)
            {
                pageUrl += "&Page={0}";
            }
            else
            {
                pageUrl += "?Page={0}";
            }
            return pageUrl;
        }
        public static string GetHtmlPagingAdvanced(int pagesToOutput, int currentPage, int pageCount, string currentPageUrl, string[] strText)
        {
            //Nếu Số trang hiển thị là số lẻ thì tăng thêm 1 thành chẵn
            if (pagesToOutput % 2 != 0)
            {
                pagesToOutput++;
            }

            //Một nửa số trang để đầu ra, đây là số lượng hai bên.
            int pagesToOutputHalfed = pagesToOutput / 2;

            //Url của trang
            string pageUrl = GetPageUrl(currentPage, currentPageUrl);


            //Trang đầu tiên
            int startPageNumbersFrom = currentPage - pagesToOutputHalfed; ;

            //Trang cuối cùng
            int stopPageNumbersAt = currentPage + pagesToOutputHalfed; ;

            StringBuilder output = new StringBuilder();

            //Nối chuỗi phân trang
            //output.Append("<div class=\"paging\">");
            //output.Append("<ul class=\"paging_hand\">");

            //Link First(Trang đầu) và Previous(Trang trước)
            if (currentPage > 1)
            {
                //output.Append("<li class=\"UnselectedPrev \" ><a title=\"" + strText[0] + "\" href=\"" + string.Format(pageUrl, 1) + "\">|<</a></li>");
                //output.Append("<li class=\"UnselectedPrev\" ><a title=\"" + strText[1] + "\" href=\"" + string.Format(pageUrl, currentPage - 1) + "\"><i class=\"fa fa-angle-left\"></i></a></li>");
                output.Append("<a class=\"prev-page pagi-button\" title=\"" + strText[1] + "\" href=\"" + string.Format(pageUrl, currentPage - 1) + "\">Prev</a>");
                //output.Append("<span class=\"Unselect_prev\"><a href=\"" + string.Format(pageUrl, currentPage - 1) + "\"></a></span>");
            }

            /******************Xác định startPageNumbersFrom & stopPageNumbersAt**********************/
            if (startPageNumbersFrom < 1)
            {
                startPageNumbersFrom = 1;

                //As page numbers are starting at one, output an even number of pages.  
                stopPageNumbersAt = pagesToOutput;
            }

            if (stopPageNumbersAt > pageCount)
            {
                stopPageNumbersAt = pageCount;
            }

            if ((stopPageNumbersAt - startPageNumbersFrom) < pagesToOutput)
            {
                startPageNumbersFrom = stopPageNumbersAt - pagesToOutput;
                if (startPageNumbersFrom < 1)
                {
                    startPageNumbersFrom = 1;
                }
            }
            /******************End: Xác định startPageNumbersFrom & stopPageNumbersAt**********************/

            //Các dấu ... chỉ những trang phía trước  
            if (startPageNumbersFrom > 1)
            {
                output.Append("<a href=\"" + string.Format(GetPageUrl(currentPage - 1, pageUrl), startPageNumbersFrom - 1) + "\">&hellip;</a>");
            }

            //Duyệt vòng for hiển thị các trang
            for (int i = startPageNumbersFrom; i <= stopPageNumbersAt; i++)
            {
                if (currentPage == i)
                {
                    output.Append("<a class=\"pagi-button current-active\">" + i.ToString() + "</a>");
                }
                else
                {
                    output.Append("<a class=\"pagi-button\" href=\"" + string.Format(pageUrl, i) + "\">" + i.ToString() + "</a>");
                }
            }

            //Các dấu ... chỉ những trang tiếp theo  
            if (stopPageNumbersAt < pageCount)
            {
                output.Append("<a href=\"" + string.Format(pageUrl, stopPageNumbersAt + 1) + "\">&hellip;</a>");
            }

            //Link Next(Trang tiếp) và Last(Trang cuối)
            if (currentPage != pageCount)
            {
                //output.Append("<span class=\"Unselect_next\"><a href=\"" + string.Format(pageUrl, currentPage + 1) + "\"></a></span>");
                //output.Append("<li class=\"UnselectedNext\" ><a title=\"" + strText[2] + "\" href=\"" + string.Format(pageUrl, currentPage + 1) + "\"><i class=\"fa fa-angle-right\"></i></a></li>");
                output.Append("<a class=\"next-page pagi-button\" title=\"" + strText[2] + "\" href=\"" + string.Format(pageUrl, currentPage + 1) + "\">Next</a>");
                //output.Append("<li class=\"UnselectedNext\" ><a title=\"" + strText[3] + "\" href=\"" + string.Format(pageUrl, pageCount) + "\">>|</a></li>");
            }
            //output.Append("</ul>");
            //output.Append("</div>");
            return output.ToString();
        }
        #endregion

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            int i = ViewState["ID"].ToString().ToInt(0);
            if (i > 0)
            {
                var la = SmallPackageController.GetAllBySQLWorkingSessionIDExcel(i);
                StringBuilder StrExport = new StringBuilder();
                StrExport.Append(@"<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:excel' xmlns='http://www.w3.org/TR/REC-html40'><head><title>Time</title>");
                StrExport.Append(@"<body lang=EN-US style='mso-element:header' id=h1><span style='mso--code:DATE'></span><div class=Section1>");
                StrExport.Append("<DIV  style='font-size:12px;'>");
                StrExport.Append("<table border=\"1\">");
                StrExport.Append("  <tr>");
                StrExport.Append("      <th><strong>STT</strong></th>");
                StrExport.Append("      <th style=\"mso-number-format:'\\@'\"><strong>Username</strong></th>");
                StrExport.Append("      <th style=\"mso-number-format:'\\@'\"><strong>Mã đơn hàng</strong></th>");
                StrExport.Append("      <th style=\"mso-number-format:'\\@'\"><strong>Tên</strong></th>");
                StrExport.Append("      <th style=\"mso-number-format:'\\@'\"><strong>Số điện thoại</strong></th>");
                StrExport.Append("      <th style=\"mso-number-format:'\\@'\"><strong>Địa chỉ</strong></th>");
                StrExport.Append("      <th style=\"mso-number-format:'\\@'\"><strong>Mã vận đơn</strong></th>");
                StrExport.Append("      <th style=\"mso-number-format:'\\@'\"><strong>Cân nặng (kg)</strong></th>");
                StrExport.Append("      <th style=\"mso-number-format:'\\@'\"><strong>Dài (cm)</strong></th>");
                StrExport.Append("      <th style=\"mso-number-format:'\\@'\"><strong>Rộng (cm)</strong></th>");
                StrExport.Append("      <th style=\"mso-number-format:'\\@'\"><strong>Cao (cm)</strong></th>");
                StrExport.Append("      <th style=\"mso-number-format:'\\@'\"><strong>Ghi chú kiểm hàng</strong></th>");
                StrExport.Append("      <th style=\"mso-number-format:'\\@'\"><strong>Ghi chú</strong></th>");
                StrExport.Append("      <th><strong>Trạng thái</strong></th>");
                StrExport.Append("      <th><strong>Ngày tạo</strong></th>");
                StrExport.Append("  </tr>");
                if (la.Count > 0)
                {
                    int STT = 1;
                    foreach (var item in la)
                    {
                        var acc = AccountController.GetByUsername(item.Username);
                        var accInfor = AccountInfoController.GetByUserID(acc.ID);
                        StrExport.Append("<tr>");
                        StrExport.Append("<td>" + STT + "</td>");
                        StrExport.Append("<td style=\"mso-number-format:'\\@'\">" + item.Username + "</td>");
                        StrExport.Append("<td style=\"mso-number-format:'\\@'\">" + item.MainOrderID + "</td>");
                        StrExport.Append("<td style=\"mso-number-format:'\\@'\">" + accInfor.FirstName + accInfor.LastName + "</td>");
                        StrExport.Append("<td style=\"mso-number-format:'\\@'\">" + accInfor.MobilePhone + "</td>");
                        StrExport.Append("<td style=\"mso-number-format:'\\@'\">" + accInfor.Address + "</td>");
                        StrExport.Append("<td style=\"mso-number-format:'\\@'\">" + item.OrderTransactionCode + "</td>");
                        StrExport.Append("<td style=\"mso-number-format:'\\@'\">" + item.Weight + "</td>");
                        StrExport.Append("<td style=\"mso-number-format:'\\@'\">" + item.Length + "</td>");
                        StrExport.Append("<td style=\"mso-number-format:'\\@'\">" + item.Width + "</td>");
                        StrExport.Append("<td style=\"mso-number-format:'\\@'\">" + item.Height + "</td>");
                        StrExport.Append("<td style=\"mso-number-format:'\\@'\">" + item.UserNote + "</td>");
                        StrExport.Append("<td style=\"mso-number-format:'\\@'\">" + item.Description + "</td>");
                        StrExport.Append("<td style=\"mso-number-format:'\\@'\">" + item.StatusString + "</td>");
                        StrExport.Append("<td>" + item.CreatedDateString + "</td>");
                        StrExport.Append("</tr>");
                        STT++;
                    }
                }

                StrExport.Append("</table>");
                StrExport.Append("</div></body></html>");
                string strFile = "SessionList-" + i + ".xls";
                string strcontentType = "application/vnd.ms-excel";
                Response.ClearContent();
                Response.ClearHeaders();
                Response.BufferOutput = true;
                Response.ContentType = strcontentType;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + strFile);
                Response.Write(StrExport.ToString());
                Response.Flush();
                //Response.Close();
                Response.End();
            }
        }

        protected void btncreateuser_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            int ID = ViewState["ID"].ToString().ToInt(0);
            string username_current = Session["userLoginSystem"].ToString();
            DateTime currentDate = DateTime.Now;
            if (ID > 0)
            {
                int status = ddlStatus.SelectedValue.ToInt();
                string Note = txtPackageNote.Text;
                var session = WorkingSessionController.GetByID(ID);
                if (session != null)
                {
                    WorkingSessionController.UpdateStatus(ID, status, currentDate, username_current);
                    WorkingSessionController.UpdateNote(ID, Note, currentDate, username_current);
                    Response.Redirect("/manager/Session-Detail.aspx?ID=" + ID);
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["Page"].ToString()))
            {
                Response.Redirect("SessionList?Page=" + Session["Page"].ToString());
            }
            else
            {
                Response.Redirect("SessionList.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string i = ViewState["ID"].ToString();
            string searchname = tSearchName.Text.Trim();
            if (string.IsNullOrEmpty(searchname) == false)
            {
                Response.Redirect("Session-Detail.aspx?ID=" + i + "&s=" + searchname);
            }
            else
            {

                Response.Redirect("Session-Detail.aspx?ID=" + i);
            }
        }
    }
}
﻿<%@ Page  Title="Danh sách phiếu in" MasterPageFile="~/UserMasterNew.Master" Language="C#" AutoEventWireup="true" CodeBehind="user-outstock-payment.aspx.cs" Inherits="NHST.user_outstock_payment" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Import Namespace="NHST.Controllers" %>
<%@ Import Namespace="NHST.Models" %>
<%@ Import Namespace="NHST.Bussiness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        [type="checkbox"].filled-in:disabled:checked + span.checkColor:not(.lever):after {
            border: 2px solid #F64302;
            background-color: #F64302;
        }
        table.table.bordered.highlight tbody tr:nth-child(even){
            background: #f5f5f5;
        }
    </style>
    <asp:Button Style="display: none" UseSubmitBehavior="false" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
    <div id="main" class="main-full">
        <div class="row">
            <div class="content-wrapper-before bg-dark-gradient"></div>
            <div class="page-title">
                <div class="card-panel" style="display:none">
                    <div class="right-action" style="display:none">
                        <a href="#" class="btn" id="filter-btn">Bộ lọc</a>
                    </div>
                    <div class="clearfix"></div>
                    <div class="filter-wrap">
                        <div class="row mt-2 pt-2">
                            <div class="input-field col s12 l2">
                                <select id="select_by" disabled>
                                    <option value="0">Tất cả</option>
                                    <option value="1" selected>Username</option>
                                </select>
                                <label for="select_by">Tìm kiếm theo</label>
                            </div>
                            <div class="input-field col s12 l4">
                                <asp:TextBox ID="search_name" name="txtSearchName" type="text" onkeypress="myFunction()" runat="server" />

                            </div>
                            <div class="input-field col s12 l6">
                                <asp:DropDownList runat="server" ID="ddlStatus">
                                    <asp:ListItem Text="Tất cả" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Chưa xử lý" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Đã xử lý" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                                <label for="status">Trạng thái</label>
                            </div>
                            <div class="input-field col s6">
                                <asp:TextBox runat="server" ID="rFD" type="text" class="datetimepicker from-date"></asp:TextBox>
                                <label>Từ ngày</label>
                            </div>
                            <div class="input-field col s6">
                                <asp:TextBox runat="server" ID="rTD" type="text" class="datetimepicker to-date"></asp:TextBox>
                                <label>Đến ngày</label>
                                <span class="helper-text" data-error="Vui lòng chọn ngày bắt đầu trước"></span>
                            </div>
                            <div class="col s12 right-align">
                                <span class="search-action btn">Lọc kết quả</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="list-staff col s12 section">
                <div class="all" style="box-shadow: 0px 15px 40px rgba(183, 194, 214, 0.12);">
                <div class="list-table card-panel" style="margin-top: 20px">
                    <div class="center-f" style="text-align: center">
                    <h4 class="title no-margin" style="display: inline-block;;color: #366136; text-transform: uppercase;font-weight: bold"">In phiếu</h4>
                    </div>
                    <div class="responsive-tb">
                        <table class="table bordered highlight mt-2">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                   <%-- <th>Mã khách hàng</th>--%>
                                    <th>Username</th>
                                    <th>Tổng tiền</th>
                                    <th style="min-width: 100px;">Ngày tạo</th>
                                    <%--<th style="min-width: 50px;">Thanh toán</th>--%>
                                  <%--  <th style="min-width: 130px;">Trạng thái</th>--%>
                                    <th style="min-width: 100px;">Thao tác</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal ID="ltr" runat="server" EnableViewState="false"></asp:Literal>
                            </tbody>
                        </table>

                    </div>
                    <div class="pagi-table float-right mt-2">
                        <%this.DisplayHtmlStringPaging1();%>
                    </div>
                    <div class="clearfix"></div>
                </div>
                    </div>
            </div>
        </div>
    </div>
    <script>
        function myFunction() {
            if (event.which == 13 || event.keyCode == 13) {
                console.log($('#<%=search_name.ClientID%>').val());
                $('#<%=btnSearch.ClientID%>').click();
            }
        }
        $('.search-action').click(function () {
            console.log('dkm ngon');
            console.log($('#<%=search_name.ClientID%>').val());
            $('#<%=btnSearch.ClientID%>').click();
        })
    </script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/NguonHangTanGocMaster.Master" AutoEventWireup="true" CodeBehind="chi-tiet-trang.aspx.cs" Inherits="NHST.chi_tiet_trang2" %>

<%@ Register Src="~/UC/uc_Sidebar.ascx" TagName="SideBar" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        p {
            text-align: initial;
        }

        .intro-page table {
            width: 100% !important;
        }
    </style>
    <style>
        .services {
            background: #f8f8f8;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="main main-page" style="padding: unset;margin-top: 15px">
        <div class="breadcrumb">
            <div class="container">
                <ul style="margin-top: 10px; margin-bottom: -10px;">
                    <li><a href="/">Trang chủ</a></li>
                    <asp:Literal runat="server" ID="ltrBread"></asp:Literal>
                </ul>
            </div>
        </div>

        <asp:Panel runat="server" ID="pnSideBar" Visible="false" style="width: 100%">
            <div class="service-page-section sec">
                <div class="container">
                    <div class="columns">
                        <div class="column left wow fadeInLeft" data-wow-duration="1s" data-wow-delay="0s">
                            <uc:SideBar ID="SideBar1" runat="server" />
                        </div>
                        <div class="column right">
                            <asp:Label runat="server" ID="lblTitle"></asp:Label>
                            <asp:Literal runat="server" ID="ltrDetail"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnFull">
            <section class="about-section sec">
                <div class="container">
                    <asp:Label runat="server" ID="lblTitleFull"></asp:Label>
                    <asp:Literal runat="server" ID="ltrContent"></asp:Literal>
                </div>
            </section>
        </asp:Panel>

    </main>
</asp:Content>
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/NguonHangTanGocMaster.Master" CodeBehind="Default.aspx.cs" Inherits="NHST.Default" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <main id="main-wrap">

        <div class="sec panel-sec ">
            <div class="banner-bg wow animate__zoomIn" style="background-image: url(/App_Themes/CSSNHTG/images/bg-banner.jpg);"></div>
            <div class="inner">
                <div class="head-title">
                    <h3 class="title-big wow animate__backInDown" data-wow-delay="0.5">NGUỒN HÀNG TẬN GỐC</h3>
                    <h1 class="title-big animation-title animated" data-in-effect="rollIn" data-out-effect="fadeOutDown" data-out-shuffle="true" data-wow-delay="0.5s">NHANH CHÓNG, TIỆN LỢI,TẬN TÂM</h1>
                </div>
                <h1 class="inner-tt wow animate__fadeInDownBig">CÔNG CỤ ĐẶT HÀNG TRUNG QUỐC</h1>
                <div class="box-plg">
                    <a href="https://chrome.google.com/webstore/detail/c%C3%B4ng-c%E1%BB%A5-%C4%91%E1%BA%B7t-h%C3%A0ng-ngu%E1%BB%93n-h%C3%A0/kbjdfcibdbkgfjjolhnlenpofhpdeaic"
                        class="browser-down wow animate__bounceIn" data-wow-delay="1s">
                        <img src="/App_Themes/CSSNHTG/images/gg-ic.png" alt="">
                        <div class="text-browser">
                            <p>Tải về cho trình duyệt</p>
                            <span>google chrome</span>
                        </div>
                    </a>
                    <a href="https://chrome.google.com/webstore/detail/c%C3%B4ng-c%E1%BB%A5-%C4%91%E1%BA%B7t-h%C3%A0ng-ngu%E1%BB%93n-h%C3%A0/kbjdfcibdbkgfjjolhnlenpofhpdeaic"
                        class="browser-down wow animate__bounceIn" data-wow-delay="1s">
                        <img src="/App_Themes/CSSNHTG/images/coc-ic.png" alt="">
                        <div class="text-browser">
                            <p>Tải về cho trình duyệt</p>
                            <span>google chrome</span>
                        </div>
                    </a>
                </div>
            </div>
            <div class="truck-animation">
                <img src="/App_Themes/CSSNHTG/images/car/3.png" alt="" class="">
            </div>
        </div>

        <section class="sec sec-register">
            <div class="all">
                <div class="sec-above wow animate__bounceInDown">
                    <h2 class="tt-txt hl-txt">Dịch vụ</h2>
                </div>
                <ul class="step-ul clear wow fadeInUp">
                    <asp:Literal runat="server" ID="ltrStepName"></asp:Literal>
                    <li id="step-arrow"></li>
                </ul>
                <div class="slider-cont slider-register wow animate__bounceIn" id="step-slider">
                    <asp:Literal runat="server" ID="ltrStepContent"></asp:Literal>
                </div>
            </div>
        </section>

        <section class="sec sec-feats">
            <div class="all">
                <div class="sec-above wow wow animate__bounceInDown">
                    <h3 class="tt-txt">Nguồn Hàng Tận Gốc <span class="hl-txt">Quyền lợi khách hàng</span></h3>
                </div>
                <div class="featlist wow animate__rotateIn">
                    <div>
                        <asp:Literal runat="server" ID="ltrCamKet"></asp:Literal>
                    </div>

                </div>
            </div>
        </section>

        <div class="sec sec-params wow animate__backInUp">
            <div class="all">
                <div class="params-box wow animate__bounceInUp" data-wow-delay="0.4s">
                    <p class="title">6</p>
                    <p class="smr">Năm kinh nghiệm</p>
                </div>
                <div class="params-box wow animate__bounceInUp" data-wow-delay="0.6s">
                    <p class="title">7</p>
                    <p class="smr">Kho hàng Việt - Trung</p>
                </div>
                <div class="params-box wow animate__bounceInUp" data-wow-delay="0.8s">
                    <p class="title">800</p>
                    <p class="smr">Đơn hàng mỗi ngày</p>
                </div>
                <div class="params-box wow animate__bounceInUp" data-wow-delay="1s">
                    <p class="title">9101</p>
                    <p class="smr">Khách hàng sử dụng</p>
                </div>

            </div>
        </div>

        <div class="sec sec-contact wow animate__flash">
            <div class="fw-map">
                <div class="contacts-info">
                    <article class="ct-box">
                        <i class="fa fa-envelope"></i>
                        <div class="info">
                            <h4 class="lb">Email contact:</h4>
                            <asp:Literal runat="server" ID="ltrEmail"></asp:Literal>
                        </div>
                    </article>
                    <article class="ct-box">
                        <i class="fa fa-clock-o"></i>
                        <div class="info">
                            <h4 class="lb">Giờ hoạt động:</h4>
                            <asp:Literal runat="server" ID="ltrTimework"></asp:Literal>
                        </div>
                    </article>
                    <article class="ct-box">
                        <i class="fa fa-tty"></i>
                        <div class="info">
                            <h4 class="lb">Hotline:</h4>
                            <asp:Literal runat="server" ID="ltrHotline"></asp:Literal>
                        </div>
                    </article>
                </div>

                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1107.0190146899058!2d105.77839657850531!3d21.05055296159307!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x313455cb29c0139b%3A0xafb871e39a16500b!2zVMOyYSBBMiBDaHVuZyBjxrAgQW4gQsOsbmggQ2l0eQ!5e0!3m2!1svi!2s!4v1659074615217!5m2!1svi!2s" width="100%" height="450" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>

                <div class="map" id="map-canvas" style="display: none"></div>
                <div class="arrow-down wow animate__heartBeat">
                    <div class="arrow-down-bg"></div>
                    <i class="fas fa-angle-down"></i>
                </div>
            </div>
        </div>

        <div class="sec contact">
            <div class="all">
                <div class="contact-content">
                    <div class="sec-title2">
                        <h2 class="hd">Liên hệ với chúng tôi</h2>
                    </div>
                    <div class="ct-detail">
                        <div class="ct-detail-title">VĂN PHÒNG MIỀN BẮC</div>
                        <div class="ct-detail-content">
                            <div class="dt-info">
                                <i class="fas fa-fw fa-mobile-alt"
                                    aria-hidden="true"></i>Hotline 1:
                                <asp:Literal runat="server" ID="ltrHotlineCt"></asp:Literal>
                            </div>
                            <div class="dt-info">
                                <i class="fas fa-fw fa-mobile-alt"
                                    aria-hidden="true"></i>Hotline 2:
                                <asp:Literal runat="server" ID="ltrHotlineCt2"></asp:Literal>
                            </div>
                            <div class="dt-info">
                                <i class="fas fa-fw fa-mobile-alt"
                                    aria-hidden="true"></i>Kho Hà Nội:
                                <asp:Literal runat="server" ID="ltrHotlineKhoHN"></asp:Literal>
                            </div>
                            <div class="dt-info">
                                <i class="fas fa-fw fa-home" aria-hidden="true"></i>Địa chỉ: 
                                <asp:Literal runat="server" ID="ltrAddressCt"></asp:Literal>
                            </div>
                        </div>
                    </div>
                    <div class="ct-detail">
                        <div class="ct-detail-title">VĂN PHÒNG KINH DOANH VÀ KHO MIỀN NAM</div>
                        <div class="ct-detail-content">
                            <div class="dt-info">
                                <i class="fas fa-fw fa-mobile-alt"
                                    aria-hidden="true"></i>Hotline:
                                <asp:Literal runat="server" ID="ltrHotlineKhoMN"></asp:Literal>
                            </div>
                            <div class="dt-info" data-wow-delay="0.8s">
                                <i class="fas fa-fw fa-mobile-alt"
                                    aria-hidden="true"></i>Địa chỉ:
                                <asp:Literal runat="server" ID="ltrAddressKhoMN"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="contact-form">

                    <div class="form__child">
                        <asp:TextBox runat="server" class="f-control" placeholder="Họ tên khách hàng" ID="txtFullName" data-type="text-only" type="text"></asp:TextBox>
                        <span class="helper-text">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Contact" runat="server" ControlToValidate="txtFullName"
                                ForeColor="Red" Display="Dynamic" ErrorMessage="Không được để trống."></asp:RequiredFieldValidator>
                        </span>
                    </div>

                    <div class="form__child">
                        <asp:TextBox runat="server" class="f-control" placeholder="Email" ID="txtEmail" data-type="text-only" type="text"></asp:TextBox>
                        <span class="helper-text">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                                ForeColor="Red" Display="Dynamic" ErrorMessage="Không được để trống." ValidationGroup="Contact"></asp:RequiredFieldValidator>
                        </span>
                        <span class="helper-text">
                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator4" ForeColor="Red" Display="Dynamic" ControlToValidate="txtEmail"
                                ErrorMessage="Sai định dạng Email" ValidationGroup="Contact"
                                ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" />
                        </span>
                    </div>

                    <div class="form__child">
                        <asp:TextBox runat="server" MaxLength="11" class="f-control" placeholder="Số điện thoại" ID="txtPhone" type="text"></asp:TextBox>
                        <span class="helper-text">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPhone" ForeColor="Red"
                                Display="Dynamic" ErrorMessage="Không được để trống." ValidationGroup="Contact"></asp:RequiredFieldValidator>
                        </span>
                    </div>

                    <div class="form__child">
                        <asp:TextBox runat="server" TextMode="MultiLine" class="f-control" placeholder="Nội dung cần liên hệ" ID="txtNoteContact" type="text"></asp:TextBox>
                        <span class="helper-text">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Contact" runat="server" ControlToValidate="txtNoteContact"
                                ForeColor="Red" Display="Dynamic" ErrorMessage="Không được để trống."></asp:RequiredFieldValidator>
                        </span>
                    </div>

                    <div class="form__submit">
                        <asp:Button ID="btnSend" runat="server" UseSubmitBehavior="false" Text="Gửi thông tin"
                            CssClass="mn-btn btn-1" OnClick="btnSend_Click" ValidationGroup="Contact" />
                    </div>
                </div>

            </div>
        </div>
    </main>
    <script type="text/javascript">        
        function close_popup_ms() {
            $("#pupip_home").animate({ "opacity": 0 }, 400);
            $("#bg_popup_home").animate({ "opacity": 0 }, 400);
            setTimeout(function () {
                $("#pupip_home").remove();
                $(".zoomContainer").remove();
                $("#bg_popup_home").remove();
                $('body').css('overflow', 'auto').attr('onkeydown', '');
            }, 500);
        }
        function closeandnotshow() {
            $.ajax({
                type: "POST",
                url: "/Default.aspx/setNotshow",
                //data: "{ID:'" + id + "',UserName:'" + username + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    close_popup_ms();
                },
                error: function (xmlhttprequest, textstatus, errorthrow) {
                    alert('lỗi');
                }
            });
        }
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "/Default.aspx/getPopup",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (msg.d != "null") {
                        var data = JSON.parse(msg.d);
                        var title = data.NotiTitle;
                        var content = data.NotiContent;
                        var email = data.NotiEmail;
                        var obj = $('form');
                        $(obj).css('overflow', 'hidden');
                        $(obj).attr('onkeydown', 'keyclose_ms(event)');
                        var bg = "<div id='bg_popup_home'></div>";
                        var fr = "<div id='pupip_home' class=\"columns-container1\">" +
                            "  <div class=\"center_column col-xs-12 col-sm-5\" id=\"popup_content_home\">";
                        fr += "<div class=\"popup_header\">";
                        fr += title;
                        fr += "<div><a style='cursor:pointer;right:5px;color:whlite;' onclick='close_popup_ms()' class='close_message'>x</a></div>";
                        fr += "</div>";
                        fr += "     <div class=\"changeavatar\">";
                        fr += "         <div class=\"content1\">";
                        fr += content;
                        fr += "         </div>";
                        fr += "         <div class=\"content2\">";
                        //fr += "<a href=\"javascript:;\" class=\"btn btn-close-full\" onclick='closeandnotshow()'>Đóng & không hiện thông báo</a>";
                        //fr += "<a href=\"javascript:;\" class=\"btn btn-close\" onclick='close_popup_ms()'>Đóng</a>";
                        fr += "         </div>";
                        fr += "     </div>";
                        fr += "<div class=\"popup_footer\">";
                        fr += "<span class=\"float-right\">" + email + "</span>";
                        fr += "</div>";
                        fr += "   </div>";
                        fr += "</div>";
                        $(bg).appendTo($(obj)).show().animate({ "opacity": 0.7 }, 800);
                        $(fr).appendTo($(obj));
                        setTimeout(function () {
                            $('#pupip').show().animate({ "opacity": 1, "top": 20 + "%" }, 200);
                            $("#bg_popup").attr("onclick", "close_popup_ms()");
                        }, 1000);
                    }
                },
                error: function (xmlhttprequest, textstatus, errorthrow) {
                    alert('lỗi');
                }
            });
        });
    </script>
    <style>
        #bg_popup_home {
            position: fixed;
            width: 100%;
            height: 100%;
            background-color: #333;
            opacity: 0.7;
            filter: alpha(opacity=70);
            left: 0px;
            top: 0px;
            z-index: 999999999;
            opacity: 0;
            filter: alpha(opacity=0);
        }

        #popup_ms_home {
            background: #fff;
            border-radius: 0px;
            box-shadow: 0px 2px 10px #fff;
            float: left;
            position: fixed;
            width: 735px;
            z-index: 10000;
            left: 50%;
            margin-left: -370px;
            top: 200px;
            opacity: 0;
            filter: alpha(opacity=0);
            height: 360px;
        }

            #popup_ms_home .popup_body {
                border-radius: 0px;
                float: left;
                position: relative;
                width: 735px;
            }

            #popup_ms_home .content {
                /*background-color: #487175;     border-radius: 10px;*/
                margin: 12px;
                padding: 15px;
                float: left;
            }

            #popup_ms_home .title_popup {
                /*background: url("../images/img_giaoduc1.png") no-repeat scroll -200px 0 rgba(0, 0, 0, 0);*/
                color: #ffffff;
                font-size: 24px;
                font-weight: bold;
                height: 35px;
                margin-left: 0;
                margin-top: -5px;
                padding-left: 40px;
                padding-top: 0;
                text-align: center;
            }

            #popup_ms_home .text_popup {
                color: #fff;
                font-size: 14px;
                margin-top: 20px;
                margin-bottom: 20px;
                line-height: 20px;
            }

                #popup_ms_home .text_popup a.quen_mk, #popup_ms_home .text_popup a.dangky {
                    color: #FFFFFF;
                    display: block;
                    float: left;
                    font-style: italic;
                    list-style: -moz-hangul outside none;
                    margin-bottom: 5px;
                    margin-left: 110px;
                    -webkit-transition-duration: 0.3s;
                    -moz-transition-duration: 0.3s;
                    transition-duration: 0.3s;
                }

                    #popup_ms_home .text_popup a.quen_mk:hover, #popup_ms_home .text_popup a.dangky:hover {
                        color: #8cd8fd;
                    }

            #popup_ms_home .close_popup {
                background: url("/App_Themes/Camthach/images/close_button.png") no-repeat scroll 0 0 rgba(0, 0, 0, 0);
                display: block;
                height: 28px;
                position: absolute;
                right: 0px;
                top: 5px;
                width: 26px;
                cursor: pointer;
                z-index: 10;
            }

        #popup_content_home {
            height: auto;
            position: fixed;
            background-color: #fff;
            top: 15%;
            z-index: 999999999;
            left: 25%;
            border-radius: 10px;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            width: 50%;
        }

        #popup_content_home {
            padding: 0;
        }

        .popup_header, .popup_footer {
            float: left;
            width: 100%;
            background: #e84545;
            padding: 10px;
            position: relative;
            color: #fff;
        }

        .popup_header {
            font-weight: bold;
            font-size: 16px;
            text-transform: uppercase;
        }

        .close_message {
            top: 10px;
        }

        .changeavatar {
            padding: 10px;
            margin: 5px 0;
            float: left;
            width: 100%;
            overflow-y: auto;
        }

        /* .changeavatar .content1 {
                overflow-y: auto;
            }*/

        .float-right {
            float: right;
        }

        .content1 {
            float: left;
            width: 100%;
            height: 500px;
            overflow-y: auto;
        }

        .content2 {
            float: left;
            width: 100%;
            border-top: 1px solid #eee;
            clear: both;
            margin-top: 10px;
        }

        .btn.btn-close {
            float: right;
            background: #e84545;
            color: #fff;
            margin-top: 20px;
            text-transform: none;
            padding: 10px 20px;
            width: unset;
        }

            .btn.btn-close:hover {
                background: #5f0d0d;
            }

        .btn.btn-close-full {
            float: right;
            background: #7bb1c7;
            color: #fff;
            margin: 20px 5px;
            text-transform: none;
            padding: 10px 20px;
            width: unset;
        }

            .btn.btn-close-full:hover {
                background: #435156;
            }

        @media screen and (max-width: 768px) {
            #popup_content_home {
                left: 10%;
                width: 80%;
            }

            .content1 {
                overflow: auto;
                /*height: 300px;*/
            }
        }

        @media screen and (max-width: 768px) {
            .changeavatar {
                height: auto !important;
                overflow-y: hidden;
            }
        }
    </style>
</asp:Content>

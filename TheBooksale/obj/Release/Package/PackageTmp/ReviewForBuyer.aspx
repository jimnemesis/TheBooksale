<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReviewForBuyer.aspx.cs" Inherits="TheBooksale.ReviewForBuyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="author" content="James Gagni Jr." />

    <title>Rate the Buyer</title>

    <!-- Bootstrap CSS -->
    <link href="Styles/images/favicon.png" rel="shortcut icon" />
    <link href="Styles/Classix/assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Classix/assets/css/jasny-bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Classix/assets/css/jasny-bootstrap.min.css" rel="stylesheet" type="text/css" />

    <!-- Material CSS -->
    <link href="Styles/Classix/assets/css/material-kit.css" rel="stylesheet" type="text/css" />

    <!-- Font Awesome CSS -->
    <link href="Styles/Classix/assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- Line Icons CSS -->
    <link href="Styles/Classix/assets/fonts/line-icons/line-icons.css" rel="stylesheet" type="text/css" />

    <!-- Main Styles -->
    <link href="Styles/Classix/assets/css/main.css" rel="stylesheet" type="text/css" />

    <!-- Animate CSS -->
    <link href="Styles/Classix/assets/extras/animate.css" rel="stylesheet" type="text/css" />

    <!-- Owl Carousel -->
    <link href="Styles/Classix/assets/extras/owl.carousel.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Classix/assets/extras/owl.theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Classix/assets/extras/settings.css" rel="stylesheet" type="text/css" />

    <!-- Responsive CSS Styles -->
    <link href="Styles/Classix/assets/css/responsive.css" rel="stylesheet" type="text/css" />

    <!-- Bootstrap Select -->
    <link href="Styles/Classix/assets/css/bootstrap-select.min.css" rel="stylesheet" />

    <!-- File Input -->
    <link href="Styles/Classix/assets/css/fileinput.css" rel="stylesheet" />
</head>

<body>

    <!-- Header Section Start -->
    <div class="header">
        <nav class="navbar navbar-default main-navigation" role="navigation">
            <div class="container">
                <div class="navbar-header">

                    <!-- Stat Toggle Nav Link For Mobiles -->
                    <button class="navbar-toggle" data-target=".navbar-collapse" data-toggle="collapse" type="button"><span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                    <!-- End Toggle Nav Link For Mobiles -->
                    <a class="navbar-brand logo" href="Main.aspx">
                        <img alt="" src="Styles/images/Logo.png"></a>
                </div>
                <!-- brand and toggle menu for mobile End -->

                <!-- Navbar Start -->
                <div class="collapse navbar-collapse" id="navbar">
                    <ul class="nav navbar-nav navbar-right">
                        <li id="liHome" runat="server"><a href="Main.aspx"><i class="lnr lnr-home"></i>Home</a></li>
                        <li id="liMyAccount" runat="server"><a href="UserAccount.aspx"><i class="lnr lnr-license"></i>My Account</a></li>
                        <li id="liMyAds" runat="server"><a href="UserAds.aspx?XLM=0"><i class="lnr lnr-book"></i>My Ads</a></li>
                        <li id="liMyReports" runat="server"><a href="UserReports.aspx"><i class="lnr lnr-file-add"></i>My Reports</a></li>
                        <li id="liLogout" runat="server"><a href="Logout.aspx"><i class="lnr lnr-exit"></i>Logout</a></li>
                        <li id="liLogin" runat="server"><a href="Login.aspx"><i class="lnr lnr-enter"></i>Login</a></li>
                        <li id="liSignup" runat="server"><a href="Signup.aspx"><i class="lnr lnr-user"></i>Signup</a></li>
                        <li class="postadd">
                            <a class="btn btn-danger btn-post" href="AdsPost.aspx"><span class="fa fa-plus-circle"></span>Post an Ad </a>
                        </li>
                    </ul>
                </div>
                <!-- Navbar End -->
            </div>
        </nav>

      <!-- Off Canvas Navigation -->
      <div class="navmenu navmenu-default navmenu-fixed-left offcanvas"> 
      <!--- Off Canvas Side Menu -->
        <div class="close" data-toggle="offcanvas" data-target=".navmenu">
            <i class="fa fa-close"></i>
        </div>
          <h3 class="title-menu">Menu</h3>
          <ul class="nav navmenu-nav"> <!--- Menu -->
            <li id="liSNavHome" runat="server"><a href="Main.aspx">Home</a></li>
            <li id="liSNavCategories" runat="server"><a href="Categories.aspx?XCA=0">Categories</a></li>  
            <li id="liSNavPostAd" runat="server"><a href="AdsPost.aspx">Post ad</a></li>      
            <li id="liSNavSignUp" runat="server"><a href="SignUp.aspx">Sign Up</a></li>
            <li id="liSNavMyAccount" runat="server"><a href="UserAccount.aspx">My Account</a></li>
            <li id="liSNavMyAdsAll" runat="server"><a href="UserAds.aspx?XLM=0">All My Ads</a></li>
            <li id="liSNavMyAdsPending" runat="server"><a href="UserAds.aspx?XLM=2">My Pending Ads</a></li>
            <li id="liSNavMyReports" runat="server"><a href="UserReports.aspx">My Reports</a></li>
            <li id="liSNavFaq" runat="server"><a href="InfoFaq.aspx">FAQ</a></li>
            <li id="liSNavDisclaimer" runat="server"><a href="InfoDisclaimer.aspx">Disclaimer</a></li>
            <li id="liSNavTerms" runat="server"><a href="InfoTerms.aspx">Terms and Conditions</a></li>
            <li id="liSNavPrivacy" runat="server"><a href="InfoPrivacy.aspx">Privacy Policy</a></li>
        </ul><!--- End Menu -->
      </div> <!--- End Off Canvas Side Menu -->
      <div class="tbtn wow pulse" id="menu" data-wow-iteration="infinite" data-wow-duration="500ms" data-toggle="offcanvas" data-target=".navmenu">
        <p><i class="fa fa-file-text-o"></i>Menu</p>
      </div>

    <!-- Header Section End -->
    <!-- Content section Start -->
    <section id="content">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 col-md-10 col-md-offset-1">
                    <form id="PostForm" runat="server">
                        <div class="page-ads box">
                            <h2 class="title-2">Rate "<asp:Label ID="lblBuyerName" runat="server" Text="Label"></asp:Label>" as a Buyer</h2>
                            <!-- Start Search box -->
                            <div class="row search-bar red-bg">
                                <div class="advanced-search">
                                    <div class="search-form">
                                        <div class="col-md-4 col-sm-12 search-col">
                                            <div class="input-group-addon search-category-container">
                                                <label class="styled-select">
                                                    <span class="hidden-sm hidden-xs">Rating </span>
                                                    <asp:DropDownList ID="ddlRating" runat="server" CssClass="dropdown-product selectpicker">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdnUserId" runat="server" />
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Search box -->

                            <div class="form-ad">
                                    <label class="control-label" for="textarea">Review</label>
                                                <asp:TextBox ID="txtReview" runat="server" TextMode="MultiLine" class="form-control" placeholder="Provide a description for your book ad" Rows="4"></asp:TextBox>
                                </div>
                        </div>
                        <div class="mb30"></div>
                        <div class="form-group">
                            <div class="page-ads box">
                                <p>By using our site, you acknowledge that you have read 
                                    and understood our <a href="InfoDisclaimer.aspx" target="_blank">Disclaimer</a>, 
                                    <a href="InfoTerms.aspx" target="_blank">Terms of Use</a> 
                                    and <a href="InfoPrivacy.aspx" target="_blank">Privacy Policy</a></p>
                                <div class="checkbox">
                                    <label>
                                <input type="checkbox" runat="server" id="chkAgree" name="chkAgree" value="forever" style="float: left;" />
                                        I agree to the <a href="InfoDisclaimer.aspx" target="_blank">Disclaimer</a>, 
                                        <a href="InfoTerms.aspx" target="_blank">Terms of Use</a> and <a href="InfoPrivacy.aspx" target="_blank">Privacy Policy</a></label>
                                </div>
                                <br />
                                <asp:Button ID="btnSubmit" runat="server" class="btn btn-common" Text="Submit Review" OnClientClick="if (!checkAgree()) return false; " OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>
    <!-- Content section End -->
    <!-- Footer Section Start -->
    <footer>
        <!-- Footer Area Start -->
        <section class="footer-Content">
            <div class="container">
                <div class="row">
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <div class="widget">
                            <h3 class="block-title">About</h3>
                            <div id="about">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <div class="widget">
                            <h3 class="block-title">Useful Links</h3>
                            <div id="links">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <div class="widget">
                            <h3 class="block-title">Tweets</h3>
                            <div class="twitter-content clearfix">
                                <ul class="twitter-list">
                                    <li class="clearfix"><span>Make sure you are following <a href="#">@StarWitsApps</a> for all your application development needs!</span></li>
                                    <li class="clearfix"><span>All the apps you need, right here, at Star Wits Apps. Join us: <a href="#">http://starwitsapps.com</a></span></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <div class="widget">
                            <h3 class="block-title">Latest Book Ads</h3>
                            <ul class="featured-list">

<asp:ListView ID="lvwLatestAds" runat="server">
                                <ItemTemplate>
                                <li>
                                    <asp:Image ID="imgPhotoMain" runat="server" ImageUrl='<%# Eval("PHO_PATH") %>' />
                                    <div class="hover">
                                        <a id="lnkAdViaPrice" runat="server" href='<%# "AdsDetails.aspx?XAD=" + Eval("ADS_ID") %>'><span>
                                            <asp:Label ID="lblPrice" runat="server" Text='<%# "Php " + Eval("ADS_PRICE") %>'></asp:Label>
                                                    </span></a>
                                    </div>
                                </li>
                                    </ItemTemplate>
    </asp:ListView>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- Footer area End -->
        <!-- Copyright Start  -->
        <div id="copyright">
        </div>
        <!-- Copyright End -->
    </footer>
    <!-- Footer Section End -->
    <!-- Go To Top Link -->
    <a class="back-to-top" href="#"><i class="fa fa-angle-up"></i></a>

<asp:SqlDataSource ID="sqlLatestAds" runat="server" ConnectionString="<%$ ConnectionStrings:cnBooksale %>" ProviderName="<%$ ConnectionStrings:cnBooksale.ProviderName %>"></asp:SqlDataSource>



    <asp:SqlDataSource ID="sqlAdReview" runat="server" InsertCommand="insert into dbo.rvw_reviews 
(rvw_id, usr_user_id, rvw_for_usr_user_id, rvw_rate, rvw_review, rvw_reviewdate, rvw_status, rvw_type)
values (@prmRvwId, @prmUserId, @prmRvwForUserId, @prmRate, @prmReview, GetDate(), 1, 1)"
        ConnectionString="<%$ ConnectionStrings:cnBooksale %>" ProviderName="<%$ ConnectionStrings:cnBooksale.ProviderName %>">
        <InsertParameters>
            <asp:Parameter Name="prmAdDetailsId" />
            <asp:Parameter Name="prmAdsid" />
            <asp:Parameter Name="prmAuthorId" />
            <asp:Parameter Name="prmRvwId" />
            <asp:Parameter Name="prmUserId" />
            <asp:Parameter Name="prmRvwForUserId" />
            <asp:Parameter Name="prmRate" />
            <asp:Parameter Name="prmReview" />
        </InsertParameters>
    </asp:SqlDataSource>



    <!-- Main JS  -->
    <script type="text/javascript" src="Styles/Classix/assets/js/jquery-min.js"></script>
    <script type="text/javascript" src="Styles/Classix/assets/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Styles/Classix/assets/js/material.min.js"></script>
    <script type="text/javascript" src="Styles/Classix/assets/js/material-kit.js"></script>
    <script type="text/javascript" src="Styles/Classix/assets/js/jquery.parallax.js"></script>
    <script type="text/javascript" src="Styles/Classix/assets/js/owl.carousel.min.js"></script>
    <script type="text/javascript" src="Styles/Classix/assets/js/wow.js"></script>
    <script type="text/javascript" src="Styles/Classix/assets/js/main.js"></script>
    <script type="text/javascript" src="Styles/Classix/assets/js/jquery.counterup.min.js"></script>
    <script type="text/javascript" src="Styles/Classix/assets/js/waypoints.min.js"></script>
    <script type="text/javascript" src="Styles/Classix/assets/js/jasny-bootstrap.min.js"></script>
    <script type="text/javascript" src="Styles/Classix/assets/js/form-validator.min.js"></script>
    <script type="text/javascript" src="Styles/Classix/assets/js/contact-form-script.js"></script>
    <script type="text/javascript" src="Styles/Classix/assets/js/jquery.themepunch.revolution.min.js"></script>
    <script type="text/javascript" src="Styles/Classix/assets/js/jquery.themepunch.tools.min.js"></script>
    <script src="Styles/Classix/assets/js/bootstrap-select.min.js"></script>
    <script src="Styles/Classix/assets/js/fileinput.js"></script>
    
    <!-- Reuse HTMLs -->
    <script>
        //-- Reuse About
        $(function () {
            $('#about').load('ReuseAbout.html');
        });

        //-- Reuse Useful Links
        $(function () {
            $('#links').load('ReuseLinks.html');
        });

        //-- Reuse Copyright
        $(function () {
            $('#copyright').load('ReuseCopyright.html');
        });
    </script>

    <script>
        //-- Validations

        //-- chkAgree must be Checked
        function checkAgree() {
            var chkAgree = document.getElementById("<% = chkAgree.ClientID %>");
            if (!chkAgree.checked) {
                alert("You need to Agree to the Terms and Conditions.");
                return false;
            }
            else {
                return true; 
            }
        }

    </script>
</body>

</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="TheBooksale.Categories" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="author" content="James Gagni Jr." />

    <title>The Booksale: Categories</title>

    <!-- Favicon -->
    <link rel="shortcut icon" href="Styles/images/favicon.png" />
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="Styles/Classix/assets/css/bootstrap.min.css" type="text/css" />
    <link rel="stylesheet" href="Styles/Classix/assets/css/jasny-bootstrap.min.css" type="text/css" />
    <link rel="stylesheet" href="Styles/Classix/assets/css/jasny-bootstrap.min.css" type="text/css" />
    <!-- Material CSS -->
    <link rel="stylesheet" href="Styles/Classix/assets/css/material-kit.css" type="text/css" />
    <!-- Font Awesome CSS -->
    <link rel="stylesheet" href="Styles/Classix/assets/css/font-awesome.min.css" type="text/css" />

    <link rel="stylesheet" href="Styles/Classix/assets/fonts/line-icons/line-icons.css" type="text/css" />
    <!-- Main Styles -->
    <link rel="stylesheet" href="Styles/Classix/assets/css/main.css" type="text/css" />
    <!-- Animate CSS -->
    <link rel="stylesheet" href="Styles/Classix/assets/extras/animate.css" type="text/css" />
    <!-- Owl Carousel -->
    <link rel="stylesheet" href="Styles/Classix/assets/extras/owl.carousel.css" type="text/css" />
    <link rel="stylesheet" href="Styles/Classix/assets/extras/owl.theme.css" type="text/css" />
    <link rel="stylesheet" href="Styles/Classix/assets/extras/settings.css" type="text/css" />
    <!-- Responsive CSS Styles -->
    <link rel="stylesheet" href="Styles/Classix/assets/css/responsive.css" type="text/css" />
    <!-- Bootstrap Select -->
    <link rel="stylesheet" href="Styles/Classix/assets/css/bootstrap-select.min.css" />
</head>
<body>
    <!-- Header Section Start -->
    <div class="header">
        <nav class="navbar navbar-default main-navigation" role="navigation">
            <div class="container">
                <div class="navbar-header">
                    <!-- Stat Toggle Nav Link For Mobiles -->
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <!-- End Toggle Nav Link For Mobiles -->
                    <a class="navbar-brand logo" href="Main.aspx">
                        <img src="Styles/images/Logo.png" alt="" /></a>
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
            <ul class="nav navmenu-nav">
                <!--- Menu -->
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
            </ul>
            <!--- End Menu -->
        </div>
        <!--- End Off Canvas Side Menu -->
        <div class="tbtn wow pulse" id="menu" data-wow-iteration="infinite" data-wow-duration="500ms" data-toggle="offcanvas" data-target=".navmenu">
            <p><i class="fa fa-file-text-o"></i>Menu</p>
        </div>

    </div>
    <!-- Header Section End -->

    <form class="search-form" runat="server">
        <!-- Search wrapper Start -->
        <div id="search-row-wrapper">
            <div class="container">
                <div class="search-inner">
                    <!-- Start Search box -->
                    <div class="row search-bar">
                        <div class="advanced-search">
                            <div class="col-md-3 col-sm-6 search-col">
                                <div class="input-group-addon search-category-container">
                                    <label class="styled-select">
                                        <asp:DropDownList ID="ddlCategories" runat="server" CssClass="dropdown-product selectpicker">
                                            <asp:ListItem Enabled="true" Selected="True" Text="All Categories" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </label>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-6 search-col">
                                <div class="input-group-addon search-category-container">
                                    <label class="styled-select location-select">
                                        <asp:DropDownList ID="ddlLocations" runat="server" CssClass="dropdown-product selectpicker">
                                            <asp:ListItem Enabled="true" Selected="True" Text="All Locations" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </label>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-6 search-col">
                                <asp:TextBox ID="txtSearch" runat="server" class="form-control keyword" placeholder="Enter Keyword"></asp:TextBox>
                                <i class="fa fa-search"></i>
                            </div>
                            <div class="col-md-3 col-sm-6 search-col">
                                <asp:Button ID="btnSearch" runat="server" class="btn btn-common btn-search btn-block" Text="Search" OnClientClick="if (!checkValidation()) return false;" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>
                    <!-- End Search box -->
                </div>
            </div>
        </div>
        <!-- Search wrapper End -->

        <!-- Main container Start -->
        <div class="main-container">
            <div class="container">
                <div class="row">
                    <div class="col-sm-3 page-sidebar">
                        <aside>
                            <div class="inner-box">
                                <div class="categories">
                                    <div class="widget-title">
                                        <i class="fa fa-align-justify"></i>
                                        <h4>All Categories</h4>
                                    </div>
                                    <div class="categories-list">
                                        <ul runat="server" id="lstCategories">
                                        </ul>
                                    </div>
                                </div>
                            </div>


                            <div class="inner-box">
                                <div class="user-panel-sidebar">

                                    <div class="widget-title">
                                        <i class="fa fa-align-justify"></i>
                                        <h4>Filters</h4>
                                    </div>


                                    <div class="collapse-box">
                                        <h5 class="collapset-title no-border">Condition <a aria-expanded="true" class="pull-right" data-toggle="collapse" href="#filterconditions"><i class="fa fa-angle-down"></i></a></h5>
                                        <div aria-expanded="true" id="filterconditions" class="panel-collapse collapse in">
                                            <ul class="acc-list">
                                                <li>
                                                    <asp:DropDownList ID="ddlFltConditions" runat="server" style="width: 100%;">
                                                    </asp:DropDownList>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="collapse-box">
                                        <h5 class="collapset-title no-border">Price <a aria-expanded="true" class="pull-right" data-toggle="collapse" href="#filterprice"><i class="fa fa-angle-down"></i></a></h5>
                                        <div aria-expanded="true" id="filterprice" class="panel-collapse collapse in">
                                            <ul class="acc-list">
                                                <li>From
                                                    <asp:TextBox ID="txtFltMinimum" runat="server" class="form-control input-md" placeholder="Minimum"></asp:TextBox>
                                                </li>
                                                <li>To
                                                    <asp:TextBox ID="txtFltMaximum" runat="server" class="form-control input-md" placeholder="Maximm"></asp:TextBox>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="collapse-box">
                                        <h5 class="collapset-title no-border"><a aria-expanded="true" class="pull-right" data-toggle="collapse" href="#filterremove"><i class="fa fa-angle-down"></i></a></h5>
                                        <div aria-expanded="true" id="filterremove" class="panel-collapse collapse in">
                                            <ul class="acc-list">
                                                <li>
                                                    <asp:Button ID="btnFilterApply" runat="server" class="btn btn-common" Text="Apply Filters" OnClick="btnFilterApply_Click" />
                                                </li><br />
                                                <li>
                                                    <asp:Button ID="btnFilterRemove" runat="server" class="btn btn-common" Text="Erase Filters" OnClick="btnFilterRemove_Click" />
                                                </li>
                                            </ul>
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div class="inner-box">
                                <div class="widget-title">
                                    <h4>Advertisement</h4>
                                </div>
                                <img src="Files/Photos/Sponsors/Lulu-James.jpg" alt="" />
                            </div>
                        </aside>
                    </div>
                    <div class="col-sm-9 page-content">
                        <!-- Product filter Start -->
                        <div class="product-filter">
                            <div class="grid-list-count">
                                <a class="list switchToGrid" href="#"><i class="fa fa-list"></i></a>
                                <a class="grid switchToList" href="#"><i class="fa fa-th-large"></i></a>
                            </div>
                            <div class="short-name">
                                <span>Sort By</span>
                                <label>
                                    <select name="order" class="orderby">
                                        <option selected="selected" value="menu-order">Sort by</option>
                                        <option value="popularity">Price: Low to High</option>
                                        <option value="popularity">Price: High to Low</option>
                                    </select>
                                </label>
                            </div>
                        </div>



                        <div class="product-filter">
                            <div class="Show-item">
                                <span>Filter: </span>
                                <label class="control-label text-left">
                                    <asp:Label ID="lblFilter" runat="server" Text="None"></asp:Label>
                                </label>
                            </div>
                            <div class="Show-item">
                                <span>Category: </span>
                                <label class="control-label text-left">
                                    <asp:Label ID="lblHdrCategory" runat="server" Text="All Categories"></asp:Label>
                                    </label>
                            </div>
                        </div>
                        <!-- Product filter End -->

                        <!-- Ads wrapper Start -->
                        <asp:ListView ID="lvwCategoryItems" runat="server" ItemPlaceholderID="plhCategoryItems">
                            <LayoutTemplate>
                                <div class="adds-wrapper">
                                    <asp:PlaceHolder ID="plhCategoryItems" runat="server"></asp:PlaceHolder>
                                </div>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div class="item-list">
                                    <div class="col-sm-2 no-padding photobox">
                                        <div class="add-image">
                                            <a id="lnkAdViaPhoto" runat="server" href='<%# "AdsDetails.aspx?XAD=" + Eval("ADS_ID") %>'>
                                                <asp:Image ID="imgPhotoMain" runat="server" ImageUrl='<%# Eval("PHO_PATH") %>' /></a>
                                            <span class="photo-count"><i class="fa fa-camera"></i>
                                                <asp:Label ID="lblImageCount" runat="server" Text='<%# Eval("ADP_PHOTOS_COUNT") %>'></asp:Label></span>
                                        </div>
                                    </div>
                                    <div class="col-sm-7 add-desc-box">
                                        <div class="add-details">
                                            <h5 class="add-title"><a id="lnkAdViaTitle" runat="server" href='<%# "AdsDetails.aspx?XAD=" + Eval("ADS_ID") %>'>
                                                <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("ADS_TITLE") %>'></asp:Label></a></h5>
                                            <div class="info">
                                                <span class="add-type">
                                                    <asp:Label ID="lblAdTypeInitial" runat="server" Text='<%# Eval("ADT_NAME") %>'></asp:Label>
                                                </span>
                                                <span class="date">
                                                    <i class="fa fa-clock"></i>
                                                    <asp:Label ID="lblPublishDate" runat="server" Text='<%# Eval("ADS_MODIFIEDDATE","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </span>-
                      <span class="category">
                          <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("CAT_CATEGORY_NAME") %>'></asp:Label>
                      </span>-
                      <span class="item-location"><i class="fa fa-map-marker"></i>
                          <asp:Label ID="lblProvince" runat="server" Text='<%# Eval("PRV_NAME") %>'></asp:Label>
                      </span>
                                            </div>
                                            <div class="item_desc">
                                                <a id="lnkAdViaDesc" runat="server" href='<%# "AdsDetails.aspx?XAD=" + Eval("ADS_ID") %>'>
                                                    <asp:Label ID="lblAdDetails" runat="server" Text='<%# Eval("ADS_DESCRIPTION") %>'></asp:Label>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3 text-right  price-box">
                                        <h2 class="item-price">
                                            <asp:Label ID="lblPrice" runat="server" Text='<%# "Php " + Eval("ADS_PRICE") %>'></asp:Label>
                                        </h2>
                                        <a class="btn btn-common btn-sm"> <i class="fa fa-eye"></i> <span>
                                            <asp:Label ID="lblAdViews" runat="server" Text='<%# Eval("ADV_COUNT") %>'></asp:Label>
                                        </span> </a> 
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                        <div class="pager">
                            <asp:DataPager ID="pgrCategoryItems" runat="server" PagedControlID="lvwCategoryItems" PageSize="5">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn btn-common btn-sm"
                                        ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="True" />
                                    <asp:NumericPagerField ButtonCount="5" ButtonType="Link" NumericButtonCssClass="btn btn-common btn-sm" />
                                    <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn btn-common btn-sm"
                                        ShowLastPageButton="True" ShowNextPageButton="True" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </div>
                        <!-- Ads wrapper End -->

                        <div class="post-promo text-center">
                            <h2>Have you got any book to sell? </h2>
                            <h5>Sell your books online FOR FREE. It's easier than you think!</h5>
                            <a href="AdsPost.aspx" class="btn btn-post btn-danger">Post a Free Ad </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Main container End -->
    </form>

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
                                    <li class="clearfix">
                                        <span>Make sure you are following
                        <a href="#">@StarWitsApps</a> for all your application development needs! 
                                        </span>
                                    </li>
                                    <li class="clearfix">
                                        <span>All the apps you need, right here, at Star Wits Apps. Join us: 
                        <a href="#">http://starwitsapps.com</a>
                                        </span>
                                    </li>
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
    <a href="#" class="back-to-top">
        <i class="fa fa-angle-up"></i>
    </a>

    <asp:SqlDataSource ID="sqlCategoryItems" runat="server" ConnectionString="<%$ ConnectionStrings:cnBooksale %>" ProviderName="<%$ ConnectionStrings:cnBooksale.ProviderName %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlLatestAds" runat="server" ConnectionString="<%$ ConnectionStrings:cnBooksale %>" ProviderName="<%$ ConnectionStrings:cnBooksale.ProviderName %>"></asp:SqlDataSource>

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

    <!-- Validations -->
    <script>
        //-- Search Validation
        function checkValidation() {
            var txtSearch = document.getElementById("<% = txtSearch.ClientID %>");
            if (txtSearch.value.length < 4) {
                alert("You need to enter at least 4 characters to perform a Search.");
                return false;
            }
            else {
                return true;
            }
        }

        //-- Filter Validation
        function checkFltPrice() {
            var txtFltMinimum = document.getElementById("<% = txtFltMinimum.ClientID %>");
            var txtFltMaximum = document.getElementById("<% = txtFltMaximum.ClientID %>");
            if ((txtFltMinimum.innerText.trim.length <= 0) || (txtFltMaximum.innerText.trim.length <= 0)) {
                alert("A Minimum and Maximum value needs to be set first.");
                return false;
            }
        }
    </script>

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
</body>
</html>

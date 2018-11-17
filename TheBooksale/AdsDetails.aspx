<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdsDetails.aspx.cs" Inherits="TheBooksale.AdsDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="author" content="James Gagni Jr." />

    <title>The Booksale: Ad Details</title>

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
    <style type="text/css">
        .auto-style1 {
            font-size: 14px;
            color: #FFFFFF;
            text-transform: uppercase;
            vertical-align: middle;
            background-color: #3498DB;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
                            <img src="Styles/images/Logo.png" alt=""></a>
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

        <!-- Start Content -->
        <div id="content">
            <div class="container">
                <div class="row">
                    <!-- Product Info Start -->
                    <div class="product-info">
                        <div class="col-sm-8">
                            <div class="inner-box ads-details-wrapper">
                                <h2>
                                    <asp:Label ID="lblTitle" runat="server" Text="Ad Title"></asp:Label>
                                </h2>
                                <p class="item-intro">
                                    <span class="poster">
                                        <asp:Label ID="lblForAdType" runat="server" Text="For sale by"></asp:Label>
                                        <span class="ui-bubble is-member">
                                            <asp:Label ID="lblForName" runat="server" Text="Name"></asp:Label>
                                        </span>
                                        <span class="date">
                                            <asp:Label ID="lblPublishDate" runat="server" Text="on 2018-10-18"></asp:Label>
                                        </span>
                                        from <span class="location">
                                            <asp:Label ID="lblForLocation" runat="server" Text="City, Province"></asp:Label>
                                        </span>
                                    </span>
                                </p>
                                <div id="divOwlDemo" runat="server">
                                    <div id="owl-demo" class="owl-carousel owl-theme">
                                        <div class="item">
                                            <asp:Image ID="imgAds1" runat="server" alt="Ad Photo 1" ImageUrl="Files/Photos/Samples/ad.jpg" />
                                        </div>
                                        <div class="item">
                                            <asp:Image ID="imgAds2" runat="server" alt="Ad Photo 2" ImageUrl="Files/Photos/Samples/ad.jpg" />
                                        </div>
                                        <div class="item">
                                            <asp:Image ID="imgAds3" runat="server" alt="Ad Photo 3" ImageUrl="Files/Photos/Samples/ad.jpg" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="box">
                                <h2 class="title-2"><strong>Book Ad Details</strong></h2>
                                <div class="row">
                                    <div class="ads-details-info col-md-8">
                                        <p class="mb15">
                                            <asp:Label ID="lblAdDetails" runat="server" Text="Powerful dual-core and quad-core Intel processors"></asp:Label>
                                        </p>
                                    </div>
                                    <div class="col-md-4">
                                        <aside class="panel panel-body panel-details">
                                            <ul>
                                                <li>
                                                    <p class=" no-margin ">
                                                        <strong>Author:</strong>
                                                        <asp:Label ID="lblAuthor" runat="server" Text=""></asp:Label>
                                                    </p>
                                                </li>
                                                <li>
                                                    <p class=" no-margin ">
                                                        <strong>Price:</strong>
                                                        Php
                                                    <asp:Label ID="lblPrice" runat="server" Text="0,000.00"></asp:Label>
                                                    </p>
                                                </li>
                                                <li>
                                                    <p class="no-margin">
                                                        <strong>Type:</strong>
                                                        <a href="#">
                                                            <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label></a>,  
                                                    <a href="#">
                                                        <asp:Label ID="lblSubCategory" runat="server" Text="SubCategory"></asp:Label></a>, 
                                                    <a href="#">
                                                        <asp:Label ID="lblAdType" runat="server" Text="For Sale or To Buy"></asp:Label></a>
                                                    </p>
                                                </li>
                                                <li>
                                                    <p class="no-margin">
                                                        <strong>Location:</strong>
                                                        <a href="#">
                                                            <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label></a>, 
                                                    <a href="#">
                                                        <asp:Label ID="lblProvince" runat="server" Text="Province"></asp:Label></a>
                                                    </p>
                                                </li>
                                                <li>
                                                    <p class=" no-margin ">
                                                        <strong>Condition:</strong>
                                                        <asp:Label ID="lblCondition" runat="server" Text="Condition"></asp:Label>
                                                    </p>
                                                </li>
                                            </ul>
                                        </aside>

                                        <div id="adsActionLoggedIn" class="ads-action" runat="server">
                                            <ul class="list-border">
                                                <li>
                                                    <a href="#"><i class=" fa fa-phone"></i>
                                                        <asp:Label ID="lblContactPhone" runat="server" Text="09991119999"></asp:Label>
                                                    </a></li>
                                                <li>
                                                    <a href="#"><i class=" fa fa-mail-reply"></i>
                                                        <asp:Label ID="lblContactEmail" runat="server" Text="mail@mail.com"></asp:Label>
                                                    </a></li>
                                                <li>
                                                    <a id="lnkPostedBy" runat="server">Posted by <i class=" fa fa-user"></i>
                                                        <asp:Label ID="lblContactDisplayName" runat="server" Text="Name"></asp:Label>
                                                    </a></li>
                                                <li>
                                                    <p>
                                                        <a id="lnkUserProfile" runat="server" class="btn btn-primary btn-xs">
                                                            <i class="fa fa-share-square-o"></i>
                                                            <asp:Label ID="lblLnkViewUserProfile" runat="server" Text="Name"></asp:Label>
                                                        </a>
                                                    </p>
                                                </li>
                                                <li>
                                                    <p>
                                                        <a id="lnkReviewSeller" runat="server" class="btn btn-primary btn-xs">
                                                            <i class="fa fa-share-square-o"></i>Review Seller</a>
                                                    </p>
                                                </li>
                                                <li>
                                                    <p>
                                                        <a id="lnkReviewBuyer" runat="server" class="btn btn-primary btn-xs">
                                                            <i class="fa fa-share-square-o"></i>Review Buyer</a>
                                                    </p>
                                                </li>
                                            </ul>
                                        </div>
                                        <div id="adsActionNotLoggedIn" class="ads-action" runat="server">
                                            <ul class="list-border">
                                                <li class="auto-style1">/</li>
                                            </ul>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="inner-box">
                                <div class="widget-title">
                                    <h4>Advertisement</h4>
                                </div>
                                <img src="Files/Photos/Sponsors/Lulu-James.jpg" alt="" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End Content -->

            <!-- Related Book Ads Start -->
            <section class="featured-lis mb30">
                <div class="container">
                    <!-- Related Books by Genre -->
                    <div class="row">
                        <div class="col-md-12 wow fadeIn" data-wow-delay="0.5s">
                            <h1 class="section-title">Interested in these other 
                                <asp:Label ID="lblRelatedGenre" runat="server" Text=""></asp:Label>
                                items?</h1>
                            <div id="related-genre" class="owl-carousel">
                                <asp:ListView ID="lvwRelatedByGenre" runat="server">
                                    <ItemTemplate>
                                        <div class="item">
                                            <div class="product-item">
                                                <div class="carousel-thumb">
                                                    <asp:Image ID="imgPhotoMain" runat="server" ImageUrl='<%# Eval("PHO_PATH") %>' />
                                                    </a>
                                        <div class="overlay">
                                            <a id="lnkAdViaPhoto" runat="server" href='<%# "AdsDetails.aspx?XAD=" + Eval("ADS_ID") %>'>
                                                <i class="fa fa-link"></i></a>
                                        </div>
                                                </div>
                                                <a href='<%# "AdsDetails.aspx?XAD=" + Eval("ADS_ID") %>' class="item-name">
                                                    <asp:Label ID="lblListTitle" runat="server" Text='<%# Eval("ADS_TITLE") %>'></asp:Label></a>
                                                <span class="price">
                                                    <asp:Label ID="lblListPrice" runat="server" Text='<%# "Php " + Eval("ADS_PRICE") %>'></asp:Label>
                                                </span>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>

                    <!-- Related Books by Author -->
                    <div class="row">
                        <div class="col-md-12 wow fadeIn" data-wow-delay="0.5s">
                            <h1 class="section-title">...How about other books by 
                                <asp:Label ID="lblRelatedAuthor" runat="server" Text=""></asp:Label>?</h1>
                            <div id="related-author" class="owl-carousel">
                                <asp:ListView ID="lvwRelatedByAuthor" runat="server">
                                    <ItemTemplate>
                                        <div class="item">
                                            <div class="product-item">
                                                <div class="carousel-thumb">
                                                    <asp:Image ID="imgPhotoMainByAuthor" runat="server" ImageUrl='<%# Eval("PHO_PATH") %>' />
                                                    </a>
                                        <div class="overlay">
                                            <a id="lnkAdViaPhotoByAuthor" runat="server" href='<%# "AdsDetails.aspx?XAD=" + Eval("ADS_ID") %>'>
                                                <i class="fa fa-link"></i></a>
                                        </div>
                                                </div>
                                                <a href='<%# "AdsDetails.aspx?XAD=" + Eval("ADS_ID") %>' class="item-name">
                                                    <asp:Label ID="lblListTitleByAuthor" runat="server" Text='<%# Eval("ADS_TITLE") %>'></asp:Label></a>
                                                <span class="price">
                                                    <asp:Label ID="lblListPriceByAuthor" runat="server" Text='<%# "Php " + Eval("ADS_PRICE") %>'></asp:Label>
                                                </span>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>


                    <!-- Other Sellers Where Similar Books have been Sold -->
                    <div class="row">
                        <div class="col-md-12 wow fadeIn" data-wow-delay="0.5s">
                            <h1 class="section-title">...And they may have that book you're looking for... </h1>
                            <div id="new-products" class="owl-carousel">
                                <asp:ListView ID="lvwRelatedSeller" runat="server">
                                    <ItemTemplate>
                                        <div class="item">
                                            <div class="product-item">
                                                <div class="carousel-thumb">
                                                    <asp:Image ID="imgProfilePhoto" runat="server" ImageUrl='<%# Eval("USR_PHOTO") %>' />
                                                    </a>
                                        <div class="overlay">
                                            <a id="lnkAdViaPhoto" runat="server" href='<%# "ProfileAds.aspx?XAT=2&XID=" + Eval("USR_USER_ID") %>'>
                                                <i class="fa fa-link"></i></a>
                                        </div>
                                                </div>
                                                <a href='<%# "ProfileAds.aspx?XAT=2&XID=" + Eval("USR_USER_ID") %>' class="item-name">
                                                    <asp:Label ID="lblListTitle" runat="server" Text='<%# Eval("DISPLAYNAME") %>'></asp:Label></a>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>

                </div>
            </section>
            <!-- Related Book Ads End -->

        </div>


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

        <asp:SqlDataSource ID="sqlLatestAds" runat="server" ConnectionString="<%$ ConnectionStrings:cnBooksale %>" ProviderName="<%$ ConnectionStrings:cnBooksale.ProviderName %>"></asp:SqlDataSource>

        <asp:SqlDataSource ID="sqlRelatedAdsByGenre" runat="server" ConnectionString="<%$ ConnectionStrings:cnBooksale %>" ProviderName="<%$ ConnectionStrings:cnBooksale.ProviderName %>"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sqlRelatedAdsByAuthor" runat="server" ConnectionString="<%$ ConnectionStrings:cnBooksale %>" ProviderName="<%$ ConnectionStrings:cnBooksale.ProviderName %>"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sqlRelatedSellers" runat="server" ConnectionString="<%$ ConnectionStrings:cnBooksale %>" ProviderName="<%$ ConnectionStrings:cnBooksale.ProviderName %>"></asp:SqlDataSource>

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
        <script type="text/javascript" src="Styles/Classix/assets/js/bootstrap-select.min.js"></script>

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
    </form>
</body>
</html>

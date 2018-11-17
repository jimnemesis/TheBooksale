<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="TheBooksale.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="author" content="James Gagni Jr." />

    <title>The Booksale</title>

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
    <!-- Line Icons CSS -->
    <link rel="stylesheet" href="Styles/Classix/assets/fonts/line-icons/line-icons.css" type="text/css" />

    <!-- Main Styles -->
    <link rel="stylesheet" href="Styles/Classix/assets/css/main.css" type="text/css" />
    <!-- Animate CSS -->
    <link rel="stylesheet" href="Styles/Classix/assets/extras/animate.css" type="text/css" />
    <!-- Owl Carousel -->
    <link rel="stylesheet" href="Styles/Classix/assets/extras/owl.carousel.css" type="text/css" />
    <link rel="stylesheet" href="Styles/Classix/assets/extras/owl.theme.css" type="text/css" />
    <!-- Responsive CSS Styles -->
    <link rel="stylesheet" href="Styles/Classix/assets/css/responsive.css" type="text/css" />
    <!-- Slicknav js -->
    <link rel="stylesheet" href="Styles/Classix/assets/css/slicknav.css" type="text/css" />
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
                            <a class="btn btn-danger btn-post" href="AdsPost.aspx"><span class="fa fa-plus-circle"></span> Post an Ad </a>
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

    </div>
    <!-- Header Section End -->

    <!-- Start intro section -->
    <section id="intro" class="section-intro">
        <div class="overlay">
            <div class="container">
                <div class="main-text">
                    <h1 class="intro-title">Welcome To <span style="color: #3498DB">The Booksale</span></h1>
                    <p id="pSubTitle" runat="server" class="sub-title">Have you found that book you've always been looking for? It could be here!</p>

                    <!-- Start Search box -->
                    <div class="row search-bar">
                        <div class="advanced-search">
                            <form class="search-form" runat="server">
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
                                    <strong>
                                        <asp:Button ID="btnSearch" runat="server" class="btn btn-common btn-search btn-block" Text="Search" OnClientClick="if (!checkValidation()) return false;" OnClick="btnSearch_Click" />
                                    </strong>
                                </div>
                            </form>
                        </div>
                    </div>
                    <!-- End Search box -->
                </div>
            </div>
        </div>
    </section>
    <!-- end intro section -->

    <div class="wrapper">
        <!-- Categories Homepage Section Start -->
        <section class="grid-category" id="categories-homepage">
        <div class="container">
          <div class="row">
            <div class="col-md-12">
              <div class="box-title no-border">
                <div class="inner">
                  <h3 class="section-title"><span>Browse by</span> Category</h3>   
                  <a href="Categories.aspx?XCA=0" class="sell-your-item"><i class="fa fa-th-large"></i> View more 
                  </a>
                </div>
              </div>
            </div>
            <div runat="server" id="divCategories" class="col-md-12" > 
            </div>
          </div>
        </div>
      </section>
        <!-- Categories Homepage Section End -->

        <!-- Latest Books Posted -->
        <section class="featured-lis">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 wow fadeIn" data-wow-delay="0.5s">
                        <h3 class="section-title">Latest Book Ads Posted</h3>
                        <div id="new-products" class="owl-carousel">
<asp:ListView ID="lvwLatestAds" runat="server">
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
                                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("ADS_TITLE") %>'></asp:Label></a>
                                    <span class="price">
                                        <asp:Label ID="lblPrice" runat="server" Text='<%# "Php " + Eval("ADS_PRICE") %>'></asp:Label>
                                    </span>
                                </div>
                            </div>
                                    </ItemTemplate>
    </asp:ListView>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- Latest Books Posted End -->
        
    </div>

    <!-- Counter Section Start -->
    <section id="counter">
        <div class="container">
            <div class="row">
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="counting wow fadeInDownQuick" data-wow-delay=".5s">
                        <div class="icon">
                            <span>
                                <i class="lnr lnr-tag"></i>
                            </span>
                        </div>
                        <div class="desc">
                            <h3 class="counter">
                                <asp:Label ID="lblCtrAdsTotal" runat="server" Text="Label"></asp:Label>
                            </h3>
                            <p>Total Book Ads</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="counting wow fadeInDownQuick" data-wow-delay="1s">
                        <div class="icon">
                            <span>
                                <i class="lnr lnr-map"></i>
                            </span>
                        </div>
                        <div class="desc">
                            <h3 class="counter">
                                <asp:Label ID="lblCtrLocations" runat="server" Text="Label"></asp:Label>
                            </h3>
                            <p>Number of Cities with Book Ads</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="counting wow fadeInDownQuick" data-wow-delay="1.5s">
                        <div class="icon">
                            <span>
                                <i class="lnr lnr-users"></i>
                            </span>
                        </div>
                        <div class="desc">
                            <h3 class="counter">
                                <asp:Label ID="lblCtrUsersActive" runat="server" Text="Label"></asp:Label>
                            </h3>
                            <p>Active Users with Ads</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="counting wow fadeInDownQuick" data-wow-delay="2s">
                        <div class="icon">
                            <span>
                                <i class="lnr lnr-license"></i>
                            </span>
                        </div>
                        <div class="desc">
                            <h3 class="counter">
                                <asp:Label ID="lblCtrAdsToday" runat="server" Text="Label"></asp:Label>
                            </h3>
                            <p>New Book Ads Today</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Counter Section End -->

    <!-- Footer Section Start -->
    <footer>
        <!-- Footer Area Start -->
        <section class="footer-Content">
            <div class="container">
                <div class="row">
                    <div class="col-md-3 col-sm-6 col-xs-12 wow fadeIn" data-wow-delay="0">
                        <div class="widget">
                            <h3 class="block-title">About us</h3>
                            <div id="about">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12 wow fadeIn" data-wow-delay="0.5">
                        <div class="widget">
                            <h3 class="block-title">Useful Links</h3>
                            <div id="links">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12 wow fadeIn" data-wow-delay="1s">
                        <div class="widget">
                            <h3 class="block-title">Tweets</h3>
                            <div class="twitter-content clearfix">
                                <ul class="twitter-list">
                                    <li class="clearfix">
                                        <span>Buy and Sell Bookads via @StarWitsApps' The Booksale
                        <a href="#">http://thebooksale.com</a>
                                        </span>
                                    </li>
                                    <li class="clearfix">
                                        <span>New Apps and Websites via @StarWitsApps
                        <a href="#">http://starwitsapps.com</a>
                                        </span>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12 wow fadeIn" data-wow-delay="1.5s">
                        <div class="widget">
                            <h3 class="block-title">Testimonials</h3>
                            <div id="testimonials">
                            </div>
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
            else
            {
                return true;
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

        //-- Reuse Testimonial
        $(function () {
            $('#testimonials').load('ReuseTestimonials.html');
        });

        //-- Reuse Copyright
        $(function () {
            $('#copyright').load('ReuseCopyright.html');
        });
    </script>
</body>
</html>

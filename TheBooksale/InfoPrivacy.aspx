<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoPrivacy.aspx.cs" Inherits="TheBooksale.InfoPrivacy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="author" content="James Gagni Jr." />

    <title>Privacy Policy</title>

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

    <!-- Page Header Start -->
    <div class="page-header" style="background: url(Styles/Classix/assets/img/banner1.jpg);">
      <div class="container">
        <div class="row">         
          <div class="col-md-12">
            <div class="breadcrumb-wrapper">
              <h2 class="page-title">Privacy Policy</h2>
            </div>
          </div>
        </div>
      </div>
    </div>
    <!-- Page Header End --> 

    <!-- Start Content -->
    <div id="content">
      <div class="container">        
        <div class="row">
          <div class="col-md-12">
            <div class="head-faq text-center">
              <h2 class="section-title">The Booksale's Privacy Policy</h2>
            </div>
            <!-- accordion start -->
            <div class="panel-group" id="accordion">
              <div class="panel panel-default">
                <div class="panel-heading">
                  <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">
                      Overall Privacy
                    </a>
                  </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                  <div class="panel-body">
                    <p>
                      At The Booksale, we value your privacy. Rest assured that the information you provide when you use our websites and related applications will be collected and used in the manner stated in this Policy.
                    </p>
                  </div>
                </div>
              </div>
              <div class="panel panel-default">
                <div class="panel-heading">
                  <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                      What Information We Collect
                    </a>
                  </h4>
                </div>
                <div id="collapseTwo" class="panel-collapse collapse">
                  <div class="panel-body">
                    <p>
                      As a member, you need to provide us with your name, mobile number, and email address. These pieces of information are required, to serve as our point of contact with our members, and must be indicated in our registration forms and profile update forms. 
                    </p>
                    <br />
                    <p>
                        To maintain the accuracy of members’ personal information, they may access this at any time and change any inaccuracies they may find by updating their profile. Members also have the option to delete their information from our database by updating their profile or sending us a support ticket to deactivate their account. Upon such change or request from a member, we shall notify third parties who have previously received or processed such information.
                    </p>
                  </div>
                </div>
              </div>
              <div class="panel panel-default">
                <div class="panel-heading">
                  <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree">
                      How We Use Your Personal Information
                    </a>
                  </h4>
                </div>
                <div id="collapseThree" class="panel-collapse collapse">
                  <div class="panel-body">
                    <p>
                      All information that you provide us, including information you post in the site, may be collected and processed internally, or by authorized third parties.  Also, by using our services, you consent to the collection, transfer, processing and storage of information we collect whether done within or outside of the Philippines. We assure you that our actions concerning your personal information will be guided by this Privacy Policy.
                    </p>
                  </div>
                </div>
              </div>
              <div class="panel panel-default">
                <div class="panel-heading">
                  <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseFour">
                      Purposes for Information.
                    </a>
                  </h4>
                </div>
                <div id="collapseFour" class="panel-collapse collapse">
                  <div class="panel-body">
                      <p>
                           The information you provide us may be used in any of the following manner:
                      </p>
                      <br />
                    <p>
                      a. Product Personalization
                    </p>
                    <br />
                    <p>
                      To provide better and customized service to you. 
                        <br />
                       To customize and tailor fit the items you see on our platform recommendations to your interests.
                        <br />
                       We are able to do this with your help. By using your cookies, we are able to track usage patterns and deliver customized content to all users. A cookie is a small text file that our Web server places on a user’s computer hard drive as a unique identifier. Our cookies have an expiration date.
                    </p>

                    <br />
                    <p>
                      b. Communications Service - To provide communications services to our members.
                    </p>
                    <br />
                    <p>
                      Send customized email, SMS, and push notifications based on the custom segmentations we get from the entire database. 
                        <br />
                       Our members receive e-mails and SMS regarding items posted in our system.
                        <br />
                       We also send additional announcements about products, services, special deals and newsletters.
                        <br />
                    Members may opt not to receive these types of communications.
                    </p>

                    <br />
                    <p>
                      c. Product Improvement.
                    </p>
                    <br />
                    <p>
                      To improve our products and services and to develop new ones.
                    </p>

                    <br />
                    <p>
                      d. Expanded Data Segmentation.
                    </p>
                    <br />
                    <p>
                      Connect behavioral data on our platform (buying and selling actions) with your customer profile and demographics. 
                        <br />
                       Extract patterns of behavior based on the profiles we can identify from the information you have given us.
                        <br />
                       We also send additional announcements about products, services, special deals and newsletters.
                    </p>
                  </div>
                </div>
              </div>
              <div class="panel panel-default">
                <div class="panel-heading">
                  <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseFive">
                      Information Sharing.
                    </a>
                  </h4>
                </div>
                <div id="collapseFive" class="panel-collapse collapse">
                  <div class="panel-body">
                      <p>
                           Subject to applicable law, we may share, transfer, and disclose the information we collect, to the following:
                      </p>
                      <br />
                    <p>
                      a. Companies that form part of our group of companies, to enable them to offer or improve their respective services or products;
                    </p>

                    <br />
                    <p>
                      b. Service providers that help us provide our services, to the extent needed to perform their duties and their functions;
                    </p>

                    <br />
                    <p>
                      c. Government authorities, at their request and only when legally required to do so; and,
                    </p>

                    <br />
                    <p>
                      d. Purchasers or potential purchasers of our rights and obligations relating to the services we provide. In this case, all information collected are deemed assets that may be transferred to such third parties.
                    </p>
                  </div>
                </div>
              </div>
              <div class="panel panel-default">
                <div class="panel-heading">
                  <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseSix">
                      Necessary to Protect Legitimate Interests.
                    </a>
                  </h4>
                </div>
                <div id="collapseSix" class="panel-collapse collapse">
                  <div class="panel-body">
                      <p>
                           The information we collect may also be shared, transferred and disclosed when this is necessary:
                      </p>
                      <br />
                    <p>
                      a. To protect the rights and interests of The Booksale, business partners, customers or third parties, as may be required and permitted by law; and
                    </p>

                    <br />
                    <p>
                      b. To pursue your legitimate interests, as may be required or permitted by law.
                    </p>
                  </div>
                </div>
              </div>
              <div class="panel panel-default">
                <div class="panel-heading">
                  <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseSeven">
                      Advertisement in different media.
                    </a>
                  </h4>
                </div>
                <div id="collapseSeven" class="panel-collapse collapse">
                  <div class="panel-body">
                      <p>
                           Images and information uploaded or posted may be used to advertise The Booksale and its services in different media (i.e., Above-the-line, Below-the-line, SEM, Social Media advertising). Information may be used for the conduct of promotions and advertisements through e-mails and SMS.
                      </p>
                  </div>
                </div>
              </div>
              <div class="panel panel-default">
                <div class="panel-heading">
                  <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseEight">
                      Location identification.
                    </a>
                  </h4>
                </div>
                <div id="collapseEight" class="panel-collapse collapse">
                  <div class="panel-body">
                      <p>
                           Through information provided by the device you use to access our Apps and services, we are provided with IP addresses and other locational information. An IP Address is a unique identifier that identifies your computer or device in the Internet. These information are used to identify the location of the device (i.e., town, city and country), and these are added to all data that are submitted to the system.
                      </p>
                  </div>
                </div>
              </div>
              <div class="panel panel-default">
                <div class="panel-heading">
                  <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseNine">
                      Market analysis.
                    </a>
                  </h4>
                </div>
                <div id="collapseNine" class="panel-collapse collapse">
                  <div class="panel-body">
                      <p>
                           The information we collect may be used for assessment, record keeping, market analysis and generation of reports.
                      </p>
                      <br />
                    <p>
                      For the purpose of the foregoing, you agree and authorize The Booksale to disclose any and all information you provided, to its partners, customers, third party service providers, to government agencies, and such entities that may have a legitimate interest in the said information.
                    </p>
                  </div>
                </div>
              </div>
              <div class="panel panel-default">
                <div class="panel-heading">
                  <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseTen">
                      How We Secure your Personal Information
                    </a>
                  </h4>
                </div>
                <div id="collapseTen" class="panel-collapse collapse">
                  <div class="panel-body">
                    <p>
                      We endeavor to protect your information by using hosts that have secure servers. Sufficient physical and technical methods and procedures are employed to safeguard and secure the information from unauthorized or unlawful processing. We have no control, however, over any information you provide when you leave our websites and Apps. Our Websites and Apps offer listings, as well as links to third-party websites. When you click on these links, you effectively leave our Website and Apps.
                    </p>

                      <br />
                      <p>
                          To ensure your protection, we encourage you to read their privacy policies. We also have no control over third-party advertising companies that serve ads when you visit our Website and Apps. They may use information about your visits to our Apps and other websites in order to provide advertisements about goods and services that may be of interest to you. While we will not provide them your name, mobile number, or email address, we do not control their collection of information.
                      </p>
                  </div>
                </div>
              </div>
            </div>
            <!-- accordion End -->    
          </div>      
        </div>
      </div>      
    </div>
    <!-- End Content -->

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

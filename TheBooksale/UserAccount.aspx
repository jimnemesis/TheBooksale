<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAccount.aspx.cs" Inherits="TheBooksale.MyAccountHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="author" content="James Gagni Jr." />

    <title>The Booksale: My Account</title>

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
    <!-- File Input -->
    <link rel="stylesheet" href="Styles/Classix/assets/css/fileinput.css" />
    <!-- JQuery UI -->
    <link href="Styles/Classix/assets/js/jquery-ui-1.11.0/jquery-ui.min.css" rel="stylesheet" type="text/css" />

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

    <!-- Start Content -->
    <div id="content">
        <div class="container">
            <div class="row">
                <div class="col-sm-3 page-sideabr">
                    <aside>
                        <div class="inner-box">
                            <div class="user-panel-sidebar">
                                <div class="collapse-box">
                                    <h5 class="collapset-title no-border">My Account <a aria-expanded="true" class="pull-right" data-toggle="collapse" href="#myclassified"><i class="fa fa-angle-down"></i></a></h5>
                                    <div aria-expanded="true" id="myclassified" class="panel-collapse collapse in">
                                        <ul class="acc-list">
                                            <li class="active">
                                                <a href="UserAccount.aspx"><i class="fa fa-home"></i> Account </a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="collapse-box">
                                    <h5 class="collapset-title">My Ads <a aria-expanded="true" class="pull-right" data-toggle="collapse" href="#myads"><i class="fa fa-angle-down"></i></a></h5>
                                    <div aria-expanded="true" id="myads" class="panel-collapse collapse in">
                                        <ul class="acc-list">
                                            <li>
                                                <a href="UserAds.aspx?XLM=0"><i class="fa fa-credit-card"></i> All My Ads </a>
                                            </li>
                        <li>
                          <a href="UserAds.aspx?XLM=1"><i class="fa fa-star-o"></i> Published </a>
                        </li>
                                            <li>
                                                <a href="UserAds.aspx?XLM=2"><i class="fa fa-hourglass-o"></i> Pending Approval </a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="collapse-box">
                                    <h5 class="collapset-title">Terminate Account <a aria-expanded="true" class="pull-right" data-toggle="collapse" href="#close"><i class="fa fa-angle-down"></i></a></h5>
                                    <div aria-expanded="true" id="close" class="panel-collapse collapse in">
                                        <ul class="acc-list">
                                            <li>
                                                <a id="lnkUserDelete" runat="server"><i class="fa fa-close"></i> Close Account </a>
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
                    <div class="inner-box">
                        <div class="usearadmin">
                            <h3><a href="#">
                                <asp:Image ID="imgProfilePhoto" runat="server" class="userimg" alt="" ImageUrl="~/Files/Photos/Samples/user.png" />
                                <asp:Label ID="lblProfileName" runat="server" Text="James Gagni"></asp:Label></a></h3>
                        </div>
                    </div>
                    <div class="inner-box">
                        <div class="welcome-msg">
                            <h3 class="page-sub-header2 clearfix no-padding">Hello <asp:Label ID="lblGreetName" runat="server" Text="James"></asp:Label> </h3>
                        </div>
                        <div id="accordion" class="panel-group">

                            <form id="userProfileForm" role="form" data-toggle="validator" runat="server">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title"><a href="#collapseB1" data-toggle="collapse">My details </a></h4>
                                    </div>
                                    <div class="panel-collapse collapse in" id="collapseB1">
                                        <div class="panel-body">
                                            <div class="form-group">
<div class="row search-bar red-bg">
                                <div class="advanced-search">
                                    <div class="search-form">
                                        <div class="col-md-5 col-sm-12 search-col">
                                            <div class="input-group-addon search-category-container">
                                                <label class="styled-select">
                                                    <span class="hidden-sm hidden-xs">Province </span>
                                                    <asp:DropDownList ID="ddlProvinces" runat="server" CssClass="dropdown-product selectpicker" 
                                                        OnSelectedIndexChanged="ddlProvinces_SelectedIndexChanged" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                </label>
                                            </div>
                                        </div>
                                        <div class="col-md-5 col-sm-12 search-col">
                                            <div class="input-group-addon search-category-container">
                                                <label class="styled-select">
                                                    <span class="hidden-sm hidden-xs">City </span>
                                                    <asp:DropDownList ID="ddlCities" runat="server" CssClass="dropdown-product selectpicker">
                                                    </asp:DropDownList>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">First Name</label>
                                                <asp:TextBox ID="txtFName" runat="server" class="form-control" placeholder="First Name"></asp:TextBox>
                                                <asp:HiddenField ID="hdnUsrProfileId" runat="server" />
                                                <asp:HiddenField ID="hdnUsrUserId" runat="server" />
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">Last Name</label>
                                                <asp:TextBox ID="txtLName" runat="server" class="form-control" placeholder="Last Name"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">Name to Display</label>
                                                <asp:TextBox ID="txtDisplayName" runat="server" class="form-control" placeholder="Name to Display"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">Email</label>
                                                <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" class="form-control" placeholder="Email Address" Enabled="false"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">Address</label>
                                                <asp:TextBox ID="txtAddress" runat="server" class="form-control" placeholder="Address"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="Phone" class="control-label">Philippines Contact Number</label>
                                                <asp:TextBox ID="txtPhone" TextMode="Phone" runat="server" class="form-control" placeholder="Philippines Contact Number" Enabled="false"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">Birthdate</label>
                                                <asp:TextBox ID="txtBirthDate" TextMode="Date" runat="server" class="form-control datepicker" placeholder="Birth Date"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">Biography</label>
                                                <asp:TextBox ID="txtBiography" runat="server" TextMode="MultiLine" class="form-control" placeholder="Biography" Rows="3"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="btnUpdate" runat="server" class="btn btn-common" Text="Update" OnClick="btnUpdate_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title"><a aria-expanded="false" class="collapsed" href="#collapseB2" data-toggle="collapse">Profile Photo </a></h4>
                                    </div>
                                    <div style="height: 0px;" aria-expanded="false" class="panel-collapse collapse" id="collapseB2">
                                        <div class="panel-body">
                                            <div class="form-group">                                                
                                    <label class="control-label">Profile Photo</label>
                                    <asp:FileUpload ID="fupUsrImage" runat="server" class="file" />
                                            </div>
                                            
                                            <div class="form-group">
                                                <asp:Button ID="btnUpdatePhoto" runat="server" class="btn btn-common" Text="Update Photo" OnClick="btnUpdatePhoto_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title"><a aria-expanded="false" class="collapsed" href="#collapseB3" data-toggle="collapse">Account Settings </a></h4>
                                    </div>
                                    <div style="height: 0px;" aria-expanded="false" class="panel-collapse collapse" id="collapseB3">
                                        <div class="panel-body">
                                            <div class="form-group">
                                                <label class="control-label">New Password</label>
                                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" class="form-control" placeholder="Password"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">Confirm Password</label>
                                                <asp:TextBox ID="txtPasswordReType" TextMode="Password" runat="server" class="form-control" placeholder="Retype Password"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="btnUpdateSecurity" runat="server" class="btn btn-common" Text="Update Security" OnClientClick="if (!checkValidationSecurity()) return false;" OnClick="btnUpdateSecurity_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title"><a aria-expanded="false" class="collapsed" href="#collapseB4" data-toggle="collapse">Preferences </a></h4>
                                    </div>
                                    <div style="height: 0px;" aria-expanded="false" class="panel-collapse collapse" id="collapseB4">
                                        <div class="panel-body">
                                            <div class="form-group">
                                                <div class="col-sm-12">
                                                    <div class="checkbox">
                                                        <label>
                                                            <input type="checkbox" runat="server" id="chkDisplayName"  value="forever"  />Show Display Name?
                                                        </label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="btnUpdateDisplay" runat="server" class="btn btn-common" Text="Update Display" OnClick="btnUpdateDisplay_Click" />
                                            </div>
                                        </div>
                                        </div>
                                    </div>
                            </form>
                        </div>
                    </div>
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

    <asp:SqlDataSource ID="sqlUserProfile" runat="server"
        ConnectionString="<%$ ConnectionStrings:cnBooksale %>" ProviderName="<%$ ConnectionStrings:cnBooksale.ProviderName %>" UpdateCommand="update dbo.usr_profiles
set usr_lastname = @prmLName, 
  usr_firstname = @prmFName, 
  usr_display = @prmDisplayName, 
  usr_address = @prmAddress, 
  cit_city_id = @prmCityId, 
  usr_dateofbirth = @prmDateOfBirth, 
  usr_biography = @prmBiography
where usr_profile_id = @prmUsrProfId">
        <UpdateParameters>
            <asp:Parameter Name="prmLName" />
            <asp:Parameter Name="prmFName" />
            <asp:Parameter Name="prmDisplayName" />
            <asp:Parameter Name="prmAddress" />
            <asp:Parameter Name="prmCityId" />
            <asp:Parameter Name="prmDateOfBirth" />
            <asp:Parameter Name="prmBiography" />
            <asp:Parameter Name="prmUsrProfId" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sqlUserProfilePhoto" runat="server"
        ConnectionString="<%$ ConnectionStrings:cnBooksale %>" ProviderName="<%$ ConnectionStrings:cnBooksale.ProviderName %>" UpdateCommand="update dbo.usr_profiles
set usr_photo = @prmPhotoFileName
where usr_profile_id = @prmUsrProfId">
        <UpdateParameters>
            <asp:Parameter Name="prmPhotoFileName" />
            <asp:Parameter Name="prmUsrProfId" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sqlUserProfileDisplay" runat="server"
        ConnectionString="<%$ ConnectionStrings:cnBooksale %>" ProviderName="<%$ ConnectionStrings:cnBooksale.ProviderName %>" UpdateCommand="update dbo.usr_profiles
set usr_showdisplay = @prmDisplayFlag
where usr_profile_id = @prmUsrProfId">
        <UpdateParameters>
            <asp:Parameter Name="prmDisplayFlag" />
            <asp:Parameter Name="prmUsrProfId" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlUser" runat="server"
        ConnectionString="<%$ ConnectionStrings:cnBooksale %>" ProviderName="<%$ ConnectionStrings:cnBooksale.ProviderName %>" UpdateCommand="update dbo.usr_users
set usr_password = @prmPwd, 
  usr_date_updated = GetDate()
where usr_user_id = @prmUserId">
        <UpdateParameters>
            <asp:Parameter Name="prmPwd" />
            <asp:Parameter Name="prmUserId" />
        </UpdateParameters>
    </asp:SqlDataSource>

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

    <script src="Styles/Classix/assets/js/jquery-ui-1.11.0/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1;
        var yyyy = today.getFullYear();

        $("#txtBirthDate").datepicker(
            {
                dateFormat: 'yy-mm-dd'
            });
    </script>
    
    <script>
        //-- Validations
        //-- Fields should not be empty

        //-- New Password must be equal to Retype Password
        function checkValidationSecurity() {
            var txtPassword = document.getElementById("<% = txtPassword.ClientID %>"); 
            var txtPasswordReType = document.getElementById("<% = txtPasswordReType.ClientID %>"); 

            if (txtPassword.value != txtPasswordReType.value)
            {
                alert("You need to retype your password exactly.");
                return false; 
            }

            return true; 
        }
    </script>

</body>
</html>

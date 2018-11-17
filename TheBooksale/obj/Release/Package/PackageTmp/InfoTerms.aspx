<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoTerms.aspx.cs" Inherits="TheBooksale.InfoTerms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="author" content="James Gagni Jr." />

    <title>Terms</title>

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

    <!-- Page Header Start -->
    <div class="page-header" style="background: url(Styles/Classix/assets/img/banner1.jpg);">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="breadcrumb-wrapper">
                        <h2 class="page-title">Terms and Conditions</h2>
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
                        <h2 class="section-title">Terms and Conditions</h2>
                    </div>
                    <!-- accordion start -->
                    <div class="panel-group" id="accordion">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">
                                        <b>THESE TERMS OF USE WERE UPDATED ON 13 NOVEMBER 2018</b>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse1" class="panel-collapse collapse in">
                                <div class="panel-body">
                                    <p>
                                        <b>PLEASE CAREFULLY READ THE FOLLOWING TERMS OF USE.  CHOOSING AND CONTINUING TO USE AND ACCESS THIS PLATFORM INDICATE THAT YOU ARE OF LEGAL AGE, AND THAT YOU UNDERSTAND AND ACCEPT THESE TERMS THAT WILL BE BINDING UPON YOU.  IF YOU ARE A MINOR OR DO NOT AGREE TO THESE TERMS YOU MAY OPT TO LEAVE AND NOT USE THE PLATFORM.</b>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">
                                        <b>ACCEPTANCE</b>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse2" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>
                                        The Booksale provides a collection of online resources including classified advertisements for books (hereinafter collectively referred to as “the SERVICE”) on the website www.thebooksale.com, as well as in corresponding mobile applications of the same (hereinafter collectively referred to as “the PLATFORM”).
                        <br />
                                        The Platform and the Service are provided to you subject to these The Booksale Terms of Use (hereinafter referred to as "the TERMS”).  For the purpose of the Terms and wherever the context so requires, the terms “we” and “our” shall refer to The Booksale, and terms "you" and "your" shall mean any person who uses or accesses, whether through manual or automated means, the Platform or the Service in any manner whatsoever including persons browsing the Platform and its content, posting comments or any content or responding to any advertisements or content on the Platform.  By using or accessing the Platform or the Service, you agree to comply with these Terms.  Additionally, when using the Service or a portion thereof, you agree to conform to any applicable posted guidelines for such Service, which may be changed or be updated from time to time at The Booksale’s sole discretion without further notice.  You understand and agree that you are solely responsible for reviewing these Terms and guidelines as posted from time to time.  Should you object to any of these Terms, guidelines, or any subsequent changes thereto or become unsatisfied with The Booksale, the Platform, or the Service in any way, your only recourse is to immediately discontinue use of the Platform.  These Terms may be updated by The Booksale at any time at its sole discretion without further notice.
                        <br />
                                        The Booksale may send you notices of changes to the Platform, the Terms, or guidelines.  However your failure to receive such notices is not an indication of an absence of such changes or a failure on the part of The Booksale to send the same.  The posted changes reflect the actual and updated versions of the Platform, the Terms, or guidelines, and it is your responsibility to review them from time to time.  Any translation provided by The Booksale of any communication, notice, Terms or guidelines, is for your convenience and the English version of such translation shall govern in the event of conflict or doubt between versions. 
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">
                                        <b>DESCRIPTION OF SERVICE AND CONTENT POLICY</b>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse3" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>
                                        The Booksale is main classified ads website for books.  We act as a venue to allow our users who comply with these Terms to offer, sell, and buy books listed on the Platform. You hereby acknowledge and agree that by using third-party vendors such as The Booksale does not in any way make The Booksale involved in such transactions.  The Booksale is not a party to such transactions, has no control over any element of such transactions, and shall have no liability to any party in connection with such transactions. You use the Service and the Platform at your own risk.
                                        <br />
                                        <br />
                                        You understand that The Booksale does not control, and is not responsible for ads, directory information, business listings/information, messages between users, including without limitation e-mails sent from outside The Booksale’s domain or other means of electronic communication, or SMS messages or calls, whether through the Platform or another third party website or offerings, comments, user profiles or postings, files, images, photos, business listings/information and directory information or any other material made available through the Platform and the Service ("CONTENT"), and that by using the Platform and the Service, you may be exposed to Content that is offensive, indecent, inaccurate, misleading, or otherwise objectionable.
                                        <br />
                                        <br />
                                        You acknowledge and agree that The Booksale has no reasonable control over the same and that you are responsible for and must evaluate, and bear all risks associated with, the use of any Content, that you may opt not to rely on said Content, and that under no circumstances will The Booksale be liable in any way for the Content or for any loss or damage of any kind incurred as a result of the browsing, using or reading any Content listed, e-mailed or otherwise made available via the Service.  
                                        <br />
                                        <br />
                                        You acknowledge and agree that The Booksale cannot and does not pre-screen or approve any Content, but that The Booksale has the right, in its sole and absolute discretion, to refuse, delete or move any Content that is or may be available through the Service, for violating these Terms and such violation being brought to The Booksale’s knowledge or for any other reason or no reason at all.  
                                        <br />
                                        <br />
                                        Furthermore, the Platform and Content available through the Platform may contain links to other third party websites which are completely unrelated to The Booksale.  If you access the link to third party websites, you may be subject to those third party websites’ terms and conditions and other policies.  The Booksale makes no representation or guarantee as to the accuracy or authenticity of the information contained in any such third party websites, and your linking to any other websites is completely voluntary and at your own risk and The Booksale disclaims all liability thereto.
                                        <br />
                                        <br />
                                        You acknowledge and agree that you are solely responsible for your own Content posted on, transmitted through, or linked from the Service and the consequences of posting, transmitting, linking or publishing it.  More specifically, you are solely responsible for all Content that you upload, email or otherwise make available via the Service. In connection with such Content posted on, transmitted through, or linked from the Service by you, you affirm, acknowledge, represent, warrant and covenant that: (i) you own or have and shall continue to have, for such time the Content is available on the Platform, the necessary legal capacity, authority, licenses, rights, consents, and permissions to use such Content on the Service and Platform (including without limitation: all patent, trademark, trade secret, copyright or other proprietary rights in and to any and all such Content) and hereby authorize The Booksale to use such Content to enable inclusion and use of the Content in the manner contemplated by the Service, the Platform and these Terms; and (ii) you have the written consent, release, and/or permission of each and every identifiable individual person or business in the Content to use the name or likeness of each and every such identifiable individual person or business to enable inclusion and use of the Content in the manner contemplated by the Service, the Platform and these Terms.  
                                        <br />
                                        <br />
                                        You retain all of your ownership rights in your Content, however, by submitting any Content on the Platform, you hereby grant to The Booksale an irrevocable, non-cancellable, perpetual, worldwide, non-exclusive, royalty-free, sub-licensable, transferable license to use, reproduce, distribute, prepare derivative works of, display, and perform the Content in connection with the Platform and The Booksale's (and its successors') business, including without limitation for the purpose of promoting and redistributing part or all of the Platform and Content therein (and derivative works thereof) in any media formats and through any media channels now or hereafter known.  These rights are required by The Booksale in order to host and display your Content.  Furthermore, by you posting Content to any public area of the Service, you agree to and do hereby grant to The Booksale all rights necessary to prohibit or allow any subsequent aggregation, display, copying, duplication, reproduction, or exploitation of the Content on the Service or Platform by any party for any purpose.  
                                        <br />
                                        <br />
                                        You also hereby grant each user of the Platform (a) a non-exclusive license to access your Content through the Platform; and (b) the right to contact you with regard to the Content posted by you.  Further, you grant The Booksale the right to make available your Content to any third party in connection with the transaction contemplated in your book ad.  Still further, you also grant The Booksale the right to supply to a user the non-public contact information you provided to The Booksale in connection with any transaction or failed transaction you may have with such user, as well as any complaint a user or any third party may have with you in respect of your use of the Platform, or your Content.
                                        <br />
                                        <br />
                                        The Booksale does not endorse any Content or any opinion, statement, recommendation, or advice expressed therein, and The Booksale expressly disclaims any and all liability in connection with user Content or user’s motivation, intent, purpose, or actions in accessing the Platform or Content, or in entering into any transactions through said Platform.  
                                        <br />
                                        <br />
                                        The Booksale does not permit any infringement of intellectual property rights on the Platform, and The Booksale may, at its sole discretion, remove any infringing Content if The Booksale is properly notified, and the same is identified in accordance with applicable laws as being such Content that verifiably infringes on another's intellectual property rights.  Unless properly identified and proven to be infringing Content, The Booksale may not be compelled, and is under no obligation to remove the same without proper orders from the court.  The Booksale, however, may at its sole discretion, upon being satisfied that the Content appears to be infringing Content, remove the same immediately.   
                                        <br />
                                        <br />
                                        The Booksale reserves the right to remove any Content without prior notice. The Booksale may also terminate a user's access to the Platform, if they are determined to be an infringer, a repeat infringer or found to be indulging in any act contrary to the law or these Terms.  Further, at its sole discretion, The Booksale reserves the right to decide whether any Content is appropriate and complies with these Terms.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse4">
                                        <b>CONDUCT</b>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse4" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>
                                        You agree to access and use the Platform with the best intentions and motivations that are moral, ethical, and at the very least, legal.  You hereby represent and warrant that your Content, any communication made, or transaction entered through, or as a result of your access and use of the Platform, does not violate any law, or infringe on anyone’s rights, and is for some legal purpose.
                                        <br />
                                        <br />
                                        You agree not to post, email, host, display, upload, modify, publish, transmit, update or share any information on the Platform, or otherwise make available Content:
                                        <br />
                                        <br />
                                        1. that violates any law or regulation;
                                        <br />
                                        2. that is copyrighted or patented, protected by trade secret or trademark, or otherwise subject to third party proprietary rights, including privacy and publicity rights, unless you are the owner of such rights or have permission or a license from their rightful owner to post the material, enter into transactions with respect to the same, and to grant The Booksale all of the license rights granted herein, in which case you hereby represent and warrant to possess such ownership, permission, or license;
                                        <br />
                                        3. that infringes any of the foregoing intellectual property rights of any party, or is Content that you do not have a right to make available under any law, regulation, contractual or fiduciary relationship(s);
                                        <br />
                                        4. that is harmful, offensive, abusive, unlawful, threatening, harassing, blasphemous, defamatory, obscene, pornographic, paedophilic, libellous, invasive of another's privacy or other rights, hateful, or racially, ethnically objectionable, disparaging, relating or encouraging money laundering or illegal gambling or harms or could harm minors in any way or otherwise unlawful in any manner whatsoever;
                                        <br />
                                        5. that harasses, degrades, intimidates or is hateful towards any individual or group of individuals on the basis of religion, gender, sexual orientation, race, ethnicity, age, or disability;
                                        <br />
                                        6. that violates any (local) equal employment laws, including but not limited to those prohibiting labor only contracting, the stating, in any advertisement for employment, a preference or requirement based on race, color, religion, sex, national origin, age, or disability of the applicant;
                                        <br />
                                        7. that threatens the unity, integrity, defence, security or sovereignty of the Republic of the Philippines, friendly relations with foreign states, or public order or causes incitement to the commission of any cognisable offense or obstructs justice, prevents investigation of any offense or is insulting to any other nation and gives motives for reprisals;
                                        <br />
                                        8. that includes the image, likeness of, or personal or identifying information about another person without that person's explicit consent;
                                        <br />
                                        9. that impersonates any person or entity, including, but not limited to, an The Booksale employee, or falsely states or otherwise misrepresents an affiliation with a person or entity;
                                        <br />
                                        10. that deceives or misleads the addressee about the origin of such messages or communicates any information which is grossly offensive or menacing in nature;
                                        <br />
                                        11. that is false, deceptive, misleading, deceitful, misinformative, or constitutes "bait and switch" offer;
                                        <br />
                                        12. that constitutes or contains "pyramid schemes," "affiliate marketing," "link referral code," "junk mail," "spam," "chain letters," or unsolicited advertisements of a commercial nature;
                                        <br />
                                        13. that constitutes or contains any form of advertising or solicitation if (1) posted in areas or categories of the Platform which are not designated for such purposes; or (2) e-mailed to The Booksale users who have requested not to be contacted about other services, products or commercial interests;
                                        <br />
                                        14. that includes links to commercial services or Third Party Websites, except as specifically allowed by The Booksale;
                                        <br />
                                        15. that advertises the sale of any items the sale of which is prohibited or restricted by applicable law, including without limitation items the sale of which is prohibited or regulated by applicable law;
                                        <br />
                                        16. that contains software viruses or any other computer code, files or programs designed to interrupt, destroy or limit the functionality of any computer software or hardware or telecommunications equipment or any other computer resource;
                                        <br />
                                        17. that disrupts the normal flow of dialogue with an excessive number of messages (flooding attack) to the Service, or that otherwise negatively affects other users' ability to use the Service; or
                                        <br />
                                        18. that employs misleading email addresses, or forged headers or otherwise manipulated identifiers in order to disguise the origin of Content transmitted through the Service.
                                        <br />
                                        <br />
                                        Additionally, you agree not to:
                                        <br />
                                        <br />
                                        1. contact anyone who has asked not to be contacted, or make unsolicited contact with anyone for any commercial purpose, specifically, contact any user to post advertisement on a third party website or post any advertisement on behalf of such user; or to "stalk" or otherwise harass anyone;
                                        <br />
                                        2. make any libellous or defamatory comments or postings to or against anyone;
                                        <br />
                                        3. collect personal data about other users or entities for commercial or unlawful purposes;
                                        <br />
                                        4. use automated means, including spiders, robots, crawlers, data mining tools, or the like to download or scrape data from the Service, except for internet search engines (e.g,. Google) and non-commercial public archives (e.g. archive.org) that comply with our robots.txt file;
                                        <br />
                                        5. post Content that is outside the local area or not relevant to the local area, repeatedly post the same or similar Content, or otherwise impose unreasonable or disproportionately large loads on our servers and other infrastructure;
                                        <br />
                                        6. attempt to gain unauthorized access to computer systems owned or controlled by The Booksale or engage in any activity that disrupts, diminishes the quality of, interferes with the performance of, or impairs the functionality of, the Service or the Platform. 
                                        <br />
                                        7. use any form of automated device or computer program (sometimes referred to as "flagging tools") that enables the use of The Booksale's "flagging system" or other community control systems without each flag being manually entered by a human that initiates the flag (an "automated flagging device"), or use any such flagging tool to remove posts of competitors, other third parties or to remove posts without a reasonable good faith belief that the post being flagged violates these Terms or any applicable law or regulation.
                                        <br />
                                        8. use any automated device or software that enables the submission of automatic postings on The Booksale without human intervention or authorship (an "automated posting device"), including without limitation, the use of any such automated posting device in connection with bulk postings, or for automatic submission of postings at certain times or intervals; or
                                        <br />
                                        <br />
                                        Any Content uploaded by you shall be subject to relevant laws and may disabled, or and may be subject to investigation under appropriate laws. Furthermore, if you are found to be in non-compliance with the laws and regulations, these terms, or the privacy policy of the Site, we may terminate your account/block your access to the Site and we reserve the right to remove any non-compliant Content uploaded by you.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse5">
                                        <b>ACCESS TO THE PLATFORM</b>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse5" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>
The Booksale grants you a limited, revocable, non-exclusive license to access and use the Service and Platform for personal use. This license granted herein does not include any collection, aggregation, copying, duplication, display or derivative use of the Service nor any use of data mining, robots, spiders, or similar data gathering and extraction tools for any purpose unless expressly permitted by The Booksale or as otherwise set forth in these Terms.  
<br /><br />
Notwithstanding the foregoing, general purpose internet search engines and non-commercial public archives that gather information for the sole purpose of displaying hyperlinks to the Service, provided they each do so from a stable IP address or range of IP addresses using an easily identifiable agent and comply with our robots.txt file, may engage in the activities set forth.  For purposes of this exception, a "general purpose internet search engine" does not include a website or search engine or other service that specializes in classified listings especially a subset of classifieds listings such as books which otherwise provides classified ad listing services. The license set forth in this Section permits you to display on your website, or create a hyperlink thereto, individual postings on the Service so long as such use is for non-commercial and/or news reporting purposes only (e.g., for use in personal blogs or other personal online media).
<br /><br />
If the total number of such postings displayed on or linked to your website exceeds limits set by The Booksale, your use will be considered to be in violation of these Terms, unless The Booksale expressly grants you permission otherwise.  You are also permitted to create a hyperlink to the home page of the Platform so long as the link does not portray The Booksale, its employees, affiliates or agents in a false, confusing, misleading, derogatory, or otherwise offensive matter. Use of the Service beyond the scope of authorized access as set forth in these Terms immediately terminates any permission or license granted herein.  In order to collect, aggregate, copy, duplicate, display or make derivative use of the Service or any Content made available via the Service for other purposes (including commercial purposes) not stated herein, you must first obtain a license from The Booksale.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse6">
                                        <b>INTELLECTUAL PROPERTY</b>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse6" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>
You acknowledge and agree that the materials on the Platform, other than user Content, including without limitation, the text, software, scripts, graphics, photos, sounds, music, videos, interactive features, designs, layouts, and the like ("MATERIALS") and the trademarks, service marks and logos contained therein ("MARKS"), are owned by or licensed to The Booksale, and are subject to copyright and other intellectual property rights under relevant local laws, foreign laws and international treaties and/or conventions.
<br /><br />
In connection with the Services, the Platform may display certain trademarks belonging to third parties.  The Booksale does not claim ownership over these trademarks.  Use of these trademarks may be subject to license granted by third parties to The Booksale. You shall, in no event, reverse engineer, decompile, or disassemble such materials and nothing herein shall be construed to grant you any right in relation to such materials.  Materials on the Platform are provided to you AS IS for your information and personal use only and may not be used, copied, reproduced, distributed, transmitted, broadcast, displayed, sold, licensed, or otherwise exploited for any other purposes whatsoever without the prior written consent of the respective owners.  
<br /><br />
The Booksale reserves all rights not expressly granted herein to the Platform and the Materials. You agree to not engage in the use, copying, or distribution of any of the Materials other than as expressly permitted herein, including any use, copying, or distribution of Materials of third parties obtained through the Platform for any commercial purposes.  If you download or print a copy of the Materials for personal use, you must retain all copyright and other proprietary notices contained therein.  
<br /><br />
You agree not to circumvent, disable or otherwise interfere with security related features of the Platform or features that prevent or restrict use or copying of any Materials or enforce limitations on use of the Platform or the Materials therein.  The Service is protected to the maximum extent permitted by copyright laws, other laws, and international treaties and/or conventions.  Content displayed on or through the Service is protected by copyright as a collective work and/or compilation, pursuant to copyrights laws, other laws, and international conventions.  Any reproduction, modification, creation of derivative works from or redistribution of the Platform, the Materials, or the collective work or compilation is expressly prohibited. Copying or reproducing the Platform, the Materials, or any portion thereof to any other server or location for further reproduction or redistribution is expressly prohibited.  
<br /><br />
You further agree not to reproduce, duplicate or copy Content or Materials from the Service, and agree to abide by any and all copyright notices and other notices displayed on the Service.  You may not decompile or disassemble, reverse engineer or otherwise attempt to discover any source code contained in the Service.  Without limiting the foregoing, you agree not to reproduce, duplicate, copy, sell, resell or exploit for any commercial purposes, any aspect of the Service. The Booksale is a service mark registered with the Intellectual Property Office of the Philippines, as well as in patent and trademark authorities in various other jurisdictions.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse7">
                                        <b>USER SUBMISSIONS</b>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse7" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>
You understand that when using the Platform, you will be exposed to Content from a variety of sources, and that The Booksale is not responsible for the accuracy, usefulness, safety, or intellectual property rights of or relating to such Content, and you agree and assume all liability for your use. You further understand and acknowledge that you may be exposed to Content that is inaccurate, offensive, indecent, or objectionable, defamatory or libellous and you agree to waive, and hereby do waive, any legal or equitable rights or remedies you have or may have against The Booksale with respect thereto.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse8">
                                        <b>INDEMNITY</b>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse8" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>
You agree to indemnify, defend, and hold harmless The Booksale as well as all of its subsidiaries, affiliates, officers, directors, employees, agents, attorneys, service providers, predecessors, successors and assigns from and against any and all losses, risks, claims, obligations, actions, debts and expenses, including attorney’s fees and legal costs, including those brought by third parties arising from: (i) your use of and access to the Platform and/or the Service; (ii) your violation of any term of these Terms; (iii) your violation of any third party right, including without limitation any copyright, trademark, trade secret or other property right; or (iv) any claim that your Content caused damage to a third party, and  (iv) for any other breach, act or omission, fault or negligence, contributory or otherwise, on your part including breaches of the obligations on confidentiality and data privacy arising out of the performance or non-performance of the duties and responsibilities set forth in these Terms and from alleged violations of, or noncompliance with, relevant laws.  This defense and indemnification obligation survives termination, modification or expiration of these Terms and your use of the Service and the Platform.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse9">
                                        <b>NO SPAM POLICY</b>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse9" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>
You understand and agree that sending unsolicited email advertisements or other unsolicited communications to The Booksale email addresses or through The Booksale computer systems are expressly prohibited by these Terms.  You acknowledge and agree that from time to time The Booksale may monitor email usage using human monitors or automated software to flag certain words associated with spam or scams in emails that are sent between one user to another in the The Booksale e mail system.  Any communication between yourself and any other user utilizing the communication features available on the Service and the Platform may be used only in accordance with the Terms.  Any unauthorized use of The Booksale computer systems is a violation of these Terms and certain applicable laws.  Such violations may subject the sender and his or her agents to civil and criminal penalties.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse10">
                                        <b>LIMITATION OF SERVICE</b>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse10" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>
You acknowledge and agree that The Booksale may establish limits from time to time concerning use of the Service, including among others, the maximum number of days that Content will be maintained or retained by the Service, the maximum number and size of postings, e-mail messages, or other Content that may be transmitted or stored by the Service, and the frequency and the manner in which you may access the Service or the Platform.  You acknowledge that your account is identified and linked through your mobile number and email address through which you have registered.  In the event you have more than one account linked through your mobile number and email address, The Booksale reserves the right to remove or restrict the usage of such duplicate accounts.  
<br /><br />
You acknowledge and agree that The Booksale has no responsibility or liability for the deletion or failure to store any Content maintained or transmitted by the Platform or the Service.  You acknowledge and agree that The Booksale reserves the right at any time to modify, limit or discontinue the Service (or any part thereof) with or without notice, and that The Booksale shall not be liable to you or to any third party for any such modification, suspension or discontinuance of the Service.  You acknowledge and agree that The Booksale, in its sole and absolute discretion, has the right (but not the obligation) to delete or deactivate your account, block your e-mail or IP address, or otherwise terminate your access to or use of the Service (or any part thereof), immediately and without notice, and remove and discard any Content within the Service, for any reason or no reason at all, including, without limitation, if The Booksale believes that you have violated these Terms.  Further, you agree that The Booksale shall not be liable to you or any third-party for any termination of your access to the Platform or the Service.  Further, you agree not to attempt to use the Service after any such termination.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse11">
                                        <b>DISCLAIMER OF WARRANTIES</b>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse11" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>
YOU EXPRESSLY ACKNOWLEDGE AND AGREE THAT USE OF THE PLATFORM AND THE SERVICE IS ENTIRELY AT YOUR OWN RISK AND THAT THE PLATFORM AND THE SERVICE ARE PROVIDED ON AN "AS IS" OR "AS AVAILABLE" BASIS, WITHOUT ANY WARRANTIES OF ANY KIND. ALL EXPRESS AND IMPLIED WARRANTIES, INCLUDING, WITHOUT LIMITATION, THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, AND NON-INFRINGEMENT OF PROPRIETARY RIGHTS ARE EXPRESSLY DISCLAIMED TO THE FULLEST EXTENT PERMITTED BY LAW. TO THE FULLEST EXTENT PERMITTED BY LAW THE BOOKSALE, ITS OFFICERS, DIRECTORS, EMPLOYEES, AND AGENTS DISCLAIM ALL WARRANTIES, EXPRESS OR IMPLIED, IN CONNECTION WITH THE PLATFORM AND YOUR USE THEREOF. THE BOOKSALE MAKES NO WARRANTIES OR REPRESENTATIONS ABOUT THE ACCURACY OR COMPLETENESS OF THE PLATFORM'S CONTENT OR THE CONTENT OF ANY THIRD PARTY WEBSITES LINKED TO THE PLATFORM AND ASSUMES NO LIABILITY OR RESPONSIBILITY FOR ANY (I) ERRORS, MISTAKES, OR INACCURACIES OF CONTENT, (II) PERSONAL INJURY OR PROPERTY DAMAGE, OF ANY NATURE WHATSOEVER, RESULTING FROM YOUR ACCESS TO AND USE OF THE PLATFORM AND SERVICE, (III) ANY UNAUTHORIZED ACCESS TO OR USE OF OUR SERVERS AND/OR ANY AND ALL PERSONAL INFORMATION AND/OR FINANCIAL INFORMATION STORED THEREIN, (IV) ANY INTERRUPTION OR CESSATION OF TRANSMISSION TO OR FROM THE PLATFORM, (IV) ANY BUGS, VIRUSES, TROJAN HORSES, OR THE LIKE WHICH MAY BE TRANSMITTED TO OR THROUGH THE PLATFORM BY ANY THIRD PARTY, AND/OR (V) ANY ERRORS OR OMISSIONS IN ANY CONTENT OR FOR ANY LOSS OR DAMAGE OF ANY KIND INCURRED AS A RESULT OF THE USE OF ANY CONTENT POSTED, EMAILED, COMMUNICATED, TRANSMITTED, OR OTHERWISE MADE AVAILABLE VIA THE PLATFORM OR THE SERVICE. THE BOOKSALE DOES NOT WARRANT, ENDORSE, GUARANTEE, OR ASSUME RESPONSIBILITY FOR ANY PRODUCT OR SERVICE ADVERTISED OR OFFERED BY A THIRD PARTY THROUGH THE PLATFORM OR ANY HYPERLINKED WEBSITE OR FEATURED IN ANY BANNER OR OTHER ADVERTISING, AND THE BOOKSALE WILL NOT BE A PARTY TO OR IN ANY WAY BE RESPONSIBLE FOR MONITORING ANY TRANSACTION BETWEEN YOU AND/OR OTHER USERS AND/OR THIRD-PARTY PROVIDERS OF PRODUCTS OR SERVICES. AS WITH THE PURCHASE OF A PRODUCT OR SERVICE THROUGH ANY MEDIUM OR IN ANY ENVIRONMENT, YOU SHOULD USE YOUR BEST JUDGMENT AND EXERCISE CAUTION WHERE APPROPRIATE.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse12">
                                        <b>LIMITATION ON LIABILITY </b>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse12" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>
IN NO EVENT SHALL THE BOOKSALE, ITS OFFICERS, DIRECTORS, EMPLOYEES, OR AGENTS, BE LIABLE FOR DIRECT, INDIRECT, INCIDENTAL, SPECIAL, CONSEQUENTIAL OR EXEMPLARY DAMAGES (EVEN IF THE BOOKSALE HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES), RESULTING FROM ANY ASPECT OF YOUR USE OF THE PLATFORM OR THE SERVICE, INCLUDING WITHOUT LIMITATION WHETHER THE DAMAGES ARISE FROM USE OR MISUSE OF THE PLATFORM OR THE SERVICE, FROM INABILITY TO USE THE PLATFORM OR THE SERVICE, OR THE INTERRUPTION, SUSPENSION, MODIFICATION, ALTERATION, OR TERMINATION OF THE PLATFORM OR THE SERVICE. SUCH LIMITATION OF LIABILITY SHALL ALSO APPLY WITH RESPECT TO DAMAGES INCURRED BY REASON OF OTHER SERVICES OR PRODUCTS RECEIVED THROUGH OR ADVERTISED IN CONNECTION WITH THE PLATFORM OR THE SERVICE OR ANY LINKS ON THE PLATFORM, AS WELL AS BY REASON OF ANY INFORMATION, OPINIONS OR ADVICE RECEIVED THROUGH OR ADVERTISED IN CONNECTION WITH THE PLATFORM OR THE SERVICE OR ANY LINKS ON THE THE BOOKSALE SITE. THESE LIMITATIONS SHALL APPLY TO THE FULLEST EXTENT PERMITTED BY LAW. YOU SPECIFICALLY ACKNOWLEDGE AND AGREE THAT THE BOOKSALE SHALL NOT BE LIABLE FOR USER SUBMISSIONS OR THE DEFAMATORY, OFFENSIVE, OR ILLEGAL CONDUCT OF ANY USER OR THIRD PARTY AND THAT THE RISK OF HARM OR DAMAGE FROM THE FOREGOING RESTS ENTIRELY WITH YOU. <b>THE PLATFORM IS CONTROLLED AND OFFERED BY THE BOOKSALE. THE BOOKSALE MAKES NO REPRESENTATIONS OR WARRANTIES THAT THE PLATFORM IS APPROPRIATE FOR USE IN OTHER LOCATIONS. THOSE WHO ACCESS OR USE THE PLATFORM FROM OTHER JURISDICTIONS DO SO AT THEIR OWN VOLITION AND RISK AND ARE RESPONSIBLE FOR COMPLIANCE WITH LOCAL LAW.</b>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse13">
                                        <b>ASSIGNMENT</b>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse13" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>
These Terms, and any rights and licenses granted hereunder, may not be transferred or assigned by you, but may be assigned by The Booksale without restriction. Any assignment or transfer by you shall be null and void.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse14">
                                        <b>PRIVACY</b>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse14" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <p>
You hereby acknowledge and agree that by your registration with The Booksale, and/or your access or use of the Service or Platform, The Booksale may collect and store your personal and non-personal information in order to perform the Service and grant you such access and use, and that by such registration, access or use, you specifically consent to such collection and storage.  Further, you agree that The Booksale does so in full compliance with relevant data privacy laws, and that you specifically consent to disclosure to a requesting third party of such personal and non-personal information which is: (i) in any event already made public through your Content on the Platform; (ii) necessary to any legal investigation subject to a valid court order; or (iii) relevant to a legitimate grievance or complaint for misuse such as but not limited to fraud, intellectual property rights violations, abusive conduct, and defamation, made with respect to your Content, use of the Service or Platform.  For purposes of such disclosure, you acknowledge and agree that The Booksale may provide the following information: your name, email address, contact number, address, IP address, user profile and use history. 
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


/* 
 * Application Name: The Booksale
 * File: Common.cs
 * File Description: Holder of common variables and functions
 * Author: James L. Gagni Jr.
 * UPOU Student Number: 2016-30148
 * Course: IS 295 - Information System Project
 * Program: Master of Information Systems
 * Date: 7 August 2018
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

using System.Web.UI.WebControls;

namespace TheBooksale
{
    public class Common
    {
        //-- BEGIN: Public constants and variables --//
        //-- BEGIN: Constants 
        //-- END: Constants 
        //-- BEGIN: Variables
        //-- Connection String
        public static string cnBooksaleDB = ConfigurationManager.ConnectionStrings["cnBooksale"].ConnectionString;

        //-- Photos File Path and folders
        public static string pathPhotos = "Files/Photos";
        public static string pathPhotosAds = pathPhotos + "/Ads";
        public static string pathPhotosUsers = pathPhotos + "/Users";
        public static int maxPhotos = 3;

        public static string prefixAds = "AD"; //-- prefix for Ads
        public static string topXLatest = "TOPXXX";  //-- keyword for retrieving the top items in a list

        public static string autMultiple = "999999997";
        public static string autNA = "999999998";
        public static string autOthers = "999999999";

        //-- Host Server's ShortDateTime format
        public static string strHostShortDateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

        //-- Various SQL Strings
        //-- Main Modules per User
        public static string sqlUserModuleMain = "select * from appln_mapping.usm_usersmods a "
            + "inner join  appln_mapping.mod_modules b "
            + "    on  a.usm_module_id = b.mod_module_id "
            + "where   b.mod_parent_id is null "
            + "and   upper(a.usm_user_id) = upper(:prmUserId) "
            + "order by b.mod_sortorder";
        //-- Main Modules per User Extended
        public static string sqlUserModuleMainEx = "select distinct b.mod_sortorder, b.mod_name, a.usm_module_id,  "
            + "    case when trim(min(c.mod_sortorder || '-' || c.mod_url)) = '-' then "
            + "        b.mod_url "
            + "    else "
            + "        substr(min(c.mod_sortorder || '-' || c.mod_url), instr(min(c.mod_sortorder || '-' || c.mod_url), '-') + 1) "
            + "    end mod_url "
            + "from appln_mapping.usm_usersmods a "
            + "inner join appln_mapping.mod_modules b "
            + "    on a.usm_module_id = b.mod_module_id "
            + "left outer join  ( "
            + "    select ax.*, bx.* from appln_mapping.usm_usersmods ax "
            + "    inner join  appln_mapping.mod_modules bx "
            + "        on ax.usm_module_id = bx.mod_module_id "
            + "    ) c "
            + "    on  upper(a.usm_user_id) = upper(c.usm_user_id) "
            + "    and c.mod_parent_id = a.usm_module_id "
            + "where   b.mod_parent_id is null  "
            + "and upper(a.usm_user_id) = upper(:prmUserId) "
            + "group by    b.mod_sortorder, b.mod_name, a.usm_module_id, b.mod_url "
            + "order by b.mod_sortorder";

        //-- Get User Information
        public static string sqlUserInfo = "select usr.*, usp.*, rol.*, cit.*, prv.* "
            + "from dbo.usr_users usr "
            + "inner join dbo.usr_profiles usp "
            + "  on usr.usr_profile_id = usp.usr_profile_id "
            + "inner join dbo.rol_roles rol "
            + "  on usr.rol_role_id = rol.rol_role_id "
            + "left outer join dbo.lup_cities cit "
            + "  on usp.cit_city_id = cit.cit_city_id "
            + "left outer join dbo.lup_provinces prv "
            + "  on cit.prv_province_id = prv.prv_province_id "
            + "where   usr.usr_active = 1 "
            + "and usr.usr_username = @prmUserName ";
        public static string sqlUserInfoByUserId = "select usr.*, usp.*, rol.*, cit.*, prv.* "
            + "from dbo.usr_users usr "
            + "inner join dbo.usr_profiles usp "
            + "  on usr.usr_profile_id = usp.usr_profile_id "
            + "inner join dbo.rol_roles rol "
            + "  on usr.rol_role_id = rol.rol_role_id "
            + "left outer join dbo.lup_cities cit "
            + "  on usp.cit_city_id = cit.cit_city_id "
            + "left outer join dbo.lup_provinces prv "
            + "  on cit.prv_province_id = prv.prv_province_id "
            + "where   usr.usr_active = 1 "
            + "and usr.usr_user_id = @prmUserId ";
        public static string sqlUserInfoByEmailPhone = "select usr.*, usp.*, rol.*, cit.*, prv.* "
            + "from dbo.usr_users usr "
            + "inner join dbo.usr_profiles usp "
            + "  on usr.usr_profile_id = usp.usr_profile_id "
            + "inner join dbo.rol_roles rol "
            + "  on usr.rol_role_id = rol.rol_role_id "
            + "left outer join dbo.lup_cities cit "
            + "  on usp.cit_city_id = cit.cit_city_id "
            + "left outer join dbo.lup_provinces prv "
            + "  on cit.prv_province_id = prv.prv_province_id "
            + "where   usr.usr_active = 1 "
            + "and (usp.usr_email = @prmEmailPhone "
            + "    or usp.usr_phone = @prmEmailPhone) ";

        //-- Get Ad Details
        public static string sqlAdDetails = "select ads.*, addt.*, aut.*, sub.*, cat.*, adt.*, usr.*, usp.*, "
            + "    sta.*, con.*, adv.* "
            + "from dbo.ads_bookads ads "
            + "inner join dbo.ads_bookads_details addt "
            + "    on ads.ads_id = addt.ads_id "
            + "inner join dbo.lup_authors aut "
            + "    on addt.aut_author_id = aut.aut_author_id "
            + "left outer join dbo.sub_subcategories sub "
            + "    on ads.sub_subcategory_id = sub.sub_subcategory_id "
            + "inner join dbo.cat_categories cat "
            + "    on sub.cat_category_id = cat.cat_category_id "
            + "inner join dbo.lup_adtypes adt "
            + "    on ads.adt_adtype_id = adt.adt_adtype_id "
            + "inner join dbo.usr_users usr "
            + "    on ads.usr_user_id = usr.usr_user_id "
            + "inner join dbo.usr_profiles usp "
            + "    on usr.usr_profile_id = usp.usr_profile_id "
            + "inner join dbo.lup_status sta "
            + "    on ads.sta_status_id = sta.sta_status_id "
            + "inner join dbo.lup_condition con "
            + "    on ads.con_condition_id = con.con_condition_id "
            + "left outer join dbo.dtw_adviews adv "
            + "    on ads.ads_id = adv.ads_id "
            + "where ads.ads_id = @prmAdsId ";

        //-- Get Ad Detail Photos
        public static string sqlAdPhotos = "select pho.* from dbo.ads_bookads ads "
            + "left outer join dbo.adp_adsphotos adp "
            + "    on ads.ads_id = adp.ads_id "
            + "left outer join dbo.pho_photos pho "
            + "    on adp.pho_photo_id = pho.pho_photo_id "
            + "where ads.ads_id = @prmAdsId "
            + "order by pho.pho_order ";
        public static string sqlAdPhotosOrder = "select pho.* from dbo.ads_bookads ads "
            + "left outer join dbo.adp_adsphotos adp "
            + "    on ads.ads_id = adp.ads_id "
            + "left outer join dbo.pho_photos pho "
            + "    on adp.pho_photo_id = pho.pho_photo_id "
            + "where ads.ads_id = @prmAdsId "
            + "and pho.pho_order = @prmOrder "
            + "order by pho.pho_order ";

        //-- Get Ads By Category
        public static string sqlAdsByCategory = "select ads.*, addt.*, aut.*, sub.*, cat.*, adt.*, sta.*, con.*, "
            + "adp.*, adpcount.adp_photos_count, pho.*, usr.*, usp.*, cit.*, prv.*, adv.* "
            + "from dbo.ads_bookads ads "
            + "inner join dbo.ads_bookads_details addt "
            + "    on ads.ads_id = addt.ads_id "
            + "inner join dbo.lup_authors aut "
            + "    on addt.aut_author_id = aut.aut_author_id "
            + "left outer join dbo.sub_subcategories sub "
            + "    on ads.sub_subcategory_id = sub.sub_subcategory_id "
            + "left outer join dbo.cat_categories cat "
            + "    on sub.cat_category_id = cat.cat_category_id "
            + "inner join dbo.usr_users usr "
            + "    on ads.usr_user_id = usr.usr_user_id "
            + "inner join dbo.usr_profiles usp "
            + "    on usr.usr_profile_id = usp.usr_profile_id "
            + "left outer join dbo.lup_cities cit "
            + "    on usp.cit_city_id = cit.cit_city_id "
            + "left outer join dbo.lup_provinces prv "
            + "    on cit.prv_province_id = prv.prv_province_id "
            + "inner join dbo.lup_adtypes adt "
            + "    on ads.adt_adtype_id = adt.adt_adtype_id "
            + "inner join dbo.lup_status sta "
            + "    on ads.sta_status_id = sta.sta_status_id "
            + "inner join dbo.lup_condition con "
            + "    on ads.con_condition_id = con.con_condition_id "
            + "left outer join dbo.adp_adsphotos adp "
            + "    on ads.ads_id = adp.ads_id "
            + "left outer join (select adp.ads_id, count(adp.pho_photo_id) adp_photos_count "
            + "    from dbo.adp_adsphotos adp "
            + "    group by adp.ads_id) adpcount "
            + "    on adp.ads_id = adpcount.ads_id "
            + "inner join dbo.pho_photos pho "
            + "    on adp.pho_photo_id = pho.pho_photo_id "
            + "    and pho.pho_order = 1 "
            + "left outer join dbo.dtw_adviews adv "
            + "    on ads.ads_id = adv.ads_id ";

        public static string sqlAdsByCategoryLatest = "select " + topXLatest + " ads.*, addt.*, aut.*, sub.*, cat.*, adt.*, sta.*, con.*, "
            + "adp.*, adpcount.adp_photos_count, pho.*, usr.*, usp.*, cit.*, prv.* "
            + "from dbo.ads_bookads ads "
            + "inner join dbo.ads_bookads_details addt "
            + "    on ads.ads_id = addt.ads_id "
            + "inner join dbo.lup_authors aut "
            + "    on addt.aut_author_id = aut.aut_author_id "
            + "left outer join dbo.sub_subcategories sub "
            + "    on ads.sub_subcategory_id = sub.sub_subcategory_id "
            + "left outer join dbo.cat_categories cat "
            + "    on sub.cat_category_id = cat.cat_category_id "
            + "inner join dbo.usr_users usr "
            + "    on ads.usr_user_id = usr.usr_user_id "
            + "inner join dbo.usr_profiles usp "
            + "    on usr.usr_profile_id = usp.usr_profile_id "
            + "left outer join dbo.lup_cities cit "
            + "    on usp.cit_city_id = cit.cit_city_id "
            + "left outer join dbo.lup_provinces prv "
            + "    on cit.prv_province_id = prv.prv_province_id "
            + "inner join dbo.lup_adtypes adt "
            + "    on ads.adt_adtype_id = adt.adt_adtype_id "
            + "inner join dbo.lup_status sta "
            + "    on ads.sta_status_id = sta.sta_status_id "
            + "inner join dbo.lup_condition con "
            + "    on ads.con_condition_id = con.con_condition_id "
            + "left outer join dbo.adp_adsphotos adp "
            + "    on ads.ads_id = adp.ads_id "
            + "left outer join (select adp.ads_id, count(adp.pho_photo_id) adp_photos_count "
            + "    from dbo.adp_adsphotos adp "
            + "    group by adp.ads_id) adpcount "
            + "    on adp.ads_id = adpcount.ads_id "
            + "inner join dbo.pho_photos pho "
            + "    on adp.pho_photo_id = pho.pho_photo_id "
            + "    and pho.pho_order = 1 "
            + "where ads.sta_status_id = 2 "
            + "order by ads.ads_modifieddate desc";

        public static string sqlAdsByRelatedGenre = "select " + topXLatest + " ads.*, aut.*, sub.*, cat.*, "
            + "adp.*, adpcount.adp_photos_count, pho.*, adv.*, rand(checksum(newid())) as sort2 "
            + "from dbo.ads_bookads ads "
            + "inner join dbo.ads_bookads_details addt "
            + "    on ads.ads_id = addt.ads_id "
            + "inner join dbo.lup_authors aut "
            + "    on addt.aut_author_id = aut.aut_author_id "
            + "left outer join dbo.sub_subcategories sub "
            + "    on ads.sub_subcategory_id = sub.sub_subcategory_id "
            + "left outer join dbo.cat_categories cat "
            + "    on sub.cat_category_id = cat.cat_category_id "
            + "left outer join dbo.adp_adsphotos adp "
            + "    on ads.ads_id = adp.ads_id "
            + "left outer join (select adp.ads_id, count(adp.pho_photo_id) adp_photos_count "
            + "    from dbo.adp_adsphotos adp "
            + "    group by adp.ads_id) adpcount "
            + "    on adp.ads_id = adpcount.ads_id "
            + "inner join dbo.pho_photos pho "
            + "    on adp.pho_photo_id = pho.pho_photo_id "
            + "    and pho.pho_order = 1 "
            + "left outer join dbo.dtw_adviews adv "
            + "    on ads.ads_id = adv.ads_id "
            + "where ((upper(sub.sub_subcategory_name) like '%' + @prmSearch + '%') "
            + "    or(upper(ads.ads_title) like '%' + @prmSearch + '%') "
            + "    or(upper(ads.ads_description) like '%' + @prmSearch + '%')) "
            + "and ads.sta_status_id = 2 and ads.ads_id <> @prmAdsId "
            + "order by adv.adv_count desc, sort2";
        public static string sqlAdsByRelatedAuthor = "select " + topXLatest + " ads.*, addt.*, aut.*, sub.*, cat.*, "
            + "adp.*, adpcount.adp_photos_count, pho.*, adv.*, rand(checksum(newid())) as sort2 "
            + "from dbo.ads_bookads ads "
            + "inner join dbo.ads_bookads_details addt "
            + "    on ads.ads_id = addt.ads_id "
            + "inner join dbo.lup_authors aut "
            + "    on addt.aut_author_id = aut.aut_author_id "
            + "left outer join dbo.sub_subcategories sub "
            + "    on ads.sub_subcategory_id = sub.sub_subcategory_id "
            + "left outer join dbo.cat_categories cat "
            + "    on sub.cat_category_id = cat.cat_category_id "
            + "left outer join dbo.adp_adsphotos adp "
            + "    on ads.ads_id = adp.ads_id "
            + "left outer join (select adp.ads_id, count(adp.pho_photo_id) adp_photos_count "
            + "    from dbo.adp_adsphotos adp "
            + "    group by adp.ads_id) adpcount "
            + "    on adp.ads_id = adpcount.ads_id "
            + "inner join dbo.pho_photos pho "
            + "    on adp.pho_photo_id = pho.pho_photo_id "
            + "    and pho.pho_order = 1 "
            + "left outer join dbo.dtw_adviews adv "
            + "    on ads.ads_id = adv.ads_id "
            + "where ((upper(aut.aut_name) like '%' + @prmSearch + '%') "
            + "    or (upper(addt.add_author_name) like '%' + @prmSearch + '%') "
            + "    or (upper(ads.ads_title) like '%' + @prmSearch + '%') "
            + "    or (upper(ads.ads_description) like '%' + @prmSearch + '%')) "
            + "and ads.sta_status_id = 2 and ads.ads_id <> @prmAdsId "
            + "order by adv.adv_count desc, sort2";
        public static string sqlRelatedUsersSold = "select distinct " + topXLatest + " usr.usr_user_id, "
            + "case when usr_showdisplay = 1 then "
            + "    isnull(usr_display, isnull(usr_firstname, usr_lastname)) "
            + "else "
            + "    isnull(usr_firstname, usr_lastname) "
            + "end as displayname,  "
            + "isnull('" + "~/" + Common.pathPhotosUsers + "/" + "' + usr.usr_user_id + '/' + usp.usr_photo, '"
            + "~/" + Common.pathPhotosUsers + "/" + "' + 'user.png') as usr_photo,  "
            + "sum(adv.adv_count) as advcount, rand(checksum(newid())) as sort2 "
            + "from dbo.ads_bookads ads "
            + "inner join dbo.ads_bookads_details addt "
            + "    on ads.ads_id = addt.ads_id "
            + "inner join dbo.lup_authors aut "
            + "    on addt.aut_author_id = aut.aut_author_id "
            + "left outer join dbo.sub_subcategories sub "
            + "    on ads.sub_subcategory_id = sub.sub_subcategory_id "
            + "left outer join dbo.cat_categories cat "
            + "    on sub.cat_category_id = cat.cat_category_id "
            + "inner join dbo.usr_users usr "
            + "    on ads.usr_user_id = usr.usr_user_id "
            + "inner join dbo.usr_profiles usp "
            + "    on usr.usr_profile_id = usp.usr_profile_id "
            + "left outer join dbo.dtw_adviews adv "
            + "    on ads.ads_id = adv.ads_id  "
            + "where ((upper(aut.aut_name) like '%' + @prmSearchAuthor + '%') "
            + "    or (upper(addt.add_author_name) like '%' + @prmSearchAuthor + '%') "
            + "    or (upper(sub.sub_subcategory_name) like '%' + @prmSearchGenre + '%') "
            + "    or (upper(ads.ads_title) like '%' + @prmSearchAuthor + '%') "
            + "    or (upper(ads.ads_description) like '%' + @prmSearchAuthor + '%') "
            + "    or (upper(ads.ads_title) like '%' + @prmSearchGenre + '%') "
            + "    or (upper(ads.ads_description) like '%' + @prmSearchGenre + '%')) "
            + "and ads.sta_status_id = 5 and ads.ads_id <> @prmAdsId "
            + "group by usr.usr_user_id, "
            + "	case when usr_showdisplay = 1 then "
            + "        isnull(usr_display, isnull(usr_firstname, usr_lastname)) "
            + "	else "
            + "        isnull(usr_firstname, usr_lastname) "
            + "    end, "
            + "    isnull('" + "~/" + Common.pathPhotosUsers + "/" + "' + usr.usr_user_id + '/' + usp.usr_photo, '"
            + "~/" + Common.pathPhotosUsers + "/" + "' + 'user.png') "
            + "order by advcount desc, sort2";

        public static string sqlAdsCount = "select count(distinct ads.ads_id) as count_adstotal, "
            + "count(distinct cit.cit_city_id) as count_cities, "
            + "count(distinct case when usr.usr_active = 1 "
            + "    then usr.usr_user_id else null end) as count_usersactive, "
            + "    count(distinct case when ((ads.sta_status_id = 2) "
            + "         and(convert(date, cast(ads.ads_modifieddate as datetime), 112) "
            + "             = convert(date, cast(GetDate() as datetime), 112))) "
            + "         then ads.ads_id else null end) as count_adstoday "
            + "from dbo.ads_bookads ads "
            + "inner join dbo.ads_bookads_details addt "
            + "    on ads.ads_id = addt.ads_id "
            + "inner join dbo.lup_authors aut "
            + "    on addt.aut_author_id = aut.aut_author_id "
            + "left outer join dbo.sub_subcategories sub "
            + "    on ads.sub_subcategory_id = sub.sub_subcategory_id "
            + "left outer join dbo.cat_categories cat "
            + "    on sub.cat_category_id = cat.cat_category_id "
            + "inner join dbo.usr_users usr "
            + "    on ads.usr_user_id = usr.usr_user_id "
            + "inner join dbo.usr_profiles usp "
            + "    on usr.usr_profile_id = usp.usr_profile_id "
            + "left outer join dbo.lup_cities cit "
            + "    on usp.cit_city_id = cit.cit_city_id "
            + "left outer join dbo.lup_provinces prv "
            + "    on cit.prv_province_id = prv.prv_province_id "
            + "inner join dbo.lup_adtypes adt "
            + "    on ads.adt_adtype_id = adt.adt_adtype_id "
            + "inner join dbo.lup_status sta "
            + "    on ads.sta_status_id = sta.sta_status_id "
            + "inner join dbo.lup_condition con "
            + "    on ads.con_condition_id = con.con_condition_id "
            + "left outer join dbo.adp_adsphotos adp "
            + "    on ads.ads_id = adp.ads_id "
            + "left outer join (select adp.ads_id, count(adp.pho_photo_id) adp_photos_count "
            + "    from dbo.adp_adsphotos adp "
            + "    group by adp.ads_id) adpcount "
            + "    on adp.ads_id = adpcount.ads_id "
            + "inner join dbo.pho_photos pho "
            + "    on adp.pho_photo_id = pho.pho_photo_id "
            + "    and pho.pho_order = 1 ";

        public static string sqlUserCount = "select count(distinct ads.ads_id) as count_adstotal, "
            + "sum(distinct advu.adv_count) as count_viewstotal, "
            + "count(distinct rvwf.rvw_id) as count_reviewsforme, "
            + "count(distinct rvw.rvw_id) as count_reviewsbyme, "
            + "count(distinct case when ads.sta_status_id = 4 then ads.ads_id else null end) as count_adsreserved, "
            + "count(distinct case when ads.sta_status_id = 5 then ads.ads_id else null end) as count_adssold "
            + "from dbo.ads_bookads ads "
            + "inner join dbo.ads_bookads_details addt "
            + "    on ads.ads_id = addt.ads_id "
            + "inner join dbo.lup_authors aut "
            + "    on addt.aut_author_id = aut.aut_author_id "
            + "left outer join dbo.sub_subcategories sub "
            + "    on ads.sub_subcategory_id = sub.sub_subcategory_id "
            + "left outer join dbo.cat_categories cat "
            + "    on sub.cat_category_id = cat.cat_category_id "
            + "inner join dbo.usr_users usr "
            + "    on ads.usr_user_id = usr.usr_user_id "
            + "inner join dbo.usr_profiles usp "
            + "    on usr.usr_profile_id = usp.usr_profile_id "
            + "left outer join dbo.lup_cities cit "
            + "    on usp.cit_city_id = cit.cit_city_id "
            + "left outer join dbo.lup_provinces prv "
            + "    on cit.prv_province_id = prv.prv_province_id "
            + "inner join dbo.lup_adtypes adt "
            + "    on ads.adt_adtype_id = adt.adt_adtype_id "
            + "inner join dbo.lup_status sta "
            + "    on ads.sta_status_id = sta.sta_status_id "
            + "inner join dbo.lup_condition con "
            + "    on ads.con_condition_id = con.con_condition_id "
            + "left outer join dbo.adp_adsphotos adp "
            + "    on ads.ads_id = adp.ads_id "
            + "left outer join (select adp.ads_id, count(adp.pho_photo_id) adp_photos_count "
            + "    from dbo.adp_adsphotos adp "
            + "    group by adp.ads_id) adpcount "
            + "    on adp.ads_id = adpcount.ads_id "
            + "inner join dbo.pho_photos pho "
            + "    on adp.pho_photo_id = pho.pho_photo_id "
            + "    and pho.pho_order = 1 "
            + "left outer join dbo.rvw_reviews rvw "
            + "    on  usr.usr_user_id = rvw.usr_user_id "
            + "left outer join dbo.rvw_reviews rvwf "
            + "    on usr.usr_user_id = rvwf.rvw_for_usr_user_id "
            + "left outer join dbo.dtw_adviews adv "
            + "    on ads.ads_id = adv.ads_id "
            + "left outer join "
            + "    (select usr.usr_user_id, sum(advx.adv_count) adv_count "
            + "    from dbo.ads_bookads ads "
            + "    inner join dbo.usr_users usr "
            + "      on ads.usr_user_id = usr.usr_user_id "
            + "    inner join dbo.dtw_adviews advx "
            + "      on ads.ads_id = advx.ads_id "
            + "    group by usr.usr_user_id) advu "
            + "    on usr.usr_user_id = advu.usr_user_id "
            + "where usr.usr_user_id = @prmUserId ";

        public static string sqlAuthorsMin = "select aut.* from dbo.lup_authors aut order by aut.aut_name ";
        public static string sqlAuthors = "select 0 as sortorder, aut.* from dbo.lup_authors aut "
            + "where aut_author_id in (" + autOthers + ") "
            + "union "
            + "select 1 as sortorder, aut.* from dbo.lup_authors aut "
            + "where aut_author_id in (" + autMultiple + ", " + autNA + ") "
            + "union "
            + "select 2 as sortorder, aut.* from dbo.lup_authors aut "
            + "where aut_author_id not in (" + autMultiple + ", " + autNA + ", " + autOthers + ") "
            + "order by sortorder, aut_name";
        public static string sqlCategories = "select cat.*, count(ads.ads_id) count_ads from dbo.cat_categories cat "
            + "left outer join dbo.sub_subcategories sub "
            + "  on cat.cat_category_id = sub.cat_category_id "
            + "left outer join dbo.ads_bookads ads "
            + "  on sub.sub_subcategory_id = ads.sub_subcategory_id "
            + "  and ads.sta_status_id = 2 "
            + "group by cat.cat_category_id, cat.cat_category_name, cat.cat_icon_fa ";
        public static string sqlSubCategoriesByCat = "select sub.*, cat.* from dbo.sub_subcategories sub "
            + "inner join dbo.cat_categories cat "
            + "  on sub.cat_category_id = cat.cat_category_id "
            + "where sub.cat_category_id = @prmCategoryId "
            + "order by sub.sub_subcategory_name";

        public static string sqlReviews = "select rvw.*, usr.usr_user_id usr_user_id_rvw, usp.usr_firstname usr_firstname_rvw, "
            + "	usp.usr_lastname usr_lastname_rvw, usrf.*, uspf.* from dbo.rvw_reviews rvw "
            + "inner join  dbo.usr_users usr "
            + "    on rvw.usr_user_id = usr.usr_user_id "
            + "inner join dbo.usr_profiles usp "
            + "    on usr.usr_profile_id = usp.usr_profile_id "
            + "inner join  dbo.usr_users usrf "
            + "    on rvw.rvw_for_usr_user_id = usrf.usr_user_id "
            + "inner join  dbo.usr_profiles uspf "
            + "    on usrf.usr_profile_id = uspf.usr_profile_id ";

        public static string sqlAdStatus = "select * from dbo.lup_status ";
        public static string sqlAdTypes = "select * from dbo.lup_adtypes ";
        public static string sqlConditions = "select * from dbo.lup_condition ";
        public static string sqlProvinces = "select * from dbo.lup_provinces ";
        public static string sqlProvincesInAdOnly = "select distinct prv.* from dbo.usr_profiles usr "
            + "inner join dbo.lup_cities cit "
            + "  on usr.cit_city_id = cit.cit_city_id "
            + "inner join dbo.lup_provinces prv "
            + "  on cit.prv_province_id = prv.prv_province_id";
        public static string sqlCitiesByProv = "select cit.* from dbo.lup_cities cit "
            + "inner join dbo.lup_provinces prv "
            + "  on cit.prv_province_id = prv.prv_province_id "
            + "where cit.prv_province_id = @prmProvId ";
        public static string sqlCitiesInAdOnly = "select distinct cit.* from dbo.usr_profiles usr "
            + "inner join dbo.lup_cities cit "
            + "  on usr.cit_city_id = cit.cit_city_id "
            + "inner join dbo.lup_provinces prv "
            + "  on cit.prv_province_id = prv.prv_province_id "
            + "where cit.prv_province_id = @prmProvId ";

        //-- END: Variables
        //-- END: Public variables --//

        //-- BEGIN: Local constants and variables --//
        //-- END: Local variables --//

        public static string Crypt(string strValue, int intMode)
        {
            //-- Encrypt/Decrypt
            //-- Parameters: 
            //--   strValue (string)
            //--   intMode (int)
            //--      0 - Encrypt, 1 - Decrypt
            //-- Return Value: Encrypted/Decrypted string

            string strOutput = "";

            try
            {
                StringBuilder sbStrOutput = new StringBuilder(strValue);

                for (int intCharIndex = 0; intCharIndex < strValue.Length; intCharIndex++)
                {
                    if (intMode == 0)
                        sbStrOutput[intCharIndex] = (char)((int)(strValue[intCharIndex]) - intCharIndex);
                    else
                        sbStrOutput[intCharIndex] = (char)((int)(strValue[intCharIndex]) + intCharIndex);
                }

                strOutput = sbStrOutput.ToString();

            }
            catch (Exception ex)
            {
                strOutput = "Crypt: Exception Error - " + ex.Message;
            }

            return strOutput;
        }

        public static bool RemoveFromDDL(DropDownList ddlList, string removeValue)
        {
            //-- RemoveFromDDL
            //-- Parameters: 
            //--   ddlList (DropDownList)
            //--   removeValue (string)
            //-- Return Value: true or false, depending on success

            ListItem itmRemove;

            try
            {
                itmRemove = ddlList.Items.FindByValue(removeValue);
                if (itmRemove != null)
                    ddlList.Items.Remove(itmRemove);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public static string GetCatNameById(int _categoryId)
        {
            //-- GetCatNameById
            //-- Parameters: 
            //--   _categoryId (int)
            //-- Return Value: Category Name based on categoryId

            string categoryName = "";

            try
            {
                string sqlGetCatName = "select cat.cat_category_name from dbo.cat_categories cat " +
                    "where cat.cat_category_id = @prmCategoryId ";

                using (SqlConnection cnGetCatName = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdGetCatName = new SqlCommand(sqlGetCatName, cnGetCatName);
                    cmdGetCatName.CommandType = CommandType.Text;
                    cmdGetCatName.Parameters.AddWithValue("prmCategoryId", _categoryId);

                    cnGetCatName.Open();

                    categoryName = (string)cmdGetCatName.ExecuteScalar();

                    cmdGetCatName.Dispose();
                    cnGetCatName.Close();
                }

                if ((categoryName is null) || (categoryName == ""))
                    categoryName = "All";

                return categoryName;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static string GetPrvNameById(int _provinceId)
        {
            //-- GetPrvNameById
            //-- Parameters: 
            //--   _provinceId (int)
            //-- Return Value: Province Name based on provinceId

            string provinceName = "";

            try
            {
                string sqlGetProvName = "select prv.prv_name from dbo.lup_provinces prv " +
                    "where prv.prv_province_id = @prmProvinceId ";

                using (SqlConnection cnGetProvName = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdGetProvName = new SqlCommand(sqlGetProvName, cnGetProvName);
                    cmdGetProvName.CommandType = CommandType.Text;
                    cmdGetProvName.Parameters.AddWithValue("prmProvinceId", _provinceId);

                    cnGetProvName.Open();

                    provinceName = (string)cmdGetProvName.ExecuteScalar();

                    cmdGetProvName.Dispose();
                    cnGetProvName.Close();
                }

                if ((provinceName is null) || (provinceName == ""))
                    provinceName = "All";

                return provinceName;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static string SetUniqueUserID(string lastName, string firstName)
        {
            //-- SetUniqueUserID
            //-- Parameters: 
            //--   lastName (string)
            //--   firstName (string)
            //-- Return Value: New UserID based on lastName and firstName

            string newUserID = "";

            try
            {
                //-- Get latest User ID based on Last Name and First Name
                string lastUserID = "";
                string lnFn = lastName.Trim().Substring(0, 2).ToUpper() + firstName.Trim().Substring(0, 2).ToUpper();

                string sqlGetLastUserID = "select top 1 usr.usr_user_id from dbo.usr_users usr " +
                    "where substring(usr.usr_user_id, 1, 4) = @prmLnFn " +
                    "order by usr.usr_user_id desc";

                using (SqlConnection cnGetLastUserID = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdGetLastUserID = new SqlCommand(sqlGetLastUserID, cnGetLastUserID);
                    cmdGetLastUserID.CommandType = CommandType.Text;
                    cmdGetLastUserID.Parameters.AddWithValue("prmLnFn", lnFn);

                    cnGetLastUserID.Open();

                    lastUserID = (string)cmdGetLastUserID.ExecuteScalar();

                    cmdGetLastUserID.Dispose();
                    cnGetLastUserID.Close();
                }

                //-- Set New User ID
                int userIDNum = 1;
                if ((lastUserID is null) || (lastUserID == ""))
                {
                    newUserID = lnFn + userIDNum.ToString("D6");
                }
                else
                {
                    userIDNum = int.Parse(lastUserID.Substring(4, 6));
                    userIDNum++;
                    newUserID = lnFn + userIDNum.ToString("D6");
                }

                return newUserID;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static int GetNextUsrProfId()
        {
            //-- GetNextUsrProfId
            //-- Parameters: none
            //-- Return Value: Next User Profile ID

            int nextUsrProfId = 0;

            try
            {
                //-- Get next User Profile Id
                int maxUsrProfID = 0;
                int? tempMaxUsrProfID = 0;

                string sqlGetMaxUsrProfId = "select max(usp.usr_profile_id) max_usr_profile_id from dbo.usr_profiles usp";

                using (SqlConnection cnGetMaxUsrProfId = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdGetMaxUsrProfId = new SqlCommand(sqlGetMaxUsrProfId, cnGetMaxUsrProfId);
                    cmdGetMaxUsrProfId.CommandType = CommandType.Text;

                    cnGetMaxUsrProfId.Open();

                    tempMaxUsrProfID = (int)cmdGetMaxUsrProfId.ExecuteScalar();
                    if (tempMaxUsrProfID != null)
                        maxUsrProfID = tempMaxUsrProfID.Value;
                    else
                        maxUsrProfID = 0;

                    cmdGetMaxUsrProfId.Dispose();
                    cnGetMaxUsrProfId.Close();
                }

                //-- Set Next User Profile ID
                nextUsrProfId = maxUsrProfID + 1;

                return nextUsrProfId;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public static string SetUniqueAdsId(string userId)
        {
            //-- SetUniqueAdsId
            //-- Parameters: 
            //--   userId (string)
            //-- Return Value: New Ads based on userId

            string newAdsId = "";

            try
            {
                //-- Get latest Ads ID based on UserId
                string lastAdsID = "";

                string sqlGetLastAdsID = "select top 1 ads.ads_id from dbo.ads_bookads ads " +
                    "where ads.usr_user_id = @prmUserId " +
                    "order by ads.ads_id desc";

                using (SqlConnection cnGetLastAdsId = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdGetLastAdsId = new SqlCommand(sqlGetLastAdsID, cnGetLastAdsId);
                    cmdGetLastAdsId.CommandType = CommandType.Text;
                    cmdGetLastAdsId.Parameters.AddWithValue("prmUserId", userId);

                    cnGetLastAdsId.Open();

                    lastAdsID = (string)cmdGetLastAdsId.ExecuteScalar();

                    cmdGetLastAdsId.Dispose();
                    cnGetLastAdsId.Close();
                }

                //-- Set New Ads ID
                int adsIDNum = 1;
                if ((lastAdsID is null) || (lastAdsID == ""))
                {
                    newAdsId = prefixAds + userId + adsIDNum.ToString("D6");
                }
                else
                {
                    adsIDNum = int.Parse(lastAdsID.Substring(12, 6));
                    adsIDNum++;
                    newAdsId = prefixAds + userId + adsIDNum.ToString("D6");
                }

                return newAdsId;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static string GetMaxAdsDetailsId()
        {
            //-- GetMaxAdsDetailsId
            //-- Return Value: Maximum Ads Details Id

            try
            {
                //-- Get latest Ads ID
                string maxAdsDtlId = "";

                string sqlGetMaxAdsDtlId = "select isnull(max(adsd.add_details_id), 0) max_ads_dtl_id from dbo.ads_bookads_details adsd";

                using (SqlConnection cnAdsDtlId = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdAdsDtlId = new SqlCommand(sqlGetMaxAdsDtlId, cnAdsDtlId);
                    cmdAdsDtlId.CommandType = CommandType.Text;

                    cnAdsDtlId.Open();

                    maxAdsDtlId = ((int)cmdAdsDtlId.ExecuteScalar()).ToString();

                    cmdAdsDtlId.Dispose();
                    cnAdsDtlId.Close();
                }

                return maxAdsDtlId;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static string GetMaxAdsPhotoId()
        {
            //-- GetMaxAdsPhotoId
            //-- Return Value: Maximum Ads' Photo Id

            try
            {
                //-- Get latest Ads Photo ID
                string maxAdsPhotoId = "";

                string sqlGetMaxAdsPhotoId = "select isnull(max(pho.pho_photo_id), '0') max_pho_photo_id from dbo.pho_photos pho";

                using (SqlConnection cnAdsPhotoId = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdAdsPhotoId = new SqlCommand(sqlGetMaxAdsPhotoId, cnAdsPhotoId);
                    cmdAdsPhotoId.CommandType = CommandType.Text;

                    cnAdsPhotoId.Open();

                    maxAdsPhotoId = ((int)cmdAdsPhotoId.ExecuteScalar()).ToString();

                    cmdAdsPhotoId.Dispose();
                    cnAdsPhotoId.Close();
                }

                return maxAdsPhotoId;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static DataTable GetCategories()
        {
            //-- GetCategories
            //-- Retrieve Category values
            //-- Return Value: SqlDataReader with category values

            try
            {
                using (SqlConnection cnCategory = new SqlConnection(cnBooksaleDB))
                {
                    SqlCommand cmdCategory = new SqlCommand(sqlCategories, cnCategory);
                    cmdCategory.CommandType = CommandType.Text;

                    cnCategory.Open();

                    SqlDataAdapter daCategory = new SqlDataAdapter();
                    DataSet dsCategory = new DataSet();
                    DataTable dtCategory = new DataTable();

                    daCategory.SelectCommand = cmdCategory;
                    daCategory.Fill(dsCategory);

                    dtCategory = dsCategory.Tables[0];

                    return dtCategory;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable GetAdTypes()
        {
            //-- GetAdTypes
            //-- Retrieve Ad Type values
            //-- Return Value: SqlDataReader with Ad Type values

            try
            {
                using (SqlConnection cnAdTypes = new SqlConnection(cnBooksaleDB))
                {
                    SqlCommand cmdAdTypes = new SqlCommand(sqlAdTypes, cnAdTypes);
                    cmdAdTypes.CommandType = CommandType.Text;

                    cnAdTypes.Open();

                    SqlDataAdapter daAdTypes = new SqlDataAdapter();
                    DataSet dsAdTypes = new DataSet();
                    DataTable dtAdTypes = new DataTable();

                    daAdTypes.SelectCommand = cmdAdTypes;
                    daAdTypes.Fill(dsAdTypes);

                    dtAdTypes = dsAdTypes.Tables[0];

                    return dtAdTypes;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable GetLocations(int locationType)
        {
            //-- GetLocations
            //-- Retrieve Location values
            //-- Parameters: 
            //--   locationType (int)
            //--     - 1 - Province, 2 - Cities 
            //-- Return Value: SqlDataReader with Location values

            try
            {
                string sqlLocations;

                if (locationType == 1)
                    sqlLocations = sqlProvinces;
                else
                    sqlLocations = sqlCitiesByProv;

                using (SqlConnection cnLocations = new SqlConnection(cnBooksaleDB))
                {
                    SqlCommand cmdLocations = new SqlCommand(sqlLocations, cnLocations);
                    cmdLocations.CommandType = CommandType.Text;

                    cnLocations.Open();

                    //SqlDataReader rdrLocations = cmdLocations.ExecuteReader();

                    SqlDataAdapter daLocations = new SqlDataAdapter();
                    DataSet dsLocations = new DataSet();
                    DataTable dtLocations = new DataTable();

                    daLocations.SelectCommand = cmdLocations;
                    daLocations.Fill(dsLocations);

                    dtLocations = dsLocations.Tables[0];

                    return dtLocations;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool LoadCategoryDDL(DropDownList ddlCategories)
        {
            //-- LoadCategoryDDL
            //-- Load Category items into dropdownlist object specified in the parameters
            //-- Parameters: 
            //--   ddlCategories (Dropdownlist)
            //-- Return Value: True - Successful, False - Failed

            try
            {
                using (SqlConnection cnCategory = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdCategory = new SqlCommand(sqlCategories, cnCategory);
                    cmdCategory.CommandType = CommandType.Text;

                    cnCategory.Open();

                    SqlDataReader rdrCategory = cmdCategory.ExecuteReader();

                    if (rdrCategory.HasRows)
                    {
                        ddlCategories.Items.Clear();

                        ListItem itmAll = new ListItem("All Categories", "0");
                        ddlCategories.Items.Add(itmAll);

                        while (rdrCategory.Read())
                        {
                            ListItem itmCategory = new ListItem(rdrCategory["cat_category_name"].ToString(), rdrCategory["cat_category_id"].ToString());
                            ddlCategories.Items.Add(itmCategory);
                        }
                    }

                    rdrCategory.Close();
                    cmdCategory.Dispose();
                    cnCategory.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool LoadSubCategoryDDL(DropDownList ddlSubCategories, string categoryId)
        {
            //-- LoadSubCategoryDDL
            //-- Load Category items into dropdownlist object specified in the parameters
            //-- Parameters: 
            //--   ddlCategories (Dropdownlist)
            //-- Return Value: True - Successful, False - Failed

            try
            {
                using (SqlConnection cnSubCategory = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdSubCategory = new SqlCommand(sqlSubCategoriesByCat, cnSubCategory);
                    cmdSubCategory.CommandType = CommandType.Text;

                    cmdSubCategory.Parameters.Clear();
                    cmdSubCategory.Parameters.AddWithValue("prmCategoryId", categoryId);

                    cnSubCategory.Open();

                    SqlDataReader rdrSubCategory = cmdSubCategory.ExecuteReader();

                    if (rdrSubCategory.HasRows)
                    {
                        ddlSubCategories.Items.Clear();

                        while (rdrSubCategory.Read())
                        {
                            ListItem itmSubCategory = new ListItem(rdrSubCategory["sub_subcategory_name"].ToString(), rdrSubCategory["sub_subcategory_id"].ToString());
                            ddlSubCategories.Items.Add(itmSubCategory);
                        }
                    }

                    rdrSubCategory.Close();
                    cmdSubCategory.Dispose();
                    cnSubCategory.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool LoadAdTypesDDL(DropDownList ddlAdTypes)
        {
            //-- LoadAdTypesDDL
            //-- Load Ad Type items into dropdownlist object specified in the parameters
            //-- Parameters: 
            //--   ddlAdTypes (Dropdownlist)
            //-- Return Value: True - Successful, False - Failed

            try
            {
                using (SqlConnection cnAdTypes = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdAdTypes = new SqlCommand(sqlAdTypes, cnAdTypes);
                    cmdAdTypes.CommandType = CommandType.Text;

                    cnAdTypes.Open();

                    SqlDataReader rdrAdTypes = cmdAdTypes.ExecuteReader();

                    if (rdrAdTypes.HasRows)
                    {
                        ddlAdTypes.Items.Clear();

                        while (rdrAdTypes.Read())
                        {
                            ListItem itmAdTypes = new ListItem(rdrAdTypes["adt_name"].ToString(), rdrAdTypes["adt_adtype_id"].ToString());
                            ddlAdTypes.Items.Add(itmAdTypes);
                        }

                        ddlAdTypes.SelectedValue = "2"; //-- Set Ad type to Sell by default
                    }

                    rdrAdTypes.Close();
                    cmdAdTypes.Dispose();
                    cnAdTypes.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool LoadConditionsDDL(DropDownList ddlConditions)
        {
            //-- LoadConditionsDDL
            //-- Load Condition items into dropdownlist object specified in the parameters
            //-- Parameters: 
            //--   ddlConditions (Dropdownlist)
            //-- Return Value: True - Successful, False - Failed

            try
            {
                using (SqlConnection cnConditions = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdConditions = new SqlCommand(sqlConditions, cnConditions);
                    cmdConditions.CommandType = CommandType.Text;

                    cnConditions.Open();

                    SqlDataReader rdrConditions = cmdConditions.ExecuteReader();

                    if (rdrConditions.HasRows)
                    {
                        ddlConditions.Items.Clear();

                        ListItem itmAll = new ListItem("All", "All");
                        ddlConditions.Items.Add(itmAll);

                        while (rdrConditions.Read())
                        {
                            ListItem itmConditions = new ListItem(rdrConditions["con_name"].ToString(), rdrConditions["con_condition_id"].ToString());
                            ddlConditions.Items.Add(itmConditions);
                        }

                        ddlConditions.SelectedIndex = 0;
                    }

                    rdrConditions.Close();
                    cmdConditions.Dispose();
                    cnConditions.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool LoadStatusDDL(DropDownList ddlStatus)
        {
            //-- LoadStatusDDL
            //-- Load Status items into dropdownlist object specified in the parameters
            //-- Parameters: 
            //--   ddlStatus (Dropdownlist)
            //-- Return Value: True - Successful, False - Failed

            try
            {
                using (SqlConnection cnStatus = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdStatus = new SqlCommand(sqlAdStatus, cnStatus);
                    cmdStatus.CommandType = CommandType.Text;

                    cnStatus.Open();

                    SqlDataReader rdrStatus = cmdStatus.ExecuteReader();

                    if (rdrStatus.HasRows)
                    {
                        ddlStatus.Items.Clear();

                        ListItem itmAll = new ListItem("All", "All");
                        ddlStatus.Items.Add(itmAll);

                        while (rdrStatus.Read())
                        {
                            ListItem itmStatus = new ListItem(rdrStatus["sta_status_name"].ToString(), rdrStatus["sta_status_id"].ToString());
                            ddlStatus.Items.Add(itmStatus);
                        }

                        ddlStatus.SelectedIndex = 0;
                    }

                    rdrStatus.Close();
                    cmdStatus.Dispose();
                    cnStatus.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool LoadAuthorsDDL(DropDownList ddlAuthors)
        {
            //-- LoadAuthorsDDL
            //-- Load Author items into dropdownlist object specified in the parameters
            //-- Parameters: 
            //--   ddlAuthors (Dropdownlist)
            //-- Return Value: True - Successful, False - Failed

            try
            {
                using (SqlConnection cnAuthors = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdAuthors = new SqlCommand(sqlAuthors, cnAuthors);
                    cmdAuthors.CommandType = CommandType.Text;

                    cnAuthors.Open();

                    SqlDataReader rdrAuthors = cmdAuthors.ExecuteReader();

                    if (rdrAuthors.HasRows)
                    {
                        ddlAuthors.Items.Clear();

                        while (rdrAuthors.Read())
                        {
                            ListItem itmAdTypes = new ListItem(rdrAuthors["aut_name"].ToString(),
                                rdrAuthors["aut_author_id"].ToString());
                            ddlAuthors.Items.Add(itmAdTypes);
                        }

                        ddlAuthors.SelectedIndex = 0;
                    }

                    rdrAuthors.Close();
                    cmdAuthors.Dispose();
                    cnAuthors.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool LoadLocationDDL(DropDownList ddlLocations, int locationType, string provId)
        {
            //-- LoadLocationDDL
            //-- Load Location items into dropdownlist object specified in the parameters
            //-- Parameters: 
            //--   ddlLocations (Dropdownlist)
            //--   locationType (int)
            //--     - 1 - Province, 2 - Cities 
            //--   provId (string)
            //--     - if location required is City, the province Id is needed
            //-- Return Value: True - Successful, False - Failed

            try
            {
                string sqlLocations;

                if (locationType == 1)
                    sqlLocations = sqlProvinces;
                else
                    sqlLocations = sqlCitiesByProv;

                using (SqlConnection cnLocation = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdLocation = new SqlCommand(sqlLocations, cnLocation);
                    cmdLocation.CommandType = CommandType.Text;

                    //-- if location selected is cities, add parameter for Province
                    if (locationType == 2)
                    {
                        cmdLocation.Parameters.Clear();
                        cmdLocation.Parameters.AddWithValue("prmProvId", provId);
                    }

                    cnLocation.Open();

                    SqlDataReader rdrLocation = cmdLocation.ExecuteReader();

                    if (rdrLocation.HasRows)
                    {
                        ddlLocations.Items.Clear();

                        ListItem itmAll = new ListItem("All Locations", "0");
                        ddlLocations.Items.Add(itmAll);

                        while (rdrLocation.Read())
                        {
                            ListItem itmLocation = new ListItem(rdrLocation["prv_name"].ToString(), rdrLocation["prv_province_id"].ToString());
                            ddlLocations.Items.Add(itmLocation);
                        }
                    }

                    rdrLocation.Close();
                    cmdLocation.Dispose();
                    cnLocation.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool LoadLocationDDL(DropDownList ddlLocations, int locationType, bool inAdsOnly, string provId)
        {
            //-- LoadLocationDDL
            //-- Load Location items into dropdownlist object specified in the parameters
            //-- Parameters: 
            //--   ddlLocations (Dropdownlist)
            //--   locationType (int)
            //--     - 1 - Province, 2 - Cities 
            //--   provId (string)
            //--     - if location required is City, the province Id is needed
            //--   inAdsOnly (bool)
            //--     - True - display locations with an ad, False - display all locations
            //-- Return Value: True - Successful, False - Failed

            try
            {
                string sqlLocations;

                if (locationType == 1)
                    sqlLocations = sqlProvinces;
                else
                    sqlLocations = sqlCitiesByProv;

                using (SqlConnection cnLocation = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdLocation = new SqlCommand(sqlLocations, cnLocation);
                    cmdLocation.CommandType = CommandType.Text;

                    //-- if location selected is cities, add parameter for Province
                    if (locationType == 2)
                    {
                        cmdLocation.Parameters.Clear();
                        cmdLocation.Parameters.AddWithValue("prmProvId", provId);
                    }

                    cnLocation.Open();

                    SqlDataReader rdrLocation = cmdLocation.ExecuteReader();

                    if (rdrLocation.HasRows)
                    {
                        ddlLocations.Items.Clear();

                        ListItem itmAll = new ListItem("All", "0");
                        ddlLocations.Items.Add(itmAll);

                        ListItem itmLocation;
                        while (rdrLocation.Read())
                        {
                            if (locationType == 1)
                                //-- if Province
                                itmLocation = new ListItem(rdrLocation["prv_name"].ToString(), rdrLocation["prv_province_id"].ToString());
                            else
                                //-- if City
                                itmLocation = new ListItem(rdrLocation["cit_name"].ToString(), rdrLocation["cit_city_id"].ToString());

                            ddlLocations.Items.Add(itmLocation);
                        }
                    }

                    rdrLocation.Close();
                    cmdLocation.Dispose();
                    cnLocation.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool LoadLatestAds(int _adCount, SqlDataSource _sqlLatestAds, ListView _lvwLatestAds)
        {
            //-- LoadLatestAds
            //-- Load latest ads into Listview using SqlDataSource based on adCount
            //-- Parameters: 
            //--   _adCount (int)
            //--   _sqlLatestAds (SqlDataSource)
            //--   _lvwLatestAds (ListView)
            //-- Return Value: True - Successful, False - Failed

            try
            {
                _sqlLatestAds.SelectCommand = sqlAdsByCategoryLatest;
                _sqlLatestAds.SelectCommand = _sqlLatestAds.SelectCommand.Replace(topXLatest, "top " + _adCount.ToString());
                _lvwLatestAds.DataSource = null;
                _lvwLatestAds.DataSourceID = _sqlLatestAds.ID;

                _lvwLatestAds.DataBind();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool LoadRelatedAds(int _adRelationType, int _adCount, SqlDataSource _sqlRelatedAds,
            ListView _lvwRelatedAds, string _search, string _adsId)
        {
            //-- LoadRelatedAds
            //-- Load other book ads related to the currently displayed Ad based on either genre (type = 1) or author (type = 2)
            //-- Parameters: 
            //--   _adRelationType (int) - 1 = Genre, 2 = Author
            //--   _adCount (int)
            //--   _sqlRelatedAds (SqlDataSource)
            //--   _lvwRelatedAds (ListView)
            //--   _search (string)
            //--   _adsId (string)
            //-- Return Value: True - Successful, False - Failed

            try
            {
                if (_adRelationType == 1)
                    _sqlRelatedAds.SelectCommand = sqlAdsByRelatedGenre;
                else
                    _sqlRelatedAds.SelectCommand = sqlAdsByRelatedAuthor;

                _sqlRelatedAds.SelectCommand = _sqlRelatedAds.SelectCommand.Replace(topXLatest, "top " + _adCount.ToString());

                _sqlRelatedAds.SelectParameters.Clear();
                _sqlRelatedAds.SelectParameters.Add("prmSearch", _search.ToUpper());
                _sqlRelatedAds.SelectParameters.Add("prmAdsId", _adsId);

                _lvwRelatedAds.DataSource = null;
                _lvwRelatedAds.DataSourceID = _sqlRelatedAds.ID;

                _lvwRelatedAds.DataBind();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool LoadRelatedSellers(int _adCount, SqlDataSource _sqlRelatedUsers,
            ListView _lvwRelatedUsers, string _searchGenre, string _searchAuthor, string _adsId)
        {
            //-- LoadRelatedAds
            //-- Load other book ads related to the currently displayed Ad based on either genre (type = 1) or author (type = 2)
            //-- Parameters: 
            //--   _adRelationType (int) - 1 = Genre, 2 = Author
            //--   _adCount (int)
            //--   _sqlRelatedAds (SqlDataSource)
            //--   _lvwRelatedAds (ListView)
            //--   _search (string)
            //--   _adsId (string)
            //-- Return Value: True - Successful, False - Failed

            try
            {
                _sqlRelatedUsers.SelectCommand = sqlRelatedUsersSold;
                _sqlRelatedUsers.SelectCommand = _sqlRelatedUsers.SelectCommand.Replace(topXLatest, "top " + _adCount.ToString());

                _sqlRelatedUsers.SelectParameters.Clear();
                _sqlRelatedUsers.SelectParameters.Add("prmSearchGenre", _searchGenre.ToUpper());
                _sqlRelatedUsers.SelectParameters.Add("prmSearchAuthor", _searchAuthor.ToUpper());
                _sqlRelatedUsers.SelectParameters.Add("prmAdsId", _adsId);

                _lvwRelatedUsers.DataSource = null;
                _lvwRelatedUsers.DataSourceID = _sqlRelatedUsers.ID;

                _lvwRelatedUsers.DataBind();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool LoadReviewStars(DropDownList ddlRatings)
        {
            //-- LoadReviewStars
            //-- Load Rating Stars items into dropdownlist object specified in the parameters
            //-- Parameters: 
            //--   ddlRatings (Dropdownlist)
            //-- Return Value: True - Successful, False - Failed

            try
            {
                for (int i = 1; i <= 5; i++)
                {
                    ListItem itmStar = new ListItem();
                    itmStar.Value = i.ToString();
                    itmStar.Text = i.ToString() + " Star";
                    if (i > 1)
                        itmStar.Text += "s";

                    ddlRatings.Items.Add(itmStar);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string GetMaxReviewId()
        {
            //-- GetMaxAdsDetailsId
            //-- Return Value: Maximum Ads Details Id

            try
            {
                //-- Get latest Ads ID
                string maxReviewId = "";

                string sqlGetMaxReviewId = "select isnull(max(rvw.rvw_id), 0) max_ads_dtl_id from dbo.rvw_reviews rvw";

                using (SqlConnection cnReviewId = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdReviewId = new SqlCommand(sqlGetMaxReviewId, cnReviewId);
                    cmdReviewId.CommandType = CommandType.Text;

                    cnReviewId.Open();

                    maxReviewId = ((int)cmdReviewId.ExecuteScalar()).ToString();

                    cmdReviewId.Dispose();
                    cnReviewId.Close();
                }

                return maxReviewId;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static bool IncrementAdViewCounter(string _adsId)
        {
            //-- IncrementAdViewCounter
            //-- Return Value: Maximum Ads Details Id

            int affectedRows = 0;

            try
            {
                string sqlIncAdViews = "update dbo.dtw_adviews set adv_count = adv_count + 1 where ads_id = @prmAdsId ";

                using (SqlConnection cnIncAdViews = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdIncAdViews = new SqlCommand(sqlIncAdViews, cnIncAdViews);
                    cmdIncAdViews.CommandType = CommandType.Text;

                    cmdIncAdViews.Parameters.Clear();
                    cmdIncAdViews.Parameters.AddWithValue("prmAdsId", _adsId);

                    cnIncAdViews.Open();

                    affectedRows = cmdIncAdViews.ExecuteNonQuery();

                    cmdIncAdViews.Dispose();
                    cnIncAdViews.Close();

                    if (affectedRows == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
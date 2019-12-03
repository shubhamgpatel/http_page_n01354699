using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Diagnostics;


namespace final_project
{
    public partial class main_content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            place_result.InnerHtml = "";

            string searchkey = "";
            if (Page.IsPostBack)
            {
                //https://www.csoonline.com/article/3257429/what-is-sql-injection-how-sqli-attacks-work-and-how-to-prevent-them.html
                //we will learn to defend against these attacks next semester
                //HTTP School database for reference from christine file
                searchkey = place_search.Text;
            }
            string query = "select * from places";

            if (searchkey != "")
            {
                query += " WHERE place_title like '%" + searchkey + "%' ";
                query += " or place_desc like '%" + searchkey + "%' ";
               //query += " or STUDENTNUMBER like '%" + searchkey + "%' ";
            }

            var db_connect = new HTTP_Places();
            List<Dictionary<String, String>> result_set = db_connect.List_Query(query);
            place_result.InnerHtml += "<table class=\"table table-hover\"><tr><th>Place ID</th><th>Place Title</th><th>Place Description</th><th>Created on Date</th><th>Modifications</th>";
            foreach (Dictionary<String, String> row in result_set)
            {
                place_result.InnerHtml += "<tr>";

                string PlaceId = row["place_id"];
                place_result.InnerHtml += "<td> "+ PlaceId + "</td>";
                string Placename = row["place_title"];
                
                place_result.InnerHtml += "<td><a href=\"view_place.aspx?placeid=" + PlaceId + "\">" + Placename + "</a></td>";

                string PlaceDesc = row["place_description"];
                //since the description is long content used substring function to decrease the content
                //if (PlaceDesc == "" || PlaceDesc == "NULL")    // if the string is empty
                //{
                    place_result.InnerHtml += "<td class='place_desc_subs'>" + PlaceDesc + "</td>";
                //}
                //else{
                   // string PlaceDesc_Sub = PlaceDesc.Substring(0, 50) + "...."; //if will display only 50 charcters
                   // place_result.InnerHtml += "<td class='place_desc_subs'>" + PlaceDesc_Sub + "</td>";

                //}
                
                string CreatedOn = row["created_on"];
                place_result.InnerHtml += "<td>" + CreatedOn + "</td>";

                HTTP_Places place_connect = new HTTP_Places();
                //place_connect.DeletePlace(Int32.Parse(PlaceId));

                place_result.InnerHtml += "<td><a href=\"editplace.aspx?placeid=" + PlaceId + "\"><span class=\"glyphicon glyphicon-edit\"></span></a><a href=\"#\" onclick=\"javascript:window.open('document.aspx','mypopuptitle','width=600,height=400')\"><span class=\"glyphicon glyphicon-trash\"></span></a></td>";

                place_result.InnerHtml += "</tr>";
            }
            place_result.InnerHtml += "</table>";

        }
        protected void DeletePlace_aspx(int placeid)
        {
           
            //string placeid = Request.QueryString["placeid"];
          
            HTTP_Places place_connect = new HTTP_Places();

               
            //Response.Redirect("main_content.aspx");
        }


    }
}
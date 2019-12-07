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
            /*------ this area is for delete part ------------------*/
                bool valid = true;
                string placeid = Request.QueryString["placeid"];
                if (String.IsNullOrEmpty(placeid)) valid = false;

                HTTP_Places place_connect1 = new HTTP_Places();
                //deleting the student from the system
                if (valid)
                {
                Response.Write("alert('confirm to delete ?')");
                place_connect1.DeletePlace(Int32.Parse(placeid));
                    Response.Redirect("main_content.aspx");
                }
            /*------ this area is for delete part ------------------*/

            place_result.InnerHtml = ""; //empty string to remove ppast data
            no_result.InnerHtml = "";
            string searchplace = ""; // for searching the string
            if (Page.IsPostBack)
            {
                searchplace = place_search.Text;
            }

            string query = "SELECT * FROM places";

            if (searchplace != "")
            {
                query += " WHERE place_title like '%" + searchplace + "%' ";
                query += " or place_description like '%" + searchplace + "%' ";
            }

            var db_connect = new HTTP_Places();
            List<Dictionary<String, String>> result_set = db_connect.List_query(query);
            place_result.InnerHtml += "<table class=\"table table-hover\"><tr><th>Place ID</th><th>Place Title</th><th>Created on Date</th><th>Edit</th><th>Delete</th>";
            if (result_set.Count > 0)
            {
                foreach (Dictionary<String, String> row in result_set)
                {
                    place_result.InnerHtml += "<tr>";

                    string PlaceId = row["place_id"];
                    place_result.InnerHtml += "<td> " + PlaceId + "</td>";

                    string Placename = row["place_title"];
                    place_result.InnerHtml += "<td><a href=\"view_place.aspx?placeid=" + PlaceId + "\">" + Placename + "</a></td>";

                    string PlaceDesc = row["place_description"];

                    string CreatedOn = row["created_on"];
                    place_result.InnerHtml += "<td>" + CreatedOn + "</td>";

                    HTTP_Places place_connect = new HTTP_Places();
                    //place_connect.DeletePlace(Int32.Parse(PlaceId));

                    place_result.InnerHtml += "<td><a href=\"editplace.aspx?placeid=" + PlaceId + "\"><span class=\"glyphicon glyphicon-edit edit_view\"></span></a></td>";
                    // place_result.InnerHtml += "<td><input type=\"submit\"  onsubmit=\"DeletePlace_aspx(" + PlaceId + ")\"/><span class=\"glyphicon glyphicon-trash\"></span></td>";
                    place_result.InnerHtml += "<td><a href=\"main_content.aspx?placeid=" + PlaceId + "\"><span class=\"glyphicon glyphicon-trash\"></span></a></td>";

                    place_result.InnerHtml += "</tr>";
                }
                place_result.InnerHtml += "</table>";
            }
            else
            {
                no_result.InnerHtml = "No places found!!!";
            }
        }
        /*
        protected void DeletePlace_aspx(object sender, EventArgs e)
        {
            bool valid = true;
            string placeid = Request.QueryString["placeid"];
            if (String.IsNullOrEmpty(placeid)) valid = false;

            HTTP_Places place_connect = new HTTP_Places();
            Console.WriteLine("place id " + placeid);
            //deleting the student from the system
            if (valid)
             {
            place_connect.DeletePlace(Int32.Parse(placeid));
            Response.Redirect("main_content.aspx");
            }
        }*/
    }
}
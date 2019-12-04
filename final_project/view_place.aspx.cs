using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace final_project
{
    public partial class view_place : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HTTP_Places db = new HTTP_Places();
            view_place_fn(db);

        }
        protected void view_place_fn(HTTP_Places hp)
        {
            bool valid = true;
            string place_id = Request.QueryString["placeid"]; // this will grab the value from URL
            if (String.IsNullOrEmpty(place_id)) valid = false;

            if (valid) {

                Place place_record = hp.FindPlace(Int32.Parse(place_id));

                place_title_heading.InnerHtml = place_record.GetPlacetitle();
                place_title.InnerHtml = place_record.GetPlacetitle();
                place_desc.InnerHtml = place_record.GetPlaceDesc();
                place_created_on.InnerHtml = place_record.Getcreated_on().ToString();

            }
            else
            {

                valid = false;
            }
            if (!valid)
            {
                place_title_heading.InnerHtml = "There was an error finding given place.";
            }
        }
           

protected void DeletePlace_aspx(object sender, EventArgs e)
        {
            bool valid = true;
            string placeid = Request.QueryString["placeid"];
            if (String.IsNullOrEmpty(placeid)) valid = false;

            HTTP_Places place_connect = new HTTP_Places();

            //deleting the student from the system
            if (valid)
            {
                place_connect.DeletePlace(Int32.Parse(placeid));
                Response.Redirect("main_content.aspx");
            }
            
        }
    }
}
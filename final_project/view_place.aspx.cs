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
                string placeid = Request.QueryString["placeid"];
                if (!String.IsNullOrEmpty(placeid))
                {
                var db = new HTTP_Places();
                Dictionary<String, String> place_record = db.FindPlace(Int32.Parse(placeid));

                if (place_record.Count > 0)
                {
                    place_title_heading.InnerHtml = place_record["place_title"];
                    place_title.InnerHtml = place_record["place_title"];
                    place_desc.InnerHtml = place_record["place_description"];
                    place_created_on.InnerHtml = place_record["created_on"];
                    //student_lastname.InnerHtml = place_record["STUDENTLNAME"];
                    //student_no.InnerHtml = place_record["STUDENTNUMBER"];
                    //enrolment_date.InnerHtml = place_record["ENROLMENTDATE"];
                }
                else
                {
                    //valid = false;
                }
            }
            else
            {
                Response.Redirect("main_content.aspx");
            }
            /*
            if (!valid)
            {
                place_error.InnerHtml = "Sorry!!!There was an error finding that student.";
            }
            */
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace final_project
{
    public partial class editplace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //bool valid = true;
            string placeid = Request.QueryString["placeid"];
            if (!String.IsNullOrEmpty(placeid))
            {
                var http_place = new HTTP_Places();
                var edit_place = new Place();
                //Dictionary<String, String> specific_place = edit_place.FindPlace(Int32.Parse(placeid));


                edit_place.SetPlacetitle(edit_place_title.Text);
                edit_place.SetPlaceDes(create_description.Text);
                edit_place.Setcreated_on(DateTime.ParseExact(created_on.Text, "yyyy-mm-dd H:mm:ss", null));

                try
                {
                    http_place.UpdatePlace(Int32.Parse(placeid), edit_place);
                    Response.Redirect("view_place.aspx?placeid=" + placeid);
                }
                catch
                {
                    //valid = false;
                }
            }
            else
            {
                Response.Redirect("main_content.aspx");
            }
           /* if (!valid)
            {
                place_error.InnerHtml = "Sorry!!!There was an error finding the given place!!";
            }*/
        }
    }
}

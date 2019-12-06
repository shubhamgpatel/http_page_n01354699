using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace final_project
{
    public partial class add_place : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //as there is nothing to load
            // we are adding new entry
        }
        protected void Add_Place(object sender, EventArgs e)
        {
            //create connection using HTTP Place class file
            HTTP_Places place1 = new HTTP_Places();
            //create a new particular place where we can put values in tables
            Place new_place = new Place();

            //object.method(ID.Text)
            new_place.SetPlacetitle(create_place_title.Text);
            new_place.SetPlaceDes(create_description.Text);
            //https://www.c-sharpcorner.com/blogs/date-and-time-format-in-c-sharp-programming1
            // converting datetime to sttring
            new_place.Setcreated_on(DateTime.Now.ToString("yyyy’-‘MM’-‘dd’ ’HH’:’mm’:’ss")); // set real time of system in created_on column

            //https://support.microsoft.com/en-ca/help/323246/how-to-upload-a-file-to-a-web-server-in-asp-net-by-using-visual-c-net
            //tried to use upload but didnt worked well
            //will learn more and try to make it more properly
            /*try
            {
                if ((image_url_upload != null) && (image_url_upload.PostedFile.ContentLength > 0))
                {
                    string img_upload = System.IO.Path.GetFileName(image_url_upload.FileName);
                    new_place.SetPlaceImage(img_upload);
                    // string SaveLocation = Server.MapPath("Data") + "/images/" + img_upload;

                    // image_url_upload.PostedFile.SaveAs(SaveLocation);
                    Response.Write("The image has been uploaded.");
                }
                else
                {
                    Response.Write("Please select a file to upload.");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);

            }
            */

            //add the student to the database
            //object_instace.method(passing_new_place)
            place1.AddPlace(new_place);
            // after adding in database redirecting to main content
            Response.Redirect("main_content.aspx");
        }

    }
}
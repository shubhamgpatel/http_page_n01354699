﻿using System;
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
            if (!Page.IsPostBack)
            {
                //this connection instance is for showing data
                HTTP_Places hp = new HTTP_Places();
              display_place(hp);
            }
        }
        protected void display_place(HTTP_Places hp)
        {

            bool valid = true;
            string place_id = Request.QueryString["placeid"];
            if (String.IsNullOrEmpty(place_id)) valid = false;

            //We will attempt to get the record we need
            if (valid)
            {
                // this function will get the values from database and set in textbox
                Place place_record = hp.FindPlace(Int32.Parse(place_id));
                edit_place_title.Text = place_record.GetPlacetitle();
                edit_description.Text = place_record.GetPlaceDesc();
                created_on.Text = place_record.Getcreated_on().ToString();
            }
          

            if (!valid)
            {
                edit_place_panel.InnerHtml = "There was an error finding that place.";
                Response.Redirect("main_content.aspx"); //if someone directly try to access edit file it is not possible so we redirect to main content page
            }
        }
        protected void edit_place(object sender, EventArgs e)
        {

            //this connection instance is for editing data
            HTTP_Places hp = new HTTP_Places();

            bool valid = true;
            string placeid = Request.QueryString["placeid"];
            if (String.IsNullOrEmpty(placeid)) valid = false;
            if (valid)
            {
                Place edit_place = new Place();
                //set that student data
                edit_place.SetPlacetitle(edit_place_title.Text);
                edit_place.SetPlaceDes(edit_description.Text);

                //add the student to the database
                try
                {
                    hp.UpdatePlace(Int32.Parse(placeid), edit_place);
                    Response.Redirect("view_place.aspx?placeid=" + placeid);
                }
                catch
                {
                    valid = false;
                }

            }

            if (!valid)
            {
                place_error.InnerHtml = "There was an error updating place.";
            }

        }

        
    }
}

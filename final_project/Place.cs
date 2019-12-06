using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace final_project
{
    public class Place
    {
        /*
         fields are private cannot be accessed normally
         will NOT be able to 
            set like Student.Fname = "Christine"
            get like Student.Fname ==> returns "Christine"
         */
        private int Place_id;
        private string Page_title;
        private string Page_description;
        private string created_on;


        public int GetPlaceId()
        {
            return Place_id;
        }
        public string GetPlacetitle()
        {
            return Page_title;
        }
        public string GetPlaceDesc()
        {
            return Page_description;
        }

        public string Getcreated_on()
        {
            return created_on;
        }

        //Methods used to set and get values in an object
        //example - Place.SetPlacetitle("John")
      
        public void SetPlacetitle(string value)
        {
            Page_title = value;
        }
        public void SetPlaceDes(string value)
        {
            Page_description = value;
        }

        public void Setcreated_on(string value)
        {
            created_on = value;
        }

    }
}
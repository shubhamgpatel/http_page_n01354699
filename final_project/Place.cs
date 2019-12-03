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
         These fields are private cannot be accessed normally
         will NOT be able to 
            set like Student.Fname = "Christine"
            get like Student.Fname ==> returns "Christine"
         */
        private int Place_id;
        private string Page_title;
        private string Page_description;
        private DateTime created_on;


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

        public DateTime Getcreated_on()
        {
            return created_on;
        }

        //These methods are used to set values in an object
        //i.e. if I want to change the last name to Bittle
        //student.SetLname("Bittle")
        public void SetPlacetitle(string value)
        {
            Page_title = value;
        }
        public void SetPlaceDes(string value)
        {
            Page_description = value;
        }

        public void Setcreated_on(DateTime value)
        {
            created_on = value;
        }

    }
}
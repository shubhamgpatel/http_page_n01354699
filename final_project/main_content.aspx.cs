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
                query += " WHERE STUDENTFNAME like '%" + searchkey + "%' ";
                query += " or STUDENTLNAME like '%" + searchkey + "%' ";
                query += " or STUDENTNUMBER like '%" + searchkey + "%' ";
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
                if (PlaceDesc == "")    // if the string is empty
                {
                    place_result.InnerHtml += "<td class='place_desc_subs'>" + PlaceDesc + "</td>";
                }
                else
                {
                    string PlaceDesc_Sub = PlaceDesc.Substring(0, 50) + "...."; //if will display only 50 charcters
                    place_result.InnerHtml += "<td class='place_desc_subs'>" + PlaceDesc_Sub + "</td>";

                }
                
                string CreatedOn = row["created_on"];
                place_result.InnerHtml += "<td>" + CreatedOn + "</td>";
                
                place_result.InnerHtml += "<td><a href=\"update_place.aspx?studentid=" + PlaceId + "\"><span class=\"glyphicon glyphicon-edit\"></span></a><a href=\"delete_student.aspx?placeid=" + PlaceId + "\"><span class=\"glyphicon glyphicon-trash\"></span></a></td>";

                place_result.InnerHtml += "</tr>";
            }
            place_result.InnerHtml += "</table>";

        }
        /*
        public Dictionary<String, String> FindStudent(int id)
        {
            //Utilize the connection string
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            //create a "blank" student so that our method can return something if we're not successful catching student data
            Dictionary<String, String> student = new Dictionary<String, String>();

            //we will try to grab student data from the database, if we fail, a message will appear in Debug>Windows>Output dialogue
            try
            {
                //Build a custom query with the id information provided
                string query = "select * from places where place_id = " + id;
                Debug.WriteLine("Connection Initialized...");
                //open the db connection
                Connect.Open();
                //Run out query against the database
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();

                //Create a list of students (although we're only trying to get 1)
                List<Dictionary<String, String>> Students = new List<Dictionary<String, String>>();

                //read through the result set
                while (resultset.Read())
                {
                    //information that will store a single student
                    Dictionary<String, String> Student = new Dictionary<String, String>();

                    //Look at each column in the result set row, add both the column name and the column value to our Student dictionary
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Debug.WriteLine("Attempting to transfer data of " + resultset.GetName(i));
                        Debug.WriteLine("Attempting to transfer data of " + resultset.GetString(i));
                        Student.Add(resultset.GetName(i), resultset.GetString(i));

                    }
                    //Add the student to the list of students
                    Students.Add(Student);
                }

                student = Students[0]; //get the first student

            }
            catch (Exception ex)
            {
                //If something (anything) goes wrong with the try{} block, this block will execute
                Debug.WriteLine("Something went wrong in the find Student method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return student;
        }*/

    }
}
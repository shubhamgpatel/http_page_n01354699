using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Globalization;

namespace final_project
{
    public class HTTP_Places
    {

        private static string User
        {
            get
            {
                return "root";
            }
        } //username of phpmyadmin
        private static string Password
        {
            get
            {
                return "";
            }
        } // password of phpmymadmin
        private static string Database
        {
            get
            {
                return "HTTP_Page";
            }
        } // database name
        private static string Server
        {
            get
            {
                return "localhost";
            }
        } // using localhost
        private static string Port
        {
            get
            {
                return "3306";
            }
        } // port number where server is running on

        //ConnectionString use to connect to a database
        private static string ConnectionString
        {
            get
            {
                return "server = " + Server + "; user = " + User + "; database = " + Database + "; port = " + Port + "; password = " + Password;
            }
        }

        //for getting result set we use dictionaries which has Key and Value e.g (First_name)key : (Simon)value

        public List<Dictionary<String, String>> List_Query(string query) // 2 string used because one for key and other for value
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();

            // try catch block to do everything  where inside try used to execute something and if any error arise catch is used.
            try
            {
                Debug.WriteLine("Connection Initialize");
                Debug.WriteLine("Attempt to execute query " + query);
                //open method to start db connection
                Connect.Open();
                //give the connection a query
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //get the result set
                MySqlDataReader resultset = cmd.ExecuteReader();


                // while loop used to get value of columns
                while (resultset.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>();

                    for (int c = 0; c < resultset.FieldCount; c++)
                    {
                        //for every column in the row
                        Row.Add(resultset.GetName(c), resultset.GetString(c));

                    }
                    ResultSet.Add(Row);
                }
                //end row
                resultset.Close(); // closing the connection
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong while establishing the connnection!");
                Debug.WriteLine(ex.ToString());

            }
            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }

        //function to find a place 
        public Place FindPlace(int Place_Id) // taking place in as a parameter
        {
            //Cnnection string 
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            //initialise a blank "Place" object so that method can return something if we are not successful while catching place data
            Place result_place = new Place();

            //grabbing place data from the database, if we fail, a message will appear in Debug>Windows>Output dialogue
            //christine lab 
            try
            {

                string query = "select place_id, place_title, place_description, DATE_FORMAT(created_on, \"%D %M %Y \") AS created_on from places where place_id = " + Place_Id;
                Debug.WriteLine("Connection Initialized..");
                Connect.Open(); //open method used to open the connection
                //for running query passing 2 arguments i.e actual query and connection to run that query
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();

                //create a list of places
                List<Place> All_Places = new List<Place>();

                //read through the result set
                while (resultset.Read())
                {
                    //data that will store a specific place
                    Place Specific_Place = new Place();

                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempt to transfer " + key + " data of " + value);
                        switch (key)
                        { //christine lab for reference
                            case "place_title":
                                Specific_Place.SetPlacetitle(value);
                                break;
                            case "place_description":
                                Specific_Place.SetPlaceDes(value);
                                break;
                                //case "created_on":
                                //how to convert a string to a date?
                                //http://net-informations.com/q/faq/stringdate.html
                               ///https://www.c-sharpcorner.com/blogs/date-and-time-format-in-c-sharp-programming1
                                   // Specific_Place.Setcreated_on(DateTime.ParseExact(value, "M/d/yyyy hh:mm:ss tt", new CultureInfo("en-US")));
                                  //break;
                        }

                    }
                    //Add the student to the list of students
                    All_Places.Add(Specific_Place);
                }

                result_place = All_Places[0]; //get the first place array of index 0

            }
            catch (Exception ex)
            {
                //Something goes wrong in try block  this block will execute i.e catch block
                Debug.WriteLine("Something went wrong in the find Place method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return result_place;
        }
        public void DeletePlace(int placeid) //delete method to delete specific place
        {

            string remove_place = "Delete from places where place_id = {0}"; //index{0}
            remove_place = String.Format(remove_place, placeid); //string format has 2 parameters one is query and other is place id which we will receive from function parameter


            MySqlConnection Connection = new MySqlConnection(ConnectionString); //initialise connection string

            //Command that removes the particular place from places table
            MySqlCommand cmd_removeplace = new MySqlCommand(remove_place, Connection);
            try
            {
                Connection.Open();
                //remove the data
                cmd_removeplace.ExecuteNonQuery();
                Debug.WriteLine("Executed query : " + cmd_removeplace);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the delete Place function!!!");
                Debug.WriteLine(ex.ToString());
            }

            Connection.Close();
        }

        public void UpdatePlace(int placeid, Place update_new_student) //2 parameter int and object itself which has variable
        // place title, description and created_on
        {
            string query = "UPDATE places set place_title='{0}', place_description='{1}' where place_id={2}";
            query = String.Format(query, update_new_student.GetPlacetitle(), update_new_student.GetPlaceDesc(), placeid);


            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                //Runnning updating place query with the data given
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query : " + query);

            }
            catch (Exception ex)
            {
                //If that doesn't seem to work, check Debug>Windows>Output for the below message
                Debug.WriteLine("Something went wrong in the Update Place Function!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }

        public void AddPlace(Place new_place) //adding new place
        {

            string query = "INSERT INTO places (place_title, place_description, created_on) values ('{0}','{1}','{2}')";
            query = String.Format(query, new_place.GetPlacetitle(), new_place.GetPlaceDesc(), new_place.Getcreated_on().ToString("yyyy-MM-dd H:mm:ss"));


            MySqlConnection Connect = new MySqlConnection(ConnectionString); //connnection string
            MySqlCommand cmd = new MySqlCommand(query, Connect); //running query with 2 parameter..actual query and connection string
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the Add Place Function!!!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
        }

    }
}//close
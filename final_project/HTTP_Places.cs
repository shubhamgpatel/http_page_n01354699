using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace final_project
{
    public class HTTP_Places
    {

        //for connnection we require 4 thinigs
        // - Connection (URL, port) e.g localhost
        // - username
        // - password of phpmyadmin or MAMP
        // - database name

        private static string User { get { return "root"; } }
        private static string Password { get { return ""; } }
        private static string Database { get { return "HTTP_Page"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        //ConnectionString use to connect to a database
        private static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
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


                // while loop used to get value of result set
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
                resultset.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong!");
                Debug.WriteLine(ex.ToString());

            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }

        //function to find a place 
        public Dictionary<String, String> FindPlace(int Place_Id)
        {
            //Cnnection string
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            //create a empty "Place" object so that function can return something if we are not successful while catching place data
            Dictionary<String, String> Place = new Dictionary<String, String>();

            //we will try to grab student data from the database, if we fail, a message will appear in Debug>Windows>Output dialogue
            try
            {
                //Build a custom query with the id information provided
                string query = "select * from places where place_id = " + Place_Id;
                Debug.WriteLine("Connection Initialized...");
                Connect.Open(); //open method used to open the connection
                //Run out query against the database
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();

                //Create a list of students (although we're only trying to get 1)
                List<Dictionary<String, String>> All_Places = new List<Dictionary<String, String>>();

                //read through the result set
                while (resultset.Read())
                {
                    //information that will store a single student
                    Dictionary<String, String> Specific_Place = new Dictionary<String, String>();

                    //Look at each column in the result set row, add both the column name and the column value to our Student dictionary
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Debug.WriteLine("Attempting to transfer data of " + resultset.GetName(i));
                        Debug.WriteLine("Attempting to transfer data of " + resultset.GetString(i));
                        Specific_Place.Add(resultset.GetName(i), resultset.GetString(i));

                    }
                    //Add the student to the list of students
                    All_Places.Add(Specific_Place);
                }

                Place = All_Places[0]; //get the first place array of index 0

            }
            catch (Exception ex)
            {
                //Something goes wrong in try block  this block will execute i.e catch block
                Debug.WriteLine("Something went wrong in the find Student method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return Place;
        }
        public void UpdatePlace(int placeid, Place update_new_student)
        {
            //slightly better way of injecting data into strings
            //the below technique is known as string formatting. It allows us to make strings without "" + ""
            string query = "UPDATE places set place_title='{0}', place_description='{1}'";
            query = String.Format(query, update_new_student.GetPlacetitle(), update_new_student.GetPlaceDesc(), placeid);
            //The above technique is still sensitive to SQL injection
            //we will learn about parameterized queries in the 2nd semester

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                //Try to update a student with the information provided to us.
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {
                //If that doesn't seem to work, check Debug>Windows>Output for the below message
                Debug.WriteLine("Something went wrong in the Update Place Function!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }
        public void DeletePlace(int placeid)
        {
           
            string remove_place = "Delete from places where place_id = {0}";
            remove_place = String.Format(remove_place, placeid);


            MySqlConnection Connection = new MySqlConnection(ConnectionString);
           
            //This command removes the particular place from places table
            MySqlCommand cmd_removeplace = new MySqlCommand(remove_place, Connection);
            try
            {
                //try to execute both commands!
                Connection.Open();
                //remember to remove the relational element first
                cmd_removeplace.ExecuteNonQuery();
                Debug.WriteLine("Execute delete query " + cmd_removeplace);
                //then delete the main record
                cmd_removeplace.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd_removeplace);
            }
            catch (Exception ex)
            {
                //when we build solution and exit the webpage, this method will exeucte id code doesnt work which is in try block
                Debug.WriteLine("Something went wrong in the delete place function!!!");
                Debug.WriteLine(ex.ToString());
            }

            Connection.Close();
        }
        public void AddPlace(Place new_place)
        {

            string query = "insert into places (place_title, place_description, created_on) values ('{0}','{1}','{2}')";
            query = String.Format(query, new_place.GetPlacetitle(), new_place.GetPlaceDesc(), new_place.Getcreated_on().ToString("yyyy-MM-dd H:mm:ss"));


            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
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
}
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
            
        }
        protected void Add_Place(object sender, EventArgs e)
        {
            //create connection
            HTTP_Places db = new HTTP_Places();

            //create a new particular student
            Student new_student = new Student();
            //set that student data
            new_student.SetFname(student_fname.Text);
            new_student.SetLname(student_lname.Text);
            new_student.SetNumber(student_number.Text);
            new_student.SetEnrolDate(DateTime.Now);

            //add the student to the database
            db.AddStudent(new_student);


            Response.Redirect("ListStudents.aspx");
        }

    }
}
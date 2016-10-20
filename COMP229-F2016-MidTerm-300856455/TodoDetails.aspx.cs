using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements required for EF DB access
using COMP229_F2016_MidTerm_300856455.Models;
using System.Web.ModelBinding;

namespace COMP229_F2016_MidTerm_300856455
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetTodo();
            }
        }

        protected void GetTodo()
        {
            // populate the form with existing data from db
            int TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

            // connect to the EF DB
            using (TodoContext db = new TodoContext())
            {
                // populate a Todo object instance with the TodoID from 
                // the URL parameter
                Todo updatedTodolist = (from todo in db.Todos
                                          where todo.TodoID == TodoID
                                          select todo).FirstOrDefault();

                // map the Todolist properties to the form control
                if (updatedTodolist != null)
                {
                    TodoNameTextBox.Text = updatedTodolist.TodoDescription;
                    NotesTextBox.Text = updatedTodolist.TodoNotes;
                    
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to the todo list page
            Response.Redirect("TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to conect to the server
            using (TodoContext db = new TodoContext())


            {
                // use the student model to create a new tododescription and notes  and 
                // save a new record

                Todo newTodo = new Todo();

                int TodoID = 0;

                if (Request.QueryString.Count > 0) // our URL has a TodoID in it
                {
                    // get the id from the URL
                    TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                    // get the current todo lists  from EF db
                    newTodo = (from todo in db.Todos
                                  where todo.TodoID == TodoID
                                  select todo).FirstOrDefault();
                }

                // add form data to the new tododescription and notes 
                newTodo.TodoDescription = TodoNameTextBox.Text;
                newTodo.TodoNotes = NotesTextBox.Text;
               

                // use LINQ to ADO.NET to add / insert new tododescription and notes into the db

                if (TodoID == 0)
                {
                    db.Todos.Add(newTodo);
                }

                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated Todo page
                Response.Redirect("TodoList.aspx");
            }
        }
    }
}
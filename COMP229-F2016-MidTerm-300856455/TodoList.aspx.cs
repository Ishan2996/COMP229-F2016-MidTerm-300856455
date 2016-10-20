using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMP229_F2016_MidTerm_300856455.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;
namespace COMP229_F2016_MidTerm_300856455
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time
            // populate the Todo table grid
            if (!IsPostBack)
            {
                // Get the Todo data
                this.gettodo();
            }
        }

        private void gettodo()
        {
            // connect to EF DB
            using (TodoContext db = new TodoContext())
            {
                // query the Todo Table using EF and LINQ
                var todos = (from alltodos in db.Todos
                             select alltodos);

                // bind the result to the Todo GridView
                TodoGridView.DataSource = todos.ToList();
                TodoGridView.DataBind();
            }
        }

        protected void TodoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected TodoID using the Grid's DataKey collection
            int TodoID = Convert.ToInt32(TodoGridView.DataKeys[selectedRow].Values["TodoID"]);

            // use EF and LINQ to find the selected todo in the DB and remove it
            using (TodoContext db = new TodoContext())
            {
                // create object ot the todo clas and store the query inside of it
                Todo deletedtodo = (from studentRecords in db.Todos
                                    where studentRecords.TodoID == TodoID
                                    select studentRecords).FirstOrDefault();

                // remove the selected todo description from the db
                db.Todos.Remove(deletedtodo);

                // save my changes back to the db
                db.SaveChanges();

                // refresh the grid
                this.gettodo();
            }
        }

        /// <summary>
        /// This method gets the todo data from the DB
        /// </summary>

    }
}
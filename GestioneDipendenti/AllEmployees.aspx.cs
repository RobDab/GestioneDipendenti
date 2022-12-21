using GestioneDipendenti.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestioneDipendenti
{
    public partial class AllEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmpList.Clear();
                foreach (Employee emp in Employee.GetEmployees(0))
                {
                    EmpList.Add(emp);
                }
                

            }

            GridView1.DataSource = EmpList;
            GridView1.DataBind();

        }

        public static List<Employee> EmpList = new List<Employee>();

        protected void PayBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string Id = btn.CommandArgument;

            Response.Redirect($"/Payment.aspx?id={Id}");
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AddEmployee.aspx");
        }
    }
       
}
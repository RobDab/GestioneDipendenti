using GestioneDipendenti.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestioneDipendenti
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
                string EmployeeID = Request.QueryString["id"];
                Employee CurrentEmployee = Employee.GetEmployees(Convert.ToInt32(EmployeeID))[0];

                EmpNameLabel.Text = CurrentEmployee.Nome;

                MeseRifDDL.SelectedValue = DateTime.Now.Month.ToString();
            }
           
           
        }

        protected void PaymentBtn_Click(object sender, EventArgs e)
        {
           
            Confirm.Attributes.Clear();
            Confirm.Attributes.Add("class","d-block");
        }

        protected void ConfirmBtn_Click(object sender, EventArgs e)
        {
            string EmployeeID = Request.QueryString["id"];
            Versamento ver = new Versamento();
            ver.Mese = MeseRifDDL.SelectedValue;
            ver.DataVersamento = Convert.ToDateTime(Calendar.Value);
            ver.IsAcconto = AccontoCB.Checked;
            ver.Valore = Convert.ToDouble(AmountInput.Text);
            ver.IDDipendente = Convert.ToInt32(EmployeeID);

            try
            {
                Versamento.AddVersamento(ver);
            }catch(Exception ex)
            {
                ExLbl.Visible = true;
                ExLbl.Text = ex.Message;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace GestioneDipendenti.Classes
{
    public class Versamento
    {
        public string Mese { get; set; }

        public DateTime DataVersamento { get; set; }

        public Boolean IsAcconto { get; set; }

        public double Valore { get; set; }

        public int IDDipendente { get; set; }

        public static void AddVersamento(Versamento ver)
        {
            SqlConnection con = new SqlConnection();

            
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EdilHR_DB_Connection"].ToString();
                con.Open();

                SqlCommand commandVer = new SqlCommand();
                commandVer.Parameters.AddWithValue("@PeriodoRif", ver.Mese);
                commandVer.Parameters.AddWithValue("@DataVers", ver.DataVersamento);
                commandVer.Parameters.AddWithValue("@Anticipo", ver.IsAcconto);
                commandVer.Parameters.AddWithValue("@Valore", ver.Valore);
                commandVer.Parameters.AddWithValue("@Employee", ver.IDDipendente);

                commandVer.CommandText = "INSERT INTO VersamentiTab VALUES (@PeriodoRif, @DataVers, @Anticipo, @Valore, @Employee)";
            commandVer.Connection = con;
            if (ver.IsAcconto)
            {
                Employee emp = Employee.GetEmployees(ver.IDDipendente)[0];
                emp.Credito = emp.GetSalary() - ver.Valore;
                Employee.UpdateEmployeeCredit(emp.Id, emp.Credito );

            }   
                commandVer.ExecuteNonQuery();

            con.Close();

            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestioneDipendenti.Classes
{
    public class Employee
    {

        public int Id { get; set; }
        public string Nome { get; set; }

        public string Cognome { get; set; }

        public string Indirizzo { get; set; }

        public string CF { get; set; }

        public bool Coniugato { get; set; }

        public int FigliACarico { get; set; }

        public string Mansione { get; set; }

        public double Credito { get; set; }

        public int JobLevel { get; set; }

        //public double Salary { get; set; }

        public double GetSalary()
        {
            double Salary;

            switch (JobLevel)
            {
                case 1:
                    Salary = 1000.00;
                    break;
                case 2:
                    Salary = 1500.00;
                    break;
                case 3:
                    Salary = 2000.00;
                    break;
                default:
                    Salary = 500.00;
                    break;
            }

            return Salary;
        }


        public static List<Employee> GetEmployees(int id)
        {
            SqlConnection con = new SqlConnection();
            List<Employee> EmployeesList = new List<Employee>();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EdilHR_DB_Connection"].ToString();
                con.Open();

                SqlCommand command = new SqlCommand();
                if(id == 0)
                {
                    command.CommandText = "SELECT * FROM EmployeesTab";
                }
                else
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.CommandText = "SELECT * FROM EmployeesTab WHERE IDDipendente = @ID ";
                }
                
                command.Connection = con;

                SqlDataReader reader = command.ExecuteReader();
                

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee e = new Employee();
                        e.Id = Convert.ToInt32(reader["IDDipendente"]);
                        e.Nome = reader["Nome"].ToString();
                        e.Cognome = reader["Cognome"].ToString();
                        e.Indirizzo = reader["Indirizzo"].ToString();
                        e.CF = reader["CF"].ToString();
                        e.Coniugato = Convert.ToBoolean(reader["Coniugato"]);
                        e.FigliACarico = Convert.ToInt32(reader["FigliACarico"]);
                        e.Mansione = reader["Mansione"].ToString();
                        e.Credito = Convert.ToDouble(reader["A_Credito"].ToString());
                        e.JobLevel = Convert.ToInt32(reader["Livello"]);

                        EmployeesList.Add(e);

                    }
                }
            }
            catch(Exception ex)
            {
                con.Close();
            }

            con.Close();
            return EmployeesList;
        }

        public void AddEmployee(Employee e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["EdilHR_DB_Connection"].ToString();

            try
            {
                con.Open();

                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@Nome", e.Nome) ;
                command.Parameters.AddWithValue("@Cognome", e.Cognome);
                command.Parameters.AddWithValue("@Indirizzo", e.Indirizzo);
                command.Parameters.AddWithValue("@CF", e.CF);
                command.Parameters.AddWithValue("@Coniugato", e.Coniugato);
                command.Parameters.AddWithValue("@Figli", e.FigliACarico);
                command.Parameters.AddWithValue("@Mansione", e.Mansione);
                command.Parameters.AddWithValue("@Credito", e.Credito);
                command.Parameters.AddWithValue("@Livello", e.JobLevel);

                command.CommandText = "INSERT INTO EmployeesTab VALUES (@Nome , @Cognome, @Indirizzo, @CF, @Coniugato, @Figli , @Mansione, @Credito, @Livello)";
                command.Connection = con;
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                con.Close();
            }

            con.Close();

        }

        public static void UpdateEmployeeCredit(int id, double value)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["EdilHR_DB_Connection"].ToString();

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Value", value);

                cmd.CommandText = "UPDATE EmployeesTab SET A_Credito = @Value WHERE IDDipendente = @ID";
                cmd.Connection= con;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) 
            { 
                con.Close(); 
            }

            con.Close();
        }
    }
}
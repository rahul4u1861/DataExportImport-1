using DataExportImport.Models;
using System.Data;
using System.Data.SqlClient;

namespace DataExportImport.Service
{
    public class DbContext
    {
        private SqlConnection _con = new SqlConnection();
        private SqlCommand _cmd = new SqlCommand("exe");
        public void Save(Customer customer)
        {
            using (var con = new SqlConnection("Data Source=.;Initial Catalog=HackathonDatabase;Integrated Security=True"))
            {
                using (var cmd = new SqlCommand("sp_save_customer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = customer.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = customer.LastName;
                    cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = customer.Mobile;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = customer.Email;
                    cmd.Parameters.Add("@SSN", SqlDbType.VarChar).Value = customer.SSN;
                    cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = customer.Gender;
                    cmd.Parameters.Add("@AddressLine1", SqlDbType.VarChar).Value = customer.AddressLine1;
                    cmd.Parameters.Add("@AddressLine2", SqlDbType.VarChar).Value = customer.AddressLine2;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = customer.City;
                    cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = customer.State;
                    cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = customer.ZipCode;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
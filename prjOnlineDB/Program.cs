using System.Data.SqlClient;

namespace prjOnlineDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString = "Server=tcp:rwanvig.database.windows.net,1433;Initial Catalog=rwanvigdb;Persist Security Info=False;User ID=rwanvig;Password=@Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using(SqlConnection connection =new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Student in the class!");
                    Console.WriteLine("=======================");
                    String sql = "Select * from StudentMarks";
                    using (SqlCommand command =new SqlCommand(sql, connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                Console.WriteLine("{0} - {1} {2}",reader.GetInt32(0),
                                    reader.GetString(1),reader.GetString(2));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

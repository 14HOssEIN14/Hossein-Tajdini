using AnimalManagmentSystem;
using Microsoft.Data.SqlClient;

string connectionString = "Server=localhost;Database=Zoo;Trusted_Connection=True;TrustServerCertificate=True;";
using (SqlConnection connection = new SqlConnection(connectionString))
{
    try
    {
        connection.Open();

        string checkTableQuery = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Animals') " +
                                 "BEGIN " +
                                 "CREATE TABLE Animals (" +
                                 "Id INT IDENTITY(1,1) PRIMARY KEY, " +
                                 "name NVARCHAR(100), " +
                                 "animalSpecies NVARCHAR(100), " +
                                 "age INT, " +
                                 "stock INT, " +
                                 "specialAttributes NVARCHAR(Max)" +
                                 "); " +
                                 "END";

        using (SqlCommand command = new SqlCommand(checkTableQuery, connection))
        {
            command.ExecuteNonQuery();
          
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}//check table is exist



MenuHandler menuHandler = new MenuHandler();
menuHandler.WelcomePage();
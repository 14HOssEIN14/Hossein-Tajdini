using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace AnimalManagmentSystem.DataManagment
{
    public static class DBManager
    {
        private static readonly string connectionString = "Server=localhost;Database=Zoo;Trusted_Connection=True;TrustServerCertificate=True;";
        public static void AddAnimal(Animal animal)
        {
            bool alreadyExist = CheckIfAnimalExists(animal);//if this type of animal exist
            if (alreadyExist)
            {
                string query = @" UPDATE Animals
                  SET stock = stock + 1
                  WHERE  name = @Name  AND  animalSpecies = @AnimalSpecies AND age = @Age AND specialAttributes= @specialAttributes";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        string json = JsonConvert.SerializeObject(animal.specialAttributes);

                        command.Parameters.AddWithValue("@Name", animal.name);
                        command.Parameters.AddWithValue("@AnimalSpecies", animal.animalSpecie);
                        command.Parameters.AddWithValue("@Age", animal.age);
                        command.Parameters.AddWithValue("@specialAttributes", json);
                        command.ExecuteNonQuery();
                    }
                }
                return;
            }



            try
            {
                string query = "INSERT INTO Animals (name,animalSpecies,age ,specialAttributes, stock) VALUES (@name,@animalSpecie,@age ,@specialAttributes, @stock)";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        string json = JsonConvert.SerializeObject(animal.specialAttributes);

                        command.Parameters.AddWithValue("@name", animal.name);
                        command.Parameters.AddWithValue("@animalSpecie", animal.animalSpecie);
                        command.Parameters.AddWithValue("@age", animal.age);
                        command.Parameters.AddWithValue("@stock", 1);
                        command.Parameters.AddWithValue("@specialAttributes", json);


                        int rowsAffected = command.ExecuteNonQuery();
                    }
                    Console.WriteLine($"row(s) inserted successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


        }
        public static void EditAnimal(Animal animal,int id)
        {
            string query = $@" UPDATE Animals
            SET name=@name ,age = @age, animalSpecies = @animalSpecie,specialAttributes=@specialAttributes,stock=@stock
            WHERE Id = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    string json = JsonConvert.SerializeObject(animal.specialAttributes);

                    command.Parameters.AddWithValue("@age", animal.age);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@animalSpecie", animal.animalSpecie);
                    command.Parameters.AddWithValue("@stock", animal.stock);
                    command.Parameters.AddWithValue("@specialAttributes", json);
                    command.Parameters.AddWithValue("@name", animal.name);

                    connection.Open();
                    command.ExecuteNonQuery();


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
        public static void DeleteAnimal(int id)
        {
            string query = @"
            DELETE FROM Animals
            WHERE Id = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
        public static Dictionary<int, Animal> GetAllAnimals()
        {
            string query = "SELECT Id, name, animalSpecies, age, specialAttributes, stock FROM Animals";

            var result = new Dictionary<int, Animal>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);

                        var animal = new Animal
                        {
                            name = reader["name"].ToString(),
                            animalSpecie = reader["animalSpecies"].ToString(),
                            age = Convert.ToInt32(reader["age"]),
                            stock = Convert.ToInt32(reader["stock"]),
                            specialAttributes = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader["specialAttributes"].ToString() ?? "{}")
                        };

                        result[id] = animal;
                    }
                }
            }

            return result;
        }
         private static bool CheckIfAnimalExists(Animal animal)
        {

            string query = @"
        SELECT COUNT(1) 
        FROM Animals
        WHERE  name = @Name AND animalSpecies = @AnimalSpecies AND age = @Age AND specialAttributes= @specialAttributes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                string json = JsonConvert.SerializeObject(animal.specialAttributes);

                command.Parameters.AddWithValue("@Name", animal.name);
                command.Parameters.AddWithValue("@AnimalSpecies", animal.animalSpecie);
                command.Parameters.AddWithValue("@Age", animal.age);
                command.Parameters.AddWithValue("@specialAttributes", json);

                connection.Open();

                int count = (int)command.ExecuteScalar();

                return count > 0;

            }

        }

    }
}

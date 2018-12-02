using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FinalProject.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        Settings _Settings;
        IConfiguration _config;
        
        public IngredientRepository(IOptions<Settings> settings, IConfiguration config)
        {
            _Settings = settings.Value;
            _config = config;
        }

        public void Insert(int key, int order, string ingredient)
        {
            using (SqlConnection connection = new SqlConnection(_config["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand("Ingredients_Insert", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RecipeID", key);
                    command.Parameters.AddWithValue("@Order", order);
                    command.Parameters.AddWithValue("@Ingredient", ingredient);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<string> GetIngredients(int RecipeID)
        {
            List<string> ingredients = null;
            using (SqlConnection connection = new SqlConnection(_config["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand("Ingredients_GetIngredients", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RecipeID", RecipeID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ingredients = new List<string>();
                        while (reader.Read())
                        {
                            ingredients.Add((string)reader["Ingredient"]);
                        }
                    }
                }
            }
            return ingredients;
        }

        public void Delete(int RecipeID)
        {
            using (SqlConnection connection = new SqlConnection(_config["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand("Ingredients_Delete", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RecipeID", RecipeID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

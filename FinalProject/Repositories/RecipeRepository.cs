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
    public class RecipeRepository : IRecipeRepository
    {
        Settings _Settings;
        IConfiguration _config;

        public RecipeRepository(IOptions<Settings> settings, IConfiguration config)
        {
            _Settings = settings.Value;
            _config = config;
        }

        public virtual int Insert(RecipeModel model)
        {
            int newKey;
            using (SqlConnection connection = new SqlConnection(_config["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand("Recipes_Insert", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", model.UserID);
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Description", model.Description);
                    newKey = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return newKey;
        }

        public virtual RecipeModel GetRecipe(int RecipeID)
        {
            RecipeModel recipe = null;
            using (SqlConnection connection = new SqlConnection(_config["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand("Recipes_GetRecipe", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RecipeID", RecipeID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            recipe = new RecipeModel();
                            recipe.UserID = (string)reader["UserID"];
                            recipe.Name = (string)reader["Name"];
                            recipe.Description = (string)reader["Description"];
                        }
                    }
                }
            }
            return recipe;
        }

        public virtual List<RecipeModel> Search(string SearchString)
        {
            List<RecipeModel> recipes = null;
            using (SqlConnection connection = new SqlConnection(_config["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand("Recipes_Search", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SearchString", SearchString);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        recipes = new List<RecipeModel>();
                        while (reader.Read())
                        {
                            var temp = new RecipeModel();
                            temp.UserID = (string)reader["UserID"];
                            temp.ID = Convert.ToInt32(reader["ID"]);
                            temp.Name = (string)reader["Name"];
                            temp.Description = (string)reader["Description"];
                            recipes.Add(temp);
                        }
                    }
                }
            }
            return recipes;
        }

        public virtual List<RecipeModel> GetList()
        {
            List<RecipeModel> recipes = null;
            using (SqlConnection connection = new SqlConnection(_config["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand("Recipes_GetList", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        recipes = new List<RecipeModel>();
                        while (reader.Read())
                        {
                            var temp = new RecipeModel();
                            temp.UserID = (string)reader["UserID"];
                            temp.ID = Convert.ToInt32(reader["ID"]);
                            temp.Name = (string)reader["Name"];
                            temp.Description = (string)reader["Description"];
                            recipes.Add(temp);
                        }
                    }
                }
            }
            return recipes;
        }

        public virtual void Delete(int RecipeID)
        {
            using (SqlConnection connection = new SqlConnection(_config["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand("Recipes_Delete", connection))
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

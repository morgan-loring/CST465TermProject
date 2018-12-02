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
    public class StepRepository : IStepsRepository
    {
        Settings _Settings;
        IConfiguration _config;

        public StepRepository(IOptions<Settings> settings, IConfiguration config)
        {
            _Settings = settings.Value;
            _config = config;
        }

        public void Insert(int key, int order, string ingredient)
        {
            using (SqlConnection connection = new SqlConnection(_config["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand("Steps_Insert", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RecipeID", key);
                    command.Parameters.AddWithValue("@Order", order);
                    command.Parameters.AddWithValue("@Step", ingredient);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<string> GetSteps(int RecipeID)
        {
            List<string> steps = null;
            using (SqlConnection connection = new SqlConnection(_config["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand("Steps_GetSteps", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RecipeID", RecipeID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        steps = new List<string>();
                        while (reader.Read())
                        {
                            steps.Add((string)reader["Step"]);
                        }
                    }
                }
            }
            return steps;
        }

        public void Delete(int RecipeID)
        {
            using (SqlConnection connection = new SqlConnection(_config["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand("Steps_Delete", connection))
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

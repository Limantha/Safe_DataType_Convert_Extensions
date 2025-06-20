using SafeExtensions.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SafeExtensions.DataAccess
{
    public class DBContext
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        //public User GetUserById(int id)
        //{
        //    var user = new User();
        //    var score = new Score();

        //    using(SqlConnection conn = new SqlConnection(_connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[GetAllUsers]", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter sqlParam = new SqlParameter
        //        {
        //            ParameterName = "@id",
        //            SqlDbType = SqlDbType.Int
        //        };

        //        cmd.Parameters.Add(sqlParam);

        //        conn.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            user = new User
        //            {
        //                UserId = Convert.ToInt32(reader["UserId"]),
        //                Username = Convert.ToString(reader["Username"]),
        //                NoOfSubjects = Convert.ToInt32(reader["NoOfSubjects"]),
        //                Scores = new List<Score>()
        //            };


        //        }

        //        reader.NextResult();

        //        while (reader.Read())
        //        {
        //            score = new Score
        //            {
        //                SubjectId = Convert.ToInt32(reader["SubjectId"]),
        //                Marks = Convert.ToDouble(reader["Marks"])
        //            };

        //            user.Scores.Add(score);
        //        }

        //        return user;
        //    }

        //}

        public User GetUserById(int id)
        {
            try
            {

                var user = new User();

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("[dbo].[GetAllUsers]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            user = new User
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Username = Convert.ToString(reader["UserName"]),
                                NoOfSubjects = Convert.ToInt32(reader["NoOfSubjects"]),
                                Scores = new List<Score>()
                            };
                        }

                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                var score = new Score
                                {
                                    SubjectId = Convert.ToInt32(reader["SubjectId"]),
                                    Marks = Convert.ToDouble(reader["Marks"])
                                };

                                user.Scores.Add(score);
                            }
                        }                      


                    }
                }

                return user;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
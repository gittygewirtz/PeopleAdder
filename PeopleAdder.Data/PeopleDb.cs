using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PeopleAdder.Data
{
    public class PeopleDb
    {
        private string _conStr;
        public PeopleDb(string conStr)
        {
            _conStr = conStr;
        }

        public void AddPerson(Person p)
        {
            using (SqlConnection conn = new SqlConnection(_conStr))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO People (FirstName, LastName, Age)
                                    VALUES (@firstName, @lastName, @age)";
                cmd.Parameters.AddWithValue("@firstName", p.FirstName);
                cmd.Parameters.AddWithValue("@lastName", p.LastName);
                cmd.Parameters.AddWithValue("@age", p.Age);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Person> GetPeople()
        {
            using (SqlConnection conn = new SqlConnection(_conStr))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT * FROM People";
                List<Person> result = new List<Person>();
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Person
                    {
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Age = (int)reader["Age"]
                    });
                }
                return result;
            }
        }
    }
}

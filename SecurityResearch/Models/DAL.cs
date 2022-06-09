using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SecurityResearch.Models
{
    public class DAL
    {
        private readonly string connectionString = "Server=studmysql01.fhict.local;Uid=dbi431433;Database=dbi431433;Pwd=Fontys1234;SSL Mode=None";

        public void AddData(string forename, string lastname, string gender, int age)
        {
            using MySqlConnection con = new(connectionString);
            con.Open();

            MySqlCommand cmd = new($"INSERT INTO `research` (`forename`, `lastname`, `gender`, `age`) VALUES (?forename, ?lastname, ?gender, ?age) ", con);
                cmd.Parameters.AddWithValue("?forename", forename);
                cmd.Parameters.AddWithValue("?lastname", lastname);
                cmd.Parameters.AddWithValue("?gender", gender);
                cmd.Parameters.AddWithValue("?age", age);

            MySqlDataReader reader = cmd.ExecuteReader();
        }

        public void UpdateData(string forename, string lastname, string gender, int age, int id)
        {
            using MySqlConnection con = new(connectionString);
            con.Open();

            MySqlCommand cmd = new($"UPDATE `research` SET `forename`=?forename,`lastname`=?lastname,`gender`=?gender,`age`=?age WHERE `id`=?id", con);
            cmd.Parameters.AddWithValue("?forename", forename);
            cmd.Parameters.AddWithValue("?lastname", lastname);
            cmd.Parameters.AddWithValue("?gender", gender);
            cmd.Parameters.AddWithValue("?age", age);
            cmd.Parameters.AddWithValue("?id", id);

            MySqlDataReader reader = cmd.ExecuteReader();
        }

        public void DeleteData(int id)
        {
            using MySqlConnection con = new(connectionString);
            con.Open();

            MySqlCommand cmd = new($"DELETE FROM `research` WHERE `id` =?id", con);
            cmd.Parameters.AddWithValue("?id", id);

            MySqlDataReader reader = cmd.ExecuteReader();
        }

        public List<Data> GetData()
        {
            List<Data> data = new();

            using MySqlConnection con = new(connectionString);
            con.Open();

            MySqlCommand cmd = new($"SELECT * FROM `research`", con);
            MySqlDataReader reader =  cmd.ExecuteReader();
            while (reader.Read())
            {
                Data datas = new();
                datas.Forename = reader["forename"].ToString();
                datas.Lastname = reader["lastname"].ToString();
                datas.Gender = reader["gender"].ToString();
                datas.Age = int.Parse(reader["age"].ToString());
                datas.Id = int.Parse(reader["id"].ToString());
                data.Add(datas);
            }
            reader.Close();

            return data;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Stylist
    {
        public int id { get; set; }

        [Required]
        public string first_name { get; set; }
        //public string last_name { get; set; }

        public Stylist(string first_name, int id = 0)
        {
            this.first_name = first_name;
            //this.last_name = last_name;
            this.id = id;
        }

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist stylist = (Stylist)otherStylist;
                bool nameSame = (this.first_name == stylist.first_name);   //&& (this.last_name == stylist.last_name));
                return (nameSame);
            }
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist>() { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int StylistId = rdr.GetInt32(0);
                string StylistFirstName = rdr.GetString(1);
                //string StylistLastName = rdr.GetString(2);
                Stylist newStylist = new Stylist(StylistFirstName);
                newStylist.id = StylistId;
                allStylists.Add(newStylist);
            }
            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylists;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists;";
            cmd.ExecuteNonQuery();
            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (first_name) VALUES (@StylistFirstName);";
            cmd.Parameters.AddWithValue("@StylistFirstName", this.first_name);
            //cmd.CommandText = @"INSERT INTO stylists (first_name) VALUES (@StylistLastName);";
            //cmd.Parameters.AddWithValue("@StylistLastName", this.last_name);
            cmd.ExecuteNonQuery();
            this.id = (int)cmd.LastInsertedId;
            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Update()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE stylists SET name = @StylistFirstName WHERE id = @StylistId;";
            cmd.Parameters.AddWithValue("@StylistFirstName", this.first_name);
            //cmd.Parameters.AddWithValue("@StylistLastName", this.last_name);
            cmd.Parameters.AddWithValue("@StylistId", this.id);
            cmd.ExecuteNonQuery();
            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Stylist Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE id = @searchId;";
            cmd.Parameters.AddWithValue("@searchId", id);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int stylistId = 0;
            string stylistName = "";

            while (rdr.Read())
            {
                stylistId = rdr.GetInt32(0);
                stylistName = rdr.GetString(1);
                //stylistLastName = rdr.GetString(2);
            }
            Stylist foundStylist = new Stylist(stylistName, stylistId);
            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }
            return foundStylist;
        }
    }
}
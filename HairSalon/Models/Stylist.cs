using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Stylist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StylistNum { get; set; }

        public Stylist(string Name, string StylistNum, int Id = 0)
        {
            this.Id = Id;
            this.Name = Name;
            this.StylistNum = StylistNum;
        }

        public void AddClient(Client client)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients_stylists (client_id, stylist_id) VALUES (@ClientId, @StylistId);";

            MySqlParameter client_id = new MySqlParameter();
            client_id.ParameterName = "@ClientId";
            client_id.Value = client.Id;
            cmd.Parameters.Add(client_id);

            MySqlParameter stylist_id = new MySqlParameter();
            stylist_id.ParameterName = "@StylistId";
            stylist_id.Value = Id;
            cmd.Parameters.Add(stylist_id);

            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public List<Client> GetClients()  // need to return list of clients
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"Select clients.* FROM stylists
                                JOIN clients_stylists ON (stylists.id = clients_stylists.stylist_id)
                                JOIN clients ON (clients_stylists.client_id = clients.id)
                                WHERE stylists.id = @stylistId;";

            MySqlParameter stylistIDParameter = new MySqlParameter();
            stylistIDParameter.ParameterName = "@stylistId";
            stylistIDParameter.Value = Id;
            cmd.Parameters.Add(stylistIDParameter);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            List<Client> clients = new List<Client> { }; // for all entries in DB add a new client object

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                DateTime enroll = rdr.GetDateTime(2);
                Client newClient = new Client(name, enroll, id);
                clients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return clients;

        }

        public static Stylist Find(int id)
        {
            {
                MySqlConnection conn = DB.Connection();
                conn.Open();

                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"SELECT * FROM stylists WHERE id = @thisId;";

                MySqlParameter thisId = new MySqlParameter();
                thisId.ParameterName = "@thisId";
                thisId.Value = id;
                cmd.Parameters.Add(thisId);

                var rdr = cmd.ExecuteReader() as MySqlDataReader;

                int stylistsId = 0;
                string stylistsName = "";
                string stylistNum = "";

                while (rdr.Read())
                {
                    stylistsId = rdr.GetInt32(0);
                    stylistsName = rdr.GetString(1);
                    stylistNum = rdr.GetString(2);
                }

                Stylist foundStylist = new Stylist(stylistsName, stylistNum, stylistsId);

                conn.Close();
                if (conn != null)
                {
                    conn.Dispose();
                }

                return foundStylist;
            }
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (name, stylist_code) VALUES (@stylistName, @stylistCode);";

            MySqlParameter stylistName = new MySqlParameter();
            stylistName.ParameterName = "@stylistName";
            stylistName.Value = this.Name;
            cmd.Parameters.Add(stylistName);

            MySqlParameter stylistCode = new MySqlParameter();
            stylistCode.ParameterName = "@stylistCode";
            stylistCode.Value = this.StylistNum;
            cmd.Parameters.Add(stylistCode);

            cmd.ExecuteNonQuery();
            Id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                string stylistNum = rdr.GetString(2);

                Stylist newStylist = new Stylist(name, stylistNum, id);
                allStylists.Add(newStylist);
            }

            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }

            return allStylists;
        }

        public void Delete()    // delete one stylist at a time
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists WHERE id = @StylistId; DELETE FROM clients_stylists WHERE stylist_id = @StylistId;";

            MySqlParameter cityIdParameter = new MySqlParameter();
            cityIdParameter.ParameterName = "@StylistId";
            cityIdParameter.Value = this.Id;
            cmd.Parameters.Add(cityIdParameter);

            cmd.ExecuteNonQuery();
            if (conn != null)
            {
                conn.Close();
            }
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

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist)otherStylist;
                bool idEquality = (this.Id == newStylist.Id);
                bool stylistNameEquality = (this.Name == newStylist.Name);

                return (idEquality && stylistNameEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}

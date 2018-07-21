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

        public Stylist(string Name, int Id)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public void AddClient(Client newClient)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists_clients (client_id, stylist_id) VALUES (@ClientId, @StylistId);";

            MySqlParameter client_id = new MySqlParameter();
            client_id.ParameterName = "@ClientId";
            client_id.Value = newClient.Id;
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


        public List<Client> GetClients()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT clients.* FROM stylists
                                JOIN stylists_clients ON (stylists.id = stylists_clients.stylist_id)
                                JOIN clients ON (stylists_clients.client_id = clients.id)
                                WHERE stylists.id = @StylistId;";

            MySqlParameter stylistIdParameter = new MySqlParameter();
            stylistIdParameter.ParameterName = "@StylistId";
            stylistIdParameter.Value = Id;
            cmd.Parameters.Add(stylistIdParameter);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            List<Client> clients = new List<Client> { };

            while (rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);

                Client newClient = new Client(clientName, clientId);
                clients.Add(newClient);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return clients;
        }

        public List<Client> GetAllClients()
        {
            return Client.GetAll();
        }

        public void RemoveClient(Client existingClient)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists_clients WHERE stylist_id = @searchId AND client_id = @ClientId;";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = Id;
            cmd.Parameters.Add(searchId);

            MySqlParameter client_id = new MySqlParameter();
            client_id.ParameterName = "@ClientId";
            client_id.Value = existingClient.Id;
            cmd.Parameters.Add(client_id);

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
            cmd.CommandText = @"SELECT * FROM stylists WHERE id = @thisId;";

            MySqlParameter thisId = new MySqlParameter();
            thisId.ParameterName = "@thisId";
            thisId.Value = id;
            cmd.Parameters.Add(thisId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int stylistId = 0;
            string stylistName = "";

            while (rdr.Read())
            {
                stylistId = rdr.GetInt32(0);
                stylistName = rdr.GetString(1);
            }

            Stylist foundStylist = new Stylist(stylistName, stylistId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return foundStylist;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (name) VALUES (@stylistName);";

            MySqlParameter stylistName = new MySqlParameter();
            stylistName.ParameterName = "@stylistName";
            stylistName.Value = this.Name;
            cmd.Parameters.Add(stylistName);

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
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                Stylist newStylist = new Stylist(stylistName, stylistId);
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

        public override int GetHashCode() // get rid of that annoying warning
        {
            return this.Name.GetHashCode();
        }
    }
}

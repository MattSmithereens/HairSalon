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

        public Stylist(string name)
        {
            Name = name;
        }

        public void AddClient(Client newClient)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients_stylists (client_id, stylist_id) VALUES (@ClientId, @StylistId);";

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
                                JOIN clients_stylists ON (stylists.id = clients_stylists.stylist_id)
                                JOIN clients ON (clients_stylists.client_id = clients.id)
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
            cmd.CommandText = @"DELETE FROM clients_stylists WHERE stylist_id = @searchId AND client_id = @ClientId;";

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

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
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

        public void AddSpecialty(Specialty newSpecialty)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialties_stylists (specialty_id, stylist_id) VALUES (@SpecialtyId, @StylistId);";

            MySqlParameter specialty_id = new MySqlParameter();
            specialty_id.ParameterName = "@SpecialtyId";
            specialty_id.Value = newSpecialty.Id;
            cmd.Parameters.Add(specialty_id);

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

        public void Edit(string newName)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE stylists SET name = @newName WHERE id = @searchId;";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = Id;
            cmd.Parameters.Add(searchId);

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@newName";
            name.Value = newName;
            cmd.Parameters.Add(name);

            cmd.ExecuteNonQuery();
            this.Name = newName;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public List<Specialty> GetSpecialties()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT specialties.* FROM stylists
                                JOIN specialties_stylists ON (stylists.id = specialties_stylists.stylist_id)
                                JOIN specialties ON (specialties_stylists.specialty_id = specialties.id)
                                WHERE stylists.id = @StylistId;";

            MySqlParameter stylistIdParameter = new MySqlParameter();
            stylistIdParameter.ParameterName = "@StylistId";
            stylistIdParameter.Value = Id;
            cmd.Parameters.Add(stylistIdParameter);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            List<Specialty> specialties = new List<Specialty> { };

            while (rdr.Read())
            {
                int specialtyId = rdr.GetInt32(0);
                string specialtyName = rdr.GetString(1);

                Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
                specialties.Add(newSpecialty);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return specialties;
        }

        public void RemoveSpecialty(Specialty existingSpecialty)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialties_stylists WHERE stylist_id = @searchId AND specialty_id = @SpecialtyId;";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = Id;
            cmd.Parameters.Add(searchId);

            MySqlParameter specialty_id = new MySqlParameter();
            specialty_id.ParameterName = "@SpecialtyId";
            specialty_id.Value = existingSpecialty.Id;
            cmd.Parameters.Add(specialty_id);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}

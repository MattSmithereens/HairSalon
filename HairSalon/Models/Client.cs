using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Client

    {
        private string v;

        public int Id { get; set; }
        public string Name { get; set; }
        public string ClientContact { get; set; }
        public int StylistID { get; set; }

        public Client(string Name, string ClientContact, int StylistID, int Id = 0)
        {
            this.Id = Id;
            this.Name = Name;
            this.ClientContact = ClientContact;
            this.StylistID = StylistID;
        }

        public Client(string v)
        {
            this.v = v;
        }

        public void AddStylist(Stylist stylist)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO client_stylists (student_id, stylist_id) VALUES (@StudentId, @StylistId);";

            MySqlParameter student_id = new MySqlParameter();
            student_id.ParameterName = "@StudentId";
            student_id.Value = Id;
            cmd.Parameters.Add(student_id);

            MySqlParameter stylist_id = new MySqlParameter();
            stylist_id.ParameterName = "@StylistId";
            stylist_id.Value = stylist.Id;
            cmd.Parameters.Add(stylist_id);

            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        //public List<Client> GetAllClients()
        //{
        //    return Client.GetAll();
        //}




    }
}

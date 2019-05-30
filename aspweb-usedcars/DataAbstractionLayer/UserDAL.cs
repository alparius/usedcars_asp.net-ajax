using aspweb_usedcars.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspweb_usedcars.DataAbstractionLayer
{
    public class UserDAL
    {

        public User GetUser(string username)
        {
            MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "server=localhost;port=3308;uid=dealer;pwd=password;database=web_php_cars";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from users where username='" + username + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                myreader.Read();
                User user = new User();
                user.username = myreader.GetString("username");
                user.password = myreader.GetString("password");

                myreader.Close();
                conn.Close();
                return user;   
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                return null;
            }
        }

        public void AddUser(string username, string password)
        {
            MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "server=localhost;port=3308;uid=dealer;pwd=password;database=web_php_cars";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into users (username, password) values ('" + username + "', '" + password + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
            }
        }
    }
}
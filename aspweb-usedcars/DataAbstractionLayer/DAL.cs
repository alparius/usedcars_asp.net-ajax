using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using aspweb_usedcars.Models;
using MySql.Data.MySqlClient;

namespace aspweb_usedcars.DataAbstractionLayer

{
    public class DAL
    {
        public List<Car> GetCarsFromCategory(string category)
        {
            MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;port=3308;uid=dealer;pwd=password;database=web_php_cars";
            List<Car> clist = new List<Car>();
            try
            {
                System.Diagnostics.Debug.WriteLine("about to connect");
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                System.Diagnostics.Debug.WriteLine("connected");

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from cars where category like '" + category + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();
                System.Diagnostics.Debug.WriteLine("sql executed");

                while (myreader.Read())
                {
                    Car car = new Car();
                    car.id = myreader.GetInt32("id");
                    System.Diagnostics.Debug.WriteLine(car.id);
                    car.model = myreader.GetString("model");
                    car.engine_power = myreader.GetInt32("engine_power");
                    car.fuel = myreader.GetString("fuel");
                    car.year = myreader.GetInt32("year");
                    car.color = myreader.GetString("color");
                    car.price = myreader.GetInt32("price");
                    car.category = myreader.GetString("category");
                    clist.Add(car);
                }
                myreader.Close();
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
            }
            System.Diagnostics.Debug.WriteLine("returning cars");
            return clist;
        }

        public Car GetCar(int id)
        {
            MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;port=3308;uid=dealer;pwd=password;database=web_php_cars";
            try
            {
                System.Diagnostics.Debug.WriteLine("about to connect");
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                System.Diagnostics.Debug.WriteLine("connected");

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from cars where id='" + id + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();
                System.Diagnostics.Debug.WriteLine("sql executed");

                myreader.Read();
                Car car = new Car();
                car.id = myreader.GetInt32("id");
                car.model = myreader.GetString("model");
                car.engine_power = myreader.GetInt32("engine_power");
                car.fuel = myreader.GetString("fuel");
                car.year = myreader.GetInt32("year");
                car.color = myreader.GetString("color");
                car.price = myreader.GetInt32("price");
                car.category = myreader.GetString("category");
                myreader.Close();
                conn.Close();
                return car;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                return null;
            }
        }

        public void AddCar(Car car)
        {
            MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;port=3308;uid=dealer;pwd=password;database=web_php_cars";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into cars (category, model, engine_power, fuel, year, color, price) values" 
                    + "('" + car.category + "', '"+ car.model + "', '" + car.engine_power + "', '" + car.fuel + "', '" + car.year + "', '" + car.color + "', '" + car.price + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
            }
        }

        public void UpdateCar(Car car)
        {
            MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;port=3308;uid=dealer;pwd=password;database=web_php_cars";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update cars set model='" + car.model + "', engine_power=" + car.engine_power + ", fuel='" + car.fuel + "', year=" + car.year + ", color='" + car.color + "', price=" + car.price + " where id=" + car.id;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
            }
        }

        public void DeleteCar(int id)
        {
            MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;port=3308;uid=dealer;pwd=password;database=web_php_cars";
            List<Car> clist = new List<Car>();
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                System.Diagnostics.Debug.WriteLine("delete connection");
                cmd.CommandText = "delete from cars where id='" + id + "'";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("delete executed");

                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
            }
        }
    }
}
        
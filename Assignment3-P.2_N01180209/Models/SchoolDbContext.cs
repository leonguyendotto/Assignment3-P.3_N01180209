using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Assignment3_P._2_N01180209.Models
{
    public class SchoolDbContext
    {
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "school"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        //ConnectionString is a series of credentials used to connect to the database 


        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }
        //This is the way how we can use to get to the database
        /// <summary>
        /// Returns a connection to the school database
        /// </summary>
        /// <example>
        /// MySqlConnection Conn = School.AccessDatabase()
        /// </example>
        /// <returns>A MySqlConnection Object</returns>
        public MySqlConnection AccessDatabase ()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
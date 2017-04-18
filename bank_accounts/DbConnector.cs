using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace bank_accounts
{
        public static class SessionExtensions
        {
            // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
            public static void SetObjectAsJson(this ISession session, string key, object value)
            {
                // This helper function simply serializes theobject to JSON and stores it as a string in session
                session.SetString(key, JsonConvert.SerializeObject(value));
            }
            
            // generic type T is a stand-in indicating that we need to specify the type on retrieval
            public static T GetObjectFromJson<T>(this ISession session, string key)
            {
                string value = session.GetString(key);
                // Upone retrieval the object is deserialized based on the type we specified
                return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
            }
        }
    public class DbConnector
    {
        private readonly IOptions<MySqlOptions> MySqlConfig;
 
        public DbConnector(IOptions<MySqlOptions> config)
        {
            MySqlConfig = config;
        }
        internal IDbConnection Connection {
            get {
                return new MySqlConnection(MySqlConfig.Value.ConnectionString);
            }
        }
        
        //This method runs a query and stores the response in a list of dictionary records
        public List<Dictionary<string, object>> Query(string queryString)
        {
            using(IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                   command.CommandText = queryString;
                   dbConnection.Open();
                   var result = new List<Dictionary<string, object>>();
                   using(IDataReader rdr = command.ExecuteReader())
                   {
                      while(rdr.Read())
                      {
                          var dict = new Dictionary<string, object>();
                          for( int i = 0; i < rdr.FieldCount; i++ ) {
                              dict.Add(rdr.GetName(i), rdr.GetValue(i));
                          }
                          result.Add(dict);
                      }
                   }
                   return result;
                }
            }
        }
        //This method run a query and returns no values
        public void Execute(string queryString)
        {
            using (IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                    command.CommandText = queryString;
                    dbConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TestWebsite.Models
{
    public class AmiiboListContext
    {
    public string ConnectionString { get; set; }

    public AmiiboListContext(string connectionString)
    {
      this.ConnectionString = connectionString;
    }

    private MySqlConnection GetConnection()
    {
      return new MySqlConnection(ConnectionString);
    }

    public List<Amiibo> GetAllAmiibos()
    {
      List<Amiibo> amiiboList = new List<Amiibo>();

      using (MySqlConnection conn = GetConnection())
      {
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("SELECT * FROM Amiibos order by AmiiboType asc, WaveNum asc", conn);
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            amiiboList.Add(new Amiibo()
            {
              AmiiboName = reader.GetString("AmiiboName"),
              AmiiboType = reader.GetString("AmiiboType"),
              WaveNum = reader.GetInt32("WaveNum"),
              Exclusive = reader.GetString("Exclusive"),
              Obtained= reader.GetString("Obtained"),
              DateAddedToDB = reader.GetDateTime("DateAddedToDB")
            });
          }
        }
      }

      return amiiboList;
    }
  }
}
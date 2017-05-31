using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace TestWebsite.Models
{
    public class GuestContext
    {
    public string ConnectionString { get; set; }

    public GuestContext(string connectionString)
    {
      this.ConnectionString = connectionString;
    }

    private MySqlConnection GetConnection()
    {
      return new MySqlConnection(ConnectionString);
    }

    public List<Guest> GetAllGuests()
    {
      List<Guest> guestList = new List<Guest>();

      using (MySqlConnection conn = GetConnection())
      {
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("select * from Guests order by TimeDate desc", conn);

        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
          while(reader.Read())
          {
            guestList.Add(new Guest()
            {
              Name = reader.GetString("Name"),
              Comment = reader.GetString("Comment"),
              TimeDate = reader.GetDateTime("TimeDate")
            });
          }
        }
      }

        return guestList;
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace TestWebsite.Models
{
    public class VideoGameListContext
    {
    public string ConnectionString { get; set; }

    public VideoGameListContext(string connectionString)
    {
      this.ConnectionString = connectionString;
    }

    private MySqlConnection GetConnection()
    {
      return new MySqlConnection(ConnectionString);
    }

    public List<VideoGame> GetAllVideoGames(VideoGameTables t)
    {
      List<VideoGame> vgList = new List<VideoGame>();
      string table = t.ToString(); //TODO: Make sure this does what I think it does

      using (MySqlConnection conn = GetConnection())
      {
        conn.Open();
        MySqlCommand cmd = new MySqlCommand($"select * from {table} order by GamePlatform asc, GameName asc", conn);

        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            vgList.Add(new VideoGame()
            {
              GameName = reader.GetString("GameName"),
              GamePlatform = reader.GetString("GamePlatform"),
              CompletionStatus = reader.GetString("CompletionStatus"),
              DateAddedToDB = reader.GetDateTime("DateAddedToDB")
            });
          }
        }
      }

      return vgList;
    }
  }
}
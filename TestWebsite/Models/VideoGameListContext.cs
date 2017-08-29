using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TestWebsite.Models
{
    public class VideoGameListContext : System.IDisposable
  {
    #region Constants And Variables
    public string ConnectionString { get; }
    public MySqlConnection mySQLConnection { get; private set; }
    private bool isDisposed = false;
    #endregion

    #region Constructor
    public VideoGameListContext(string connectionString)
    {
      this.ConnectionString = connectionString;
    }
    #endregion

    #region Methods
    private MySqlConnection GetConnection()
    {
      if (mySQLConnection == null)
      {
        mySQLConnection = new MySqlConnection(ConnectionString);
      }
      else if(mySQLConnection?.State == System.Data.ConnectionState.Broken)
      {
        mySQLConnection.Close();
      }
      
      return mySQLConnection;
    }

    public List<VideoGame> GetAllVideoGames(VideoGameTables t)
    {
      List<VideoGame> vgList = new List<VideoGame>();
      string table = System.Enum.GetName(typeof(VideoGameTables), t);

      try
      {
        using (MySqlConnection conn = GetConnection())
        {
          conn.Open();
          MySqlCommand cmd = new MySqlCommand($"SELECT GameName, GamePlatform, CompletionStatus, DateAddedToDB " +
                                              $"FROM {table} " +
                                              $"ORDER BY GamePlatform ASC, GameName ASC", conn);

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
      }
      catch (System.Exception)
      {
        System.Console.Out.WriteLine("Could not retrieve the VideoGameList: Cannot connect to MySQL Database!");
      }

      return vgList;
    }
    #endregion

    #region Dispose And Destructor
    public void Dispose()
    {
      if (isDisposed)
      {
        if (mySQLConnection?.State != System.Data.ConnectionState.Closed)
        {
          mySQLConnection.Close();
        }
        mySQLConnection?.Dispose();
        mySQLConnection = null;

        isDisposed = true;
      }
    }

    ~VideoGameListContext()
    {
      Dispose();
    }
    #endregion
  }
}

using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TestWebsite.Models
{
    public class AmiiboListContext
  {
    #region Constants And Variables
    public string ConnectionString { get; }
    public MySqlConnection mySQLConnection { get; private set; }
    private bool isDisposed = false;
    #endregion

    #region Constructor
    public AmiiboListContext(string connectionString)
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
      else if (mySQLConnection?.State == System.Data.ConnectionState.Broken)
      {
        mySQLConnection.Close();
      }


      return mySQLConnection;
    }

    public List<Amiibo> GetAllAmiibos()
    {
      List<Amiibo> amiiboList = new List<Amiibo>();

      try
      {
        using (MySqlConnection conn = GetConnection())
        {
          conn.Open();
          MySqlCommand cmd = new MySqlCommand("SELECT AmiiboName, AmiiboType, WaveNum, Exclusive, Obtained, DateAddedToDB " +
                                              "FROM Amiibos " +
                                              "ORDER BY AmiiboType ASC, WaveNum ASC", conn);
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
                Obtained = reader.GetString("Obtained"),
                DateAddedToDB = reader.GetDateTime("DateAddedToDB")
              });
            }
          }
        }
      }
      catch (System.Exception)
      {
        System.Console.Out.WriteLine("Could not retrieve the AmiiboList: Cannot connect to MySQL Database!");
      }

      return amiiboList;
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

    ~AmiiboListContext()
    {
      Dispose();
    }
    #endregion
  }
}
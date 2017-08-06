using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TestWebsite.Models
{
    public class GuestContext : System.IDisposable
    {
    #region Constants And Variables
    public string ConnectionString { get; }
    public MySqlConnection mySQLConnection { get; private set; }
    private bool isDisposed = false;
    #endregion

    #region Constructor
    public GuestContext(string connectionString)
    {
      this.ConnectionString = connectionString;
    }
    #endregion

    #region Methods
    private MySqlConnection GetConnection()
    {
        if(mySQLConnection == null)
        {
          mySQLConnection = new MySqlConnection(ConnectionString);
        }
        else if (mySQLConnection?.State == System.Data.ConnectionState.Broken)
        {
          mySQLConnection.Close();
        }

      return mySQLConnection;
    }

    public List<Guest> GetAllGuestsCommentsAndDates()
    {
      List<Guest> guestList = new List<Guest>();

      try
      {
        using (MySqlConnection conn = GetConnection())
        {
          conn.Open();
          MySqlCommand cmd = new MySqlCommand("SELECT Name, Comment, TimeDate " +
                                              "FROM Guests " +
                                              "ORDER BY TimeDate DESC", conn);

          using (MySqlDataReader reader = cmd.ExecuteReader())
          {
            while (reader.Read())
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
      }
      catch(System.Exception)
      {
        System.Console.Out.WriteLine("Could not retrieve the GuestList: Cannot connect to MySQL Database!");
      }

        return guestList;
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

    ~GuestContext()
    {
      Dispose();
    }
    #endregion
  }
}
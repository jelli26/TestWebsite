using System;

namespace TestWebsite.Models
{
  public class Amiibo
  {
    private AmiiboListContext context;
    public string AmiiboName { get; set; }
    public string AmiiboType { get; set; }
    public int WaveNum { get; set; }
    public string Exclusive { get; set; }
    public string Obtained { get; set; }
    public DateTime DateAddedToDB { get; set; }
  }
}

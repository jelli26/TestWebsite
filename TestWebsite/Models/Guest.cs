using System;

namespace TestWebsite.Models
{
  public class Guest
  {
    private GuestContext context;
    public string Name { get; set; }
    public string Comment { get; set; }
    public DateTime TimeDate { get; set; }
  }
}

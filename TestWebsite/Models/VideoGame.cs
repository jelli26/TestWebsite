using System;

namespace TestWebsite.Models
{
  public class VideoGame
  {
    private VideoGameListContext context;
    public string GameName { get; set; }
    public string GamePlatform { get; set; }
    public string CompletionStatus { get; set; }
    public DateTime DateAddedToDB { get; set; }
  }
}

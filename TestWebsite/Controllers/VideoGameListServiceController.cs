using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TestWebsite.Controllers
{
  [Route("api/[controller]")]//Forces only using the Get method.
  public class VideoGameListServiceController : Controller
    {
      [HttpGet]
      public JsonResult Get()
      {
        Models.VideoGameListContext context = HttpContext.RequestServices.GetService(typeof(Models.VideoGameListContext)) as Models.VideoGameListContext;
        List<Models.VideoGame> gameList = new List<Models.VideoGame>();

        //gameList.AddRange(context.GetAllVideoGames(Models.VideoGameTables.Nintendo));
        //gameList.AddRange(context.GetAllVideoGames(Models.VideoGameTables.Sony));
        //gameList.AddRange(context.GetAllVideoGames(Models.VideoGameTables.Microsoft));
        //gameList.AddRange(context.GetAllVideoGames(Models.VideoGameTables.PC));

        foreach(Models.VideoGameTables table in Enum.GetValues(typeof(Models.VideoGameTables)))
        {
          gameList.AddRange(context.GetAllVideoGames(table));
        }

      JsonResult result = new JsonResult(gameList);

      return result;
      }
  }
}

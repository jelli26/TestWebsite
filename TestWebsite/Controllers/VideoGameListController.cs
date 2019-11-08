using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestWebsite.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestWebsite.Controllers
{
  public class VideoGameListController : Controller
  {
    // GET: /<controller>/
    public IActionResult Index()
    {
      Models.VideoGameListContext context = HttpContext.RequestServices.GetService(typeof(Models.VideoGameListContext)) as Models.VideoGameListContext;

      List<VideoGame> games = context.GetAllVideoGames(Models.VideoGameTables.Nintendo);

      ViewResult result = View(games);

      return result;
    }
  }
}

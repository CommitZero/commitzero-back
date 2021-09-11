using Microsoft.AspNetCore.Mvc;
using CommitZeroBack.Models;
using CommitZeroBack.Data;

namespace CommitZeroBack.Controllers {
    public class ContentController : Controller
    {
        [HttpPost]
        public IActionResult CreatePost([FromBody] CreatePostRequest RequestRaw) {
            if(Request.Headers["CommitZero-Key"] == Globals.CommitZeroKey) {
                return Content(NewPost.Execute(Request.Headers["Authorization"], RequestRaw.title,
                RequestRaw.cathegory, RequestRaw.description, RequestRaw.content));
            }
            else {
                return Unauthorized();
            }
        }
    }
}
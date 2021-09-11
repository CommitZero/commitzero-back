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
                RequestRaw.cathegory, RequestRaw.description, RequestRaw.content, RequestRaw.miniature));
            }
            else {
                return Unauthorized();
            }
        }

        [HttpGet]
        public IActionResult Posts(int quantity) {
            if(Request.Headers["CommitZero-Key"] == Globals.CommitZeroKey) {
                return Content(GetPosts.Execute(quantity));
            }
            else {
                return Unauthorized();
            }
        }
    }
}
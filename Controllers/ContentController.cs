using Microsoft.AspNetCore.Mvc;

namespace CommitZeroBack.Controllers {
    public class ContentController : Controller
    {
        [HttpPost]
        public IActionResult CreatePost([FromBody] CreatePostRequest RequestRaw) {

        }
    }
}
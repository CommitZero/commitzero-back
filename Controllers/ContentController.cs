using Microsoft.AspNetCore.Mvc;
using CommitZeroBack.Models;
using CommitZeroBack.Data;
using System;

namespace CommitZeroBack.Controllers {
    public class contentController : Controller
    {
        [HttpDelete]
        public IActionResult deletePost([FromBody] DeletePostRequest RequestRaw) {
            if(Request.Headers["API_KEY"] == ConfigManager.api_key()) {
                return Content(DeletePost.Execute(Request.Headers["Authorization"], RequestRaw.id));
            }
            else {
                return Unauthorized();
            }
        }
        [HttpPost]
        public IActionResult createPost([FromBody] CreatePostRequest RequestRaw) {
            if(Request.Headers["API_KEY"] == ConfigManager.api_key()) {
                return Content(NewPost.Execute(Request.Headers["Authorization"], RequestRaw.title,
                RequestRaw.cathegory, RequestRaw.description, RequestRaw.content, RequestRaw.image_url));
            }
            else {
                return Unauthorized();
            }
        }

        [HttpGet]
        public IActionResult posts(int id, int quantity) {
            if(Request.Headers["API_KEY"] == ConfigManager.api_key()) {
                if(id != 0) return Content(DetailedPost.Execute(id));
                if(quantity != 0) return Content(GetPosts.Execute(quantity));
                return Content(GetPosts.Execute(9999));
            }
            else {
                return Unauthorized();//AA
            }
        }

        [HttpGet]
        public IActionResult postSearch(string search, int quantity) {
            if(Request.Headers["API_KEY"] == ConfigManager.api_key()) {
                if(quantity != 0 && search != "") return Content(PostsBySearch.Execute(search, quantity));
            }
            else {
                return Unauthorized();
            }

            return BadRequest();
        }
    }
}
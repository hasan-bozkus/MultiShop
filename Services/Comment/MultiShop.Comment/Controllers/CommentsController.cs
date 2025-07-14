using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _context.UserComments.ToListAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(UserComment userComment)
        {
            await _context.UserComments.AddAsync(userComment);
            await _context.SaveChangesAsync();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var value = await _context.UserComments.FindAsync(id);
            _context.UserComments.Remove(value);
            await _context.SaveChangesAsync();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var value = await _context.UserComments.FindAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UserComment userComment)
        {
            _context.UserComments.Update(userComment);
            await _context.SaveChangesAsync();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpGet("CommentListByProductId/{id}")]
        public async Task<IActionResult> CommentListByProductId(string id)
        {
            var values = await _context.UserComments.Where(x => x.ProductID == id).ToListAsync();
            return Ok(values);
        }

        [HttpGet("GetActiveCommentCount")]
        public async Task<IActionResult> GetActiveCommentCount()
        {
            var count = await _context.UserComments.CountAsync(x => x.Status == true);
            return Ok(count);
        }

        [HttpGet("GetPassiveCommentCount")]
        public async Task<IActionResult> GetPassiveCommentCount()
        {
            var count = await _context.UserComments.CountAsync(x => x.Status == false);
            return Ok(count);
        }

        [HttpGet("GetTotalCommentCount")]
        public async Task<IActionResult> GetTotalCommentCount()
        {
            var count = await _context.UserComments.CountAsync();
            return Ok(count);
        }
    }
}

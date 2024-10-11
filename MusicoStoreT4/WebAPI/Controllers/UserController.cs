using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    public class UserController : Controller
    {
        //private readonly MyDBContext _dBContext;

        //public UserController(MyDBContext dBContext)
        //{
        //    _dBContext = dBContext;
        //}

        //[HttpGet]
        //[Route("[controller]")]
        //public async Task<IActionResult> Fetch()
        //{
        //    var users = await _dBContext.Users.ToListAsync();
        //    return Ok(users.Select(a => new
        //    {
        //        UserId = a.Id,
        //        UserUsername = a.Username,
        //        UserDateOfCreation = a.Created,
        //    }));
        //}

        //[HttpGet]
        //[Route("[controller]/detail")]
        //public async Task<IActionResult> FetchWithPostsAndComments()
        //{
        //    var users = await _dBContext.Users
        //        .Include(a => a.Posts)
        //        .Include(a => a.Comments)
        //        .ToListAsync();

        //    return Ok(users.Select(a => new
        //    {
        //        UserId = a.Id,
        //        UserUsername = a.Username,
        //        UserDateOfCreation = a.Created,
        //        Posts = a.Posts?.Select(post => new
        //        {
        //            PostId = post.Id,
        //            PostCreated = post.Created,
        //            PostContent = post.Content,
        //        }),
        //        Comments = a.Comments?.Select(comment => new
        //        {
        //            CommentId = comment.Id,
        //            CommentPostId = comment.PostId,
        //            CommentCreated = comment.Created,
        //            CommentContent = comment.Content,
        //        }),
        //    }));
        //}

        //[HttpDelete]
        //[Route("[controller]")]
        //public async Task<IActionResult> Delete(int userId)
        //{
        //    var user = await _dBContext.Users
        //        .Include(a => a.Posts)
        //        .Include(a => a.Comments)
        //        .Where(a => a.Id == userId)
        //        .FirstOrDefaultAsync();

        //    if (user != null)
        //    {
        //        _dBContext.Users.Remove(user);
        //        await _dBContext.SaveChangesAsync();
        //    }

        //    return Ok();
        //}
    }
}

using BookStore.Contracts;
using BookStore.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers.Comment
{
    [ApiController]
    [Route("Comments")]
    public class CommentController : BookStoreController
    {
        private readonly ICommentAppService _commentAppService;

        public CommentController(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddComment(AddCommentInputDto addComment)
        {
            await _commentAppService.AddComment(addComment);
            return Ok();
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetComments(int bookId)
        {
            return Ok(await _commentAppService.GetComments(bookId));
        }

        [HttpPost("AddLike")]
        public async Task<IActionResult> AddLike(LikeInputDto likeInfo)
        {
            await _commentAppService.AddLike(likeInfo);
            return Ok();
        }

        [HttpPost("AddDislike")]
        public async Task<IActionResult> AddDislike(LikeInputDto likeInfo)
        {
            await _commentAppService.AddDislike(likeInfo);
            return Ok();
        }
    }
}

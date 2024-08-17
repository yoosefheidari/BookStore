using BookStore.Contracts;
using BookStore.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers.Comment
{
    [ApiController]
    public class CommentController : BookStoreController
    {
        private readonly ICommentAppService _commentAppService;

        public CommentController(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
        }

        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment(AddCommentInputDto addComment)
        {
            await _commentAppService.AddComment(addComment);
            return Ok();
        }

        [HttpGet("GetComments")]
        public async Task<IActionResult> GetStoreBooks()
        {
            return Ok(await _commentAppService.GetComments());
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

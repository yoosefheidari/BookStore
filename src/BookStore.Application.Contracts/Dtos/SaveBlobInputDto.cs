using Microsoft.AspNetCore.Http;

namespace BookStore.Dtos
{
    public class SaveBlobInputDto
    {
        public int BookId { get; set; }
        public IFormFile Image { get; set; }
    }
}

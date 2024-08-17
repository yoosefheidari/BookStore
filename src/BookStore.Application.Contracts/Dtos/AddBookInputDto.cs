using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BookStore.Dtos
{
    public class AddBookInputDto
    {
        public int StoreId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Price { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}

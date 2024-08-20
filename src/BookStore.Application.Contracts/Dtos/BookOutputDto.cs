using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace BookStore.Dtos
{
    public class BookOutputDto : PagedResultDto<BookOutputDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublishDate { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public List<byte[]> Covers { get; set; } = new List<byte[]>();
    }
}

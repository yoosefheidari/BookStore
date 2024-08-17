using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BookStore.Dtos
{
    public class SaveBlobInputDto
    {
        public List<IFormFile> Images { get; set; }
    }
}

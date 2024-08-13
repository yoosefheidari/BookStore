using System.ComponentModel.DataAnnotations;

namespace BookStore.Dtos
{
    public class GetBlobRequestDto
    {
        [Required]
        public string Name { get; set; }
    }
}

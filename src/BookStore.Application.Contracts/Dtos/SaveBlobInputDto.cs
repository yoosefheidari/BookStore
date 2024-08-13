using System.ComponentModel.DataAnnotations;

namespace BookStore.Dtos
{
    public class SaveBlobInputDto
    {
        public byte[] Content { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

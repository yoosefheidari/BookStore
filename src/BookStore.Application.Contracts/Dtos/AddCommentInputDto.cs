namespace BookStore.Dtos
{
    public class AddCommentInputDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public byte Rating { get; set; }
        public int BookId { get; set; }
    }
}

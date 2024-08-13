namespace BookStore.Dtos
{
    public class CommentOutputDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CountOfLikes { get; set; }
        public int CountOfDislikes { get; set; }
    }
}

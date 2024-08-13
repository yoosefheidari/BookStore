﻿namespace BookStore.Dtos
{
    public class BookOutputDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublishDate { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
    }
}

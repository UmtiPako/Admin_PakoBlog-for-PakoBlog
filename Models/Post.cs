namespace Admin_PakoBlog.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public bool isPublished { get; set; }
        public DateTime publishTime { get; set; } 
        public Author Author { get; set; }
        public Category Category { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }

    }
}

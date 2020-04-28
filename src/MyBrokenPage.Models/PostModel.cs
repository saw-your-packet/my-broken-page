namespace MyBrokenPage.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public UserModel User { get; set; }
    }
}

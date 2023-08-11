using System.Text.Json.Serialization;

namespace CRUDAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;

        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}

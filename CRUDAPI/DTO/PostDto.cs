using CRUDAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CRUDAPI.DTO
{
    public class PostDto
    {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;

        public ICollection<Comment> Comments { get; set; }

    }
}

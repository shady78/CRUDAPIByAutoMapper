using CRUDAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CRUDAPI.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }

        public int PostId { get; set; }
    }
}

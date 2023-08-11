﻿using System.ComponentModel.DataAnnotations;

namespace CRUDAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; } = null!;
    }
}

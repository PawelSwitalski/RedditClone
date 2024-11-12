using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedditClone.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(1000)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "varchar(5000)")]
        public string BodyText { get; set; }

        // Can be negative
        public int LikesNumber { get; set; } = 0;

        public Guid UserId { get; set; }
        public IdentityUser User { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Post : BaseEntity
    {
        [MinLength(1)]
        [MaxLength(100)]
        public required string Title { get; set; }

        [MinLength(1)]
        public required string Content { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User? Creator { get; set; }

        public virtual IEnumerable<Comment>? Comments { get; set; }
    }
}

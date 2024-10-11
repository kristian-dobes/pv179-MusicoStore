using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Comment : BaseEntity
    {
        [MinLength(1)]
        [MaxLength(200)]
        public required string Content { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User? Commenter { get; set; }

        public int PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        public virtual Post? Post { get; set; }
    }
}

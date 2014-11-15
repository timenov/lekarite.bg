namespace Lekarite.Mvc.Models.Comments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Lekarite.Models;
    using Lekarite.Mvc.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CommentViewModel : IMapFrom<Comment>
    {
        [Required]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
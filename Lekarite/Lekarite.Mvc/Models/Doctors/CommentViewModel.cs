namespace Lekarite.Mvc.Models.Doctors
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    using Lekarite.Models;
    using Lekarite.Mvc.Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual User User { get; set; }

        public int DoctorId { get; set; }
    }
}
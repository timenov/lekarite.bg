namespace Lekarite.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}

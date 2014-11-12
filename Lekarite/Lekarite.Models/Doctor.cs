namespace Lekarite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Doctor
    {
        private ICollection<Comment> comments;
        private ICollection<Rating> rating;

        public Doctor()
        {
            this.comments = new HashSet<Comment>();
            this.rating = new HashSet<Rating>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(10)]
        public string Uin { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string SecondName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [MaxLength(30)]
        public string PracticeAt { get; set; }

        // Did doctor working with National health insurance fund
        public bool WorkingWithNhif { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [MaxLength(15)]
        public string Gsm { get; set; }

        [MaxLength(20)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string SocialNetworks { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public int SpecialtyId { get; set; }

        public virtual Speciality Specialty { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Rating> Rating
        {
            get { return this.rating; }
            set { this.rating = value; }
        }
    }
}

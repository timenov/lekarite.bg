namespace Lekarite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Speciality
    {
        private ICollection<Doctor> doctors;

        public Speciality()
        {
            this.doctors = new HashSet<Doctor>();
        }

        public int Id { get; set; }

        public int Code { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(80)]
        public string Name { get; set; }

        public virtual ICollection<Doctor> Doctors
        {
            get { return this.doctors; }
            set { this.doctors = value; }
        }
    }
}

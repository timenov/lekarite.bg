namespace Lekarite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
        private ICollection<Doctor> doctors;

        public City()
        {
            this.doctors = new HashSet<Doctor>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public int PostalCode { get; set; }

        public virtual ICollection<Doctor> Doctors
        {
            get { return this.doctors; }
            set { this.doctors = value; }
        }
    }
}

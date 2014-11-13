namespace Lekarite.Mvc.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using Lekarite.Mvc.Models;

    public class HomeTablesViewModel
    {
        [Display(Name = "Най-коментирани")]
        public IEnumerable<DoctorViewModel> MostCommented { get; set; }

        [Display(Name = "Най-висока оценка")]
        public IEnumerable<DoctorViewModel> HighestRating { get; set; }
    }
}
namespace Lekarite.Mvc.Models.Home
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using Lekarite.Mvc.Models.Home;

    public class HomeTablesViewModel
    {
        [Display(Name = "Най-коментирани")]
        public IEnumerable<HomeDoctorViewModel> MostCommented { get; set; }

        [Display(Name = "Най-висока оценка")]
        public IEnumerable<HomeDoctorViewModel> HighestRating { get; set; }
    }
}
namespace Lekarite.Mvc.Models.Doctors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Lekarite.Models;

    public class DoctorsPageViewModel
    {
        public IEnumerable<DoctorViewModel> Doctors { get; set; }

        public int PagesCount { get; set; }

        public int CurrentPage { get; set; }

        public int PrevPage
        {
            get
            {
                if (this.CurrentPage <= 1)
                {
                    return this.PagesCount;
                }

                return this.CurrentPage - 1;
            }
        }

        public int NextPage
        {
            get
            {
                if (this.CurrentPage >= this.PagesCount)
                {
                    return 1;
                }

                return this.CurrentPage + 1;
            }
        }
    }
}
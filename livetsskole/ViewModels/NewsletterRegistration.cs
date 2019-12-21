using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace livetsskole.ViewModels
{
    public class NewsletterRegistration
    {
        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Vær venlig at indtaste dit fornavn")]
        public string Firstname { get; set; }
        [Display(Name = "Efternavn")]
        [Required(ErrorMessage = "Vær venlig at indtaste dit efternavn")]
        public string Lastname { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vær venlig at indtaste din emailadresse")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", 
            ErrorMessage = "Indtast venligst en korrekt emailadresse")]
        public string Email { get; set; }
    }
}
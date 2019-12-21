using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace livetsskole.ViewModels
{
    public class ContactMessage
    {
        [Display(Name = "Navn")]
        [Required(ErrorMessage = "Vær venlig at indtaste dit navn")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vær venlig at indtaste din email adresse")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", 
            ErrorMessage = "Indtast venligt korrekt email adresse")]
        public string Email { get; set; }
        [Display(Name = "Emne")]
        [Required(ErrorMessage = "Vær venlig at indtaste et emne")]
        public string Subject { get; set; }
        [Display(Name = "Besked")]
        [Required(ErrorMessage = "Vær venlig at indtaste en besked")]
        public string Message { get; set; }
    }
}
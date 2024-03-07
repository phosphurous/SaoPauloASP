using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MSSaoPauloASP.NET.Models
{
    public class RunnerRegistrationViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public string CountryCode { get; set; }

    }
}
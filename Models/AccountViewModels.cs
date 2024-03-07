using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MSSaoPauloASP.NET.Models
{
    public class AccountViewModels
    {
    
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email Required")]

        public string Email { get; set; }
    }


}
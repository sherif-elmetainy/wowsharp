using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WOWSharp.Web.Models
{
    public class CreateAuthenticatorModel
    {
        [Required]
        public string Region { get; set; }

        [Required]
        public string  AccountName { get; set; }
    }
}

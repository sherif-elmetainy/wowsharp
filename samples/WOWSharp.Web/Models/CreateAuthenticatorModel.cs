using System.ComponentModel.DataAnnotations;

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

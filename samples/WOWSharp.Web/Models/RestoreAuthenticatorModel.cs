﻿using System.ComponentModel.DataAnnotations;

namespace WOWSharp.Web.Models
{
    public class RestoreAuthenticatorModel
    {
        [RegularExpression("[A-Z]{2}-[0-9]{4}-[0-9]{4}-[0-9]{4}")]
        [Required]
        public string Serial { get; set; }

        [RegularExpression("[0-9A-Za-z]{10}")]
        [Required]
        public string RestoreCode { get; set; }

        [Required]
        public string  AccountName { get; set; }
    }
}

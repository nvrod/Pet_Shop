using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Pet_Store.Models
{
    public class owner_nv_CLS
    {

        public int Id { get; set; }
        [Required]

        public int owner_national_id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = ("Se excede el limite de caracteres(100)"))]

        public string owner_name { get; set;}
        [Required]
        [StringLength(100, ErrorMessage = ("Se excede el limite de caracteres(100)"))]

        public string owner_phone_number { get; set;}
        [Required]
        [EmailAddress(ErrorMessage = "El formato es incorrecto")]

        public string owner_email { get; set;}
        [Required]

        public int client_type_id { get; set; }

        public string client_type_name { get;set;}

        public bool is_active { get; set;}  
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pet_Store.Models
{
    public class pet_nv_CLS
    {

        public int Id { get; set; }

        public int pet_type_id { get; set; }

        public string pet_name { get; set; }

        public int pet_age_in_months { get; set; }

        public int owner_id { get; set; }

        public string pet_type_name { get; set; }

        public string owner_name { get; set; }
        public bool is_active { get; set; }
    }
}
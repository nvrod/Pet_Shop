using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pet_Store.Models
{
    public class service_nv_CLS
    {
        public int Id { get; set; }

        public int service_type_id { get; set; }

        public DateTime service_date { get; set;}

        public int employee_id { get; set;}

        public string employee_name { get;}

        public int pet_id { get; set;}

        public bool is_active { get; set; }
    }
}
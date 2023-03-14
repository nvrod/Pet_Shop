using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pet_Store.Models
{
    public class employee_nv_CLS
    {
        public int Id { get; set; }

        public string employee_name { get; set; }

        public int employee_national_id { get; set; }

        public bool is_active { get; set; }
    }
}
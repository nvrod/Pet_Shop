using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pet_Store.Models
{
    public class General_nv
    {
        public List<owner_nv_CLS> owner { get; set; }

        public pet_nv pets { get; set; }
    }
}
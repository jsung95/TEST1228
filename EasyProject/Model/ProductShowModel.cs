using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProject.Model
{
    public class ProductShowModel : Notifier
    {

        public string Prod_code { get; set; }
        public string Prod_name { get; set; } 
        public string Category_name { get; set; }
        public int? Prod_price { get; set; }
        public int? Prod_total { get; set; }
        public int? Imp_dept_count { get; set; }
        public DateTime Prod_expire { get; set; }
        public int? Prod_id { get; set; }
        public int? Imp_dept_id { get; set; }
    }//class

}//namespace

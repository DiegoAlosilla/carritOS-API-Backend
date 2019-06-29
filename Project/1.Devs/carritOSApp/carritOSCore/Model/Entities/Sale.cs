using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/**
 * --
 * @author Juan Diego Alosilla
 * @email diegoalosillagmail.com
 */
namespace carritOSCore.Model.Entities
{
    public class Sale
    {
        public int id { get; set; }
        public double total { get; set; }
        public Seller sellerMyProperty { get; set; }
        public string summary { get; set; }
        public DateTime dateTime{ get; set; }
    }
}

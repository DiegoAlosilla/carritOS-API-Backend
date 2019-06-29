
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
    public class Review
    {
        public int Id { get; set; }
        public int Qualification { get; set; }
        public string comment { get; set; }
        public FoodTruck foodTruck { get; set; }
        public Consumer consumer { get; set; }
        public DateTime date { get; set; }
    }
}

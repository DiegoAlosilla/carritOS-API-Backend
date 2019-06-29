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
    public class FoodTruck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Movil { get; set; }
        public string FoodType { get; set; }
        public double Costo { get; set; }
        public string url { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
        public BusinessOwner businessOwner { get; set; }
    }
}

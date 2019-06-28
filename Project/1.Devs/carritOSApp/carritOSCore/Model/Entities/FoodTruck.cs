using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carritOSCore.Model.Entities
{
    public class FoodTruck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
        public BusinessOwner businessOwner { get; set; }
    }
}

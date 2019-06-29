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
    public class Seller
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Dni { get; set; }
        public BusinessOwner businessOwner { get; set; }
    }
}

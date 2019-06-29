using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/**
 * --
 * @author Juan Diego Alosilla
 * @email diegoalosillagmail.com
 */
namespace carritOSCore.Model.Entities
{
    public class Contract
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ReportDate { get; set; }
        public string Especification { get; set; }
        public string localitation { get; set; }
        public BusinessOwner businessOwner { get; set;}
        public Consumer consumer { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
/**
 * --
 * @author Juan Diego Alosilla
 * @email diegoalosillagmail.com
 */
namespace carritOSCore.Model.Entities
{
    public class BusinessOwner
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter correct First Name")]
        [StringLength(70, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter correct Last Name"), MinLength(3)]
        public string LastName { get; set; }

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Please enter correct DNI")]
        [StringLength(8, ErrorMessage = "DNI in not valid ", MinimumLength = 8)]
        public string Dni { get; set; }
        
        [Display(Name = "Contact Number")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter Email ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Mobile No")]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public string Movil { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter correct City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter correct Country")]
        public string Country { get; set; }
    }
}

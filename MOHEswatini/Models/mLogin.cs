using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MOHEswatini.Models
{
    [Table("U_Users")]
    public class mLogin
    {
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int iID { get; set; }

        [Key]
        [Column("cUserID")]
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(50)]
        public string UserID { get; set; }

        [Column("cPassword")]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Password Must Contain At Lest 8 Character.")]
        public string Password { get; set; }

        [Column("cName")]
        [StringLength(50)]
        [Display(Name = "User Name")]
        public string Name { get; set; }

        [Column("cUserType")]
        [Display(Name = "User Type")]
        [StringLength(20)]
        public string Type { get; set; }

        [Column("cContactNo")]
        [Display(Name = "Phone #")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{9})$", ErrorMessage = "Not a valid phone number")]
        [StringLength(13)]
        public string Phone { get; set; }

        [Column("cEmailID")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(50)]
        public string EmailID { get; set; }
    }

    [NotMapped]
    public class mRegister : mLogin
    {
        [NotMapped] // Does not effect with your database
        [Display(Name = "Confirm Password")]
        [Required]
        [Column(Order = 6)]
        [Compare("Password", ErrorMessage = "Confirm Password Must Match With Password")]
        public string ConfirmPassword { get; set; }
    }
}

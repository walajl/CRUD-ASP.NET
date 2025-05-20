using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEmployees.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(20, ErrorMessage = "Full Name must not exceed 20 characters")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Hire date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [StringLength(30, ErrorMessage = "Department must not exceed 30 characters")]
        public string Department { get; set; }

        
        [Range(1000, 4000, ErrorMessage = "Salary must be between 1000 and 4000 TND")]
        [Column(TypeName = "decimal(18, 2)")]
        [DataType(DataType.Currency)]
        [Display(Name = "Salary (DT)")]
        public decimal Salary { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}


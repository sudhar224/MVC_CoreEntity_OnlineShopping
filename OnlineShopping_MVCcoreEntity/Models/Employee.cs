using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string EmployeeName { get; set; }
        [Required]
        [DisplayName("Employee Id")]
        public int EmployeeId { get; set; }
        [Required]
		[DisplayName("Date Of Birth")]
		public string EmployeeDOB { get; set; }
        [Required]
        [MaxLength(20)]
		[DisplayName("Mobile Number")]
		public string EmployeeMobile { get; set; }
        [Required]
		[DisplayName("Address")]
		public string EmployeeAddress { get; set; }
        [Required]
		[DisplayName("Joining Date")]
		public string EmployeeJoinDate { get; set; }
    }
}

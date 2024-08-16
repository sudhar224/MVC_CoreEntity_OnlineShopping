using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
	public class Register
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string FullName { get; set; }
		[Required]
		public string Gender { get; set; }
		[Required]
		public string DOB { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Phone { get; set; }
		[Required]
		public string Address { get; set; }
		[Required]
		public string Password { get; set; }
	}
}

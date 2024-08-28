using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string ProductName { get; set; }
		[Required]
        public string ProductDescription { get; set; }
		[Required]
		public int ProductCategoryId { get; set; }
		[Required]
		public double ProductPrice { get; set; }
		
	}
}

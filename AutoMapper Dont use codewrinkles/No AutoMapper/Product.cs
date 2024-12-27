
namespace No_AutoMapper
{
				public class Product
				{
        public int Id { get; set; }
        public string?  ProductName { get; set; }
        public string?  ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int VatPercentage { get; set; }

        //you can use this or the FromProduct dto
        //direct class mapping
        public ProductDto ToProductDto()
        {
            return new ProductDto
            {
                Name = ProductName,
                Description = ProductDescription,
                Price = Price + Price * 100 / VatPercentage
            };
        }

        //public static implicit operator ProductDto(Product product)
        //{
        //    return new ProductDto
								//				{
        //        Name = product.ProductName,
        //        Description = product.ProductDescription,
        //        Price = product.Price + product.Price * 100 / product.VatPercentage
								//				};
        //}
    }
}

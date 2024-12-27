﻿
namespace No_AutoMapper
{
				public class ProductDto
				{
        public string? Name { get; set; }
        public string? Description { get; set; }
    

        public decimal  Price { get; set; }
    
           public static ProductDto FromProduct(Product product)
        {
            return new ProductDto
            {
                Name = product.ProductName,
                Description = product.ProductDescription,
                Price = product.Price + product.Price * 100 / product.VatPercentage
            };
        }
        public static explicit operator ProductDto(Product product)
        {
            return new ProductDto
            {
                Name = product.ProductName,
                Description = product.ProductDescription,
                Price = product.Price + product.Price * 100 / product.VatPercentage
            };
        }

    }



}

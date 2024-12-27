using AutoMapper;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No_AutoMapper
{
				public class Benchmarks
				{

								private Product[] _products;
								private IMapper _mapper;

								[Params(10,100,100)]

								public int NumberOfElements { get; set; }

								[GlobalSetup]
								public void Init()
								{
												var config = new MapperConfiguration(cfg =>
												cfg.CreateMap<Product, ProductDto>()
												.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
												.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductDescription))
												.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price + src.Price * 100 / src.VatPercentage))
												);

												_mapper = config.CreateMapper();


												_products = Enumerable.Range(1, NumberOfElements)
																.Select(n => new Product
																{
																				Id=n,
																				ProductName=$"Product name{n}",
																				ProductDescription=$"Product description {n}",
																				Price=45.50m,
																				VatPercentage=19
																}).ToArray();
								}
								[Benchmark]
								public void With_AutoMapper()
								{
												foreach(var product in _products)
												{
																var productDto = _mapper.Map<ProductDto>(product);
												}
								}

								[Benchmark]
								public void With_Direct_Assignemet()
								{
												foreach (var product in _products)
												{
																var productDto = product.ToProductDto(); 
												}
								}
								//[Benchmark]
								//public void With_Impicit_Operator()
								//{
								//				foreach (var product in _products)
								//				{
								//								ProductDto productDto = product;
								//				}
								//}
								[Benchmark]
								public void With_Explicit_Operator()
								{
												foreach (var product in _products)
												{
																var productDto = (ProductDto)product;
												}
								}
}}

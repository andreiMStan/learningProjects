
using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using No_AutoMapper;

								BenchmarkRunner.Run<Benchmarks>();
				

//var config = new MapperConfiguration(cfg =>
//												cfg.CreateMap<Product, ProductDto>()
//												.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
//												.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductDescription))
//												.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price + src.Price * 100 / src.VatPercentage))
//												);


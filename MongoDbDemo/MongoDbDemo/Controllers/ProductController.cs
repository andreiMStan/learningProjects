using Microsoft.AspNetCore.Mvc;
using MongoDbDemo.Models;
using MongoDbDemo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoDbDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
			_productService = productService;
			  
		}
        // GET api/Product
        [HttpGet]
		
		public async Task<IActionResult> Get()
		{
			var products =await _productService.GetAllAsync();
			return Ok(products);
		}
		// GET: api/ProductController/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(string id)
		{
			var products = await _productService.GetById(id);
			if (products == null)
			{
				return NotFound();
			}
			return Ok(products);
		}

		// POST api/ProductController/5
		[HttpPost]
		
		public async Task<IActionResult> Post(Product products)
		{
			products.CategoryName = null;
			await _productService.CreateAsync(products);
			return Ok("Created Succesfully");
		}

		// PUT api/ProductController/5
		[HttpPut("{id}")]
		
		public async Task<IActionResult>  UpdatebyId(string id, [FromBody] Product newProduct)
		{
			newProduct.CategoryName = null;
			var products = await _productService.GetById(id);
			if (products == null)
			{
				return NotFound();
			}
			await _productService.Update
          (id, newProduct);
			return Ok("updated succesfully");
		}

		// DELETE api/ProductController/5
		[HttpDelete("{id}")]
		
		public async Task<IActionResult> Delete(string id)
		{
			var products = await _productService.GetById(id);
			if (products == null)
			{
				return NotFound();
			}
			await _productService.Delete(id);
			return Ok("deleted succesfully");
		}
	}
}

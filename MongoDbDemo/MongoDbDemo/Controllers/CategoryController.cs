﻿using Microsoft.AspNetCore.Mvc;
using MongoDbDemo.Models;
using MongoDbDemo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoDbDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
			_categoryService = categoryService;
			  
		}
        // GET api/Category
        [HttpGet]
		
		public async Task<IActionResult> Get()
		{
			var categories =await _categoryService.GetAllAsync();
			return Ok(categories);
		}
		// GET: api/CategoryController/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(string id)
		{
			var category = await _categoryService.GetById(id);
			if (category==null)
			{
				return NotFound();
			}
			return Ok(category);
		}

		// POST api/CategoryController/5
		[HttpPost]
		
		public async Task<IActionResult> Post(Category category)
		{
			await _categoryService.CreateAsync(category);
			return Ok("Created Succesfully");
		}

		// PUT api/CategoryController/5
		[HttpPut("{id}")]
		
		public async Task<IActionResult>  UpdatebyId(string id, [FromBody] Category newCategory)
		{
			var  category = await _categoryService.GetById(id);
			if (category==null)
			{
				return NotFound();
			}
			await _categoryService.Update
          (id, newCategory);
			return Ok("updated succesfully");
		}

		// DELETE api/CategoryController/5
		[HttpDelete("{id}")]
		
		public async Task<IActionResult> Delete(string id)
		{
			var category = await _categoryService.GetById(id);
			if (category == null)
			{
				return NotFound();
			}
			await _categoryService.Delete(id);
			return Ok("deleted succesfully");
		}
	}
}
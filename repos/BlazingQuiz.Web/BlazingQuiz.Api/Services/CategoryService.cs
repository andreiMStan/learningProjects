using BlazingQuiz.Api.Data;
using BlazingQuiz.Api.Data.Entities;
using BlazingQuiz.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BlazingQuiz.Api.Services
{
    public class CategoryService
    {
        private readonly QuizContext _context;

        public CategoryService(QuizContext context)
        {
            _context = context;
        }
        public async Task<QuizApiResponse> SaveCategoryAsync(CategoryDto dto)
        {
            if (await _context.Categories
                .AsNoTracking()
                .AnyAsync(
                c=>c.Name==dto.Name
                &&c.Id!=dto.Id))
            {
                //category with same name already exist
                return QuizApiResponse.Fail("Category with same name exists already");
            }
            if (dto.Id == 0)
            {
                //create new category
                var category = new Category
                {
                    Name = dto.Name
                };
                _context.Categories.Add(category);
            }
            else
            {
                //update existing category
                var dbCategory=await _context.Categories
                    .FirstOrDefaultAsync(c=>c.Id==dto.Id);
                if (dbCategory==null)
                {
                    //category does not exist, throw error, or send some error response
                    return QuizApiResponse.Fail("Category does not exist");
                }
                dbCategory.Name = dto.Name;
                _context.Categories.Update(dbCategory);
            }
            await _context.SaveChangesAsync();
            return QuizApiResponse.Success();
        }
        public async Task<CategoryDto[]> GetCategoriesAsync()
        => await _context.Categories.AsNoTracking()
            .Select(c => new CategoryDto
            {
                Name = c.Name,
                Id = c.Id
            }).ToArrayAsync();

        
    }
}

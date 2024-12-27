using BlazingQuiz.Shared.Dtos;
using Refit;

namespace BlazingQuiz.Web.Apis
{
    [Headers("Authorization:Bearer")]
    public interface ICategoryApi
    {
        //get the value and will append to authorization bearer
        //,get token from UI side quizauthstateprovider, user object
        //Token propriety-<from here 
        //
        [Post("/api/categories")]
        Task<QuizApiResponse> SaveCategoryAsync(CategoryDto categoryDto);

        [Get("/api/categories")]
        Task<CategoryDto[]> GetCategoriesAsync();
    }
}

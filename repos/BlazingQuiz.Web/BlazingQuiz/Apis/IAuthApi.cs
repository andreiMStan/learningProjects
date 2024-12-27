using BlazingQuiz.Shared.Dtos;
using Refit;

namespace BlazingQuiz.Web.Apis
{
    public interface IAuthApi
    {
        [Post("/api/auth/login")]
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    }
}

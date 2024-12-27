using BlazingQuiz.Shared;
using BlazingQuiz.Shared.Dtos;
using Refit;

namespace BlazingQuiz.Web.Apis
{
    [Headers("Authorization:Bearer")]
    public interface IAdminApi
    {
        [Get("/api/admin/users")]
        Task<PagedResult<UserDto>> GetUsersAsync(UserApprovedFilter approveType, int startIndex, int pageSize);

        [Patch("/api/admin/users/{userId}/toggle-status")]
        Task ToggleUserApprovedStatusAsync(int userId);

        [Get("/api/admin/home-data")]
        Task<AdminHomeDataDto> GetHomeDataAsync();

        [Get("/api/admin/quizes/{quizId}/students")]
        Task<AdminQuizStudentListDto> GetQuizStudentsAsync
            (Guid quizId, int startIndex, int pageSize, bool fetchQuizInfo);
    }
}

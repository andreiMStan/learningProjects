using BlazingQuiz.Api.Services;
using BlazingQuiz.Shared;
using BlazingQuiz.Shared.Dtos;

namespace BlazingQuiz.Api.Endpoints
{
    public static class AdminEndpoints
    {
        public static IEndpointRouteBuilder MapAdminEndpoints 
            (this IEndpointRouteBuilder app)
        {
            var adminGroup=app.MapGroup("/api/admin")
                    .RequireAuthorization(p => p.RequireRole(nameof(UserRole.Admin)));

            adminGroup.MapGet("/home-data", async (AdminService service) =>
            Results.Ok(await service.GetHomeDataAsync()));

            adminGroup.MapGet("/quizes/{quizId:guid}/students" ,
                async ( Guid quizId, int startIndex,
                    int pageSize, bool fetchQuizInfo, AdminService service)
                    =>
            Results.Ok( await service.GetQuizStudentsAsync(quizId,startIndex,pageSize,fetchQuizInfo)));


            var group = adminGroup.MapGroup("/users");

            group.MapGet("", async (UserApprovedFilter approveType
                , int startIndex, int pageSize, AdminService service) =>
            {
                //var approvedFilter = Enum.Parse<UserApprovedFilter>(filter);
                return Results.Ok(await service.GetUsersAsync(approveType, startIndex, pageSize));
            });
        
        group.MapPatch("{userId:int}/toggle-status",async (int userId ,AdminService service)=>
                
                {
                await service.ToggleUserApprovedStatusAsync(userId);
                return Results.Ok();
            });

            return app;
        }
    }

}

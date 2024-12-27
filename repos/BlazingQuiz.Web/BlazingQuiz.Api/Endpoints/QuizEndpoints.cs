using BlazingQuiz.Api.Services;
using BlazingQuiz.Shared.Dtos;
namespace BlazingQuiz.Api.Endpoints
{
    public static class QuizEndpoints
    {
        public static IEndpointRouteBuilder MapQuizEnpoint(
        this IEndpointRouteBuilder app)
        {
            var quizGroup = app.MapGroup("/api/quizes").RequireAuthorization();
                
            quizGroup.MapPost("", async (QuizSaveDto dto, QuizService service)
                =>
            {
                if (dto.Question.Count == 0)
                    return Results.BadRequest("Please provide questions");

                if (dto.Question.Count != dto.TotalQuestions)
                    return Results.BadRequest("Total Question count does not match with provide questions");

                return Results.Ok(await service.SaveQuizAsync(dto));
            });

            quizGroup.MapGet("", async (QuizService service) =>
            Results.Ok(await service.GetQuizesAsync()));

            quizGroup.MapGet("{quizId:guid}/questions", 
                async (Guid quizId, QuizService service) =>

            {
                return Results.Ok(await service.GetQuizesQuestionsAsync(quizId));
            });
            quizGroup.MapGet("{quizId:guid}", 
                async (Guid quizId, QuizService service)
                => Results.Ok(await service.GetQuizToEditAsync(quizId)));
              return app;
        }

    }

}

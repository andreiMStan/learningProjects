﻿using BlazingQuiz.Shared.Dtos;
using Refit;

namespace BlazingQuiz.Web.Apis
{
    [Headers("Authorization:Bearer")]

    public interface IQuizApi
    {
        [Post("/api/quizes")]
        Task<QuizApiResponse> SaveQuizAsync(QuizSaveDto saveDto);

        [Get("/api/quizes")]
        Task<QuizListDto[]> GetQuizesAsync();
        
        
        [Get("/api/quizes/{quizId}/questions")]
        Task<QuestionDto[]> GetQuizQuestionsAsync(Guid quizId);

        [Get("/api/quizes/{quizId}")]
        Task<QuizSaveDto?> GetQuizToEditAsync(Guid quizId);
    }

}
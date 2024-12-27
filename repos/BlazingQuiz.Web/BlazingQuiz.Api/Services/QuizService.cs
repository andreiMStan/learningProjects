using BlazingQuiz.Api.Data;
using BlazingQuiz.Api.Data.Entities;
using BlazingQuiz.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BlazingQuiz.Api.Services
{
    public class QuizService
    {
        private readonly QuizContext _context;

        public QuizService(QuizContext context)
        {
            _context = context;
        }

        public async Task<QuizApiResponse> SaveQuizAsync(QuizSaveDto dto)
        {

            var questions = dto.Question
                   .Select(
                   q =>
                   new Question
                   {
                       Id = q.Id,
                       Text = q.Text,
                       Options = q.Options.Select(o => new Option
                       {
                           Id = o.Id,
                           Text = o.Text,
                           IsCorrect = o.IsCorrect
                       }).ToArray()

                   }).ToArray();


            if (dto.Id == Guid.Empty)
            {
                //NO QUIZ CREATION

                var quiz = new Quiz
                {
                    CategoryId = dto.CategoryId,
                    IsActive = dto.IsActive,
                    Name = dto.Name,
                    TimeInMinutes = dto.TimeInMinutes,
                    TotalQuestions = dto.TotalQuestions,
                    Questions = questions

                };
                _context.Quizzes.Add(quiz);
            }
            else
            {
                var dbQuiz = await _context.Quizzes.FirstOrDefaultAsync(
                    q => q.Id == dto.Id);
                if (dbQuiz == null)
                
                    {
                        return QuizApiResponse.Fail("Quiz does not exist");

                    }
                    //updating existing quiz
                    dbQuiz.CategoryId = dto.CategoryId;
                    dbQuiz.IsActive = dto.IsActive;
                    dbQuiz.Name = dto.Name;
                    dbQuiz.TotalQuestions = dto.TotalQuestions;
                    dbQuiz.TimeInMinutes = dto.TimeInMinutes;
                    dbQuiz.Questions = questions;

                
            }
                try
                {
                    await _context.SaveChangesAsync();
                    return QuizApiResponse.Success();
                }
                catch (Exception ex)
                {
                    return QuizApiResponse.Fail(ex.Message);
                }
        }
        public async Task<QuizListDto[]> GetQuizesAsync()
        {
       // Asigment TODO: Implement Paging and server side filter (if required)

          return await _context.Quizzes.Select(q => new QuizListDto
            {
                Id = q.Id,
                Name = q.Name,
                TimeInMinutes = q.TimeInMinutes,
                TotalQuestions = q.TotalQuestions,
                IsActive = q.IsActive,
                CategoryId = q.CategoryId,
                CategoryName = q.Category.Name
            })
                .ToArrayAsync();
        }

        public async Task<QuestionDto[]> GetQuizesQuestionsAsync(Guid quizId) =>
            await _context.Questions.Where(q => q.QuizId == quizId)
            .Select(q => new QuestionDto
            {
                Id = q.Id,
                Text = q.Text,
               // Options=q.Options.Select(o=>new OptionDto
                //{ Id=o.Id
                 //  }).ToList()

            }).ToArrayAsync();

        public async Task<QuizSaveDto?> GetQuizToEditAsync(Guid quizId)
        {
            var quiz = await _context.Quizzes
                .Where(q => q.Id == quizId)
                .Select(qz => new QuizSaveDto
                {
                    Id=qz.Id,
                    CategoryId=qz.CategoryId,
                    IsActive=qz.IsActive,
                    Name=qz.Name,
                    TimeInMinutes=qz.TimeInMinutes,
                    TotalQuestions=qz.TotalQuestions,
                    Question=qz.Questions
                    .Select(q=>new QuestionDto
                    {
                        Id=q.Id,
                        Text=q.Text,
                        Options=q.Options
                        .Select(o=>new OptionDto
                        {
                            Text=o.Text,
                            Id=o.Id,
                            IsCorrect=o.IsCorrect

                        }).ToList()
                    }).ToList()
                }).FirstOrDefaultAsync();
            return quiz;
        }

      
    }
}

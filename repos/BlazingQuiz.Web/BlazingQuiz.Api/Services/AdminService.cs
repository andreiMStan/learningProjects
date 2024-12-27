﻿using BlazingQuiz.Shared.Dtos;
using BlazingQuiz.Shared;
using Microsoft.EntityFrameworkCore;
using BlazingQuiz.Api.Data;
using Microsoft.VisualBasic;

namespace BlazingQuiz.Api.Services
{
    public class AdminService
    {

        private readonly IDbContextFactory<QuizContext> _contextFactory;

        public AdminService(IDbContextFactory<QuizContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        //for multiple calls to sql db
        public async Task<AdminHomeDataDto> GetHomeDataAsync()
        {

            var totalCategoriesTask = _contextFactory.CreateDbContext().Categories.CountAsync();
            var totalStudentsTask = _contextFactory.CreateDbContext().Users.Where(u=>u.Role==nameof(UserRole.Student)).CountAsync();
            var approvedStudentsTask = _contextFactory.CreateDbContext().Users.Where(u => u.IsApproved == true&& u.Role == nameof(UserRole.Student)).CountAsync();
            var totalQuizesTask = _contextFactory.CreateDbContext().Quizzes.CountAsync();
            var activeQuizesTask = _contextFactory.CreateDbContext().Quizzes.Where(q=>q.IsActive).CountAsync();

            var totalCategories = await totalCategoriesTask; 
            var totalStudents = await totalStudentsTask; 
            var approvedStudents = await approvedStudentsTask; 
            var totalQuizes = await totalQuizesTask; 
            var activeQuizes = await activeQuizesTask; 

            return new AdminHomeDataDto(totalCategories, totalStudents, approvedStudents, totalQuizes, activeQuizes);
        }
        public async Task<PagedResult<UserDto>> GetUsersAsync(UserApprovedFilter approveType, int startIndex, int pageSize)
        {
            using var context = _contextFactory.CreateDbContext();

            var query = context.Users.Where(u => u.Role != nameof(UserRole.Admin)).AsQueryable();

            if (approveType != UserApprovedFilter.All)
            {
                if (approveType == UserApprovedFilter.ApprovedOnly)
                    query = query.Where(u => u.IsApproved);
                else
                    query = query.Where(u => !u.IsApproved);
            }

            var total = await query.CountAsync();
            var users = await query.OrderByDescending(u => u.Id)
                .Skip(startIndex)
                .Take(pageSize)
                .Select(u => new UserDto(u.Id, u.Name, u.Email, u.Phone, u.IsApproved)
                )
                .ToArrayAsync();

            return new PagedResult<UserDto>(users, total);
        }

        public async Task ToggleUserApprovedStatusAsync(int userId)
        {

            using var context = _contextFactory.CreateDbContext();
            var dbUser = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            {
                if (dbUser != null)
                {
                    dbUser.IsApproved = !dbUser.IsApproved;
                    await context.SaveChangesAsync();
                }

            }
        }

        public async Task<AdminQuizStudentListDto> GetQuizStudentsAsync
            (Guid quizId, int startIndex, int pageSize, bool fetchQuizInfo)
        {
            var result = new AdminQuizStudentListDto();
            using var context = _contextFactory.CreateDbContext();

            if (fetchQuizInfo)
            {


                var quizInfo = await context
                .Quizzes
                .Where(q => q.Id == quizId)
                .Select(q => new
                {
                    QuizName = q.Name,
                    CategoryName = q.Category.Name
                })
                .FirstOrDefaultAsync();

                if (quizInfo == null)
                {
                    result.Students = new PagedResult<AdminQuizStudentDto>([], 0);
                    return result;
                }


                result.QuizName = quizInfo.QuizName;
                result.CategoryName = quizInfo.CategoryName;
            }



                var query = context.StudentQuizzes.Where(q => q.QuizId == quizId);

                var count = await query.CountAsync();
                var students =
                   await query
                   .OrderByDescending(s => s.StartedOn)
                   .Skip(startIndex)
                   .Take(pageSize)
                        .Select(s => new AdminQuizStudentDto
                        {
                            CompletedOn = DateTime.Now,
                            Name = s.Student.Name,
                            StartedOn = DateTime.Now,
                            Score = s.Score,
                            Status = s.Status,
                        })
                        .ToArrayAsync();

                var pagedStudents = new PagedResult<AdminQuizStudentDto>(students, count);
                result.Students = pagedStudents;
            
            return result;
          }
    }
}

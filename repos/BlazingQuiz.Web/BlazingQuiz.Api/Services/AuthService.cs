﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlazingQuiz.Api.Data;
using BlazingQuiz.Api.Data.Entities;
using BlazingQuiz.Shared;
using BlazingQuiz.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BlazingQuiz.Api.Services
{
    public class AuthService
    {
        private readonly QuizContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AuthService(QuizContext context,
            IPasswordHasher<User>passwordHasher
            ,IConfiguration configuration)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }
        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {

        var user =await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u=>u.Email==dto.UserName);
            if (user==null)
            {
                //invalid username
                return new AuthResponseDto (default,"Invalid username");
            }

            if (!user.IsApproved)
            {
                return new AuthResponseDto(default, "Your account is not approved ");
            }


            var passwordResult= _passwordHasher.VerifyHashedPassword(user,user.PasswordHash,dto.Password);
            if (passwordResult == PasswordVerificationResult.Failed)
            {
                //incorrect password
                return new AuthResponseDto(default,"Incorrect password");
            }
            //generate jwt token
            var jwt = GenerateJwtToken(user);
            var loggedInUser=new LoggedInUser(user.Id,user.Name,user.Role,jwt);
            // var loggedInUser=new LoggedInUser(user.Id,user.Name,nameof(UserRole.Student),jwt);
            return new AuthResponseDto(loggedInUser);
        }

        public async Task<QuizApiResponse> RegisterAsync(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u=>u.Email==dto.Email))

            {
                return QuizApiResponse.Fail("Email already exists.Try logging in");
            }
            
            var user=new User
            {
                Email=dto.Email,
                Name=dto.Name,
                Phone=dto.Phone,
                Role=nameof(UserRole.Student),
                IsApproved=false
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);
            _context.Users.Add(user);

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
        private  string GenerateJwtToken(User user)
        {
            var claims = new[]
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.Role, user.Role)
    };

            var secretKey = _configuration.GetValue<string>("Jwt:Secret");
            var symetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCred = new SigningCredentials(symetricKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("Jwt:Issuer"),
                audience: _configuration.GetValue<string>("Jwt:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("Jwt:ExpireInMinutes")),  // Ensure expiration is correctly set
                signingCredentials: signingCred
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
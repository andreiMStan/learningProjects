﻿using System.ComponentModel.DataAnnotations;

namespace BlazingQuiz.Shared.Dtos
{
    public class OptionDto
    {
        public int Id { get; set; }

        [Required,MaxLength(200)]
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
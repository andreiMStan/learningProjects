﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingQuiz.Shared.Dtos
{
    public class StudentQuizDto
    {
        public int Id { get; set; }
        public Guid QuizId { get; set; }
        public string QuizName { get; set; }
        public string CategoryName { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public string Status { get; set; }
        public int Score { get; set; }

    }
  
}
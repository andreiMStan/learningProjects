using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingQuiz.Shared.Dtos
{
    public class QuizSaveDto
    {
        // [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please provide valid number  of questions")]

        public int TotalQuestions { get; set; }


        [Range(1, 120, ErrorMessage = "Please provide valid time in minutes")]
        public int TimeInMinutes { get; set; }

        public bool IsActive { get; set; }
        public List<QuestionDto> Question { get; set; } = [];

        public string? Validate()
        {
            if (TotalQuestions != Question.Count)
                return "Number of question does not match with total questions";


            if (Question.Any(q => string.IsNullOrWhiteSpace(q.Text)))
                return "Question text is required";


            if (Question.Any(q => q.Options.Count < 2))
                return "At least 2 options are required for questions";

            if (Question.Any(q => !q.Options.Any(o => o.IsCorrect)))
                return "All options should have correct answer";

            return null;
        }
    }
}
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingQuiz.Shared.Dtos
{
    public record StudentQuizQuestionResponeDto
        (int StudentQuizId,int QuestionId,int OptionId);
}

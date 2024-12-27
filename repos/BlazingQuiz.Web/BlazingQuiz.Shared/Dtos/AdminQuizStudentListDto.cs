namespace BlazingQuiz.Shared.Dtos
{
    public class AdminQuizStudentListDto
    {
        public string QuizName { get; set; }
        public string  CategoryName { get; set; }

        public PagedResult<AdminQuizStudentDto> Students { get; set; }

    }
    public class AdminQuizStudentDto
    {

        public string Name { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public string Status { get; set; }
        public int Score { get; set; }
    }
}

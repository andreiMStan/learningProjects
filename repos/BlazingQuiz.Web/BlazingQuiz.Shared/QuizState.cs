﻿using BlazingQuiz.Shared.Dtos;

namespace BlazingQuiz.Shared
{
    public class QuizState
    {
        public int StudentQuizId { get; private set; }
        public QuizListDto? Quiz { get; private set; }
        public void StartQuiz(QuizListDto? quiz, int studentQuizId) =>
           (Quiz, StudentQuizId) = (quiz, studentQuizId);

        public void StopQuiz()=>
           (Quiz, StudentQuizId) = (null, 0);
    }

}
using AdventureApp.DataAccess.Entities;
using System.Collections.Generic;

namespace AdventureApp.ServiceTests
{
    public class QuestionServiceTestData : BaseServiceTestData
    {
        public QuestionServiceTestData(string? dbName = null) : base(dbName)
        {

        }

        internal Question Test01_Question;
        internal Question Test01_NextQuestion;

        internal void GetNextQuestion_ReturnsQuestionSuccess_TestData()
        {
            Test01_Question = CreateQuestion(value: false);

            Test01_NextQuestion = CreateQuestion("Test Question", true);
            Question question2 = CreateQuestion();
            Question question3 = CreateQuestion();
            Question question4 = CreateQuestion();

            Test01_Question.Questions = new List<Question>()
            {
                Test01_NextQuestion,
                CreateQuestion(value:false)
            };


            List<Question> questions = new List<Question> { question2, Test01_Question, question3, question4 };

            AdventureDbContext.Question.AddRange(questions);
            AdventureDbContext.SaveChanges();
        }
    }
}

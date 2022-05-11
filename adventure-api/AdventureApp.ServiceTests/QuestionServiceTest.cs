using AdventureApp.DataAccess.Models;
using AdventureApp.DataAccess.Repositories;
using AdventureApp.Services;
using Xunit;

namespace AdventureApp.ServiceTests
{
    public class QuestionServiceTest : QuestionServiceTestData
    {
        private IQuestionService _service;

        public QuestionServiceTest() : base("questionServiceTest")
        {
            QuestionRepository questionRespository = new QuestionRepository(AdventureDbContext);
            _service = new QuestionService(questionRespository, Mapper);
        }


        /// <summary>
        /// Given: I am a user and want to load next question of a specified question
        /// When: Id of a question is provided
        /// Then: It should return adventure list
        /// </summary>
        [Fact]
        public void GetNextQuestion_ReturnsQuestionSuccess()
        {
            // Arrange
            GetNextQuestion_ReturnsQuestionSuccess_TestData();

            // Act 
            QuestionDto question = _service.GetNextQuestion(Test01_Question.Id, true).Result;

            // Assert
            Assert.IsAssignableFrom<QuestionDto>(question);
            Assert.NotNull(question);
            Assert.Equal(question.Value, Test01_NextQuestion.Value);
            Assert.Equal(question.Name, Test01_NextQuestion.Name);
        }

    }
}

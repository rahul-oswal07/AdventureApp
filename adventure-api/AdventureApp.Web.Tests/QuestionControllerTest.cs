using AdventureApp.DataAccess.Models;
using AdventureApp.Services;
using AdventureApp.Web.Controllers;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace AdventureApp.Web.Tests
{
    public class QuestionControllerTest
    {
        private QuestionController _controller;
        private Mock<IQuestionService> questionService;

        public QuestionControllerTest()
        {
            questionService = new Mock<IQuestionService>();
            _controller = new QuestionController(questionService.Object);
        }

        /// <summary>
        /// Given:I want to question specified by id
        /// When: There is no question
        /// Then: It should return null
        /// </summary>
        [Fact]
        public void GetQuestionById_ReturnsNull()
        {
            // Arrange
            int id = 1;
            questionService.Setup(item => item.GetQuestionById(id)).Returns(Task.FromResult((QuestionDto)null));

            // Act 
            var actualAdventure = _controller.Get(id).Result;

            // Assert
            questionService.VerifyAll();
            Assert.Null(actualAdventure);
        }

        /// <summary>
        /// Given:I want to question specified by id
        /// When: There is a question
        /// Then: It should return correct question
        /// </summary>
        [Fact]
        public void GetQuestionById_ReturnsQuestion()
        {
            // Arrange
            QuestionDto expectedQuestion = new QuestionDto
            {
                Id = 1,
                Name = "Question",
                Value = true
            };

            int id = 1;
            questionService.Setup(item => item.GetQuestionById(id)).Returns(Task.FromResult(expectedQuestion));

            // Act 
            var actualAdventure = _controller.Get(id).Result;

            // Assert
            questionService.VerifyAll();
            Assert.NotNull(actualAdventure);
            Assert.Equal(expectedQuestion.Id, actualAdventure.Id);
            Assert.Equal(expectedQuestion.Name, actualAdventure.Name);
            Assert.Equal(expectedQuestion.Value, actualAdventure.Value);
        }

        /// <summary>
        /// Given:I want to a next question of a question specified by id
        /// When: There is no question
        /// Then: It should return null
        /// </summary>
        [Fact]
        public void GetNextQuestion_ReturnsNull()
        {
            // Arrange
            int id = 1;
            questionService.Setup(item => item.GetNextQuestion(id, false)).Returns(Task.FromResult((QuestionDto)null));

            // Act 
            var actualQuestion = _controller.GetNextQuestion(id, false).Result;

            // Assert
            questionService.VerifyAll();
            Assert.Null(actualQuestion);
        }

        /// <summary>
        /// Given:I want to a next question of a question specified by id
        /// When: There is a question
        /// Then: It should return question
        /// </summary>
        [Fact]
        public void GetNextQuestion_ReturnsQuestion()
        {
            // Arrange

            QuestionDto expectedQuestion = new QuestionDto
            {
                Id = 1,
                Name = "Question",
                Value = true
            };

            int id = 1;
            questionService.Setup(item => item.GetNextQuestion(id, true)).Returns(Task.FromResult(expectedQuestion));

            // Act 
            var actualQuestion = _controller.GetNextQuestion(id, true).Result;

            // Assert
            questionService.VerifyAll();
            Assert.NotNull(actualQuestion);
            Assert.Equal(expectedQuestion.Id, actualQuestion.Id);
            Assert.Equal(expectedQuestion.Name, actualQuestion.Name);
            Assert.Equal(expectedQuestion.Value, actualQuestion.Value);
        }
    }
}
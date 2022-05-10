using AdventureApp.DataAccess.Models;
using AdventureApp.Services;
using AdventureApp.Web.Controllers;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AdventureApp.Web.Tests
{
    public class UserAdventureControllerTest
    {
        private UserAdventureController _controller;
        private Mock<IUserAdventureService> userAdvenureService;

        public UserAdventureControllerTest()
        {
            userAdvenureService = new Mock<IUserAdventureService>();
            _controller = new UserAdventureController(userAdvenureService.Object);
        }

        /// <summary>
        /// Given:As a user,I want to get all my adventures
        /// When: There are no adventures
        /// Then: It should return empty list
        /// </summary>
        [Fact]
        public void GetAll_ReturnsEmptyUserAdventures()
        {
            // Arrange
            int userId = 1;
            userAdvenureService.Setup(item => item.GetUserAdventures(userId)).Returns(Task.FromResult(Enumerable.Empty<UserAdventureDto>()));

            // Act 
            var result = _controller.GetAll(userId).Result;

            // Assert
            userAdvenureService.VerifyAll();
            Assert.IsAssignableFrom<IEnumerable<UserAdventureDto>>(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Given:As a user,I want to get all my adventures
        /// When: There are adventures
        /// Then: It should return list of adventures
        /// </summary>
        [Fact]
        public void GetAll_ReturnsUserAdventuresList()
        {
            // Arrange
            int userId = 1;
            IEnumerable<UserAdventureDto> expectedUserAdventures = new List<UserAdventureDto>()
            {
                new UserAdventureDto() {Id=1,Name="Test Adventure",RootQuestionId= 1},
                new UserAdventureDto() {Id=2,Name="Test Adventure 2",RootQuestionId = 2},
                new UserAdventureDto() {Id=3,Name="Test Adventure 3",RootQuestionId = 3}
            };
            userAdvenureService.Setup(item => item.GetUserAdventures(userId)).Returns(Task.FromResult(expectedUserAdventures));

            // Act 
            var actualUserAdventures = _controller.GetAll(userId).Result;

            // Assert
            userAdvenureService.VerifyAll();
            Assert.IsAssignableFrom<IEnumerable<UserAdventureDto>>(actualUserAdventures);
            Assert.Equal(expectedUserAdventures.Count(), actualUserAdventures.Count());
        }

        /// <summary>
        /// Given:As a user,I want to a user adventure specified by id
        /// When: There is no adventure
        /// Then: It should return null
        /// </summary>
        [Fact]
        public void Get_ReturnsNull()
        {
            // Arrange
            int id = 1;
            userAdvenureService.Setup(item => item.GetUserAdventure(id)).Returns(Task.FromResult((UserAdventureDto)null));

            // Act 
            var actualUserAdventure = _controller.Get(id).Result;

            // Assert
            userAdvenureService.VerifyAll();
            Assert.Null(actualUserAdventure);
        }

        /// <summary>
        /// Given:I want to user adventure specified by id
        /// When: There is a user adventure
        /// Then: It should return user adventure
        /// </summary>
        [Fact]
        public void Get_ReturnsUserAdventure()
        {
            // Arrange

            UserAdventureDto expectedUserAdventure = new UserAdventureDto
            {
                Id = 1,
                Name = "User Adventure",
                RootQuestionId = 3
            };

            int id = 1;
            userAdvenureService.Setup(item => item.GetUserAdventure(id)).Returns(Task.FromResult(expectedUserAdventure));

            // Act 
            var actualQuestion = _controller.Get(id).Result;

            // Assert
            userAdvenureService.VerifyAll();
            Assert.NotNull(actualQuestion);
            Assert.Equal(expectedUserAdventure.Id, actualQuestion.Id);
            Assert.Equal(expectedUserAdventure.Name, actualQuestion.Name);
            Assert.Equal(expectedUserAdventure.RootQuestionId, actualQuestion.RootQuestionId);
        }


        /// <summary>
        /// Given: As a user, I want to create user adventure
        /// When: There is a user adventure
        /// Then: It should save user adventure
        /// </summary>
        [Fact]
        public void SaveUserAdventure_ReturnsUserAdventure()
        {
            // Arrange
            CreateUserAdventureDto expectedUserAdventure = new CreateUserAdventureDto
            {
                AdventureId = 1,
                QuestionId = 10,
                UserId = 3
            };

            UserAdventureDto userAdventureDto = new UserAdventureDto
            {
                AdventureId = expectedUserAdventure.AdventureId,
                LeafQuestionId = expectedUserAdventure.QuestionId,
                RootQuestionId = 1
            };


            int id = 1;
            userAdvenureService.Setup(item => item.SaveUserAdventure(expectedUserAdventure)).Returns(Task.FromResult(userAdventureDto));

            // Act 
            var actualUserAdventureDto = _controller.SaveUserAdventure(expectedUserAdventure).Result;

            // Assert
            userAdvenureService.VerifyAll();
            Assert.NotNull(actualUserAdventureDto);
            Assert.IsAssignableFrom<UserAdventureDto>(actualUserAdventureDto);
            Assert.Equal(userAdventureDto.Id, actualUserAdventureDto.Id);
            Assert.Equal(userAdventureDto.Name, actualUserAdventureDto.Name);
            Assert.Equal(userAdventureDto.RootQuestionId, actualUserAdventureDto.RootQuestionId);
        }
    }
}
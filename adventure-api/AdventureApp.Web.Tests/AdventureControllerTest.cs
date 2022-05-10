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
    public class AdventureControllerTest
    {
        private AdventureController _controller;
        private Mock<IAdventureService> adventureService;

        public AdventureControllerTest()
        {
            adventureService = new Mock<IAdventureService>();
            _controller = new AdventureController(adventureService.Object);
        }

        /// <summary>
        /// Given: I am a user and want to load all the adventures
        /// When: There are no adventures
        /// Then: It should return a result of an empty list
        /// </summary>
        [Fact]
        public void Get_ReturnsEmptyList()
        {
            // Arrange
            adventureService.Setup(item => item.GetAdventures()).Returns(Task.FromResult(Enumerable.Empty<AdventureDto>()));

            // Act 
            var result = _controller.Get().Result;

            // Assert
            adventureService.VerifyAll();
            Assert.IsAssignableFrom<IEnumerable<AdventureDto>>(result);
            Assert.Empty(result);

        }

        /// <summary>
        /// Given: I am a user and want to load all the adventures
        /// When: There are adventures
        /// Then: It should return a result of adventure list
        /// </summary>
        [Fact]
        public void Get_ReturnsListOfAllAdventures()
        {
            // Arrange
            IEnumerable<AdventureDto> expectedAdventures = new List<AdventureDto>()
            {
                new AdventureDto() {Id=1,Name="Test Adventure",RootQuestionId= 1},
                new AdventureDto() {Id=2,Name="Test Adventure 2",RootQuestionId = 2},
                new AdventureDto() {Id=3,Name="Test Adventure 3",RootQuestionId = 3}
            };
            adventureService.Setup(item => item.GetAdventures()).Returns(Task.FromResult(expectedAdventures));

            // Act 
            var actualAdventures = _controller.Get().Result;

            // Assert
            adventureService.VerifyAll();
            Assert.IsAssignableFrom<IEnumerable<AdventureDto>>(actualAdventures);
            Assert.Equal(expectedAdventures.Count(), actualAdventures.Count());
        }

        /// <summary>
        /// Given: I am a user and want to an adventures specified by id
        /// When: There are no adventure
        /// Then: It should return null
        /// </summary>
        [Fact]
        public void GetAdventureById_ReturnsNull()
        {
            // Arrange
            int id = 1;
            adventureService.Setup(item => item.GetAdventureById(id)).Returns(Task.FromResult((AdventureDto)null));

            // Act 
            var actualAdventure = _controller.GetAdventureById(id).Result;

            // Assert
            adventureService.VerifyAll();
            Assert.Null(actualAdventure);
        }

        /// <summary>
        /// Given: I am a user and want to load an adventure specified by id
        /// When: There is an adventure
        /// Then: It should return adventure
        /// </summary>
        [Fact]
        public void GetAdventureById_ReturnsAdventure()
        {
            // Arrange
            AdventureDto expectedAdventure = new AdventureDto
            {
                Id = 1,
                Name = "My Adventure",
                RootQuestionId = 1
            };

            int id = 1;
            adventureService.Setup(item => item.GetAdventureById(id)).Returns(Task.FromResult(expectedAdventure));

            // Act 
            var actualAdventure = _controller.GetAdventureById(id).Result;

            // Assert
            adventureService.VerifyAll();
            Assert.NotNull(actualAdventure);
            Assert.Equal(expectedAdventure.Id, actualAdventure.Id);
            Assert.Equal(expectedAdventure.Name, actualAdventure.Name);
            Assert.Equal(expectedAdventure.RootQuestionId, actualAdventure.RootQuestionId);
        }

        /// <summary>
        /// Given: I am a user and want to create an adventure
        /// When: The Adventure is created
        /// Then: It should return an adventure
        /// </summary>
        [Fact]
        public void CreateAdventure_ReturnsCreatedAdventure()
        {
            // Arrange
            QuestionDto questionDto = new QuestionDto
            {
                Id = 1,
                Name = "Adventure"
            };
            CreateAdventureDto adventure = new CreateAdventureDto
            {
                Name = "My Adventure",
                RootQuestion = questionDto
            };
            AdventureDto expectedAdventure = new AdventureDto
            {
                Id = 1,
                Name = "My Adventure",
                RootQuestionId = questionDto.Id,
            };

            adventureService.Setup(item => item.CreateAdventure(adventure)).Returns(Task.FromResult(expectedAdventure));

            // Act 
            var actualAdventure = _controller.CreateAdventure(adventure).Result;

            // Assert
            adventureService.VerifyAll();
            Assert.NotNull(actualAdventure);
            Assert.Equal(expectedAdventure.Name, actualAdventure.Name);
            Assert.Equal(expectedAdventure.RootQuestionId, actualAdventure.RootQuestionId);
        }
    }
}
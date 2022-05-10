using AdventureApp.DataAccess.Models;
using AdventureApp.DataAccess.Repositories;
using AdventureApp.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventureApp.ServiceTests
{
    public class AdventureServiceTest : AdventureServiceTestData
    {
        private IAdventureService _service;

        public AdventureServiceTest() : base("adventureService")
        {
            AdventureRepository adventureRepository = new AdventureRepository(Mapper, AdventureDbContext);
            _service = new AdventureService(Mapper, adventureRepository);
        }

        /// <summary>
        /// Given: I am a user and want to load all the adventures
        /// When: There are adventures
        /// Then: It should return adventure list
        /// </summary>
        [Fact]
        public void GetAdventures_ReturnsListOfAllAdventures()
        {
            // Arrange
            GetAdventures_ReturnsListOfAllAdventures_TestData();

            // Act 
            var actualAdventures = _service.GetAdventures().Result;

            AdventureDto actualAdventure = actualAdventures
                .Where(item => item.Name == Test01_Adventure.Name)
                .FirstOrDefault();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<AdventureDto>>(actualAdventures);
            Assert.NotNull(actualAdventure);
            Assert.Equal(actualAdventure.RootQuestionId, Test01_Question.Id);
        }

        /// <summary>
        /// Given: I am a user and want to a adventure specified by adventure id
        /// When: There are adventures
        /// Then: It should return a adventure
        /// </summary>
        [Fact]
        public void GetAdventureById_ReturnsAdventure()
        {
            // Arrange
            GetAdventureById_ReturnsAdventure_TestData();

            // Act 
            var actualAdventure = _service.GetAdventureById(Test02_Adventure.Id).Result;

            // Assert
            Assert.NotNull(actualAdventure);
            Assert.IsAssignableFrom<AdventureDto>(actualAdventure);
            Assert.Equal(Test02_Adventure.Name, actualAdventure.Name);
            Assert.Equal(Test02_Adventure.RootQuestionId, actualAdventure.RootQuestionId);
            Assert.Equal(Test02_Adventure.RootQuestion.Name, actualAdventure.RootQuestion.Name);
        }

        /// <summary>
        /// Given: I am a user and want to create an adventure
        /// When: I am passing all the required information
        /// Then: It should create a adventure and return it
        /// </summary>
        [Fact]
        public void CreateAdventure_Success()
        {
            // Arrange
            CreateAdventure_Success_TestData();

            // Act 
            var actualAdventure = _service.CreateAdventure(Test03_CreataAdventureDto).Result;

            // Assert
            Assert.NotNull(actualAdventure);
            Assert.IsAssignableFrom<AdventureDto>(actualAdventure);
            Assert.Equal(actualAdventure.Name, Test03_CreataAdventureDto.Name);
            Assert.Equal(actualAdventure.RootQuestion.Name, Test03_CreataAdventureDto.RootQuestion.Name);
            Assert.Equal(actualAdventure.RootQuestion.Questions.Count(), Test03_CreataAdventureDto.RootQuestion.Questions.Count());
        }
    }
}
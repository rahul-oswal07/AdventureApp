using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using AdventureApp.DataAccess.Repositories;
using AdventureApp.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventureApp.ServiceTests
{
    public class UserAdventureServiceTest : UserAdventureServiceTestData
    {
        private IUserAdventureService _userAdventureService;

        public UserAdventureServiceTest() : base("userAdventureService")
        {
            UserAdventureRepository userAdventureRepository = new UserAdventureRepository(AdventureDbContext);
            QuestionRepository questionRepository = new QuestionRepository(AdventureDbContext);
            _userAdventureService = new UserAdventureService(userAdventureRepository, questionRepository, Mapper);
        }

        /// <summary>
        /// Given: I am a user and want to load all the user adventures
        /// When: There are no adventures
        /// Then: It should empty user adventure list
        /// </summary>
        [Fact]
        public void GetAdventures_ReturnsListOfAllUserAdventures()
        {
            // Arrange
            GetAdventures_ReturnsListOfAllUserAdventures_TestData();

            // Act 
            var actualAdventures = _userAdventureService.GetUserAdventures(Test01_User.Id).Result;

            IEnumerable<UserAdventure> actualAdventure = AdventureDbContext.UserAdventure
                .Where(item => item.UserId == Test01_User.Id)
                .ToList();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<UserAdventureDto>>(actualAdventures);
            Assert.NotNull(actualAdventure);
            Assert.Equal(actualAdventure.Count(), 2);
            Assert.True(actualAdventure.Any(item=>item.QuestionId == Test01_Question.Id));
        }
    }
}

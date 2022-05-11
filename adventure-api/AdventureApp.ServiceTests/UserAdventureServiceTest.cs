using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using AdventureApp.DataAccess.Repositories;
using AdventureApp.Services;
using Microsoft.EntityFrameworkCore;
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
        /// When: The user is passed and there are adventures
        /// Then: It should return user adventure list
        /// </summary>
        [Fact]
        public void GetUserAdventures_ReturnsListOfAllUserAdventures()
        {
            // Arrange
            GetUserAdventures_ReturnsListOfAllUserAdventures_TestData();

            // Act 
            var actualAdventures = _userAdventureService.GetUserAdventures(Test01_User.Id).Result;

            IEnumerable<UserAdventure> actualAdventure = AdventureDbContext.UserAdventure
                .Where(item => item.UserId == Test01_User.Id)
                .ToList();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<UserAdventureDto>>(actualAdventures);
            Assert.NotNull(actualAdventure);
            Assert.Equal(actualAdventure.Count(), 2);
            Assert.True(actualAdventure.Any(item => item.QuestionId == Test01_Question.Id));
        }

        /// <summary>
        /// Given: I am a user and want to load all the user adventures
        /// When: The user is passed and there are no adventures
        /// Then: It should empty user adventure list
        /// </summary>
        [Fact]
        public void GetUserAdventures_ReturnsEmptyList()
        {
            // Arrange
            GetUserAdventures_ReturnsEmptyList_TestData();

            // Act 
            var actualAdventures = _userAdventureService.GetUserAdventures(Test02_User.Id).Result;


            // Assert
            Assert.IsAssignableFrom<IEnumerable<UserAdventureDto>>(actualAdventures);
            Assert.Empty(actualAdventures);
        }

        /// <summary>
        /// Given: I am a user and want to a specific adventure
        /// When: The Adventure id is provided 
        /// Then: It should return adventure
        /// </summary>
        [Fact]
        public void GetUserAdventure_ReturnsUserAdventuere()
        {
            // Arrange
            GetUserAdventure_ReturnsUserAdventure_TestData();

            // Act 
            var actualUserAdventure = _userAdventureService.GetUserAdventure(Test03_UserAdventure.Id).Result;

            // Get the selected question from level 1 and compare
            QuestionDto level1Question = actualUserAdventure.Question.Questions.FirstOrDefault(q => q.IsSelected = true);

            // Assert
            Assert.IsAssignableFrom<UserAdventureDto>(actualUserAdventure);
            Assert.Equal(actualUserAdventure.Name, Test03_Adventure.Name);
            Assert.Equal(actualUserAdventure.AdventureId, Test03_Adventure.Id);
            Assert.Equal(actualUserAdventure.LeafQuestionId, Test03_LeafQuestion.Id);
            Assert.Equal(actualUserAdventure.RootQuestionId, Test03_RootQuestion.Id);
            Assert.NotNull(level1Question);
            Assert.Equal(level1Question.Name, Test03_SelectedQuestion.Name);
            Assert.Equal(level1Question.Id, Test03_SelectedQuestion.Id);
            Assert.Equal(level1Question.Value, Test03_SelectedQuestion.Value);
        }

        /// <summary>
        /// Given: I am a user and create an adventure
        /// When: The Adventure details are provided 
        /// Then: It should create the adventure
        /// </summary>
        [Fact]
        public void SaveUserAdventure_Success()
        {
            // Arrange
            SaveUserAdventure_Success_TestData();

            // Act 
            var actualUserAdventure = _userAdventureService.SaveUserAdventure(Test04_CreateUserAdventureDto).Result;

            Assert.IsAssignableFrom<UserAdventureDto>(actualUserAdventure);
            Assert.Equal(actualUserAdventure.AdventureId, Test04_Adventure.Id);
        }
    }
}

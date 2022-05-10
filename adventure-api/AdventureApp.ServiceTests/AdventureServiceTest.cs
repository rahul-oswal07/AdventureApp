using AdventureApp.DataAccess;
using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using AdventureApp.DataAccess.Repositories;
using AdventureApp.Services;
using AdventureApp.Web;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventureApp.ServiceTests
{
    public class AdventureServiceTest : IDisposable
    {
        private IAdventureService _service;
        private AdventureDbContext _dbContext;

        public AdventureServiceTest()
        {
            var options = new DbContextOptionsBuilder<AdventureDbContext>()
                .UseInMemoryDatabase(databaseName: "AdventureDB")
                .Options;

            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new MappingProfile());
            });
            IMapper mapper = config.CreateMapper();
            _dbContext = new AdventureDbContext(options);
            AdventureRepository adventureRepository = new AdventureRepository(mapper, _dbContext);
            _service = new AdventureService(mapper, adventureRepository);

        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }


        /// <summary>
        /// Given: I am a user and want to load all the adventures
        /// When: There are adventures
        /// Then: It should return a result of adventure list
        /// </summary>
        [Fact]
        public void Get_ReturnsListOfAllAdventures()
        {

            Question question = new Question() { Name = "Question 1" };
            Question question2 = new Question() { Name = "Question 2" };
            Question question3 = new Question() { Name = "Question 3", };

            // Arrange
            IEnumerable<Adventure> adventures = new List<Adventure>()
            {
                new Adventure() {Name="Test Adventure",RootQuestion =question },
                new Adventure() {Name="Test Adventure 2",RootQuestion = question2},
                new Adventure() {Name="Test Adventure 3",RootQuestion = question3}
            };

            _dbContext.Adventure.AddRange(adventures);
            _dbContext.SaveChanges();

            // Act 
            var actualAdventures = _service.GetAdventures().Result;

            // Assert
            Assert.IsAssignableFrom<IEnumerable<AdventureDto>>(actualAdventures);
            Assert.Equal(actualAdventures.Count(), adventures.Count());
            Assert.Equal(actualAdventures.First().RootQuestionId, question.Id);
            Assert.Equal(actualAdventures.First().Name, adventures.First().Name);
        }
    }
}
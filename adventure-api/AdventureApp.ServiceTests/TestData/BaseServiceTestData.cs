using AdventureApp.DataAccess;
using AdventureApp.DataAccess.Entities;
using AdventureApp.Web;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureApp.ServiceTests
{
    public class BaseServiceTestData
    {
        public AdventureDbContext AdventureDbContext;

        public IMapper Mapper;

        public BaseServiceTestData(string? dbName = null)
        {
            AdventureDbContext = new AdventureDbContext(new DbContextOptionsBuilder<AdventureDbContext>()
                .UseInMemoryDatabase(databaseName: dbName ?? "Adventure").Options);
            AdventureDbContext.Database.EnsureDeleted();
            AdventureDbContext.Database.EnsureCreated();

            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new MappingProfile());
            });
            Mapper = config.CreateMapper();
        }

        public Adventure CreateAdventure(string? name = null, Question? question = null)
        {
            string guid = Guid.NewGuid().ToString();
            Adventure adventure = new Adventure()
            {
                Name = name ?? "Test name" + guid,
                RootQuestion = question ?? CreateQuestion()
            };

            return adventure;
        }

        public Question CreateQuestion(string name = null, bool? value = null, Question? parentQuestion = null)
        {
            string guid = Guid.NewGuid().ToString();
            Question question = new Question()
            {
                Name = name ?? "Test title" + guid,
                Value = value ?? false
            };

            return question;
        }

        public Question CreateQuestionWithChildQuestions(string name = null, bool? value = null, IEnumerable<Question>? questions = null)
        {
            string guid = Guid.NewGuid().ToString();
            Question question = new Question()
            {
                Name = name ?? "Test title" + guid,
                Questions = questions != null ? questions.ToList() : new List<Question>
                {
                    CreateQuestion(value:true),
                    CreateQuestion(value:false)
                }
            };

            return question;
        }

        public UserAdventure CreateUserAdventure(Adventure? adventure = null, User? user = null, Question? question = null)
        {
            string guid = Guid.NewGuid().ToString();
            UserAdventure userAdventure = new UserAdventure()
            {
                Question = question ?? CreateQuestion(),
                Adventure = adventure ?? CreateAdventure(),
                User = user ?? CreateUser()
            };

            return userAdventure;
        }

        public User CreateUser(string? name = null)
        {
            string guid = Guid.NewGuid().ToString();
            User user = new User()
            {
                Name = name ?? "User" + guid
            };

            return user;
        }
    }
}
